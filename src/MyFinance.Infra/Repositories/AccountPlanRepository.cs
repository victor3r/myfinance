using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Infra.Interfaces;

namespace MyFinance.Infra.Repositories;

public class AccountPlanRepository(MyFinanceDbContext dbContext) : Repository<AccountPlan>(dbContext), IAccountPlanRepository
{
}
