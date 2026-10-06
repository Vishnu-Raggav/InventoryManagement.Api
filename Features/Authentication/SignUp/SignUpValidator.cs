using FluentValidation;

namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpValidator: AbstractValidator<SignUpRequest>
{
  public SignUpValidator()
  {
    RuleFor(r => r.Username).NotEmpty().Length(8, 50);
    RuleFor(r => r.Password).NotEmpty().Length(8, 50);
    RuleFor(r => r.Email).NotEmpty().EmailAddress();
    RuleFor(r => r.Role).NotEmpty().IsEnumName(typeof(Role));
  }

  private enum Role
  {
    Admin,
    Employee
  }
}
