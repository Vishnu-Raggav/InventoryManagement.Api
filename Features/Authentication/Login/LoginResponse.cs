namespace InventoryManagement.Api.Features.Authentication.Login;

public class LoginResponse
{
  public string Username { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Role { get; set; } = null!;
}
