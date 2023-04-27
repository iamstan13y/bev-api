using BevAPI.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BevAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}