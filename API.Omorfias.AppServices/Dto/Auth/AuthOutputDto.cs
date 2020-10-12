using API.Omorfias.AppServices.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Dto.Login
{
    public class AuthOutputDto
    {
        public string Token { get; set; }
        public UsersOutputDto User { get; set; }
    }
}
