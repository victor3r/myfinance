
using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Infra;
using MyFinance.Service.Interfaces;

public class TransactionService : ITransactionService
{
    private readonly MyFinanceDbContext _dbContext;

    public TransactionService(MyFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Transaction transaction)
    {
        var dbSet = _dbContext.Transaction;

        if (transaction.Id is null)
        {
            await dbSet.AddAsync(transaction);
            return;
        }

        dbSet.Attach(transaction);
        _dbContext.Entry(transaction).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var transaction = new Transaction { Id = id };
        _dbContext.Attach(transaction);
        _dbContext.Remove(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Transaction>> GetAll()
    {
        return await _dbContext.Transaction.AsNoTracking().ToListAsync();
    }

    public async Task<Transaction?> GetById(int id)
    {
        return await _dbContext.Transaction.AsNoTracking().FirstOrDefaultAsync(transaction => transaction.Id == id);
    }
}