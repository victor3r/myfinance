
using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Infra;
using MyFinance.Service.Interfaces;

namespace MyFinance.Service;

public class AccountPlanService(MyFinanceDbContext dbContext) : IAccountPlanService
{
    private readonly MyFinanceDbContext _dbContext = dbContext;

    public async Task Add(AccountPlan accountPlan)
    {
        var dbSet = _dbContext.AccountPlan;

        if (accountPlan.Id is null)
        {
            await dbSet.AddAsync(accountPlan);
            await _dbContext.SaveChangesAsync();
            return;
        }

        dbSet.Attach(accountPlan);
        _dbContext.Entry(accountPlan).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var accountPlan = new AccountPlan { Id = id };
        _dbContext.Attach(accountPlan);
        _dbContext.Remove(accountPlan);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<AccountPlan>> GetAll()
    {
        return await _dbContext.AccountPlan.AsNoTracking().ToListAsync();
    }

    public async Task<AccountPlan?> GetById(int id)
    {
        return await _dbContext.AccountPlan.AsNoTracking().FirstOrDefaultAsync(accountPlan => accountPlan.Id == id);
    }
}