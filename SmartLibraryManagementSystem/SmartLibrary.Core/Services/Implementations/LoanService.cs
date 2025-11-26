using SmartLibrary.Core.DTOs.Loans;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Infrastructure.Repositories;
using SmartLibrary.Core.Entities;

namespace SmartLibrary.Core.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepo;
        private readonly IBookRepository _bookRepo;

        public LoanService(ILoanRepository loanRepo, IBookRepository bookRepo)
        {
            _loanRepo = loanRepo;
            _bookRepo = bookRepo;
        }

        public async Task<LoanDto> BorrowBookAsync(CreateLoanDto dto)
        {
            var loan = new Loan
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                BorrowedDate = DateTime.Now
            };

            await _loanRepo.AddAsync(loan);

            return new LoanDto
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                BorrowedDate = loan.BorrowedDate
            };
        }

        public async Task<LoanDto> ReturnBookAsync(ReturnLoanDto dto)
        {
            var loan = await _loanRepo.GetByIdAsync(dto.LoanId);
            if (loan == null) return null;

            loan.ReturnedDate = DateTime.Now;
            await _loanRepo.UpdateAsync(loan);

            return new LoanDto
            {
                Id = loan.Id,
                UserId = loan.UserId,
                BookId = loan.BookId,
                BorrowedDate = loan.BorrowedDate,
                ReturnedDate = loan.ReturnedDate
            };
        }

        public async Task<List<LoanDto>> GetAllLoansAsync()
        {
            var loans = await _loanRepo.GetAllAsync();

            return loans.Select(l => new LoanDto
            {
                Id = l.Id,
                UserId = l.UserId,
                BookId = l.BookId,
                BorrowedDate = l.BorrowedDate,
                ReturnedDate = l.ReturnedDate
            }).ToList();
        }
    }
}
