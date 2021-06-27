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
                .LessThan(1000000000)
                .NotEqual(000000000);    
        }
    }
}
