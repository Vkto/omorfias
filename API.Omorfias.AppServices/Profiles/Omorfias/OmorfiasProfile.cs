﻿using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Services;
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
            CreateMap<EnterpriseOutputDto, User>().ReverseMap();
            CreateMap<UsersInputDto, UserDomain>().ReverseMap();
            CreateMap<AuthInputDto, LoginDomain>().ReverseMap();
            CreateMap<ErrorOutPutDto, ErrorAction>().ReverseMap();
            CreateMap<EnterpriseOutputDto, Enterprise>().ReverseMap();
            CreateMap<ServicesOutputDto, Data.Models.Services>().ReverseMap();
            
        }
    }
}
