using System.Collections.Generic;

namespace Library.Data.Models
{
    public class KeyWord
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public ICollection<BookKeyWord> Books { get; set; } = new HashSet<BookKeyWord>();
    }
}
