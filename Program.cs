using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Dummy_DB
{
    internal class Program
    {
        const int Id = 0;
        const int Author = 1;
        const int Title = 2;
        const int ReaderName = 3;
        const int BorrowingTime = 4;
        const int SpaceForDate = 10;

        static void Main(string[] args)
        {
            ShowAllBooks();
        }

        public static void ShowAllBooks()
        {
            StringBuilder sb = new StringBuilder();
            List<Reader> readers = InitReaders();
            List<Book> books = InitBooks(readers);

            string[] columnsName = new string[] { "id", "Author", "Title", "Reader", "Borrowing Time" };
            int[] maxLengths = GetMaxLengths(readers, books, columnsName);
            int cntOfSeparators = columnsName.Count();
            int legthOfTable = maxLengths.Sum() + cntOfSeparators;

            Console.WriteLine(FormatColumnsNames(columnsName, maxLengths));
            Console.WriteLine(new String('-', legthOfTable));

            foreach (Book book in books)
            {
                Console.WriteLine(book.FormatBookToString(maxLengths));
            }

            Console.WriteLine(new String('-', legthOfTable));
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

        public static int[] GetMaxLengths(List<Reader> readers, List<Book> books, string[] columnsName)
        {
            int idMaxLength = Math.Max(books.Max(x => x.Id.ToString().Length), columnsName[Id].Length);
            int authorMazLength = Math.Max(books.Max(x => x.Author.Length), columnsName[Author].Length);
            int titleMaxLength = Math.Max(books.Max(x => x.Title.Length), columnsName[Title].Length);
            int readerNameMaxLength = Math.Max(books.Max(x => x.Reader.Name.Length), columnsName[ReaderName].Length);
            int borrowingTimeMaxLength = Math.Max(SpaceForDate, columnsName[BorrowingTime].Length);

            return new int[] { idMaxLength, authorMazLength, titleMaxLength, readerNameMaxLength, borrowingTimeMaxLength};
        }

        public static string FormatColumnsNames(string[] columnsName, int[] maxLengths)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(columnsName[Id].PadLeft(maxLengths[Id]));
            sb.Append($"|{columnsName[Author].PadRight(maxLengths[Author])}");
            sb.Append($"|{columnsName[Title].PadRight(maxLengths[Title])}");
            sb.Append($"|{columnsName[ReaderName].PadRight(maxLengths[ReaderName])}");
            sb.Append($"|{columnsName[BorrowingTime]}|");

            return sb.ToString();
        }
    }
}