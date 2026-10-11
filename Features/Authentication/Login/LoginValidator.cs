using FluentValidation;

namespace InventoryManagement.Api.Features.Authentication.Login;

public class LoginValidator: AbstractValidator<LoginRequest>
{
  public LoginValidator()
  {
    RuleFor(r => r.Username).NotEmpty().Length(8, 50);
    RuleFor(r => r.Password).NotEmpty().Length(8, 50);
    RuleFor(r => r.Email).NotEmpty().EmailAddress();
  }
}
