using System;
using System.Collections.Generic;
using Library.Interface;
using Library.Models;

namespace Library {
  class App {
    LocalLib cald = new LocalLib ("Caldwell, Idaho", "Caldwell Library");
    public void Run () {
      Console.WriteLine ($"Welcome to the {cald.Name} in {cald.Location}");
      colorOutput ("Available Books", "Yellow");

      Console.ForegroundColor = ConsoleColor.Blue;
      cald.PrintItems ();
      Console.ResetColor ();

      while (true) {
        colorOutput ("Are you here to \"C\" checkout or \"R\" return books", "Yellow");
        string input = Console.ReadLine ().ToUpper ();
        if (input == "C") {
          Console.WriteLine ("Please select a book number to checkout");
          string requestString = Console.ReadLine ();
          int outIndex = checkInputValReturnNum (requestString);
          if (!cald.checkIndex (outIndex)) {
            colorOutput ("That isn't a good index number", "Red");
            continue;
          } else {
            colorOutput ($"You have chosen {cald.infoItem(outIndex).Name}. Continue \"Y\"", "Yellow");
            string answer = Console.ReadLine ().ToUpper ();
            if (answer == "Y") {
              colorOutput ($"Result: {cald.checkOutItem(outIndex)}", "Blue");
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

          if (!cald.checkIndex (outIndex)) {
            colorOutput ("That isn't a good index number", "Red");
            continue;
          } else {
            colorOutput (cald.returnBook (outIndex), "Green");
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

}