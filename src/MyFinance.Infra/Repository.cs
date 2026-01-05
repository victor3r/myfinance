using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities.Base;
using MyFinance.Infra.Interfaces.Base;

namespace MyFinance.Infra;

public abstract class Repository<T>(MyFinanceDbContext dbContext) : IRepository<T> where T : BaseEntity, new()
{
    protected DbSet<T> dbSet = dbContext.Set<T>();
    public async Task Add(T entity)
    {
        if (entity.Id is null)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return;
        }

        dbSet.Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = new T { Id = id };
        dbContext.Attach(entity);
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }
}
