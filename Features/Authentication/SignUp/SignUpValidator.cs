using FluentValidation;

namespace InventoryManagement.Api.Features.Authentication.SignUp;

public class SignUpValidator: AbstractValidator<SignUpRequest>
{
  public SignUpValidator()
  {
    RuleFor(r => r.username).NotEmpty().Length(8, 50);
    RuleFor(r => r.password).NotEmpty().Length(8, 50);
    RuleFor(r => r.email).NotEmpty().EmailAddress();
    RuleFor(r => r.role).NotEmpty().IsEnumName(typeof(Role));
  }

  private enum Role
  {
    Admin,
    Employee
  }
}
