using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            //CHAMAR OUTRA TELA DO PROJETO
            //1/ºInstancio um novo objeto do form
            //Login TelaLogin = new Login();
            //TelaLogin.ShowDialog();
 
           

            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;
            
        }
        //CADASTRAR CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {
            ListandoCliente listandoCliente = new ListandoCliente();
            listandoCliente.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                ListagemUsuario listagem = new ListagemUsuario();
                listagem.ShowDialog();
            }
            else
            {
                MessageBox.Show("SEU USUÁRIO NÂO TEM PERMISSÂO PARA VIZUALIZAR OS USUÁRIOS", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //SAIR DO USUARIO
        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
        //PRATOS
        private void button2_Click_1(object sender, EventArgs e)
        {
            ListagemPratos listagem = new ListagemPratos();
            listagem.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListagemPedido pedido = new ListagemPedido();
            pedido.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var perguntaFecharSistema = MessageBox.Show("TEM CERTEZA QUE DESEJA FINALIZAR O SISTEMA ?", "KYNTAL D'LURDIS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (perguntaFecharSistema == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
