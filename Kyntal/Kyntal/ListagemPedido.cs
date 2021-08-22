using Kyntal.Conexao;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class ListagemPedido : Form
    {
        public ListagemPedido()
        {
            InitializeComponent();
        }

        private void ListagemPedido_Load(object sender, EventArgs e)
        {
            StatusPedidoDAL statusDAL = new StatusPedidoDAL();
            cboStatus.DataSource = statusDAL.Listar();
            cboStatus.ValueMember = "IDStatus";
            cboStatus.DisplayMember = "Status";
            cboStatus.Text = "SELECIONE O STATUS";
        }
        public void Limpar()
        {
            lblTamanho1.Text = "";
            lblPrato1.Text = "";
            lblPedido1.Text = "";
            lblHora1.Text = "";
            cboStatus.Text = "SELECIONE O STATUS";
        }
        private void btnFinalizar1_Click(object sender, EventArgs e)
        {

            switch (cboStatus.Text)
            {
                case "FINALIZADO":
                    lblResposta1.Text = "PEDIDO FINALIZADO COM SUCESSO";
                    Limpar();
                break;

                default:
                    MessageBox.Show("O STATUS DO PEDIDO AINDA NAO ESTA FINALIZADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResposta1.Text = "";
                    cboStatus.Focus();
                break;
            }          
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TelaInicial tela = new TelaInicial();
            tela.ShowDialog();
        }
    }
}
