using FluentValidation;

namespace SmartMeterLogger.Api.Models;

public class CreateTelegramViewModelValidator : AbstractValidator<CreateTelegramViewModel>
{
    public CreateTelegramViewModelValidator()
    {
        // RuleFor(login => login.EmailAddress).NotEmpty();
        // RuleFor(login => login.Password).NotEmpty();
    }
}