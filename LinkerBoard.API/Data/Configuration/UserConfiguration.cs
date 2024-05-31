using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkerBoard.API.Data.Configuration;

internal class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tblUser");
        
        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.Username)
            .HasColumnName("username")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        
        builder.Property(x => x.CreatedAt)
            .HasColumnType("date")
            .HasColumnName("createdAt");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("date")
            .HasColumnName("updatedAt");
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}