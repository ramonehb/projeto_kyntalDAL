using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kyntal.Modelos
{
    public class Pedidoo 
    {
        public int IDPedido { get; set; }

        public int IDStatus { get; set; }

        public int IDCliente { get; set; }

        public int IDPrato { get; set; }

        public int NumeroPedido { get; set; }

        public DateTime HoraPedido { get; set; }
    }
}
