
using API.Omorfias.Data.Base;
using API.Omorfias.Domain.Users.Interfaces;

namespace API.Omorfias.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly OmorfiasContext _dbContext;

        public UsersRepository(OmorfiasContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
