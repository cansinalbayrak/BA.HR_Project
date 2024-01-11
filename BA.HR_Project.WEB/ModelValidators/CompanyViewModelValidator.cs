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

            RuleFor(x => x.Photo)
                .Must(file => file == null || IsAllowedImageFile(file))
                .WithMessage("Invalid file format. Please choose a valid image file (jpeg or jpg).")
                .When(x => !x.UseExistingPhoto);

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone must be provided").Matches("^[0-9]{10}$").WithMessage("Phone must be 10 digits long and contain only numbers");
            RuleFor(x => x.TaxNo).NotEmpty().WithMessage("Phone must be provided").Matches("^[0-9]{10}$").WithMessage("Text no must be 10 digits long and contain only numbers");
            RuleFor(x => x.Mail).NotEmpty().NotEmpty().WithMessage("Phone must be provided").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.StartUpDate)
                .NotEmpty().WithMessage("StartUpDate must be provided")
                .Must(BeValidDate).WithMessage("StartUpDate must be before Current date");

            RuleFor(x => x.ContractStartDate)
                .NotEmpty().WithMessage("ContractStartDate must be provided")
                .Must((viewModel, contractStartDate) => contractStartDate < viewModel.ContractEndDate && contractStartDate > viewModel.StartUpDate)
                .WithMessage("ContractStartDate must be between StartUpDate and before ContractEndDate");

            RuleFor(x => x.ContractEndDate)
                .NotEmpty().WithMessage("ContractEndDate must be provided")
                .GreaterThan(x => x.ContractStartDate).WithMessage("ContractEndDate must be after ContractStartDate");

            RuleFor(x => x.MersisNo)
                .NotEmpty().WithMessage("MersisNo must be provided")
                .Must((viewModel, mersisNo) => ValidateMersisNo(viewModel.CompanyTitleEnum, mersisNo))
                .WithMessage("Invalid MersisNo for the selected CompanyTitle");

          
        }
        private bool IsAllowedImageFile(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg" , ".png" };
            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
        }
        private bool BeValidDate(DateTime date)
        {
            return date < DateTime.Now;
        }

        private bool ValidateMersisNo(CompanyTitle companyTitle, string mersisNo)
        {
            if (companyTitle == CompanyTitle.LTD || companyTitle == CompanyTitle.AS)
            {
               
                return mersisNo.StartsWith("0") &&
                       mersisNo.Length == 16 &&
                       (mersisNo.EndsWith("000") ||
                       mersisNo.EndsWith("013") ||
                       mersisNo.EndsWith("014") ||
                       mersisNo.EndsWith("015"));    
            }
            else if (companyTitle == CompanyTitle.KOOP)
            {
                return mersisNo.EndsWith("00015") || mersisNo.EndsWith("00019");
            }

            return false;
        }
    }
}

