using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using provateste.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// SQL Server + Identity
builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ProdutoContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LoginRedirect}/{id?}");


app.MapRazorPages(); // Identity UI

app.Run();
