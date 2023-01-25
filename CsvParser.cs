using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DB
{
    public static class CsvParser
    {
        private const int LibraryCardNumber = 0;
        private const int Name = 1;
        private const int IdConst = 0;
        private const int Author = 1;
        private const int Title = 2;
        private const int ReaderId = 3;
        private const int BorrowTime = 4;
        private const int Year = 5;
        private const int BookcaseNumber = 6;
        private const int ShelfNumber = 7;

        public static Reader ParseReader(string reader)
        {
            string[] nameAndLibraryCardNumber = reader.Split(';');
            int libraryCardNumber = TryParseLibraryCardNumber(nameAndLibraryCardNumber[LibraryCardNumber]);
            string name = nameAndLibraryCardNumber[Name];

            return new Reader(libraryCardNumber, name);
        }

        public static Book ParseBook(string book, List<Reader> readers)
        {
            string[] bookProps = book.Split(';');

            int id = TryParseId(bookProps[IdConst]);
            int readerId = TryParseId(bookProps[ReaderId]);
            DateTime borrowTime = TryParseBorrowTime(bookProps[BorrowTime]);
            int year = TryParseYear(bookProps[Year]);
            int bookcaseNumber = TryParseBookcaseNumber(bookProps[BookcaseNumber]);
            int shelfNumber = TryParseShelfNumber(bookProps[ShelfNumber]);

            Reader thisReader;
            foreach(Reader reader in readers)
            {
                if (readerId == reader.LibraryCardNumber)
                {
                    thisReader = reader;
                    return new Book(id, bookProps[Author], bookProps[Title], borrowTime, year, bookcaseNumber, shelfNumber, thisReader);
                }
            }
            return new Book(id, bookProps[Author], bookProps[Title], borrowTime, year, bookcaseNumber, shelfNumber, null);
        }

        private static int TryParseLibraryCardNumber(string LibraryCardNumber)
        {
            int libraryCardNumber;
            if(!int.TryParse(LibraryCardNumber, out libraryCardNumber) || libraryCardNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'readers.csv' столбец 'libraryCardNumber' ({LibraryCardNumber})");
            }
            return libraryCardNumber;
        }

        private static int TryParseId(string Id)
        {
            int id;
            if(!int.TryParse(Id, out id) || id <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'id' ({Id})");
            }
            return id;
        }

        private static int TryParseReaderId(string ReaderId)
        {
            int readerId;
            if (!int.TryParse(ReaderId, out readerId) || readerId <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'readerId' ({ReaderId})");
            }
            return readerId;
        }

        private static DateTime TryParseBorrowTime(string BorrowTime)
        {
            DateTime borrowTime;
            if (!DateTime.TryParse(BorrowTime, out borrowTime))
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'borrowTime' ({BorrowTime})");
            }
            return borrowTime;
        }

        private static int TryParseYear(string Year)
        {
            int year;
            if(int.TryParse(Year, out year) || year <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'year' ({Year})");
            }
            return year;
        }

        private static int TryParseBookcaseNumber(string BookcaseNumber)
        {
            int bookcaseNumber;
            if(!int.TryParse(BookcaseNumber, out bookcaseNumber) || bookcaseNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'bookcaseNumber' ({BookcaseNumber})");
            }
            return bookcaseNumber;
        }

        private static int TryParseShelfNumber(string ShelfNumber)
        {
            int shelfNumber;
            if (!int.TryParse(ShelfNumber, out shelfNumber) || shelfNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'bookcaseNumber' ({ShelfNumber})");
            }
            return shelfNumber;
        }
    }
}
