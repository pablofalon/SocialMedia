using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
           .HasColumnName("IdUsuario");

            builder.Property(e => e.LastName)
            .HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
            .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.IsActive)
          .HasColumnName("Activo");

            builder.Property(e => e.BirthDate)
            .HasColumnName("FechaNacimiento")
            .HasColumnType("date");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telephone)
            .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
