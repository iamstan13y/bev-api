using BevAPI.Models.Data;
using BevAPI.Models.Local;
using BevAPI.Models.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BevAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository) => _accountRepository = accountRepository;

        [HttpPost]
        public async Task<IActionResult> Post(AccountRequest request)
        {
            var result = await _accountRepository.AddAsync(new Account
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _accountRepository.GetByIdAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginRequest request)
        {
            var result = await _accountRepository.LoginAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}