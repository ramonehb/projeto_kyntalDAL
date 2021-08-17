using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class UsuarioDAL: Conexao
    {
        public Usuario VerificarLogin(string login, string senha)
        {
            try
            {
                
                AbrirConexao();
                //comando a ser executados (query)
                cmd = new SqlCommand("SELECT * FROM USUARIO WHERE nome = @pLogin AND senha = @pSenha AND FlStatus = 1", conn);
                //passando os parametros para o comando
                cmd.Parameters.AddWithValue("@pLogin", login);
                cmd.Parameters.AddWithValue("@pSenha", senha);
                //executo o comando
                dr = cmd.ExecuteReader();

                if (dr.Read()) //retornou valor ?  HasRows = Se encontrou linhas
                {
                    Usuario usuario = new Usuario();
                    usuario.IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                    usuario.Nome = Convert.ToString(dr["nome"]);
                    usuario.Senha = Convert.ToString(dr["senha"]);
                    usuario.Email = Convert.ToString(dr["email"]);
                    usuario.IDTipoUsuario = Convert.ToInt32(dr["IDTipoUsuario"]);
                    usuario.FlStatus = Convert.ToInt32(dr["FlStatus"]);
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO TENTAR VERIFICAR LOGIN: " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        
        
        
        //METODOS CADASTRAR LOGIN 
        public void CadastrarLogin(Usuario usuario)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("INSERT USUARIO (IDTipoUsuario,nome,senha,email,flstatus) VALUES (@pIDTipoUsuario,@pNome,@pSenha,@pEmail,@pFlStatus)", conn);
                cmd.Parameters.AddWithValue("@pIDTipoUsuario", usuario.IDTipoUsuario);
                cmd.Parameters.AddWithValue("@pNome", usuario.Nome);
                cmd.Parameters.AddWithValue("@pSenha", usuario.Senha);
                cmd.Parameters.AddWithValue("@pEmail", usuario.Email);
                cmd.Parameters.AddWithValue("@pFlStatus", usuario.FlStatus);
                cmd.ExecuteNonQuery();


            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO TENTAR CADASTRAR USUARIO NO BANCO: " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT USUARIO.IDUsuario,USUARIO.IDTipoUsuario,USUARIO.nome,USUARIO.senha,USUARIO.email,USUARIO.FlStatus, TIPO_USUARIO.tipo FROM USUARIO inner join TIPO_USUARIO on USUARIO.IDTipoUsuario = TIPO_USUARIO.IDTipoUsuario", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                    usuario.IDTipoUsuario = Convert.ToInt32(dr["IDTipoUsuario"]);
                    usuario.Nome = Convert.ToString(dr["nome"]);
                    usuario.Senha = Convert.ToString(dr["senha"]);
                    usuario.TipoUsuario = Convert.ToString(dr["tipo"]);
                    usuario.Email = Convert.ToString(dr["email"]);
                    usuario.FlStatus = Convert.ToInt32(dr["FlStatus"]);

                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR USUARIO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }

            
        }

        public void Editar (Usuario usuario)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("UPDATE USUARIO SET IDTipoUsuario = @pTipoUsuario , nome = @pNome ," +
                    " senha = @pSenha, FlStatus = @pFlStatus WHERE IDUsuario = @pIDUsuario", conn);
                cmd.Parameters.AddWithValue("@pIDUsuario", usuario.IDUsuario);
                cmd.Parameters.AddWithValue("@pTipoUsuario", usuario.IDTipoUsuario);
                cmd.Parameters.AddWithValue("@pNome", usuario.Nome);
                cmd.Parameters.AddWithValue("@pSenha", usuario.Senha);
                cmd.Parameters.AddWithValue("@pEmail", usuario.Email);
                cmd.Parameters.AddWithValue("@pFlStatus", usuario.FlStatus);

                cmd.ExecuteNonQuery();

            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO EDITAR USUARIO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public Usuario Selecionar(int idUsuario)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM USUARIO WHERE IDUsuario = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idUsuario);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                    usuario.IDTipoUsuario = Convert.ToInt32(dr["IDTipoUsuario"]);
                    usuario.Nome = Convert.ToString(dr["nome"]);
                    usuario.Senha = Convert.ToString(dr["senha"]);
                    usuario.Email = Convert.ToString(dr["email"]);
                    usuario.FlStatus = Convert.ToInt32(dr["FlStatus"]);

                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR USUARIO " + erro.Message) ;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM USUARIO WHERE IDUsuario = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}
