using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Web_CSharp1.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
