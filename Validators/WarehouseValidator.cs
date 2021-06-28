using FluentValidation;
using GameStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Validators
{
    public class WarehouseValidator : AbstractValidator<WarehouseDto>
    {
        public WarehouseValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-z ]*$");
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Length(9);
        }
    }
}
