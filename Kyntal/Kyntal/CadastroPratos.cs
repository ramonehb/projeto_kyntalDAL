using Kyntal.Conexao;
using Kyntal.Modelos;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class CadastroPratos : Form 
    {
        private int Teste;

        private int ID;

        bool[] erro = new bool[3];
        public CadastroPratos()
        {
            InitializeComponent();
        }
        public CadastroPratos(int id , int teste)
        {
            InitializeComponent();
            Teste = teste;
            ID = id;
            txtID.Text = ID.ToString();
            
        }

        //METODO VOID LIMPAR
        public void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = string.Empty;
            lblNome.Text = "";
            lblIngre.Text = "";
            lblTamanho.Text = "";
            txtIngre.Text = string.Empty;
            cboTamanho.Text = "SELECIONE UMA OPÇÂO";

        }
        //BOTAO LIMPAR
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }


        public void VerificarCampos()
        {
            erro[0] = true;
            erro[1] = true;
            erro[2] = true;
            //NOME
            if (txtNome.Text.Trim() == "")
            {
                erro[0] = true;
                lblNome.Text = "NOME DO PRATO EM BRANCO";
            }
            else if (txtNome.Text.Trim().Length < 3)
            {
                erro[0] = true;
                lblNome.Text = "NOME DO PRATO MUITO CURTO";
            }
            else
            {
                erro[0] = false;
                lblNome.Text = "";
            }

            //
            if (txtIngre.Text.Trim() == "")
            {
                erro[1] = true;
                lblIngre.Text = "INGREDIENTES EM BRANCO";

            }
            else if (txtIngre.Text.Trim().Length < 5)
            {
                erro[1] = true;
                lblIngre.Text = "POUCOS CARACTERES";
            }
            else
            {
                lblIngre.Text = "";
                erro[1] = false;
            }

            //COMBO BOX TAMANHO
            if (cboTamanho.Text == "SELECIONE UMA OPÇÂO")
            {
                erro[2] = true;
                lblTamanho.Text = "SELECIONE UM TAMANHO";

            }
            else
            {
                lblTamanho.Text = "";
                erro[2] = false;
            }
        }
        //BOTAO FINALIZAR
        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            VerificarCampos();

            //VERIFICAÇÂO DO ARRAY
            if ((erro[0] == false) && (erro[1] == false) && (erro[2] == false))
            {
                Prato prato = new Prato();
                prato.Nome = txtNome.Text;
                prato.IDTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                prato.Ingredientes = Convert.ToString(txtIngre.Text);
                prato.FlStatus = 1;

                PratosDAL pratosDAL = new Kyntal.Conexao.PratosDAL();
                if (txtID.Text == "")
                {

                    pratosDAL.Cadastrar(prato);
                    MessageBox.Show("PRATO CADASTRADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {

                    prato.IDPrato = ID;
                    pratosDAL.Editar(prato);
                    MessageBox.Show("PRATO ALTERADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }

                TelaInicial inicial = new TelaInicial();
                inicial.ShowDialog();
            }
            else
            {
                txtNome.Focus();
            }
            

        }

        private void CadastroPratos_Load(object sender, EventArgs e)
        {
            //PREENCHENDO COMBO BOX COM INFORMAÇÔES DO BANCO
            TamanhoDAL tamanhoDAL = new TamanhoDAL();
            cboTamanho.DataSource = tamanhoDAL.Listar();
            cboTamanho.ValueMember = "IDTamanho";
            cboTamanho.DisplayMember = "Tamanhos";
            cboTamanho.Text = "SELECIONE UMA OPÇÂO";

            //NOME DO USUARIO LOGADO
            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;

            if (Teste != 1)
            {
                txtNome.Focus();
            }
            else
            {
                PratosDAL pratosDAL = new PratosDAL();
                Prato prato = pratosDAL.Selecionar(ID);

                txtNome.Text = prato.Nome;
                txtIngre.Text = prato.Ingredientes;
                cboTamanho.SelectedValue = prato.IDTamanho;
            }
            
        }
        //TELA INICIAL NO TOOTRIP
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListagemPratos listagem = new ListagemPratos();
            listagem.ShowDialog();
        }
    }
}
