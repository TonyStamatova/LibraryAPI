namespace Library.Data.Models
{
    public class BookKeyWord
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int KeyWordId { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}