using BevAPI.Models.Data;
using BevAPI.Models.Local;
using BevAPI.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BevAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DrillController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrillController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Player.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Player.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayerRequest request)
        {
            var result = await _unitOfWork.Player.AddAsync(new Player
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
                Height = request.Height,
                Weight = request.Weight,
                KitNumber = request.KitNumber
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePlayerRequest request)
        {
            var result = await _unitOfWork.Player.UpdateAsync(new Player
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
                Height = request.Height,
                Weight = request.Weight,
                KitNumber = request.KitNumber
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
