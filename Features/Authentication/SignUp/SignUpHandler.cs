using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpHandler
{
  public static async Task<SignUpResponse> Handle(SignUpRequest request, UserManager<IdentityUser> userManager)
  {
    var user = new IdentityUser
    {
      UserName = request.Username,
      Email = request.Email,
    };

    var createUserResult = await userManager.CreateAsync(user, request.Password);
  
    if(!createUserResult.Succeeded)
      throw new Exception("Failed to create user");

    var addToRoleResult = await userManager.AddToRoleAsync(user, request.Role);

    if(!addToRoleResult.Succeeded)
      throw new Exception($"Failed to add user to role '{request.Role}'");

    return new SignUpResponse()
    {
      Username = request.Username,
      Email = request.Email,
      Role = request.Role
    };
  }
} 
