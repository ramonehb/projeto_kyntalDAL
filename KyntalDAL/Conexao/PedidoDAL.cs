using KyntalDAL.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyntalDAL.Conexao
{
    public class PedidoDAL : Conexao
    {
        //corresponde ao R do CRUD = SELECT
        public Pedido Select(int id)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PEDIDO WHERE IDPedido = @pID", conn);
                cmd.Parameters.AddWithValue("@pID", id);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.IDPedido = (int)(dr["IDPedido"]);
                    pedido.IDStatus = (int)(dr["IDStatus"]);
                    pedido.IDCliente = (int)(dr["IDCliente"]);
                    pedido.IDPrato = (int)(dr["IDPrato"]);
                    pedido.NomePedido = (string)(dr["NomePedido"]);
                    pedido.NumeroPedido = (int)(dr["NumeroPedido"]);
                    pedido.HoraPedido = (DateTime)(dr["HoraPedido"]);

                    return pedido;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO SELECIONAR PEDIDO " + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //corresponde ao D do CRUD = DELETE
        public void Delete(int id)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("DELETE FROM PEDIDO WHERE IDPedido = @pID",conn);
                cmd.Parameters.AddWithValue("@pID", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO DELETAR PEDIDO" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //corresponde ao R do CRUD = LISTAR
        public List<Pedido> Listar()
        {
            List<Pedido> pedidos = new List<Pedido>();
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM PEDIDO", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.IDPedido = (int)(dr["IDPedido"]);
                    pedido.IDStatus = (int)(dr["IDStatus"]);
                    pedido.IDCliente = (int)(dr["IDCliente"]);
                    pedido.IDPrato = (int)(dr["IDPrato"]);
                    pedido.NomePedido = (string)(dr["NomePedido"]);
                    pedido.NumeroPedido = (int)(dr["NumeroPedido"]);
                    pedido.HoraPedido = (DateTime)(dr["HoraPedido"]);
                    pedidos.Add(pedido);
                    
                }
                return pedidos;
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO LISTAR PEDIDO" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        //corresponde ao U do CRUD = UPDATE
        public void Update(Pedido pedido)
        {
            try
            {
                AbrirConexao();
                cmd = new SqlCommand("UPDATE PEDIDO SET IDStatus = @pIDStatus , IDPrato = @p@IDPrato , IDCliente = @pIDCliente ," +
                " IDPrato = @pIDPrato , NomePedido = @pNome , NumeroPedido = @Mesa , HoraPedido = @pHora", conn);
                cmd.Parameters.AddWithValue("@pIDStatus", pedido.IDStatus);
                cmd.Parameters.AddWithValue("@p@IDPrato", pedido.IDPrato);
                cmd.Parameters.AddWithValue("@pIDCliente", pedido.IDCliente);
                cmd.Parameters.AddWithValue("@pNome", pedido.NomePedido);
                cmd.Parameters.AddWithValue("@Mesa", pedido.NumeroPedido);
                cmd.Parameters.AddWithValue("@pHora", pedido.HoraPedido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception("ERRO AO ALTERAR O PEDIDO" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //INSERT
    }
}
