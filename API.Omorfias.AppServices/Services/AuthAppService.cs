using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using API.Omorfias.DataAgent.Interfaces;
using API.Omorfias.Operations.Interfaces;
using AutoMapper;
using System;

namespace API.Omorfias.AppServices.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IMapper _mapper;
        private readonly ICryptyService _cryptyService;
        private readonly IAuthRepository _authRepository;
        private readonly IDataAgentService _dataAgent;
        public AuthAppService(ICryptyService cryptyService, IMapper mapper, IAuthRepository authRepository, IDataAgentService dataAgent)
        {
            _cryptyService = cryptyService;
            _mapper = mapper;
            _authRepository = authRepository;
            _dataAgent = dataAgent;
        }
        public AuthOutputDto Login(AuthInputDto login)
        {

            string passwordHashed = _cryptyService.GenerateHashKey(login.Password);

            User userLoged = _authRepository.FindByEmail(login.Email);

            if (!passwordHashed.Equals(userLoged.Password))
            {
                throw new Exception(Messages.Messages.UsuarioNaoEncontrado.Replace("{0}", login.Email));
            }

            string token = _dataAgent.GenerateToken(userLoged);


            UsersOutputDto userOutput = _mapper.Map<UsersOutputDto>(userLoged);

            AuthOutputDto authOutput = new AuthOutputDto { Token = token, User = userOutput };
            return _mapper.Map<AuthOutputDto>(authOutput);

        }
    }
}
