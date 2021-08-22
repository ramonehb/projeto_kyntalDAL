using Kyntal.Conexao;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class ListagemUsuario : Form
    {
        public ListagemUsuario()
        {
            InitializeComponent();
        }
        //BOTAO VOLTAR PARA TELA INICIAL
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TelaInicial tela = new TelaInicial();
            tela.ShowDialog();
        }
        //BOTAO NOVO USUARIO
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            //SE O USUARIO FOR ADMINISTRADOR = 1 PODE CRIAR USUARIOS
            if (Sessao.IDTipoUsuario == 1)
            {
                CadastroUsuario cadastrousuario = new CadastroUsuario();
                cadastrousuario.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("SEU USUARIO NÂO TEM PERMISSÂO PARA CRIAR USUARIOS", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //ALTERAR USUARIO
        private void tsbAlterar_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                var IDSelecionado = dataGridViewUsuario.CurrentRow.Cells["IDUsuario"].Value;

                if (IDSelecionado != null)
                {
                    int teste = 1;
                    CadastroUsuario cadastroUsuario = new CadastroUsuario((int)IDSelecionado, teste);
                    cadastroUsuario.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("SEU USUARIO NÂO TEM PERMISSÂO PARA ALTERAR USUARIOS", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void ListagemUsuario_Load(object sender, EventArgs e)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            
            dataGridViewUsuario.DataSource = usuarioDAL.Listar();
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                var IDSelecionado = (int)dataGridViewUsuario.CurrentRow.Cells["IDUsuario"].Value;
                if (IDSelecionado != 0)
                {
                    var pergunta = MessageBox.Show("TEM CERTEZA DA EXCLUSÂO ? ", "KYNTAL D'LURDIS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (pergunta == DialogResult.Yes)
                    {
                        UsuarioDAL usuarioDAL = new UsuarioDAL();
                        usuarioDAL.Excluir(IDSelecionado);
                        MessageBox.Show("USUARIO DELETADO COM SUCESSO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaInicial telaInicial = new TelaInicial();
                        telaInicial.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("SEU USUARIO NAO TEM PERMISSAO PARA EXCLUIR USUARIOS !", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
