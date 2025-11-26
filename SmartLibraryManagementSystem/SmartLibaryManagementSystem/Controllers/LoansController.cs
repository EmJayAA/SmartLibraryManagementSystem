using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Core.DTOs.Loans;
using SmartLibrary.Core.Interfaces;

namespace SmartLibaryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _loanService.GetAllLoansAsync());
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow(CreateLoanDto dto)
        {
            return Ok(await _loanService.BorrowBookAsync(dto));
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return(ReturnLoanDto dto)
        {
            return Ok(await _loanService.ReturnBookAsync(dto));
        }
    }
}
