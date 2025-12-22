using Microsoft.AspNetCore.Mvc.Rendering;
using MyFinance.Domain.Entities;

namespace MyFinance.Web.Models
{
    public class TransactionModel
    {
        public int? Id { get; set; }
        public string History { get; set; }
        public DateOnly Date { get; set; }
        public decimal Value { get; set; }
        public int AccountPlanId { get; set; }
        public IEnumerable<SelectListItem>? AccountPlans { get; set; }
        public AccountPlan AccountPlan { get; set; }
    }
}
