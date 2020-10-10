using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.Data.Models;
using API.Omorfias.Domain.Handler;
using API.Omorfias.Domain.Models;
using AutoMapper;

namespace API.Omorfias.AppServices.Profiles.Omorfias
{
    public class OmorfiasProfile : Profile
    {
        public OmorfiasProfile()
        {
            CreateMap<UsersOutputDto, User>().ReverseMap();
            CreateMap<UsersInputDto, UserDomain>().ReverseMap();
            CreateMap<AuthInputDto, LoginDomain>().ReverseMap();
            CreateMap<ErrorOutPutDto, ErrorAction>().ReverseMap();
        }
    }
}
