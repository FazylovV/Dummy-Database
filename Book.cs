using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DB
{
    public class Book
    {
        public int Id { get; }
        public string Author { get; }
        public string Title { get; }
        public DateTime BorrowTime { get; set; }
        public int Year { get; }
        public int BookcaseNumber { get; }
        public int ShelfNumber { get; }
        public Reader Reader { get; set; }

        public Book(int id, string author, string title, DateTime borrowTime, int year, int bookcaseNumber, int shelfNumber, Reader reader)
        {
            Id = id;
            Author = author;
            Title = title;
            BorrowTime = borrowTime;
            Year = year;
            BookcaseNumber = bookcaseNumber;
            ShelfNumber = shelfNumber;
            Reader = reader;
        }
    }
}
