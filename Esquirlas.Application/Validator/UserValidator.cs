using Esquirlas.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
           
            
            
        //Los datos que esperemos Augusti nos de algun dia

        //ACA SE LOS CARGUEEEEE
        }
    }
}
