using Kyntal.Conexao;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class PedidosProntos : Form
    {
        public PedidosProntos()
        {
            InitializeComponent();
        }

        private void PedidosProntos_Load(object sender, EventArgs e)
        {
            PedidooDAL pedidooDAL = new PedidooDAL();

            dataGridView1.DataSource = pedidooDAL.Listar();
        }
    }
}
