using SmartLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface IFineRepository
    {
        Task<Fine?> GetByLoanIdAsync(int loanId);
        Task<IEnumerable<Fine>> GetAllAsync();
        Task AddAsync(Fine fine);
    }
}
