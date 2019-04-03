using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;

namespace Library.Models {
  class NewsPaper : Publication {
    public NewsPaper (string name) : base (name) {
      CanCheckOut = true;
    }

    public bool CanCheckOut { get; set; }

  }
}