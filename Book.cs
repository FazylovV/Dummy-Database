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
        public int BookcaseNumber { get; set; }
        public int ShelfNumber { get; set; }
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

        public string FormatBookToString(int[] maxLengths)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id.ToString().PadLeft(maxLengths[0]));
            sb.Append($"|{Author.PadRight(maxLengths[1])}");
            sb.Append($"|{Title.PadRight(maxLengths[2])}");

            if(Reader.Name != "")
            {
                sb.Append($"|{Reader.Name.PadRight(maxLengths[3])}");
                sb.Append($"|{BorrowTime.ToString("dd-MM-yyyy").PadRight(maxLengths[4])}|");
            }
            else
            {
                sb.Append($"|{new String(' ', maxLengths[3])}");
                sb.Append($"|{new String(' ', maxLengths[4])}|");
            }

            return sb.ToString();
        }
    }
}
