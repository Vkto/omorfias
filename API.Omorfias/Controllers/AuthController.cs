using System;
using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Handler;
using Microsoft.AspNetCore.Mvc;

namespace API.Omorfias.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
            catch (ErrorAction error)
            {
                var err = BadRequest(new { error.Text, error.Status });
                return err;
            }
        }

        [HttpPost]
        [Route("/register")]
        public ActionResult<AuthOutputDto> Register(UsersInputDto user)
        {

            try
            {
                AuthOutputDto tokenAcesso = _authAppService.Register(user);

                return Ok(tokenAcesso);
            }
            catch (ErrorAction error)
            {
                var err = BadRequest(new { error.Text, error.Status });
                return err;
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
