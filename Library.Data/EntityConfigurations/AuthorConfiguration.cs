using System.Data.Entity.ModelConfiguration;

using Library.Data.Models;

namespace Library.Data.EntityConfigurations
{
    internal class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        internal AuthorConfiguration()
        {
            this.HasKey(a => a.Id);

            this.Property(a => a.FirstName)
                .IsRequired();
        }
    }
}
