using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    class LocalLib
    {
        public string Location { get; private set; }
        public string Name { get; private set; }

        //list of books in Library and books checked out
        List<Book> Books { get; set; }
        List<Book> CheckedOut { get; set; }


        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public string checkOutBook(int index)
        {
            Book book = Books[index];

            if (Books.Contains(book))
            {
                CheckedOut.Add(book);
                Books.Remove(book);
                return $"{book.Name}";
            }
            return $"{book.Name} isn't available";
        }

        public Book infoBook(int index)
        {
            return Books[index];
        }

        public bool checkBook(int index)
        {
            if (Books.Contains(Books[index]))
            {
                return true;
            }
            return false;
        }
        
        public void PrintBooks()
        {
            for (int i = 0; i < Books.Count; i++)
            {
            Console.WriteLine($"{i+1}-{Books[i].Name} by {Books[i].Author}");

            }
        }
        
        public LocalLib(string location, string name)
        {
            Location = location;
            Name = name;
            Books = new List<Book>();
        }
    }
}
