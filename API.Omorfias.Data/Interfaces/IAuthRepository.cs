using API.Omorfias.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Data.Interfaces
{
    public interface IAuthRepository
    {
        User GetById(int id);
        User FindUser(User userData);
        User FindByEmail(string email);
        User Register(User userData);
    }
}
