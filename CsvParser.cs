using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy_DB
{
    public class CsvParser
    {
        public static Reader ParseReader(string reader)
        {
            string[] nameAndLibraryCardNumber = reader.Split(';');
            bool isLibraryCardNumberCorrect = int.TryParse(nameAndLibraryCardNumber[0], out int libraryCardNumber);
            string name = nameAndLibraryCardNumber[1];

            if (!isLibraryCardNumberCorrect || libraryCardNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'readers.csv' столбец 'libraryCardNumber' ({nameAndLibraryCardNumber[0]})");
            }

            return new Reader(libraryCardNumber, name);
        }

        public static Book ParseBook(string book, List<Reader> readers)
        {
            string[] bookProps = book.Split(';');
            bool isIdCorrect = int.TryParse((bookProps[0]), out int id);
            bool isReaderIdCorrect = int.TryParse(bookProps[3], out int readerId);
            bool isBorrowTimeCorrect = DateTime.TryParse(bookProps[4], out DateTime borrowTime);
            bool isYearCorrect = int.TryParse(bookProps[5], out int year);
            bool isBookcaseNumberCorrect = int.TryParse(bookProps[6], out int bookcaseNumber);
            bool isShelfNumberCorrect = int.TryParse(bookProps[7], out int shelfNumber);
            Reader thisReader;

            if (!isIdCorrect || id <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'id' ({bookProps[0]})");
            }
            else if ((!isReaderIdCorrect || readerId <= 0) && bookProps[3] != "")
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'readerId' ({bookProps[0]})");
            }
            else if (!isBorrowTimeCorrect)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'borrowTime' ({bookProps[0]})");
            }
            else if (!isYearCorrect)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'year' ({bookProps[0]})");
            }
            else if (!isBookcaseNumberCorrect || bookcaseNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'bookcaseNumber' ({bookProps[0]})");
            }
            else if (!isShelfNumberCorrect || shelfNumber <= 0)
            {
                throw new Exception($"Данные неверны в 'books.csv' столбец 'shelfNumber' ({bookProps[0]})");
            }
            
            foreach(Reader reader in readers)
            {
                if (readerId == reader.LibraryCardNumber)
                {
                    thisReader = reader;
                    return new Book(id, bookProps[1], bookProps[2], borrowTime, year, bookcaseNumber, shelfNumber, thisReader);
                }
            }
            return new Book(id, bookProps[1], bookProps[2], borrowTime, year, bookcaseNumber, shelfNumber, null);
        }
    }
}
