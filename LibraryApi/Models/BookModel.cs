using System.Collections.Generic;

namespace LibraryApi.Models
{
    public class BookModel
    {
        public string Title { get; set; }

        public AuthorModel Author { get; set; }

        public string Genre { get; set; }

        public string GenreType { get; set; }

        public string Language { get; set; }

        public ICollection<string> KeyWords { get; set; }

        public string Description { get; set; }
    }
}