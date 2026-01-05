using MyFinance.Domain.Entities.Base;

namespace MyFinance.Domain.Entities;

public class AccountPlan : BaseEntity
{
    public string? Description { get; set; }
    public char Type { get; set; }
}