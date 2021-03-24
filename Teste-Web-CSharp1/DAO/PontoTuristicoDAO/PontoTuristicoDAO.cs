﻿using System;
using System.Collections.Generic;
using Teste_Web_CSharp1.Models;
using Teste_Web_CSharp1.DTO;
using Teste_Web_CSharp1.Util;
using System.Data.SqlClient;

namespace Teste_Web_CSharp1.DAO.PontoTuristicoDAO
{
    public class PontoTuristicoDAO : IPontoTuristicoDAO
    {
        public bool Cadastrar(PontoTuristico pontoTuristico)
        {          
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                //Comando SQL
                string sql = "INSERT INTO PontosTuristicos(nome, descricao, id_enderecoFK, data_inclusao) VALUES (@nome, @descricao, @endereco, @data_inclusao)";
                //Objeto do tipo comando
                SqlCommand command = new SqlCommand(sql, conn);
                //Adiciona so parâmetros ao comando SQL
                command.Parameters.Add(new SqlParameter("@nome", pontoTuristico.Nome));
                command.Parameters.Add(new SqlParameter("@descricao", pontoTuristico.Descricao));
                command.Parameters.Add(new SqlParameter("@endereco", pontoTuristico.Endereco.Id));
                command.Parameters.Add(new SqlParameter("@data_inclusao", pontoTuristico.Data_Inclusao.ToString("yyyy/MM/dd")));
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

        public List<PontoTuristicoDTO> Listar()
        {
            List<PontoTuristicoDTO> pontoTuristicos = new List<PontoTuristicoDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                //Comando SQL
                string sql = "SELECT p.id_pontoturistico, p.nome, p.descricao, e.localizacao, e.cidade, e.estado, p.data_inclusao FROM PontosTuristicos p, Enderecos e WHERE p.id_enderecoFK = e.id_endereco  ORDER BY p.data_inclusao ASC";
                //Abre a conexão
                conn.Open();
                //Objeto do tipo comando
                SqlCommand command = new SqlCommand(sql, conn);
                //Objeto para ler os resultados
                SqlDataReader reader = command.ExecuteReader();               
                //Enquanto houver registros
                while (reader.Read()) 
                {
                    PontoTuristicoDTO pontoTuristicoDTO = new PontoTuristicoDTO()
                    {
                        Id = Int32.Parse(reader["id_pontoturistico"].ToString()),
                        Nome = reader["nome"].ToString(),
                        Descricao = reader["descricao"].ToString(),
                        Localizacao = reader["localizacao"].ToString(),
                        Cidade = reader["cidade"].ToString(),
                        Estado = reader["estado"].ToString(),
                        Data_Inclusao = DateTime.Parse(reader["data_inclusao"].ToString())                      
                    };

                    pontoTuristicos.Add(pontoTuristicoDTO);
                }

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

            return pontoTuristicos;
        }
    }
}
