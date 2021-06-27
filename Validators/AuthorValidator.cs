using FluentValidation;
using GameStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Z ]*$");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Z ]*$");  
        }
    }
}
