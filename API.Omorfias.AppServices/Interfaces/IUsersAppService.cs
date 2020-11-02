using API.Omorfias.AppServices.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Interfaces
{
    public interface IUsersAppService
    {
        /// <summary>
        /// Retorna o usuário por ID
        /// <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        EnterpriseOutputDto ObterPorId(int id);
        IEnumerable<EnterpriseOutputDto> ObterTodos();
        /// <summary>
        /// Inclui usuário na base
        /// <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        UsersInputDto Incluir(UsersInputDto user);

        UsersInputDto Modificar(UsersInputDto usuario);

        UsersInputDto Excluir(UsersInputDto usuario);
    }
}
