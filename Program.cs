using System;
using System.Collections.Generic;
using Library.Models;

namespace Library {
    class Program {
        static void Main (string[] args) {

            Book silverstien1 = new Book ("Where the SideWalk Ends", "Shell Silverstein");
            Book tolkien = new Book ("The Lord Of The Rings", "J.R.R. Tolkien");
            Book lewis = new Book ("The Lion The Witch and the Wardrobe", "C.S. Lewis");
            Book rowling = new Book ("Harry Potter and the Gobblet Of Fire", "J.K. Rowling");

            LocalLib caldwell = new LocalLib ("Caldwell, Id", "Caldwell Library");
            caldwell.AddBook (silverstien1);
            caldwell.AddBook (tolkien);
            caldwell.AddBook (lewis);
            caldwell.AddBook (rowling);

            Console.WriteLine ($"Welcome to the {caldwell.Name} in {caldwell.Location}");

            colorOutput ("Available Books", "Yellow");

            Console.ForegroundColor = ConsoleColor.Blue;

            caldwell.PrintBooks ();

            Console.ResetColor ();

            while (true) {
                colorOutput ("Are you here to \"C\" checkout or \"R\" return books", "Yellow");
                string input = Console.ReadLine ().ToUpper ();
                if (input == "C") {
                    Console.WriteLine ("Please select a book number to checkout");
                    string requestString = Console.ReadLine ();
                    int outIndex = checkInputValReturnNum (requestString);
                    if (!caldwell.checkBook (outIndex)) {
                        colorOutput ("That isn't a good index number", "Red");
                        continue;
                    } else {
                        colorOutput ($"You have chosen {caldwell.infoBook(outIndex).Name}. Continue \"Y\"", "Yellow");
                        string answer = Console.ReadLine ().ToUpper ();
                        if (answer == "Y") {
                            colorOutput ($"Result: {caldwell.checkOutBook(outIndex)}", "Blue");
                            return;
                        } else {
                            colorOutput ("Response not \"Y\". Book not checked out. Thankyou.", "Red");
                            return;
                        }
                    }

                } else if (input == "R") {
                    colorOutput ("Please Enter the index of your book from the list above", "Blue");
                    string requestString = Console.ReadLine ();
                    int outIndex = checkInputValReturnNum (requestString);

                    if (!caldwell.checkBook (outIndex)) {
                        colorOutput ("That isn't a good index number", "Red");
                        continue;
                    } else {
                        colorOutput (caldwell.returnBook (outIndex), "Green");
                        return;
                    }
                } else {
                    colorOutput ("You didn't select \"C\" or \"R\". Do you want to continue. \"Y\" or \"N\" to leave.", "Red");
                    string leave = Console.ReadLine ().ToUpper ();
                    if (leave == "Y") {
                        continue;
                    } else {
                        return;
                    }
                }
            }

        }
        static int checkInputValReturnNum (string input) {
            int result;
            if (Int32.TryParse (input, out result)) {
                result = Int32.Parse (input);
                return result - 1;
            }
            return -1;
        }

        static void colorOutput (string output, string color) {
            ConsoleColor consoleColor = (ConsoleColor) Enum.Parse (typeof (ConsoleColor), color, true);

            Console.ForegroundColor = consoleColor;
            Console.WriteLine (output);
            Console.ResetColor ();
        }

    }
    public enum MusicStyle {
        RandB = 1,
        Rock,
        Country,
        Classical
    }

    public enum MovieStyle {
        Comedy = 1,
        Drama,
        Horror,
        Action,
        Adventure
    }
}