using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using InventoryManagement.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
      options.User.RequireUniqueEmail = true;
    })
  .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
    {
      options.AddPolicy("AdminOnly", policy =>
	  {
	    policy.RequireRole("Admin");
	  });
    });

var app = builder.Build();

// Middleware
app.UseAuthentication();
app.UseAuthorization();

app.Run();
