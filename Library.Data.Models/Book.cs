using System.Collections.Generic;
using Library.Data.Models.Enumerations;

namespace Library.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public GenreType GenreType { get; set; }

        public Language Language { get; set; }

        public ICollection<BookKeyWord> KeyWords { get; set; } = new HashSet<BookKeyWord>();

        public string Description { get; set; }

        public string ContentPath { get; set; }
    }
}
