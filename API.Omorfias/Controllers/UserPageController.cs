using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Controllers.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Omorfias.Controllers
{

    [Route("[controller]")]
    public class UserPageController : ApiBaseController
    {
        private readonly IUserPageAppService _userPageAppService;
        public UserPageController(IHandler<DomainNotification> notifications, IUserPageAppService userPageAppService) : base(notifications)
        {
            _userPageAppService = userPageAppService;
        }

        [HttpGet]
        [Route("obter/GetBetterRated")]
        public DataResultsDto<List<EnterpriseOutputDto>> GetBetterRated()
        {
            var retorno = ResponseResult(_userPageAppService.GetBetterRated());

            return retorno;

        }

    }
}