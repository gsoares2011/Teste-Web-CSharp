using System;
using System.Collections.Generic;
using Teste_Web_CSharp1.Builder;
using Teste_Web_CSharp1.DTO;
using Teste_Web_CSharp1.DAO.PontoTuristicoDAO;

namespace Teste_Web_CSharp1.Facade
{
    public class PontoTuristicoFacade
    {
        public string CadastrarPontoTuristico(string nome, string descricao, string localizacao, string cidade, string estado)
        {
            if (PontoTuristicoBuilder.NovoPontoTuristico().comNome(nome).comDescricao(descricao).comEndereco(localizacao).comCidade(cidade).comEstado(estado).comData().Construir().GravarPontoTuristico())
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
