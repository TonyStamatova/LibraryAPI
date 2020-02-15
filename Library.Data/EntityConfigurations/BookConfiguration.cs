using System.Data.Entity.ModelConfiguration;

using Library.Data.Models;

namespace Library.Data.EntityConfigurations
{
    internal class BookConfiguration : EntityTypeConfiguration<Book>
    {
        internal BookConfiguration()
        {
            this.HasKey(b => b.Id);

            this.Property(b => b.Title)
                .IsRequired();

            this.Property(b => b.ContentPath)
                .IsRequired();

            this.HasRequired(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            this.Property(b => b.Language)
                .IsOptional();

            this.Property(b => b.GenreType)
                .IsOptional();

            this.HasMany(b => b.KeyWords)
                .WithRequired(bkw => bkw.Book)
                .HasForeignKey(bkw => bkw.BookId);
        }
    }
}
