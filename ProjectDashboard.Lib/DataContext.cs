using Microsoft.EntityFrameworkCore;
using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib;

public class DataContext : DbContext
{
    public DbSet<Solution> Solutions { get; set; }

    #region Overrides of DbContext
    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=dashboard.db;");
    }
    #endregion
}