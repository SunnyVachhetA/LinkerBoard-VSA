using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkerBoard.API.Data.Configuration;

internal sealed class LinkConfiguration
    : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.ToTable("tblLink");

        builder.HasOne(x => x.LinkBoard)
            .WithMany(y => y.Links)
            .HasForeignKey(f => f.LinkBoardId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.LinkBoardId)
            .HasColumnName("linkBoardId");

        builder.Property(x => x.CreatedAt)
            .HasColumnType("date")
            .HasColumnName("createdAt");

        builder.Property(x => x.UpdatedAt)
            .HasColumnType("date")
            .HasColumnName("updatedAt");

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(255)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Note)
            .HasColumnName("note")
            .HasColumnType("text")
            .HasComment("Side notes for link; can be overview");

        builder.Property(x => x.Url)
            .HasColumnName("url")
            .HasColumnType("varchar")
            .HasMaxLength(2083); // TODO: Learn about url length and shortner in .NET
        
        //https://www.npgsql.org/efcore/mapping/full-text-search.html#method-2-expression-index
        builder.HasIndex(x => new { x.Title, x.Url })
            .HasMethod("gin")
            .IsTsVectorExpressionIndex("english"); 
    }
}