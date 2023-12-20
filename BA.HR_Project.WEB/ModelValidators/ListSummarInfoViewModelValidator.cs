using FluentValidation;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class ListSummarInfoViewModelValidator : AbstractValidator<ListSummarInfoViewModel>
    {
        public ListSummarInfoViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("SurName must be provided");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be provided");
            RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format");
             

            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("IdentityNumber must be provided")
               .Matches("^[0-9]{10}$").WithMessage("PhoneNumber must be a 11-digit numeric value");
        }
    }
}
