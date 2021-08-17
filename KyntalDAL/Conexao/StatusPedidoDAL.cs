using Kyntal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Kyntal.Conexao
{
    public class StatusPedidoDAL : Conexao
    {
        public StatusPedido Selecionar(int id)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM STATUS_PEDIDO WHERE IDStatus = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", id);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    StatusPedido statusPedido = new StatusPedido();
                    statusPedido.IDStatus = (int)(dr["IDStatus"]);
                    statusPedido.Status = (string)(dr["StatusPedido"]);
                    return statusPedido;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR STATUS_PEDIDO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //LISTAR
        public List<StatusPedido> Listar()
        {
            List<StatusPedido> statusPedidos = new List<StatusPedido>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM STATUS_PEDIDO",conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StatusPedido statusPedido = new StatusPedido();
                    statusPedido.IDStatus = (int)(dr["IDStatus"]);
                    statusPedido.Status = (string)(dr["StatusPedido"]);
                    statusPedidos.Add(statusPedido);
                }
                return statusPedidos;
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
