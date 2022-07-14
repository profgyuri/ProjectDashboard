namespace ProjectDashboard.Library.Models;

using Microsoft.EntityFrameworkCore;

internal class DatabaseContext : DbContext
{
    internal DbSet<Standalone> Standalones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }
}
