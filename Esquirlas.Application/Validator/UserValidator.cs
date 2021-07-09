using Esquirlas.Domain.Entities;
using FluentValidation;

namespace Esquirlas.Application.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Usuario)
              .NotNull()
              .NotEmpty()
              .MaximumLength(20).WithMessage("{propertyUsuario} no cumple el máximo permitido");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress().WithErrorCode("No es un mail válido");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty();
        }
    }
}
