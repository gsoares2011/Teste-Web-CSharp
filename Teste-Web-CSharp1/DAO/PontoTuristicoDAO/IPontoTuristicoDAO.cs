using System.Collections.Generic;
using Teste_Web_CSharp1.Models;
using Teste_Web_CSharp1.DTO;

namespace Teste_Web_CSharp1.DAO.PontoTuristicoDAO
{
    public interface IPontoTuristicoDAO
    {
        bool Cadastrar(PontoTuristico pontoTuristico);
        List<PontoTuristicoDTO> Listar();
    }
}
