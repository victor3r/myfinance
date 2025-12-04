namespace MyFinance.Domain.Entities;

public class Transaction
{
    public int? Id { get; set; }
    public string History { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public int AccountPlanId { get; set; }
    public AccountPlan AccountPlan { get; set; }
}