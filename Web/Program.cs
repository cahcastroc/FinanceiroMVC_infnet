using Financeiro.Domain.Interfaces;
using Financeiro.Service;
using Financeiro.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add camada de servicço
builder.Services.AddScoped<ITipoInvestimentoService, TipoInvestimentoService>();

//DbConnection
builder.Services.AddDbContext<FinanceiroDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceiroDB")
));

//Session Definir distribuição de cache com a estratégia de inmemory
builder.Services.AddDistributedMemoryCache();

//Session - Setup session - vamos colocar sem parametro, mas pode customizar, como tempo...
builder.Services.AddSession(options =>
options.Cookie.Name = "Data");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Configurar para o app (aplicação usar se~ssão)
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
