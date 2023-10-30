using FluentValidation;

namespace SmartMeterLogger.Api.Models;

public class GetElectricityUsageRequestViewModelValidator : AbstractValidator<GetElectricityUsageRequestViewModel>
{
    public GetElectricityUsageRequestViewModelValidator()
    {
        // RuleFor(model => model.SerialNumber)
        //     .NotEmpty();
            // .Length(34)
            // .Matches("^[0-9]*$");
        
        RuleFor(model => model.PageSize).GreaterThan(0);
    }
}