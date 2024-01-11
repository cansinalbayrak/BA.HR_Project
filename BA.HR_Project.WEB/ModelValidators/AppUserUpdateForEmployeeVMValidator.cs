using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserUpdateForEmployeeVMValidator : AbstractValidator<AppUserUpdateForEmployeeVM>
    {
        public AppUserUpdateForEmployeeVMValidator()
        {
   
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number must be provided")
                .Matches(@"^\d{10}$").WithMessage("Phone Number must contain 10 digits");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adress must be provided")
                .MaximumLength(80).WithMessage("Adress cannot be more than 80 characters");
            RuleFor(x => x.Photo)
             .Must((model, file) => file != null || model.UseExistingPhoto)
             .WithMessage("File must be provided or Choose This Photo")
             .When(x => !x.UseExistingPhoto);

            RuleFor(x => x.Photo)
                .Must(file => file == null || IsAllowedImageFile(file))
                .WithMessage("Invalid file format. Please choose a valid image file (jpeg , jpg or png).")
                .When(x => !x.UseExistingPhoto);

           

        }
        private bool IsAllowedImageFile(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
        }

    }
}
