using API.Omorfias.Data.Models;

namespace API.Omorfias.Data.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(int id);
        User FindUser(User userData);
        User FindByEmail(string email);
    }
}
