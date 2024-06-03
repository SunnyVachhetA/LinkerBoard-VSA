using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkerBoard.API.Data.Configuration;

internal sealed class LinkBoardConfiguration
    : IEntityTypeConfiguration<LinkBoard>
{
    public void Configure(EntityTypeBuilder<LinkBoard> builder)
    {
        builder.ToTable("tblLinkBoard");
        
        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(255)
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.UserId)
            .HasColumnName("userId");
        
        builder.Property(x => x.CreatedAt)
            .HasColumnType("date")
            .HasColumnName("createdAt");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("date")
            .HasColumnName("updatedAt");
        
        //https://www.npgsql.org/efcore/mapping/full-text-search.html#method-2-expression-index
        builder.HasIndex(x => new { x.Title })
            .HasMethod("gin")
            .IsTsVectorExpressionIndex("english"); 
    }
}