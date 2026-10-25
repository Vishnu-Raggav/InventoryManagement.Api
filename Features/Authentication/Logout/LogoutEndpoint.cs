using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.Logout;

public class LogoutEndpoint
{
  public void Map(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/auth/login", async (SignInManager<IdentityUser> signInManager) =>
    {
      await LogoutHandler.Handle(signInManager);
      return Results.NoContent();
    });
  }
}
