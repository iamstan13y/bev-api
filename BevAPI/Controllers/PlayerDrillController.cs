﻿using BevAPI.Models.Data;
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

        [HttpPost]
        public async Task<IActionResult> Post(DrillRequest request)
        {
            var result = await _unitOfWork.Drill.AddAsync(new Drill
            {
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
                MaxMark = request.MaxMark,
                MinMark = request.MinMark
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}