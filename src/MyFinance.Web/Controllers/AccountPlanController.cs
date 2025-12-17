using Microsoft.AspNetCore.Mvc;
using MyFinance.Domain.Entities;
using MyFinance.Service.Interfaces;
using MyFinance.Web.Models;

namespace MyFinance.Web.Controllers;

[Route("[controller]")]
public class AccountPlanController(ILogger<AccountPlanController> logger) : Controller
{
    private readonly ILogger<AccountPlanController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Index(
        [FromServices] IAccountPlanService accountPlanService)
    {
        var accountPlans = await accountPlanService.GetAll();
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

    [HttpGet]
    [Route("add")]
    [Route("add/{id}")]
    public async Task<IActionResult> Add(
        [FromServices] IAccountPlanService accountPlanService,
        [FromRoute] int? id)
    {
        if(id is not null)
        {
            var accountPlan = await accountPlanService.GetById((int)id);

            return View(new AccountPlanModel
            {
                Id = accountPlan.Id,
                Description = accountPlan.Description,
                Type = accountPlan.Type
            });
        }

        return View();

    }

    [HttpPost]
    [Route("add")]
    [Route("add/{id}")]
    public async Task<IActionResult> Add(
        [FromServices] IAccountPlanService accountPlanService,
        AccountPlanModel model)
    {
       await accountPlanService.Add(new AccountPlan
        {
            Id = model.Id,
            Type = model.Type,
            Description = model.Description,
        });

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(
        [FromServices] IAccountPlanService accountPlanService,
        [FromRoute] int id)
    {
        await accountPlanService.Delete(id);

        return RedirectToAction("Index");
    }
}
