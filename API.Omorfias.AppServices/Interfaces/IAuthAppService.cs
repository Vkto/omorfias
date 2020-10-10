using API.Omorfias.AppServices.Dto.Login;
using API.Omorfias.AppServices.Dto.Users;

namespace API.Omorfias.AppServices.Interfaces
{
    public interface IAuthAppService
    {
        AuthOutputDto Login(AuthInputDto login);
        AuthOutputDto Register(UsersInputDto user);
    }
}
