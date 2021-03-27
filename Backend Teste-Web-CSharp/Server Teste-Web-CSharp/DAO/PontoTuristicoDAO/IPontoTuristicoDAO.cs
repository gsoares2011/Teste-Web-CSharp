using System.Collections.Generic;
using Server_Teste_Web_CSharp.Models;
using Server_Teste_Web_CSharp.DTO;

namespace Server_Teste_Web_CSharp.DAO.PontoTuristicoDAO
{
    public interface IPontoTuristicoDAO
    {
        bool Cadastrar(PontoTuristico pontoTuristico);
        List<PontoTuristicoDTO> Listar();
    }
}
