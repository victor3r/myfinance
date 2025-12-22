using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFinance.Domain.Entities;
using MyFinance.Service.Interfaces;
using MyFinance.Web.Models;

namespace MyFinance.Web.Controllers;

[Route("[controller]")]
public class TransactionController(ILogger<AccountPlanController> logger) : Controller
{
    private readonly ILogger<AccountPlanController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Index(
        [FromServices] ITransactionService transactionService)
    {
        var transactions = await transactionService.GetAll();
        List<TransactionModel> transactionModels = [];

        foreach (var transaction in transactions)
        {
            transactionModels.Add(new TransactionModel
            {
                Id = transaction.Id,
                History = transaction.History,
                Date = transaction.Date,
                Value = transaction.Value,
                AccountPlan = transaction.AccountPlan,
            });
        }

        ViewBag.Transactions = transactionModels;

        return View();
    }

    [HttpGet]
    [Route("add")]
    [Route("add/{id}")]
    public async Task<IActionResult> Add(
        [FromServices] ITransactionService transactionService,
        [FromServices] IAccountPlanService accountPlanService,
        [FromRoute] int? id)
    {
        var accountPlans = await accountPlanService.GetAll();

        var model = new TransactionModel{
            Date = DateOnly.FromDateTime(DateTime.Now),
            AccountPlans = new SelectList(accountPlans, "Id", "Description"),
        };

        if (id is not null)
        {
            var transaction = await transactionService.GetById((int)id);

            model.Id = transaction.Id;
            model.History = transaction.History;
            model.Date = transaction.Date;
            model.Value = transaction.Value;
            model.AccountPlanId = transaction.AccountPlanId;
        }

        return View(model);
    }

    [HttpPost]
    [Route("add")]
    [Route("add/{id}")]
    public async Task<IActionResult> Add(
        [FromServices] ITransactionService transactionService,
        TransactionModel model)
    {
        await transactionService.Add(new Transaction
        {
            Id = model.Id,
            History = model.History,
            Date = model.Date,
            Value = model.Value,
            AccountPlanId = model.AccountPlanId,
        });

        return RedirectToAction("Index");
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(
        [FromServices] ITransactionService transactionService,
        [FromRoute] int id)
    {
        await transactionService.Delete(id);

        return RedirectToAction("Index");
    }
}

