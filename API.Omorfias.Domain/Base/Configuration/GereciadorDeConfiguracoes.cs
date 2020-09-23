using API.Omorfias.Domain.Interfaces.Configuracoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Base.Configuration
{
    public class GerenciadorDeConfiguracoes : IGerenciadorDeConfiguracoes
    {
        public void InserirRegistro(KeyValuePair<string, string> registro)
        {
            Configuration.InserirRegistro(registro);
        }

        public void InserirRegistros(IEnumerable<KeyValuePair<string, string>> registros)
        {
            Configuration.InserirRegistros(registros);
        }
        public T ObterValor<T>(string chave)
        {
            return Configuration.ObterValor<T>(chave);
        }
    }
}
