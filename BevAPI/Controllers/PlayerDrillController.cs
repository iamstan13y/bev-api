using BevAPI.Models.Data;
using BevAPI.Models.Local;
using BevAPI.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BevAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayerDrillController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerDrillController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.PlayerDrill.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.PlayerDrill.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetByPlayerId(int playerId)
        {
            var result = await _unitOfWork.PlayerDrill.GetByPlayerIdAsync(playerId);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpGet("drill/{drillId}")]
        public async Task<IActionResult> GetByDrillId(int drillId) => Ok(await _unitOfWork.PlayerDrill.GetByDrillIdAsync(drillId));

        [HttpPost]
        public async Task<IActionResult> Post(PlayerDrillRequest request)
        {
            var result = await _unitOfWork.PlayerDrill.AddAsync(new PlayerDrill
            {
                PlayerId = request.PlayerId,
                DrillId = request.DrillId,
                DrillMark = request.DrillMark
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePlayerDrillRequest request)
        {
            var result = await _unitOfWork.PlayerDrill.UpdateAsync(new PlayerDrill
            {
                Id = request.Id,
                PlayerId = request.PlayerId,
                DrillId = request.DrillId,
                DrillMark = request.DrillMark
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}