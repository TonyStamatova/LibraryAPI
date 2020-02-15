using System.Data.Entity.ModelConfiguration;

using Library.Data.Models;

namespace Library.Data.EntityConfigurations
{
    internal class BookKeyWordConfiguration : EntityTypeConfiguration<BookKeyWord>
    {
        internal BookKeyWordConfiguration()
        {
            this.HasKey(bkw => new { bkw.BookId, bkw.KeyWordId });
        }
    }
}
