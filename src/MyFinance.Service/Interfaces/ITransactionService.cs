using MyFinance.Domain.Entities;

namespace MyFinance.Service.Interfaces;

public interface ITransactionService
{
    Task Add(Transaction transaction);
    Task Delete(int id);
    Task<List<Transaction>> GetAll();
    Task<Transaction?> GetById(int id);
}