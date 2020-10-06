using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Interfaces;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using API.Omorfias.DataAgent.Interfaces;
using API.Omorfias.Operations.Interfaces;
using AutoMapper;

namespace API.Omorfias.AppServices.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IMapper _mapper;
        private readonly ICryptyService _cryptyService;
        private readonly IUsersRepository _usersRepository;
        private readonly IDataAgentService _dataAgent;
        public AuthAppService(ICryptyService cryptyService, IMapper mapper, IUsersRepository usersRepository, IDataAgentService dataAgent)
        {
            _cryptyService = cryptyService;
            _mapper = mapper;
            _usersRepository = usersRepository;
            _dataAgent = dataAgent;
        }
        public AuthOutputDto Login(AuthInputDto login)
        {

            string passwordHashed = _cryptyService.GenerateHashKey(login.Password);

            User userLoged = _usersRepository.FindByEmail(login.Email);

            string token = _dataAgent.GenerateToken(userLoged);
            return _mapper.Map<AuthOutputDto>(new { Token = token, User = userLoged });

        }
    }
}
