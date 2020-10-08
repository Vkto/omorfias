using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public DataResultsDto<UsersOutputDto> ObterUser(int id)
        {
            
            var retorno = ResponseResult(_usersAppServices.ObterPorId(id));

            return retorno;
        }
        [HttpGet]
        [Route("obter")]
        public DataResultsDto<UsersOutputDto> ObterTodos()
        {

            var retorno = ResponseResult(_usersAppServices.ObterTodos());

            return retorno;
        }
        [HttpPost]
        [Route("incluir")]
        public DataResultsDto<UsersInputDto> Incluir(UsersInputDto usuario)
        {
           return ResponseResult(_usersAppServices.Incluir(usuario));

        }
        [HttpPost]
        [Route("modificar")]
        public DataResultsDto<UsersInputDto> Modificar(UsersInputDto usuario)
        {
            return ResponseResult(_usersAppServices.Modificar(usuario));

        }
        [HttpDelete]
        [Route("excluir")]
        public DataResultsDto<UsersInputDto> Excluir(UsersInputDto usuario)
        {
            return ResponseResult(_usersAppServices.Excluir(usuario));

        }
    }
}