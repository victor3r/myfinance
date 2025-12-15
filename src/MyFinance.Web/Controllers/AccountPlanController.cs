using Microsoft.AspNetCore.Mvc;
using MyFinance.Service.Interfaces;
using MyFinance.Web.Models;

namespace MyFinance.Web.Controllers;

public class AccountPlanController(ILogger<AccountPlanController> logger,IAccountPlanService accountPlanService) : Controller
{
    private readonly ILogger<AccountPlanController> _logger = logger;
    private readonly IAccountPlanService _accountPlanService= accountPlanService;

    public async Task<IActionResult> Index()
    {
        var accountPlans = await _accountPlanService.GetAll();
        List<AccountPlanModel> accountPlanModels = [];

        foreach (var accountPlan in accountPlans)
        {
            accountPlanModels.Add(new AccountPlanModel
            {
                Id = accountPlan.Id,
                Description = accountPlan.Description,
                Type = accountPlan.Type
            });
        }

        ViewBag.AccountPlans = accountPlanModels;

        return View();
    }
}
