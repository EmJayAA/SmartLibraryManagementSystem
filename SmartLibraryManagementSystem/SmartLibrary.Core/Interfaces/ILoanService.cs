using SmartLibrary.Core.DTOs.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface ILoanService
    {
        Task<LoanDto> BorrowBookAsync(CreateLoanDto dto);
        Task<LoanDto> ReturnBookAsync(ReturnLoanDto dto);
        Task<List<LoanDto>> GetAllLoansAsync();
    }
}
