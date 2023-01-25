using System.Text.Json;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace Dummy_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowAllBooks();
        }

        public static void ShowAllBooks()
        {
            string[] readersData = File.ReadAllLines("readers.csv");
            string[] booksData = File.ReadAllLines("books.csv");
            List<Reader> readers = new List<Reader>();
            List<Book> books = new List<Book>();

            Console.WriteLine($"{"id",-3}|{"Author",-20}|{"Title",-25}|{"Reader",-20}|{"Time Of Borrow",-14}|");
            Console.WriteLine(new String('-', 100));

            foreach (string readerData in readersData) readers.Add(CsvParser.ParseReader(readerData));
            foreach (string bookData in booksData)
            {
                Book book = CsvParser.ParseBook(bookData, readers);
                books.Add(book);
                Console.Write($"{book.Id,3}|{book.Author,-20}|{book.Title,-25}|");
                if (book.Reader != null) Console.Write("{0,-20}|  {1:dd-MM-yyyy}  |", book.Reader.Name, book.BorrowTime);
                else Console.Write("{0,-20}|  {1, -10}  |", "", "");
                Console.WriteLine();
            }
        }
    }
}