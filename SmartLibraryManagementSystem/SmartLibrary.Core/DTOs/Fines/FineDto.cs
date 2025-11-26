using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.DTOs.Fines
{
    public class FineDto
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
    }
}
