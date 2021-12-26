using AutoMapper;
using RpiSmartMeter.Api.Models;
using RpiSmartMeter.Business.Models;

namespace RpiSmartMeter.Api.Configurations
{
    public class UsageViewModelMapperProfile : Profile
    {
        public UsageViewModelMapperProfile()
        {
            CreateViewModelMapping();
        }

        private void CreateViewModelMapping()
        {
            CreateMap<CreateUsageViewModel, CreateUsageDTO>();

            CreateMap<GetUsageDTO, GetUsageViewModel>();
        }
    }
}
