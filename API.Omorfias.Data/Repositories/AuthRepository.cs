using API.Omorfias.Data.Base;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using System.Linq;

namespace API.Omorfias.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly OmorfiasContext _dbContext;
        public AuthRepository(OmorfiasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User FindByEmail(string email)
        {
            var user = _dbContext.User.Where(userDb => userDb.Email.Equals(email)).FirstOrDefault();
            return user;
        }
        public User FindUser(User userData)
        {
            var user = _dbContext.User.Where(userDb => userDb.Equals(userData)).FirstOrDefault();
            return user;
        }
        public User GetById(int id)
        {
            var user = _dbContext.User.Where(userDb => userDb.Id == id).FirstOrDefault();
            return user;
        }

        public User Register(User userData)
        {
            _dbContext.User.Add(userData);
            _dbContext.SaveChanges();

            return this.FindByEmail(userData.Email);
        }
    }
}
