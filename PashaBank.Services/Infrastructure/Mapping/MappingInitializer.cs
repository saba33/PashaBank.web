using AutoMapper;
using PashaBank.Core.Models;
using PashaBank.Core.Models.Enums;
using PashaBank.Services.Models.RequestModels;
using PashaBank.Services.Models.RequestModels.Product;
using PashaBank.Services.Models.RequestModels.Sales;

namespace PashaBank.Services.Infrastructure.Mapping
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<SaleDto, Sale>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
