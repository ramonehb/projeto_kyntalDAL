using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class PratosDAL : Conexao
    {
        //CADASTRANDO UM PRATO
        public void Cadastrar(Prato prato)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("INSERT INTO PRATO (IDTamanho,Nome,Ingredientes,FlStatus) " +
                    "VALUES (@pIDTamanho,@pNome,@pIngredientes,@pFlStatus)", conn);
                cmd.Parameters.AddWithValue("@pIDTamanho", prato.IDTamanho);
                cmd.Parameters.AddWithValue("@pIngredientes", prato.Ingredientes);
                cmd.Parameters.AddWithValue("@pNome", prato.Nome);
                cmd.Parameters.AddWithValue("@pFlStatus", prato.FlStatus);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception ("ERRO AO CADASTRAR PRATO " + erro.Message) ;
            }
            finally
            {
                FecharConexao();
            }
        }
        //SELECIONANDO O PRATO
        public Prato Selecionar(int idPrato)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PRATO WHERE IDPrato = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idPrato);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Prato prato = new Prato();
                    prato.IDPrato = Convert.ToInt32(dr["IDPrato"]);
                    prato.IDTamanho = Convert.ToInt32(dr["IDTamanho"]);
                    prato.Ingredientes = Convert.ToString(dr["Ingredientes"]);
                    prato.Nome = Convert.ToString(dr["Nome"]);
                    prato.FlStatus = Convert.ToInt32(dr["FlStatus"]);
                    return prato;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR PRATO "+ erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //DELETAR UM PRATO 
        public void Deletar(int idPrato)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM PRATO WHERE IDPrato = @pIDPrato" , conn);
                cmd.Parameters.AddWithValue("@pIDPrato", idPrato);
                 cmd.ExecuteNonQuery();
  
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO DELETAR PRATO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //LISTANDO OS PRATOS
        public List<Prato> Listar()
        {
            List<Prato> pratos = new List<Prato>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PRATO", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Prato prato = new Prato();
                    prato.IDPrato = Convert.ToInt32(dr["IDPrato"]);
                    prato.IDTamanho = Convert.ToInt32(dr["IDTamanho"]);
                    prato.Nome = Convert.ToString(dr["Nome"]);
                    prato.Ingredientes = Convert.ToString(dr["ingredientes"]);
                    prato.FlStatus = Convert.ToInt32(dr["FlStatus"]);
                    pratos.Add(prato);
                }
                return pratos;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR PRATOS "+ erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Editar(Prato prato)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("UPDATE PRATO SET IDTamanho = @pIDTamanho , Nome = @pNome , Ingredientes = @pIngre , FlStatus = @pFl WHERE IDPrato = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", prato.IDPrato);
                cmd.Parameters.AddWithValue("@pIDTamanho", prato.IDTamanho);
                cmd.Parameters.AddWithValue("@pNome" ,prato.Nome);
                cmd.Parameters.AddWithValue("@pIngre", prato.Ingredientes);
                cmd.Parameters.AddWithValue("@pFl", prato.FlStatus);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO EDITAR PRATO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
