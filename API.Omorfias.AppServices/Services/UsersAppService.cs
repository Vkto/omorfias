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
    public class UsersAppService : AppService, IUsersAppService
    {
        private readonly IUsersServices _usersService;
        private readonly IMapper _mapper;

        public UsersAppService(IUsersServices usersService, IMapper mapper, IUnitOfWork unitOfWork, IHandler<DomainNotification> notifications) : base(unitOfWork, notifications)
        {
            this._usersService = usersService;
            this._mapper = mapper;
        }

        public EnterpriseOutputDto ObterPorId(int id)
        {
            var retorno = this._usersService.ObterPorId(id);

            if (retorno == null)
            {
                _notifications.Handle(new DomainNotification(string.Empty, string.Format(Messages.Messages.UsuarioNaoEncontrado, id.ToString())));
            }

            return _mapper.Map<EnterpriseOutputDto>(retorno);
        }
        public IEnumerable<EnterpriseOutputDto> ObterTodos()
        {
            var retorno = this._usersService.ObterTodos();

            if (!retorno.Any())
            {
                _notifications.Handle(new DomainNotification(string.Empty, string.Format(Messages.Messages.UsuarioNaoEncontrado)));
            }

            return _mapper.Map<IEnumerable<EnterpriseOutputDto>>(retorno);
        }
        public UsersInputDto Incluir(UsersInputDto usuario)
        {
            try
            {
                this._usersService.Adicionar(_mapper.Map<UserDomain>(usuario));
                Commit();
            }
            catch (System.Exception ex)
            {
                _notifications.Handle(new DomainNotification(string.Empty, ex.Message));
            }


            return usuario;
        }
        public UsersInputDto Modificar(UsersInputDto usuario)
        {
            try
            {
                this._usersService.Modificar(_mapper.Map<UserDomain>(usuario));
                Commit();
            }
            catch (System.Exception ex)
            {
                _notifications.Handle(new DomainNotification(string.Empty, ex.Message));
            }

            return usuario;
        }
        public UsersInputDto Excluir(UsersInputDto usuario)
        {
            try
            {
                this._usersService.Remover(_mapper.Map<UserDomain>(usuario));
                Commit();
            }
            catch (System.Exception ex)
            {
                _notifications.Handle(new DomainNotification(string.Empty, ex.Message));
            }

            return usuario;
        }
    }
}
