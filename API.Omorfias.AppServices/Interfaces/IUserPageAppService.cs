using API.Omorfias.AppServices.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Interfaces
{
    public interface IUserPageAppService
    {
        List<EnterpriseOutputDto> GetBetterRated();
        List<EnterpriseOutputDto> GetNextToYou();
    }
}
