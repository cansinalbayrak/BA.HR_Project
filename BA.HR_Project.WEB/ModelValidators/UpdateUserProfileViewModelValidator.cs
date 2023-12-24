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
        .Must((model, photo) =>
        {
            if (model.Photo != null)
            {
                // Eğer yeni bir fotoğraf yüklenmişse uzantısını kontrol et
                var allowedExtensions = new[] { ".jpeg", ".jpg", ".png" };
                var fileExtension = Path.GetExtension(model.Photo.FileName).ToLowerInvariant();
                return allowedExtensions.Contains(fileExtension);
            }

            // Eğer yeni bir fotoğraf yüklenmemişse, ancak mevcut bir fotoğraf varsa geçerli kabul et
            return !string.IsNullOrWhiteSpace(model.ExistingPhotoPath);
        })
        .WithMessage("Photo must be in .jpeg, .jpg, or .png format");
        }
    }
}
