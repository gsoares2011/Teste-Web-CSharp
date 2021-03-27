using System;
using System.ComponentModel.DataAnnotations;

namespace Server_Teste_Web_CSharp.Models
{
    public class PontoTuristico
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime Data_Inclusao { get; set; }
    }
}
