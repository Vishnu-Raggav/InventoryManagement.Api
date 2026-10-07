using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpEndpoint
{
  public void Map(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/auth/register", async ([FromBody] SignUpRequest? request, UserManager<IdentityUser> userManager) =>
    {
      if(request is null)
	throw new Exception("Request body is required");

      var validator = new SignUpValidator();
      var validationResult = await validator.ValidateAsync(request);

      if(!validationResult.IsValid)
	throw new Exception(validationResult.ToString());

      var user = await SignUpHandler.Handle(request, userManager);

      return Results.Ok<SignUpResponse>(user);
    })
    .RequireAuthorization("AdminOnly");
  }
}
