using API.Omorfias.AppServices.Dto.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Interfaces
{
    public interface IAuthAppService
    {
        AuthOutputDto Login(AuthInputDto login);
    }
}
