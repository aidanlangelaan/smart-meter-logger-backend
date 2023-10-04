using AutoMapper;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data.Entities;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.configurations;

public class EntityMapperProfile : Profile
{
    public EntityMapperProfile()
    {
        CreateEntityMapping();
    }

    private void CreateEntityMapping()
    {
        CreateElectricityUsageMappings();

        CreateGasUsageMappings();

        CreateMeterUsageMappings();

        CreateTelegramMappings();
    }

    private void CreateElectricityUsageMappings()
    {
        CreateMap<ElectricityUsage, GetElectricityUsageDTO>();
    }
    
    private void CreateGasUsageMappings()
    {
        CreateMap<GasUsage, GetGasUsageDTO>();
    }
    
    private void CreateMeterUsageMappings()
    {
        CreateMap<Meter, GetMeterDTO>();
    }
    
    private void CreateTelegramMappings()
    {
        // TODO: mapping for individual meter types (mbus)?

        // mapping specifically for electricity meter
        CreateMap<CreateTelegramDTO, Meter>()
            .AddTransform<string>(s => string.IsNullOrEmpty(s) ? null : s)
            .ForMember(dest => dest.SerialNumber,
                opt => opt.MapFrom(src => src.MeterId))
            .AfterMap((src, dest) => dest.DeviceType = MeterType.Electricity);
        
        CreateMap<CreateTelegramDTO, ElectricityMeter>()
            .AddTransform<string>(s => string.IsNullOrEmpty(s) ? null : s)
            .ForMember(dest => dest.MeterId, opt => opt.Ignore());

        CreateMap<CreateTelegramDTO, ElectricityUsage>()
            .AddTransform<string>(s => string.IsNullOrEmpty(s) ? null : s)
            .ForMember(dest => dest.MeterId, opt => opt.Ignore());
    }
}