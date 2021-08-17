using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class PedidooDAL : Conexao
    {
        //INSERT
        public void Insert(Pedidoo pedidoo)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("INSERT INTO PEDIDO (IDStatus,IDCliente,IDPrato,NumeroPedido,HoraPedido) " +
                    "VALUES (@pStatus , @pCliente , @pPrato , @pNumeroPedido , @pHoraPedido)", conn);
                cmd.Parameters.AddWithValue("@pStatus", pedidoo.IDStatus);
                cmd.Parameters.AddWithValue("@pCliente", pedidoo.IDCliente);
                cmd.Parameters.AddWithValue("@pPrato", pedidoo.IDPrato);
                cmd.Parameters.AddWithValue("@pNumeroPedido", pedidoo.NumeroPedido);
                cmd.Parameters.AddWithValue("@pHoraPedido", pedidoo.HoraPedido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro )
            {

                throw new Exception("ERRO AO CADASTRAR PEDIDO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //SELECT
        public Pedidoo Select (int idPedido)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PEDIDO WHERE IDPedido = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idPedido);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Pedidoo pedidoo = new Pedidoo();
                    pedidoo.IDPedido = (int)(dr["IDPedido"]);
                    pedidoo.IDStatus = (int)(dr["IDStatus"]);
                    pedidoo.IDPrato = (int)(dr["IDPrato"]);
                    pedidoo.IDCliente = (int)(dr["IDCliente"]);
                    pedidoo.NumeroPedido = (int)(dr["NumeroPedido"]);
                    pedidoo.HoraPedido = (DateTime)(dr["HoraPedido"]);
                    return pedidoo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR PEDIDO" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //DELETE
        public void Delete(int idPedido)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM PEDIDO WHERE IDPedido = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", idPedido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO DELETAR " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //LISTAGEM  
        public List<Pedidoo> Listar ()
        {
            List<Pedidoo> pedidoos = new List<Pedidoo>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PEDIDO", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pedidoo pedidoo = new Pedidoo();
                    pedidoo.IDCliente = (int)(dr["IDPedido"]);
                    pedidoo.IDStatus = (int)(dr["IDStatus"]);
                    pedidoo.IDCliente = (int)(dr["IDCliente"]);
                    pedidoo.IDPedido = (int)(dr["IDPedido"]);
                    pedidoo.IDPrato = (int)(dr["IDPrato"]);
                    pedidoo.NumeroPedido = (int)(dr["NumeroPedido"]);
                    pedidoo.HoraPedido = Convert.ToDateTime(dr["HoraPedido"]);
                    pedidoos.Add(pedidoo);
                }
                return pedidoos;

            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

    }
}
