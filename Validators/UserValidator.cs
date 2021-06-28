using FluentValidation;
using GameStore.Dtos;
using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .Must(m => m.Contains("@"))
                .Must(c => c.Contains("."));
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
                
                
        }
    }
}
