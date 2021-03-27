using System.ComponentModel.DataAnnotations;

namespace Server_Teste_Web_CSharp.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
