using System.Reflection;
using LinkerBoard.API.Data.Extensions;
using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Data;

internal sealed class LinkerBoardDbContext(DbContextOptions<LinkerBoardDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<LinkBoard> LinkBoards { get; set; }

    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Seed(); //Seeding database using Bogus in Extension Method ModelBuilderExtension.cs
    }
}