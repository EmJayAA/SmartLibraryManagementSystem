using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Entities
{
    public class Faculty : User
    {
        public Faculty()
        {
            BorrowLimit = 5; // faculty can borrow more
        }

        public override int GetBorrowLimit() => BorrowLimit;
    }
}
