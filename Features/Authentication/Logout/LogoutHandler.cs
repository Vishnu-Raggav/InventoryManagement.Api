using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Api.Features.Authentication.Logout;

public class LogoutHandler
{
  public static async Task Handle(SignInManager<IdentityUser> signInManager)
  {
    await signInManager.SignOutAsync();
  }
}
