using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Omorfias.Controllers
{

    [Route("[controller]")]
    public class UsersController : ApiBaseController
    {
        public UsersController(IHandler<DomainNotification> notifications) : base(notifications)
        {
  
        }
        [HttpGet]
        public int ObterUser(int idd)
        {
            var retorno = 1;

            return retorno;
        }
    }
}