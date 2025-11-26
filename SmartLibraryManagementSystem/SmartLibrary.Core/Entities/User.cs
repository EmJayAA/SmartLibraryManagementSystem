using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserType { get; set; }

        // Encapsulation example:
        private int _borrowLimit;
        public int BorrowLimit
        {
            get => _borrowLimit;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Borrow limit cannot be negative.");
                _borrowLimit = value;
            }
        }

        // Polymorphic method (will be overridden)
        public virtual int GetBorrowLimit() => BorrowLimit;
    }
}
