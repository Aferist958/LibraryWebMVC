using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasComment("Индефикатор для книг");
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("Название книг");
            builder.Property(b => b.YearOfPublication)
                .HasComment("Год издания");
            builder.Property(b => b.Quantity)
                .IsRequired()
                .HasComment("Количество книг");
            builder.HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(t => t.ToTable("Book_Author"));
        }
    }
}
