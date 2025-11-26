using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Entities
{
    public class Student : User
    {
        public Student()
        {
            BorrowLimit = 3; // students can borrow 3 books
        }

        public override int GetBorrowLimit() => BorrowLimit;
    }
}
