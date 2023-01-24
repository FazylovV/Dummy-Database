using System.Text.Json;
using System.Globalization;

namespace Dummy_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] readersData = File.ReadAllLines("readers.csv");
            string[] booksData = File.ReadAllLines("books.csv");
            List<Reader> readers = new List<Reader>();
            List<Book> books = new List<Book>();
            foreach (string readerData in readersData) readers.Add(CsvParser.ParseReader(readerData));
            foreach (string bookData in booksData)
            {
                Book book = CsvParser.ParseBook(bookData, readers);
                books.Add(book);
                Console.Write($"{book.Id}|{book.Author}|{book.Title} | ");
                if (book.Reader != null) Console.Write($"{book.Reader.Name}|{book.BorrowTime.Year}-{book.BorrowTime.Month}-{book.BorrowTime.Day}|");
                Console.WriteLine();
            }
        }
    }
}