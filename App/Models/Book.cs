using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;

namespace Library.Models {
    class Book : Publication, IAvailable {
        public Book (string name, string author) : base (name) {
            Author = author;
            Available = true;
            CanCheckOut = true;
        }
        public string Author { get; set; }
        public void ChangeAvail (bool value) {
            Available = value;
        }
        public bool CanCheckOut { get; set; }

        public bool Available { get; set; }

        public void BookAvailable (bool available) {
            Available = available;
        }

    }
}