using AutoMapper;
using E_Comemerce_Web_DAL;
using E_commerce_Web_DTO;


namespace E_Commerce_Web_API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

        }
    }
}
