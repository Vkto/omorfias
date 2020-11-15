using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.AppServices.Dto.Services;
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
        [Route("obtain/GetBetterRated")]
        public DataResultsDto<List<EnterpriseOutputDto>> GetBetterRated()
        {
            var retorno = ResponseResult(_userPageAppService.GetBetterRated());

            return retorno;

        }
        [HttpGet]
        [Route("obtain/NextToYou")]
        public DataResultsDto<List<EnterpriseOutputDto>> GetNextToYou()
        {
            var retorno = ResponseResult(_userPageAppService.GetNextToYou());

            return retorno;

        }
        [HttpGet]
        [Route("obtain/RecommendedForYou")]
        public DataResultsDto<List<ServicesOutputDto>> GetRecommendedForYou()
        {
            var retorno = ResponseResult(_userPageAppService.RecommendedForYou());

            return retorno;

        }

    }
}