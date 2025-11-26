using SmartLibrary.Core.Entities;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartLibrary.Infrastructure.Repositories
{
    public class FineRepository : IFineRepository
    {
        private readonly LibraryDbContext _context;

        public FineRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Fine?> GetByLoanIdAsync(int loanId)
        {
            return await _context.Fines
                .FirstOrDefaultAsync(f => f.LoanId == loanId);
        }

        public async Task<IEnumerable<Fine>> GetAllAsync()
        {
            return await _context.Fines.ToListAsync();
        }

        public async Task AddAsync(Fine fine)
        {
            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();
        }
    }
}
