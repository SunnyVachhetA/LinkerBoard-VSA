using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Data.Extensions;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        DatabaseSeeder dbSeeder = new();

        modelBuilder.Entity<User>()
            .HasData(dbSeeder.Users);

        modelBuilder.Entity<LinkBoard>()
            .HasData(dbSeeder.LinkBoards);

        modelBuilder.Entity<Link>()
            .HasData(dbSeeder.Links);
    }
}