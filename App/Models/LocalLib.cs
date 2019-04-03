using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;

namespace Library.Models {
    class LocalLib {
        public string Location { get; private set; }
        public string Name { get; private set; }

        //list of books in Library and books checked out

        public List<IAvailable> AvailableItems { get; set; }

        public List<IAvailable> CheckedOut { get; set; }

        public void AddItemCheckout (Book item) {
            AvailableItems.Add (item);
        }

        public void AddItemCheckout (Movie item) {
            AvailableItems.Add (item);
        }

        public void AddItemCheckout (Music item) {
            AvailableItems.Add (item);
        }

        public string checkOutItem (int index) {
            if (AvailableItems.Contains (AvailableItems[index]) && AvailableItems[index].Available) {
                CheckedOut.Add (AvailableItems[index]);
                AvailableItems[index].ChangeAvail (false);
                AvailableItems.Remove (AvailableItems[index]);

                return $"{AvailableItems[index].Name} Has Been Checked Out. Please return in two weeks";
            }
            return "Book at choice isn't available";
        }

        public string returnBook (int index) {
            if (CheckedOut.Contains (CheckedOut[index])) {
                CheckedOut[index].ChangeAvail (true);
                AvailableItems.Add (CheckedOut[index]);
                CheckedOut.Remove (CheckedOut[index]);
                return "Book Has been returned. ThankYou.";
            }
            return "We don't seem to have reccord of that book. Check another Library.";
        }

        public IAvailable infoItem (int index) {
            return AvailableItems[index];
        }

        public bool checkIndex (int index) {
            if (AvailableItems.Contains (AvailableItems[index])) {
                return true;
            }
            return false;
        }

        public void PrintItems () {
            for (int i = 0; i < AvailableItems.Count; i++) {
                Console.Write ($"{i+1}-{AvailableItems[i].Name} ");
                if (AvailableItems[i] is Book g && g.Available) {
                    Console.Write ($"{g.Name}");
                }
                System.Console.WriteLine ("\n");
            }
        }

        public LocalLib (string location, string name) {
            Location = location;
            Name = name;
            AvailableItems = new List<IAvailable> ();
            CheckedOut = new List<IAvailable> ();
            Book silverstien1 = new Book ("Where the SideWalk Ends", "Shell Silverstein");
            Book tolkien = new Book ("The Lord Of The Rings", "J.R.R. Tolkien");
            Book lewis = new Book ("The Lion The Witch and the Wardrobe", "C.S. Lewis");
            Book rowling = new Book ("Harry Potter and the Gobblet Of Fire", "J.K. Rowling");

            Movie cliffhanger = new Movie ("Cliff Hanger", MovieStyle.Drama);
            Movie deathwish = new Movie ("Death Wish", MovieStyle.Drama);
            Movie theQuicknDead = new Movie ("The Quick and The Dead", MovieStyle.Drama);

            Music rolStones = new Music ("Rolling Stones", MusicStyle.Rock);
            Music cCR = new Music ("CCR", MusicStyle.Rock);
            Music lenSkin = new Music ("Lynyrd Skynyrd", MusicStyle.Rock);

            AvailableItems.Add (silverstien1);
            AvailableItems.Add (lewis);
            AvailableItems.Add (rowling);
            AvailableItems.Add (cliffhanger);
            AvailableItems.Add (deathwish);
            AvailableItems.Add (theQuicknDead);
            AvailableItems.Add (rolStones);
            AvailableItems.Add (cCR);
            AvailableItems.Add (lenSkin);

        }
    }
}