using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using API.Omorfias.DataAgent.Interfaces;
using API.Omorfias.Domain.Handler;
using API.Omorfias.Operations.Interfaces;
using AutoMapper;
using System.Reflection;

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

            User userLoged = _authRepository.FindByUserOrEmail(login.Email);

            if (userLoged == null || !passwordHashed.Equals(userLoged.Password))
            {
                ErrorAction error = new ErrorAction(1, Messages.Messages.UsuarioNaoEncontrado.Replace("{0}", login.Email));
                throw error;
            }

            string token = _dataAgent.GenerateToken(userLoged);


            UsersOutputDto userOutput = _mapper.Map<UsersOutputDto>(userLoged);

            AuthOutputDto authOutput = new AuthOutputDto { Token = token, User = userOutput };
            return _mapper.Map<AuthOutputDto>(authOutput);

        }

        public AuthOutputDto Register(UsersInputDto user)
        {
            User userToRegister = new User();

            foreach (PropertyInfo propertyInfo in user.GetType().GetProperties())
            {
                string propertyName = propertyInfo.Name;
                string value = (string)user.GetType().GetProperty(propertyName).GetValue(user, null);

                if (value == "" || value == null)
                {
                    ErrorAction error = new ErrorAction(1, Messages.Messages.CampoObrigatorio.Replace("{0}", propertyName));
                    throw error;
                }

                userToRegister.GetType().GetProperty(propertyName).SetValue(userToRegister, value);
            }

            userToRegister.Password = _cryptyService.GenerateHashKey(user.Password);

            User userData = _authRepository.Register(userToRegister);

            AuthInputDto login = new AuthInputDto { Email = userData.Email, Password = user.Password };

            return this.Login(login);
        }
    }
}
