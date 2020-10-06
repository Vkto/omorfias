using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.Domain.Models;
using AutoMapper;

namespace API.Omorfias.AppServices.Profiles.Omorfias
{
    public class OmorfiasProfile : Profile
    {
        public OmorfiasProfile()
        {
            CreateMap<UsersOutputDto, User>().ReverseMap();
            CreateMap<UsersInputDto, User>().ReverseMap();
            CreateMap<AuthInputDto, Login>().ReverseMap();
        }
    }
}
