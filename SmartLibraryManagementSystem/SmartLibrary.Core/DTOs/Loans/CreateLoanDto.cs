using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.DTOs.Loans
{
    public class CreateLoanDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }

}