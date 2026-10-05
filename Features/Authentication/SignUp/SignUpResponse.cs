namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpResponse
{
  public string Username { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Role { get; set; } = null!;
}
