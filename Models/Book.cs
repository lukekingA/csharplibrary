using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public bool Available { get; private set; }

        public void BookAvailable(bool available)
        {
            Available = available;
        }

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
            Available = true;
        }
    }
}
