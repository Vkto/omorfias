using API.Omorfias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Omorfias.Data.Mapping
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(100);


            builder.Ignore(t => t.ValidationResult);
            builder.Ignore(t => t.IsValid);
            

        }
    }
}
