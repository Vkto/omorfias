using System;
using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Handler;
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
                ErrorAction error = new ErrorAction(1, er.Message);
                return Unauthorized(error);
            }
        }

        //    [Authorize]
        //    [HttpPost]
        //    [Route("/logout")]
        //    public ActionResult<dynamic> LogOut()
        //    {
        //        return User.FindFirst("lastName").Value;
        //    }
    }
}
