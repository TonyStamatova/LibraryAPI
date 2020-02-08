using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Pseudonym { get; set; }

        public string About { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
