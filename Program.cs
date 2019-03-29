using System;
using Library.Models;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {

            Book silverstien1 = new Book("Shell Silverstein", "Where the SideWalk Ends");
            Book tolkien = new Book("J.R.R. Tolkien","The Lord Of The Rings" );
            Book lewis = new Book("C.S. Lewis", "The Lion The Witch and the Wardrobe");
            Book rowling = new Book("J.K. Rowling", "Harry Potter and the Gobblet Of Fire");

            LocalLib caldwell = new LocalLib("Caldwell, Id", "Caldwell Library");
            caldwell.AddBook(silverstien1);
            caldwell.AddBook(tolkien);
            caldwell.AddBook(lewis);
            caldwell.AddBook(rowling);

            Console.WriteLine($"Welcome to the {caldwell.Name} in {caldwell.Location}");

            colorOutput("Available Books", "Yellow");

            Console.ForegroundColor = ConsoleColor.Blue;

            caldwell.PrintBooks();

            Console.ResetColor();

            Console.WriteLine("Please select a book number to checkout");
            string requestString = Console.ReadLine();
            int outIndex = checkInputValReturnNum(requestString);
            if (caldwell.checkBook(outIndex))
            {
                colorOutput($"You have chosen {caldwell.infoBook(outIndex).Name}. Continue \"Y\"", "Yellow");
                string answer = Console.ReadLine().ToUpper();
                if ( answer == "Y")
                {
                    colorOutput($"Result: {caldwell.checkOutBook(outIndex)}", "Blue");
                }else
                {
                    colorOutput("Responce not \"Y\". Book not checked out. Thankyou.", "Red");
                }
            }
        }
        static int checkInputValReturnNum(string input)
        {
            int result;
            if (Int32.TryParse(input, out result))
            {
                result = Int32.Parse(input);
                return result -1;
            }
            return -1;
        }

        static void colorOutput(string output,string color)
        {
            ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
           
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(output);
            Console.ResetColor();

        }
    }
}
