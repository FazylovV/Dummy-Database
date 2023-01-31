using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DB
{
    public class Reader
    {
        public int LibraryCardNumber { get; }
        public string Name { get; }

        public Reader(int libraryCardNumber, string name)
        {
            Name = name;
            this.LibraryCardNumber = libraryCardNumber;
        }
    }
}
