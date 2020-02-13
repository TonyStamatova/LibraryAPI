using System.Data.Entity.ModelConfiguration;

using Library.Data.Models;

namespace Library.Data.EntityConfigurations
{
    internal class KeyWordConfiguration : EntityTypeConfiguration<KeyWord>
    {
        internal KeyWordConfiguration()
        {
            this.HasKey(kw => kw.Id);

            this.HasRequired(kw => kw.Word);

            this.HasMany(kw => kw.Books)
                .WithRequired(bkw => bkw.KeyWord)
                .HasForeignKey(bkw => bkw.KeyWordId);
        }
    }
}
