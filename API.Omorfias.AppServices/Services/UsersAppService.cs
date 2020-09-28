using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Interfaces.Services;
using AutoMapper;

namespace API.Omorfias.AppServices.Services
{
    public class UsersAppService : AppService, IUsersAppService
    {
        private readonly IUsersServices _usersService;
        private readonly IMapper _mapper;

        public UsersAppService(IUsersServices usersService, IMapper mapper, IUnitOfWork unitOfWork, IHandler<DomainNotification> notifications) : base(unitOfWork, notifications)
        {
            this._usersService = usersService;
            this._mapper = mapper;
        }

        public UsersOutputDto ObterPorId(int id)
        {
            var arroz = this._usersService.ObterTodos();
            var retorno = this._usersService.ObterPorId(1);
            return _mapper.Map<UsersOutputDto>(retorno);
        }
    }
}
