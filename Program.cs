using System;
using System.Collections.Generic;
using Library.Models;

namespace Library {
    class Program {
        static void Main (string[] args) {

            App app = new App ();
            app.Run ();

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