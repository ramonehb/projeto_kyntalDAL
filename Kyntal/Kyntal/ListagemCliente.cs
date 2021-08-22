using Kyntal.Conexao;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class ListandoCliente : Form
    {
        public ListandoCliente()
        {
            InitializeComponent();
        }

        //NO CARREGAR DO FORM 
        private void Form1_Load(object sender, EventArgs e)
        {
            
            ClienteDAL clienteDAL = new ClienteDAL();
            //CHAMANDO A CLIENTEDALL LISTAR E COLOCANDO NO DATAGRIDVIEW
            dataGridViewCliente.DataSource = clienteDAL.Listar();

        }
        //BOTAO ALTERAR
        private void tsbAlterar_Click(object sender, EventArgs e)
        {
            //PEGANDO O ID DA LINHA CLICADA DO DATA GRID VIEW
            var IDSelecionado = dataGridViewCliente.CurrentRow.Cells["ID"].Value;

            if (IDSelecionado != null)
            {
                int teste = 1;
                CadastroCliente cadastroCliente = new CadastroCliente((int)IDSelecionado, teste);
                cadastroCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("SELECIONA UM CLIENTE PARA ALTERAR", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            CadastroCliente cadastro = new CadastroCliente();
            cadastro.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TelaInicial tela = new TelaInicial();
            tela.ShowDialog();
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                var IDSelecionado = (int)dataGridViewCliente.CurrentRow.Cells["ID"].Value;
                if (IDSelecionado != 0)
                {
                    var pergunta = MessageBox.Show("TEM CERTEZA DA EXCLUSÂO ? ", "KYNTAL D'LURDIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (pergunta == DialogResult.Yes)
                    {
                        ClienteDAL clienteDAL = new ClienteDAL();
                        clienteDAL.Deletar(IDSelecionado);
                        MessageBox.Show("CLIENTE DELETADO COM SUCESSO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaInicial telaInicial = new TelaInicial();
                        telaInicial.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("SEU USUÁRIO NÂO TEM PERMISSÂO PARA EXCLUIR CLIENTES", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
