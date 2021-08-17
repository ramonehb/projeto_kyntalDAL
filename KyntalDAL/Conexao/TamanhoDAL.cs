using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Kyntal.Modelos;

namespace Kyntal.Conexao
{
    public class TamanhoDAL : Conexao
    {
        //CADASTRAR
        public void Cadastrar(Tamanho tamanho)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("INSERT INTO TAMANHO (Tamanho, Valor) VALUES (@pTamanho,@pValor)", conn);
                cmd.Parameters.AddWithValue("@pTamanho", tamanho.Tamanhos);
                cmd.Parameters.AddWithValue("@pValor", tamanho.Valor);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO CADASTRAR TAMANHO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //SELECIONAR
        public Tamanho Selecionar(int idTamanho)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELEC * FROM TAMANHO WHERE IDTamanho = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idTamanho);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Tamanho tamanho = new Tamanho();
                    tamanho.IDTamanho = Convert.ToInt32(dr["IDTamanho"]);
                    tamanho.Tamanhos = Convert.ToString(dr["Tamanho"]);
                    tamanho.Valor = Convert.ToDecimal(dr["Valor"]);
                    return tamanho;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR O TAMANHO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //DELETAR 
        public void Deletar(int idTamanho)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM TAMANHO WHERE IDTamanho = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idTamanho);
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO APAGAR O TAMANHO "+ erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //LISTAR TAMANHOS
        public List<Tamanho> Listar()
        {
            List<Tamanho> tamanhos = new List<Tamanho>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM TAMANHO", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tamanho tamanho = new Tamanho();
                    tamanho.IDTamanho = Convert.ToInt32(dr["IDTamanho"]);
                    tamanho.Tamanhos = Convert.ToString(dr["Tamanho"]);
                    tamanho.Valor = Convert.ToDecimal(dr["Valor"]);
                    tamanhos.Add(tamanho);
                }
                return tamanhos;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR TAMANHO " + erro.Message);
            }
        }
    }
}
