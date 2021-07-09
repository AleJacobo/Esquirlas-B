using Esquirlas.Domain.Entities;
using FluentValidation;

namespace Esquirlas.Application.Validator
{
    public class PersonajeValidator : AbstractValidator<Personaje>
    {
        public PersonajeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20).WithMessage("{propertyName} no cumple el máximo permitido");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30).WithMessage("{propertyLastName} no cumple el máximo permitido");

            RuleFor(x => x.Age)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Clase)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Raza)
                .NotNull()
                .NotEmpty();

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
