using System.Reflection;
using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Data;

internal sealed class LinkerBoardDbContext(DbContextOptions<LinkerBoardDbContext> options)
    : DbContext(options)
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}