using Esquirlas.Domain.Entities;
using FluentValidation;

namespace Esquirlas.Application.Validator
{
    class FaccionValidator : AbstractValidator<Faccion>
    {
        public FaccionValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20).WithMessage("{propertyName} no cumple el máximo permitido");

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.IsDeleted)
                .NotNull()
                .NotEmpty();


            // continuar con el resto conforme a personaje configuration

        }


    }
}
