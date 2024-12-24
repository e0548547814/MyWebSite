using AutoMapper;
using dto;
using Entity;
namespace MyShop
{
    public class _Mapper : Profile
    {
        public _Mapper()
        {
            CreateMap<User, userDTO>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<User, RegisterUserDTO>();
            CreateMap<Product, productDTO>();
            CreateMap<Category, categoryDTO>();
            CreateMap<Order, orderDTO>();
            CreateMap<addOrderDTO, Order>();
            CreateMap<orderItemsDTO, OrderItem>();
            CreateMap<OrderItem, orderItemsDTO>();
        }
    }
}
