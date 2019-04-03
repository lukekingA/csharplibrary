namespace Library.Interface {
  interface IAvailable {
    bool Available { get; set; }

    string Name { get; }
    void ChangeAvail (bool value);
  }
}