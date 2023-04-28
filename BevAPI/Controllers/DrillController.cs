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
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Drill.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Drill.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        private async Task<IActionResult> Post(DrillRequest request)
        {
            var result = await _unitOfWork.Drill.AddAsync(new Drill
            {
                Type = request.Type,
                MaxMark = request.MaxMark,
                MinMark = request.MinMark
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateDrillRequest request)
        {
            var result = await _unitOfWork.Drill.UpdateAsync(new Drill
            {
                Id = request.Id,
                Type = request.Type,
                MaxMark = request.MaxMark,
                MinMark = request.MinMark
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
