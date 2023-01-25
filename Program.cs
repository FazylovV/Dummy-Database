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
            List<Reader> readers = InitReaders();
            List<Book> books = InitBooks(readers);

            Console.WriteLine($"{"id",-3}|{"Author",-20}|{"Title",-25}|{"Reader",-20}|{"Borrowing Timr",-14}|");
            Console.WriteLine(new String('-', 87));

            foreach (Book book in books)
            {
                Console.Write($"{book.Id,3}|{book.Author,-20}|{book.Title,-25}|");
                if (book.Reader != null) Console.Write("{0,-20}|  {1:dd-MM-yyyy}  |", book.Reader.Name, book.BorrowTime);
                else Console.Write("{0,-20}|  {1, -10}  |", "", "");
                Console.WriteLine();
            }

            Console.WriteLine(new String('-', 87));
        }

        public static List<Reader> InitReaders()
        {
            string[] readersData = File.ReadAllLines("readers.csv");
            List<Reader> readers = new List<Reader>();
            foreach (string readerData in readersData)
            {
                readers.Add(CsvParser.ParseReader(readerData));
            }
            return readers;
        }

        public static List<Book> InitBooks(List<Reader> readers)
        {
            string[] booksData = File.ReadAllLines("books.csv");
            List<Book> books = new List<Book>();
            foreach (string bookData in booksData)
            {
                books.Add(CsvParser.ParseBook(bookData, readers));
            }
            return books;
        }
    }
}