﻿using FluentValidation;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class UpdateUserProfileViewModelValidator:AbstractValidator<UpdateUserProfileViewModel>
    {
        public UpdateUserProfileViewModelValidator()
        {
            RuleFor(x => x.PhoneNumber)
           .NotEmpty().WithMessage("PhoneNumber must be provided")
           .Matches("^[0-9]{10}$").WithMessage("PhoneNumber must be a 10-digit numeric value");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Address must be provided");

            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage("Photo must be provided");

        }
    }
}
