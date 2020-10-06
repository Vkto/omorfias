using System;
using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Omorfias.Controllers
{
    [Route("[controller]")]
    public class AuthController : ApiBaseController
    {
        private readonly IAuthAppService _authAppService;
        public AuthController(IHandler<DomainNotification> notifications, IAuthAppService authAppService) : base(notifications)
        {
            this._authAppService = authAppService;
        }

        [HttpPost]
        public ActionResult<AuthOutputDto> Login(AuthInputDto login)
        {

            try
            {
                AuthOutputDto tokenAcesso = _authAppService.Login(login);

                return Ok(tokenAcesso);
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
