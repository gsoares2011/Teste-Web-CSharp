using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_Teste_Web_CSharp.DTO
{
    public class PontoTuristicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime Data_Inclusao { get; set; }
    }
}
