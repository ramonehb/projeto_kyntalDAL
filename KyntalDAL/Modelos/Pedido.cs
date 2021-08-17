using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace KyntalDAL.Modelos
{
    public class Pedido
    {
        public int IDPedido;

        public int IDStatus;

        public int IDCliente;

        public int IDPrato;

        public string NomePedido;

        public int NumeroPedido;

        public DateTime HoraPedido;
    }
}
