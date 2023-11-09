using SaudiPieShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("SaudiPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection" +
    " string 'SaudiPieShopDbContextConnection' not found.");

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(option=>
    {
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<SaudiPieShopDbContext>(Options => {
    Options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<SaudiPieShopDbContext>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();



app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");
app.MapRazorPages();
DbInitializer.Seed(app);

app.Run();
