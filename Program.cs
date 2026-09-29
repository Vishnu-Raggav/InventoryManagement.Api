using Microsoft.AspNetCore.Identity;
using InventoryManagement.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

// Middleware
app.UseAuthentication();
app.UseAuthorization();

app.Run();
