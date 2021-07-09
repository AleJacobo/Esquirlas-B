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
            //Los datos que esperemos Augusti nos de algun dia
        }
    }
}
