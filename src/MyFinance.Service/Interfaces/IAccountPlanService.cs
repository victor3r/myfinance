using MyFinance.Domain.Entities;

namespace MyFinance.Service.Interfaces;

public interface IAccountPlanService
{
    Task Add(AccountPlan accountPlan);
    Task Delete(int id);
    Task<List<AccountPlan>> GetAll();
    Task<AccountPlan?> GetById(int id);
}