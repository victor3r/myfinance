using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;

namespace MyFinance.Infra;

public class MyFinanceDbContext : DbContext
{
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<AccountPlan> AccountPlan { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=myfinance;Trusted_Connection=True;");
    }
}
