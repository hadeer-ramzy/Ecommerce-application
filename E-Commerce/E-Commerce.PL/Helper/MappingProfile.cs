using AutoMapper;
using E_Commerce.DAL.Entities;
using E_Commerce.PL.Models;

namespace E_Commerce.PL.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

        }
    }
}
