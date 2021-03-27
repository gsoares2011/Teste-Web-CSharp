using System;

namespace Teste_Web_CSharp1.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime Data_Inclusao { get; set; }
    }
}
