using System;
using Server_Teste_Web_CSharp.Models;
using Server_Teste_Web_CSharp.Database;
using System.Data.SqlClient;

namespace Server_Teste_Web_CSharp.DAO.EnderecoDAO
{
    public class EnderecoDAO : IEnderecoDAO
    {
        public void Cadastrar(Endereco endereco)
        {

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                //Comando SQL
                string sql = "INSERT INTO Enderecos(localizacao, cidade, estado) output INSERTED.id_endereco VALUES (@endereco, @cidade, @estado)";
                //Objeto do tipo comando
                SqlCommand command = new SqlCommand(sql, conn);
                //Adiciona so parâmetros ao comando SQL
                command.Parameters.Add(new SqlParameter("@endereco", endereco.Localizacao));
                command.Parameters.Add(new SqlParameter("@cidade", endereco.Cidade));
                command.Parameters.Add(new SqlParameter("@estado", endereco.Estado));
                //Abre a conexão
                conn.Open();
                //Executa o comando e recupera o último Id inserido no banco
                endereco.Id = (int)command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                //Fecha a conexão
                conn.Close();
            }
        }
    }
}
