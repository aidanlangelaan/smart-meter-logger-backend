using AutoMapper;
using RpiSmartMeter.Api.Models;
using RpiSmartMeter.Business.Models;

namespace RpiSmartMeter.Api.Configurations
{
    public class TelegramViewModelMapperProfile : Profile
    {
        public TelegramViewModelMapperProfile()
        {
            CreateViewModelMapping();
        }

        private void CreateViewModelMapping()
        {
            CreateMap<CreateTelegramViewModel, CreateTelegramDTO>();
            CreateMap<GetTelegramDTO, GetTelegramViewModel>();
        }
    }
}
