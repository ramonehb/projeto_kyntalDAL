using System;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class Conexao   //CLASSE DE CONEXAO
    {
        //ATRIBUTOS
        protected SqlConnection conn; // DADOS DE ACESSO AO BANCO (connection string)
        protected SqlCommand cmd;     //COMANDOS (SCRIPTS) A SEREM EXECUTADOS
        protected SqlDataReader dr;    // RESULTADOS VINDO DO BANCO dr = DATA READER

        //METODOS 
        protected void AbrirConexao()
        {
            //TRY CATCH = TRATAMENTO DE ERROS   
            try
            {
                //conn = new SqlConnection(@"Data Source=DESKTOP-SCD19MS\SQLEXPRESS;Initial Catalog=KyntalProject;Integrated Security=True");
                conn = new SqlConnection(@"Data Source=DESKTOP-SCD19MS\SQLEXPRESS;Initial Catalog=KyntalProject;Integrated Security=True");    // INSTACIANDO OBJETO
                conn.Open();
            }
            catch (Exception erro) //SE APRESENTAR ERRO NO TRY VAI PARA O BLOCO CATCH
            {
                throw new Exception("ERRO AO TENTAR CONECTAR NO BANCO DE DADOS: " + erro.Message);     //PROPAGAR (RETORNAR) MENSAGEM DE ERRO
            }

        }

        protected void FecharConexao()
        {
            try
            {
                conn.Close();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO TENTAR FECHAR A CONEXÂO NO BANCO DE DADOS: " + erro.Message);
            }
        }
        
    }
}
