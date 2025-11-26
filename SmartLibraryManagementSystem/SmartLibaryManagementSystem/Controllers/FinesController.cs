using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Core.Interfaces;

namespace SmartLibaryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinesController : ControllerBase
    {
        private readonly IFineService _fineService;

        public FinesController(IFineService fineService)
        {
            _fineService = fineService;
        }

        [HttpGet("{loanId}")]
        public async Task<IActionResult> GetFine(int loanId)
        {
            var fine = await _fineService.GetFineByLoanIdAsync(loanId);
            if (fine == null) return NotFound();

            return Ok(fine);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fineService.GetAllFinesAsync());
        }
    }
}
