using FluentValidation;
using GameStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Validators
{
    public class GameValidator : AbstractValidator<GameDto>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty();
            RuleFor(x => x.WarehouseId)
                .NotEmpty();
            RuleFor(x => x.AuthorId)
                .NotEmpty();
        }
    }
}
