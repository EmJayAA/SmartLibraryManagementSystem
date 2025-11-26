using SmartLibrary.Core.DTOs.Fines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface IFineService
    {
        Task<FineDto?> GetFineByLoanIdAsync(int loanId);
        Task<List<FineDto>> GetAllFinesAsync();
    }
}
