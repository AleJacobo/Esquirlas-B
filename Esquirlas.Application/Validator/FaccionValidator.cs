using Esquirlas.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
