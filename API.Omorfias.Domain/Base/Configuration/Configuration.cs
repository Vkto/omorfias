using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Base.Configuration
{
    public static class Configuration
    {
        private static Dictionary<string, string> _tabelaValores = new Dictionary<string, string>();

        public static T ObterValor<T>(string chave)
        {
            if (_tabelaValores.ContainsKey(chave))
            {
                return (T)Convert.ChangeType(_tabelaValores[chave], typeof(T));
            }
            return default(T);
        }

        public static void InserirRegistro(KeyValuePair<string, string> registro)
        {
            _tabelaValores[registro.Key] = registro.Value;
        }

        public static void InserirRegistros(IEnumerable<KeyValuePair<string, string>> registros)
        {
            foreach (KeyValuePair<string, string> _registro in registros)
            {
                _tabelaValores.Add(_registro.Key, _registro.Value);
            }
        }

        public static void LimparRegistros()
        {
            _tabelaValores.Clear();
        }
    }
}
