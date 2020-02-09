using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

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
