using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server_Teste_Web_CSharp.Models;
using Server_Teste_Web_CSharp.DAO.PontoTuristicoDAO;
using Server_Teste_Web_CSharp.DAO.EnderecoDAO;

namespace Server_Teste_Web_CSharp.Builder
{
    public class PontoTuristicoBuilder
    {
        private readonly Endereco endereco = new Endereco();
        private readonly IEnderecoDAO enderecoDAO = new EnderecoDAO();
        private readonly PontoTuristico pontoTuristico = new PontoTuristico();
        private readonly IPontoTuristicoDAO pontoTuristicoDAO = new PontoTuristicoDAO();     

        //Nova instância do builder
        public static PontoTuristicoBuilder NovoPontoTuristico()
        {
            return new PontoTuristicoBuilder();
        }

        //Get´s e Set´s
        public PontoTuristicoBuilder comNome(string nome)
        {
            pontoTuristico.Nome = nome;
            return this;
        }
        public PontoTuristicoBuilder comDescricao(string descricao)
        {
            pontoTuristico.Descricao = descricao;
            return this;
        }
        public PontoTuristicoBuilder comEndereco(string localizacao)
        {
            endereco.Localizacao = localizacao;
            return this;
        }
        public PontoTuristicoBuilder comCidade(string cidade)
        {
            endereco.Cidade = cidade;
            return this;
        }
        public PontoTuristicoBuilder comEstado(string estado)
        {
            endereco.Estado = estado;
            return this;
        }
        public PontoTuristicoBuilder comData()
        {
            pontoTuristico.Data_Inclusao = DateTime.Now;
            return this;
        }
        //Grava o endereço na base de dados
        public PontoTuristicoBuilder GravarEndereco()
        {
            enderecoDAO.Cadastrar(endereco);
            return this;
        }
        public PontoTuristicoBuilder Construir()
        {
            pontoTuristico.Endereco = endereco;
            return this;
        }       
        //Grava o ponto turístico na base de dados
        public bool GravarPontoTuristico()
        {
            return pontoTuristicoDAO.Cadastrar(pontoTuristico);
        }
    }
}
