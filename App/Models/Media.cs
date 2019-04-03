using Library.Interface;

namespace Library.Models {
  class Media : IAvailable {
    public Media (string name) {
      Name = name;
      Available = true;
    }
    public void ChangeAvail (bool value) {
      Available = value;
    }
    public bool Available { get; set; }
    public string Name { get; set; }

  }
}