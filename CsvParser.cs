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
            string[] nameAndPK = reader.Split(';');
            bool isPKCorrect = int.TryParse(nameAndPK[0], out int pk);
            if (!isPKCorrect) Console.WriteLine($"Данные неверны в 'readers.csv' столбец 'libraryCardNumber' ({nameAndPK[0]})");
            else return new Reader(pk, nameAndPK[1]);
            return new Reader(0, nameAndPK[1]);
        }

        public static Book ParseBook(string book, List<Reader> readers)
        {
            string[] bookProps = book.Split(';');
            bool isPKCorrect = int.TryParse((bookProps[0]), out int pk);
            bool isFKCorrect = int.TryParse(bookProps[3], out int fk);
            bool isBorrowTimeCorrect = DateTime.TryParse(bookProps[4], out DateTime borrowTime);
            bool isYearCorrect = int.TryParse(bookProps[5], out int year);
            bool isBookcaseNumberCorrect = int.TryParse(bookProps[6], out int bookcaseNumber);
            bool isShelfNumberCorrect = int.TryParse(bookProps[7], out int shelfNumber);
            Reader thisReader;

            if (!isPKCorrect && pk > 0) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'id' ({bookProps[0]})");
            else if (!isFKCorrect && fk > 0) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'readerId' ({bookProps[0]})");
            else if (!isBorrowTimeCorrect) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'borrowTime' ({bookProps[0]})");
            else if (!isYearCorrect) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'year' ({bookProps[0]})");
            else if (!isBookcaseNumberCorrect && bookcaseNumber > 0) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'bookcaseNumber' ({bookProps[0]})");
            else if (!isShelfNumberCorrect && shelfNumber > 0) Console.WriteLine($"Данные неверны в 'books.csv' столбец 'shelfNumber' ({bookProps[0]})");
            else
            {
                foreach(Reader reader in readers)
                {
                    if (fk == reader.LibraryCardNumber)
                    {
                        thisReader = reader;
                        return new Book(pk, bookProps[1], bookProps[2], borrowTime, year, bookcaseNumber, shelfNumber, thisReader);
                    }
                }
                return new Book(pk, bookProps[1], bookProps[2], borrowTime, year, bookcaseNumber, shelfNumber, null);
            }
            return new Book(0, bookProps[1], bookProps[2], DateTime.Parse("00.00.0000", System.Globalization.CultureInfo.InvariantCulture), 0, 0, 0, null);
        }
    }
}
