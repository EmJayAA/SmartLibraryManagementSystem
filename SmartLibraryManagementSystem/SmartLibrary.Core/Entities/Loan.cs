using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public bool IsReturned => ReturnedDate != null;
        public int DaysLate =>
            ReturnedDate == null ? 0 :
            Math.Max(0, ((DateTime)ReturnedDate - BorrowedDate).Days - 7); // 7-day borrowing period
    }
}
