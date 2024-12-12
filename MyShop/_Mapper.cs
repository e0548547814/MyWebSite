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
        }
    }
}
