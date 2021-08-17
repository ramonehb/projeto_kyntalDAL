using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class ClienteDAL : Conexao
    {
        //corresponde ao C do CRUD = CREATE
        public void Cadastrar(Cliente cliente)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("INSERT CLIENTE (nomecompleto,numeromesa,email,telefone,assunto,nascimento)" +
                " VALUES (@pNome,@pMesa,@pEmail,@pTelefone,@pAssunto,@pNascimento)" ,conn);
                cmd.Parameters.AddWithValue("@pNome", cliente.Nome);
                cmd.Parameters.AddWithValue("@pMesa", cliente.NumeroMesa);
                cmd.Parameters.AddWithValue("@pEmail", cliente.Email);
                cmd.Parameters.AddWithValue("@pTelefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@pNascimento", cliente.Nascimento);
                cmd.Parameters.AddWithValue("@pAssunto", cliente.Assunto);
                //EXECUTAR COMANDO
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO CADASTRAR CLIENTE " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //corresponde ao U do CRUD = UPDATE
        public void Editar(Cliente cliente)
        {
            try
            {
                //ABRINDO A CONEXAO COM O BANCO DE DADOS
                AbrirConexao();
                //PASSANDO O COMANDO
                cmd = new SqlCommand("UPDATE CLIENTE SET nomecompleto = @pNome, numeromesa = @pMesa," +
                " email = @pEmail, telefone = @pTel, assunto = @pAssunto, nascimento = @pNascimento WHERE IDCLiente = @pID" , conn);
                //PASSANDO OS PARAMETROS DO COMANDO
                cmd.Parameters.AddWithValue("@pID", cliente.ID);
                cmd.Parameters.AddWithValue("@pNome", cliente.Nome);
                cmd.Parameters.AddWithValue("@pMesa", cliente.NumeroMesa);
                cmd.Parameters.AddWithValue("@pEmail", cliente.Email);
                cmd.Parameters.AddWithValue("@pTel", cliente.Telefone);
                cmd.Parameters.AddWithValue("@pAssunto", cliente.Assunto);
                cmd.Parameters.AddWithValue("@pNascimento", cliente.Nascimento);
                //F5 EXECUTANDO
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception ("ERRO AO EDITAR NO BANCO DE DADOS " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }

        }

        //corresponde ao D do CRUD = DELETE
        public void Deletar(int idCliente)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM CLIENTE WHERE IDCliente = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idCliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception ("ERRO AO EXCLUIR O CLIENTE" + erro.Message);
            }
        }

        //corresponde ao R do CRUD = SELECT
        public Cliente Selecionar(int idCliente)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM CLIENTE WHERE IDCliente = @pID" , conn);
                cmd.Parameters.AddWithValue("@pID", idCliente);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = Convert.ToInt32(dr["IDCliente"]);
                    cliente.Nome = Convert.ToString(dr["nomecompleto"]);
                    cliente.NumeroMesa = Convert.ToInt32(dr["numeromesa"]);
                    cliente.Email = Convert.ToString(dr["email"]);
                    cliente.Telefone = Convert.ToString(dr["telefone"]);
                    cliente.Assunto = Convert.ToString(dr["assunto"]);
                    cliente.Nascimento = Convert.ToDateTime(dr["nascimento"]);
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR O SERVIÇO" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //corresponde ao R do CRUD = LISTAR
        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM CLIENTE", conn);
                dr = cmd.ExecuteReader();
                //ENQUANTO TIVER RETORNANDO LINHAS NO BANCO ADD EM NO VETOR DE CLIENTES
                while (dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = Convert.ToInt32(dr["IDCliente"]);
                    cliente.Nome = Convert.ToString(dr["nomecompleto"]);
                    cliente.NumeroMesa = Convert.ToInt32(dr["numeromesa"]);
                    cliente.Email = Convert.ToString(dr["email"]);
                    cliente.Telefone = Convert.ToString(dr["telefone"]);
                    cliente.Nascimento = Convert.ToDateTime(dr["nascimento"]);
                    //ADICIONANDO UM OBJETO CLIENTE A LISTA DE OBJETOS
                    clientes.Add(cliente);
                }
                //RETORNANDO A LISTA 
                return clientes;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR CLIENTES" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
            
        }
    }
}
