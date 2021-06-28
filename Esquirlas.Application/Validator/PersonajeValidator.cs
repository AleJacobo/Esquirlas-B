using Esquirlas.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            RuleFor(x => x.Age);

            // continuar con el resto conforme a personaje configuration
                
        }
    }
}
