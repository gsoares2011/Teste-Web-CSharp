using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Web_CSharp1.Models;
using System.Data.SqlClient;

namespace Teste_Web_CSharp1.DAO.PontoTuristicoDAO
{
    public class PontoTuristicoDAO : IPontoTuristicoDAO
    {
        public bool Cadastrar(PontoTuristico pontoTuristico)
        {          
            bool aux = false;

            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connection);

            try
            {
                //Comando SQL
                string sql = "INSERT INTO PontosTuristicos(nome, descricao, localizacao, cidade, estado) VALUES (@nome, @descricao, @endereco, @cidade, @estado)";
                //Objeto do tipo comando
                SqlCommand command = new SqlCommand(sql, conn);
                //Adiciona so parâmetros ao comando SQL
                command.Parameters.Add(new SqlParameter("@nome", pontoTuristico.Nome));
                command.Parameters.Add(new SqlParameter("@descricao", pontoTuristico.Descricao));
                command.Parameters.Add(new SqlParameter("@endereco", pontoTuristico.Endereco.Localizacao));
                command.Parameters.Add(new SqlParameter("@cidade", pontoTuristico.Endereco.Cidade));
                command.Parameters.Add(new SqlParameter("@estado", pontoTuristico.Endereco.Estado));
                //Abre a conexão
                conn.Open();
                //Executa o comando
                command.ExecuteNonQuery();

                aux = true;
            } 
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                //Fecha a conexão
                conn.Close();
            }
            return aux;
        }
    }
}
