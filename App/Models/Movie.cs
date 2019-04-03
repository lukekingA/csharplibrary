using Library.Interface;

namespace Library.Models {
  class Movie : Media {
    public MovieStyle Style { get; set; }
    public Movie (string name, MovieStyle style) : base (name) {
      Style = style;
    }
  }
}