using BA.HR_Project.Domain.Enums;
using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
	public class CompanyViewModelValidator: AbstractValidator<CompanyViewModel>
	{
        public CompanyViewModelValidator()
        {
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
			RuleFor(x => x.LogoPath).NotEmpty().WithMessage("LogoPath must be provided");

			RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone must be provided").Matches("^[0-9]{10}$").WithMessage("Phone must be 10 digits long and contain only numbers");
            RuleFor(x => x.TaxNo).NotEmpty().WithMessage("Phone must be provided").Matches("^[0-9]{10}$").WithMessage("Text no must be 10 digits long and contain only numbers");
            RuleFor(x => x.Mail).NotEmpty().NotEmpty().WithMessage("Phone must be provided").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.StartUpDate).NotEmpty().WithMessage("StartUpDate must be provided");
            RuleFor(x => x.ContractStartDate).NotEmpty().WithMessage("ContractStartDate must be provided")
                .LessThan(x => x.ContractEndDate).WithMessage("ContractStartDate must be before ContractEndDate");

            RuleFor(x => x.MersisNo)
                   .NotEmpty().WithMessage("MersisNo must be provided")
                   .Must((viewModel, mersisNo) => ValidateMersisNo(viewModel.CompanyTitleEnum, mersisNo))
                   .WithMessage("Invalid MersisNo for the selected CompanyTitle");
        }

        private bool ValidateMersisNo(CompanyTitle companyTitle, string mersisNo)
        {
            if (companyTitle == CompanyTitle.LTD || companyTitle == CompanyTitle.AS)
            {
               
                return mersisNo.StartsWith("0") &&
                       mersisNo.Length == 16 &&
                       mersisNo.EndsWith("000") &&
                       char.IsDigit(mersisNo[15]) && 
                       char.IsDigit(mersisNo[14]) && 
                       char.IsDigit(mersisNo[13]);    
            }
            else if (companyTitle == CompanyTitle.KOOP)
            {
                return mersisNo.EndsWith("00015") || mersisNo.EndsWith("00019");
            }

            return false;
        }
    }
}
}
