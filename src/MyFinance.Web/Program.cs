using MyFinance.Infra;
using MyFinance.Infra.Interfaces;
using MyFinance.Infra.Repositories;
using MyFinance.Service;
using MyFinance.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbContext>();

builder.Services.AddScoped<IAccountPlanService, AccountPlanService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<IAccountPlanRepository, AccountPlanRepository>();

builder.Services.AddRouting(option => option.LowercaseUrls = true);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
