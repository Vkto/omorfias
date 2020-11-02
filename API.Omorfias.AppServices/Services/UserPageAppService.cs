using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Interfaces.Services;
using API.Omorfias.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace API.Omorfias.AppServices.Services
{
    public class UserPageAppService : AppService, IUserPageAppService
    {
        private readonly IEnterpriseRepository _userPageRepository;
        private readonly IMapper _mapper;

        public UserPageAppService(IEnterpriseRepository userPageRepository, IMapper mapper, IUnitOfWork unitOfWork, IHandler<DomainNotification> notifications) : base(unitOfWork, notifications)
        {
            this._userPageRepository = userPageRepository;
            this._mapper = mapper;
        }

        public List<EnterpriseOutputDto> GetBetterRated()
        {
            try
            {
                var enterprises = _mapper.Map<List<EnterpriseOutputDto>>(this._userPageRepository.GetBetterRated());

                return enterprises;
            }
            catch (System.Exception ex)
            {
                this._notifications.Handle(new DomainNotification(null, ex.Message));

                return null;
            }
        }

    }
}
