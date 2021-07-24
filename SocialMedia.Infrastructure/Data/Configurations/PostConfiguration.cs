using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Publicacion");
            builder.HasKey(e => e.PostId);

            builder.Property(e => e.Description)
                .IsRequired()
                 .HasColumnName("Descripcion")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.PostId)
            .HasColumnName("IdPublicacion");

            builder.Property(e => e.Date).HasColumnType("datetime")
            .HasColumnName("Fecha");

            builder.Property(e => e.Image)
            .HasColumnName("Imagen")
            .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.UserId)
        .HasColumnName("IdUsuario");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        }
    }
}
