﻿using FluentValidation;

namespace RpiSmartMeter.Api.Models
{
    public class RegisterViewModelValidator : AbstractValidator<CreateTelegramViewModel>
    {
        public RegisterViewModelValidator()
        {
            
            // RuleFor(login => login.EmailAddress).NotEmpty();
            // RuleFor(login => login.Password).NotEmpty();
        }
    }
}