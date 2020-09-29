﻿using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Profiles.Omorfias
{
    public class OmorfiasProfile : Profile
    {
        public OmorfiasProfile()
        {
            CreateMap<UsersOutputDto, User>().ReverseMap();
            CreateMap<UsersInputDto, User>().ReverseMap();
        }
    }
}
