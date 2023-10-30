using AutoMapper;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Configurations;

public class ViewModelMapperProfile : Profile
{
    public ViewModelMapperProfile()
    {
        CreateViewModelMapping();
    }

    private void CreateViewModelMapping()
    {
        CreateElectricityUsageMappings();

        CreateGasUsageMappings();

        CreateMeterUsageMappings();

        CreateTelegramMappings();
    }

    private void CreateElectricityUsageMappings()
    {
        CreateMap<GetElectricityUsageRequestViewModel, GetElectricityUsageRequestDTO>();
        CreateMap<GetElectricityUsageDTO, GetElectricityUsageViewModel>();
        CreateMap<GetElectricityUsageByDayDTO, GetElectricityUsageByDayViewModel>();
    }

    private void CreateGasUsageMappings()
    {
        CreateMap<GetGasUsageRequestViewModel, GetGasUsageRequestDTO>();
        CreateMap<GetGasUsageDTO, GetGasUsageViewModel>();
        CreateMap<GetGasUsageByDayDTO, GetGasUsageByDayViewModel>();
    }

    private void CreateMeterUsageMappings()
    {
        CreateMap<GetMeterDTO, GetMeterViewModel>();
    }

    private void CreateTelegramMappings()
    {
        CreateMap<CreateTelegramViewModel, CreateTelegramDTO>();
        CreateMap<GetTelegramDTO, GetTelegramViewModel>();
    }
}