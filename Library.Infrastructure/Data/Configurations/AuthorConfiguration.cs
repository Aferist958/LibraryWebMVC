using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasComment("Индефикатор для авторов");
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("Имя автора или его псевдоним");
            builder.Property(a => a.Description)
                .HasComment("Описание автора");
        }
    }
}
