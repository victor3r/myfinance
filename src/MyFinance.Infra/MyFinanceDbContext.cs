using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFinance.Domain.Entities;

namespace MyFinance.Infra;

public class MyFinanceDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<AccountPlan> AccountPlan { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = configuration.GetConnectionString("Database");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
