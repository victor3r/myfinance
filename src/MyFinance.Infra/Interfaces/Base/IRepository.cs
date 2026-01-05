using MyFinance.Domain.Entities;

namespace MyFinance.Infra.Interfaces.Base;

public interface IRepository<T> where T : class
{
    Task Add(T entity);
    Task Delete(int id);
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
}

