namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpRequest
{
  public string username { get; set; } = null!;
  public string email { get; set; } = null!;
  public string password { get; set; } = null!;
  public string role { get; set; } = null!;
}
