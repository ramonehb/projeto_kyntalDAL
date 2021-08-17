using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Kyntal.Conexao
{
    public class TipoUsuarioDAL: Conexao
    {
        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> tipoUsuarios = new List<TipoUsuario>();

            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM TIPO_USUARIO", conn);
                dr = cmd.ExecuteReader();
                //ENQUANTO TIVER RETORNANDO LINHAS NO BANCO ADD EM NO VETOR DE CLIENTES
                while (dr.Read())
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.IDTipoUsuario = Convert.ToInt32(dr["IDTipoUsuario"]);
                    tipoUsuario.tipo = Convert.ToString(dr["tipo"]);
                    //ADICIONANDO UM OBJETO CLIENTE A LISTA DE OBJETOS
                    tipoUsuarios.Add(tipoUsuario);
                }
                //RETORNANDO A LISTA 
                return tipoUsuarios;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR TIPOS DE USUARIOS" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }

        }
    }
}
