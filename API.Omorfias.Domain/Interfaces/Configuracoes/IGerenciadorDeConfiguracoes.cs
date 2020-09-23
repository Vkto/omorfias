using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Interfaces.Configuracoes
{
    public interface IGerenciadorDeConfiguracoes
    {
        T ObterValor<T>(string chave);
        void InserirRegistro(KeyValuePair<string, string> registro);
        void InserirRegistros(IEnumerable<KeyValuePair<string, string>> registros);
    }
}
