using asp_net_mvc_spd221.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.
builder.Services.AddControllersWithViews();
// add custom services

// configure db context
builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(connStr));

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
