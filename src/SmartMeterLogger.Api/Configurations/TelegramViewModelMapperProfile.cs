using AutoMapper;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Configurations;

public class TelegramViewModelMapperProfile : Profile
{
    public TelegramViewModelMapperProfile()
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
        CreateMap<GetElectricityUsageDTO, GetElectricityUsageViewModel>();
    }

    private void CreateGasUsageMappings()
    {
        CreateMap<GetGasUsageDTO, GetGasUsageViewModel>();
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