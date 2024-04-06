using asp_net_mvc_spd221.Data.Entities;
using asp_net_mvc_spd221.Models;
using AutoMapper;

namespace asp_net_mvc_spd221
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductFormModel, Product>().ReverseMap();
            CreateMap<Product, ProductCartModel>();
        }
    }
}
