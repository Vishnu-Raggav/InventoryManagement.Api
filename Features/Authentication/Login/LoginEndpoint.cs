using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.Login;

public class LoginEndpoint
{
  public void Map(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/auth/login", async ([FromBody] LoginRequest? request, SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager) =>
    {
      if(request is null)
	throw new Exception("Request body is required");

      var validator = new LoginValidator();
      var validationResult = await validator.ValidateAsync(request);

      if(!validationResult.IsValid)
	throw new Exception(validationResult.ToString());

      var user = await LoginHandler.Handle(request, signInManager, userManager);

      return Results.Ok<LoginResponse>(user);
    });
  }
}
