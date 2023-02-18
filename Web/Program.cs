using Financeiro.Domain.Interfaces;
using Financeiro.Service;
using Financeiro.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add camada de servic�o
builder.Services.AddScoped<ITipoInvestimentoService, TipoInvestimentoService>();

//DbConnection
builder.Services.AddDbContext<FinanceiroDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceiroDB")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
