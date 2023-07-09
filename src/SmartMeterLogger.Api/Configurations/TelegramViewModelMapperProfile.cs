using AutoMapper;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Configurations
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
