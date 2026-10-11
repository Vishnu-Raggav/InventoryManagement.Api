namespace InventoryManagement.Api.Features.Authentication.Login;

public class LoginRequest 
{
  public string Username { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;
}
