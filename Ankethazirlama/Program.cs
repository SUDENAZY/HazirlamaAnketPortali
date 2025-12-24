using Ankethazirlama.Data;
using Ankethazirlama.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();

var app = builder.Build();

// Ensure 'GetApp' does not return null to avoid CS8604.  
var nonNullApp = GetApp(app) ?? throw new InvalidOperationException("Application instance cannot be null.");

nonNullApp.MapControllerRoute(
  name: "default",
  pattern: "{controller=Admin}/{action=Login}/{id?}");

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

static WebApplication? GetApp(WebApplication? app)
{
    return app;
}