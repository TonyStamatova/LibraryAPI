using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Library.Data.EntityConfigurations
{
    internal class BookConfiguration : EntityTypeConfiguration<Book>
    {
        internal BookConfiguration()
        {
            this.HasKey(b => b.Id);

            this.HasRequired(b => b.Title);

            this.HasRequired(b => b.ContentPath);

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
