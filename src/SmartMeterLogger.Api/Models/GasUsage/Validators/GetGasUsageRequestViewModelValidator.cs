using FluentValidation;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageRequestViewModelValidator : AbstractValidator<GetGasUsageRequestViewModel>
{
    public GetGasUsageRequestViewModelValidator()
    {
        RuleFor(model => model.SerialNumber)
            .NotEmpty()
            .Length(34)
            .Matches("^[0-9]*$");
        
        RuleFor(model => model.pageSize).GreaterThan(0);
    }
}