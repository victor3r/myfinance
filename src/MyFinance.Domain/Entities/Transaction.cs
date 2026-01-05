using MyFinance.Domain.Entities.Base;

namespace MyFinance.Domain.Entities;

public class Transaction : BaseEntity
{
    public string? History { get; set; }
    public DateOnly Date { get; set; }
    public decimal Value { get; set; }
    public int AccountPlanId { get; set; }
    public AccountPlan? AccountPlan { get; set; }
}