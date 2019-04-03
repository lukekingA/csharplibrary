using Library.Interface;

namespace Library.Models {
  class Music : Media {
    public MusicStyle Style { get; set; }
    public Music (string name, MusicStyle style) : base (name) {
      Style = style;
    }
  }
}