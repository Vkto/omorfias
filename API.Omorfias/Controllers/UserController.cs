using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Omorfias.Controllers
{

    [Route("[controller]")]
    public class UsersController : ApiBaseController
    {
        private readonly IUsersAppService _usersAppServices;
        public UsersController(IHandler<DomainNotification> notifications, IUsersAppService usersAppService) : base(notifications)
        {
            _usersAppServices = usersAppService;
        }
        [HttpGet]
        [Route("obter/{id}")]
        public DataResultsDto<UsersOutputDto> ObterUser(int id)
        {

            var retorno = ResponseResult(_usersAppServices.ObterPorId(id));

            return retorno;
        }
    }
}