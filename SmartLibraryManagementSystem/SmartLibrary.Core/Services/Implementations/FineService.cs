using SmartLibrary.Core.DTOs.Fines;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Services.Implementations
{
    public class FineService : IFineService
    {
        private readonly IFineRepository _fineRepo;

        public FineService(IFineRepository fineRepo)
        {
            _fineRepo = fineRepo;
        }

        public async Task<FineDto?> GetFineByLoanIdAsync(int loanId)
        {
            var fine = await _fineRepo.GetByLoanIdAsync(loanId);

            if (fine == null)
                return null;

            return new FineDto
            {
                LoanId = fine.LoanId,
                Amount = fine.Amount
            };
        }

        public async Task<List<FineDto>> GetAllFinesAsync()
        {
            var fines = await _fineRepo.GetAllAsync();

            return fines.Select(f => new FineDto
            {
                LoanId = f.LoanId,
                Amount = f.Amount
            }).ToList();
        }
    }
}
