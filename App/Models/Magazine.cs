using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;

namespace Library.Models {
  class Magazine : Publication {
    public Magazine (string name) : base (name) {
      CanCheckOut = true;
    }

    public bool CanCheckOut { get; set; }

  }
}