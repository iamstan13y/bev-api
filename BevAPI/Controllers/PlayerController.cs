using BevAPI.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BevAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Player.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Player.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}