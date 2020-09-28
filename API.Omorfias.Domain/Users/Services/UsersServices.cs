using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Base.Interfaces.Repositories;
using API.Omorfias.Domain.Base.Services;
using API.Omorfias.Domain.Interfaces.Services;
using API.Omorfias.Domain.Models;
using API.Omorfias.Domain.Users.Interfaces;

namespace API.Omorfias.Domain.Users.Services
{
    public class UsersServices : Service<User, string>, IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IHandler<DomainNotification> _notifications;

        public UsersServices(IRepository<User, string> repositoryUsers, IUsersRepository usersRepository, IHandler<DomainNotification> notifications) : base(repositoryUsers)
        {
            _notifications = notifications;
            _usersRepository = usersRepository;
        }
    }
}
