using System.Collections.Generic;
using Server_Teste_Web_CSharp.Builder;
using Server_Teste_Web_CSharp.DTO;
using Server_Teste_Web_CSharp.DAO.PontoTuristicoDAO;

namespace Server_Teste_Web_CSharp.Facade
{
    public class PontoTuristicoFacade
    {
        public string CadastrarPontoTuristico(string nome, string descricao, string localizacao, string cidade, string estado)
        {
            if (PontoTuristicoBuilder.NovoPontoTuristico().comNome(nome).comDescricao(descricao).comEndereco(localizacao).comCidade(cidade).comEstado(estado).comData().GravarEndereco().Construir().GravarPontoTuristico())
            {
                return "Novo Ponto Turístico Cadastrado com Sucesso!";
            }
            else {
                return "Erro durante o Cadastro do Novo Ponto Turístico!";
            }
        }

        public List<PontoTuristicoDTO> Listar()
        {
            return new PontoTuristicoDAO().Listar();
        }
    }
}
