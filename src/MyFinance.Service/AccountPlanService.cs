
using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Infra;
using MyFinance.Infra.Interfaces;
using MyFinance.Service.Interfaces;

namespace MyFinance.Service;

public class AccountPlanService(IAccountPlanRepository accountPlanRepository) : IAccountPlanService
{
    public async Task Add(AccountPlan entity)
    {
        await accountPlanRepository.Add(entity);
    }

    public async Task Delete(int id)
    {
        await accountPlanRepository.Delete(id);
    }

    public async Task<List<AccountPlan>> GetAll()
    {
        return await accountPlanRepository.GetAll();
    }

    public async Task<AccountPlan?> GetById(int id)
    {
        return await accountPlanRepository.GetById(id);
    }
}