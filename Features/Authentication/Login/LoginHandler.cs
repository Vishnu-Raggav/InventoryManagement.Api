using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.Login;

public class LoginHandler
{
  public static async Task<LoginResponse> Handle(LoginRequest request, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
  {
    var user = new IdentityUser
    {
      UserName = request.Username,
      Email = request.Email,
    };
    
    var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, true, false);
    if(!signInResult.Succeeded)
      throw new Exception("Failed to login user");

    var userRole = (await userManager.GetRolesAsync(user))[0];

    return new LoginResponse
    {
      Username = request.Username,
      Email = request.Email,
      Role = userRole
    };
  }
}
