using Kyntal.Conexao;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class ListagemPratos : Form
    {
        public ListagemPratos()
        {
            InitializeComponent();
        }
        //BOTAO NOVO
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            CadastroPratos cadastroPratos = new CadastroPratos();
            cadastroPratos.ShowDialog();
        }
        //BOTAO VOLTAR PRA TELA INICIAL
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.ShowDialog();
        }
        //AO CARREGANDO O FORMULARIO
        private void ListagemPratos_Load(object sender, EventArgs e)
        {
            PratosDAL pratosDAL = new PratosDAL();

            dataGridViewPratos.DataSource = pratosDAL.Listar();
        }
        //BOTAO ALTERAR PRATO
        private void tsbAlterar_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                var IDSelecionado = dataGridViewPratos.CurrentRow.Cells["IDPrato"].Value;

                if (IDSelecionado != null)
                {
                    int teste = 1;
                    CadastroPratos cadastro = new CadastroPratos((int)IDSelecionado, teste);
                    cadastro.ShowDialog();
                }
            
            }
            else
            {
                MessageBox.Show("SEU USUÁRIO NÂO TEM PERMISSÂO PARA ALTERAR PRATOS", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //BOTAO DELETAR
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (Sessao.IDTipoUsuario == 1)
            {
                var IDSelecionado = (int)dataGridViewPratos.CurrentRow.Cells["IDPrato"].Value;
                if (IDSelecionado != 0)
                {
                    var pergunta = MessageBox.Show("TEM CERTEZA DA EXCLUSÂO ? ", "KYNTAL D'LURDIS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (pergunta == DialogResult.Yes)
                    {
                        PratosDAL pratosDAL = new PratosDAL();
                        pratosDAL.Deletar(IDSelecionado);
                        MessageBox.Show("PRATO DELETADO COM SUCESSO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaInicial telaInicial = new TelaInicial();
                        telaInicial.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("SEU USUARIO NAO TEM PERMISSAO PARA EXCLUIR PRATOS", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
