using Kyntal.Conexao;
using Kyntal.Modelos;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class CadastroUsuario : Form
    {
        private int IDUsuario;

        private int Teste;

        //ARRAY ERRO 
        bool[] erro = new bool[4];
        public CadastroUsuario()
        {
            InitializeComponent();
            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;
        }
        //POLIMORFISMO , OVERLOAD
        public CadastroUsuario(int idusuario , int teste)
        {
            InitializeComponent();
            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;
            IDUsuario = idusuario;
            txtID.Text = IDUsuario.ToString();
            Teste = teste;
        }



        //BOTAO LIMPAR
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }
        //PROCEDIMENTO LIMPAR
        public void limpar()
        {
            txtID.Text = "";
            txtEmailUser.Text = string.Empty;
            txtUsuarioNew.Text = string.Empty;
            txtSenhaNew.Text = string.Empty;
            txtSenhaOk.Text = string.Empty;
            cboTipoUsuario.Text = "SELECIONE UMA OPÇÂO";
            lblUser.Text = "";
            lblEmail.Text = "";
            lblSenhas.Text = "";
            lblNivel.Text = "";
            txtEmail.Focus();
        }
        
        public void VerificarCampos()
        {
            erro[0] = true;
            erro[1] = true;
            erro[2] = true;
            erro[3] = true;

            //EMAIL
            if (txtEmailUser.Text.Trim() == "")
            {
                lblEmail.Text = "EMAIL EM BRANCO";
                txtEmailUser.Text = string.Empty;
                txtEmailUser.Focus();
                erro[0] = true;
            }
            else if (txtEmailUser.Text.Length < 5)
            {
                lblEmail.Text = "EMAIL MUITO CURTO";
                txtEmailUser.Focus();
                erro[0] = true;
            }
            else
            {
                lblEmail.Text = "";
                txtUsuarioNew.Focus();
                erro[0] = false;
            }

            //NOME
            if (txtUsuarioNew.Text.Trim() == "")
            {
                lblUser.Text = "USUARIO EM BRANCO";
                txtUsuarioNew.Text = string.Empty;
                txtUsuarioNew.Focus();
                erro[1] = true;
            }
            else if (txtUsuarioNew.Text.Length < 3)
            {
                lblUser.Text = "USUARIO MUITO CURTO!";
                txtUsuarioNew.Focus();
                erro[1] = true;
            }
            else
            {
                lblUser.Text = "";
                txtSenhaNew.Focus();
                erro[1] = false;
            }


            //SENHA
            if (txtSenhaNew.Text.Trim() == "" || txtSenhaOk.Text.Trim() == "")
            {
                lblSenhas.Text = "SENHA EM BRANCO";
                txtSenhaNew.Focus();
                erro[2] = true;
            }
            else if (txtSenhaNew.Text != txtSenhaOk.Text)
            {
                lblSenhas.Text = "SENHAS DIFIRENTES";
                txtSenhaNew.Text = string.Empty;
                txtSenhaOk.Text = string.Empty;
                txtSenhaNew.Focus();
                erro[2] = true;
            }
            else if (txtSenhaOk.Text.Length < 3 || txtSenhaNew.Text.Length < 3)
            {
                lblSenhas.Text = "SENHA MUITO CURTA";
                txtSenhaNew.Text = string.Empty;
                txtSenhaOk.Text = string.Empty;
                txtSenhaNew.Focus();
                erro[2] = true;
            }
            else
            {
                lblSenhas.Text = "";
                erro[2] = false;

            }



            //NIVEL DE ACESSO ADMININSTRADOR OU ATENDENTE

            if (cboTipoUsuario.Text == "SELECIONE UMA OPÇÂO")
            {
                lblNivel.Text = "ESCOLHER OPÇÕES VALIDAS";
                erro[3] = true;
            }
            else
            {
                lblNivel.Text = "";
                erro[3] = false;
            }
        }


        //BOTAO FINALIZAR CADASTRO
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            VerificarCampos();

            //VERIFICAÇÂO DE ERRO
            if ((erro [0] == false) && (erro[1] == false) && (erro[2] == false) && (erro[3] == false))
            {

                
                //Obj usuario
                Usuario usuario = new Usuario();
                TipoUsuario tipoUsuario = new TipoUsuario();

                usuario.IDTipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                usuario.Nome = txtUsuarioNew.Text;
                usuario.Senha = txtSenhaOk.Text;
                usuario.Email = txtEmailUser.Text;
                usuario.FlStatus = 1;
                //CHAMANDO METODO CADASTRAR LOGIN
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                if (txtID.Text ==  "")
                {
                    usuarioDAL.CadastrarLogin(usuario);
                    //VOLTANDO PRA TELA DE LOGIN 
                    MessageBox.Show("USUÁRIO CADASTRADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuario.IDUsuario = Convert.ToInt32(txtID.Text);
                    usuarioDAL.Editar(usuario);
                    MessageBox.Show("USUÁRIO ALTERADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TelaInicial inicial = new TelaInicial();
                inicial.ShowDialog();


            }
            else
            {

                txtEmailUser.Focus();
                return;
            }
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            TipoUsuarioDAL tipoUsuarioDAL = new TipoUsuarioDAL();

            cboTipoUsuario.DataSource = tipoUsuarioDAL.Listar();
            cboTipoUsuario.ValueMember = "IDTipoUsuario";
            cboTipoUsuario.DisplayMember = "tipo";
            cboTipoUsuario.Text = "SELECIONE UMA OPÇÂO";


            if (Teste != 1)
            {
                txtEmail.Focus();
            }
            else
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuario = usuarioDAL.Selecionar(IDUsuario);

                txtEmailUser.Text = usuario.Email;
                txtUsuarioNew.Text = usuario.Nome;
                txtSenhaNew.Text = usuario.Senha;
                txtSenhaOk.Text = usuario.Senha;
                cboTipoUsuario.SelectedValue = usuario.IDTipoUsuario;

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListagemUsuario listagem = new ListagemUsuario();
            listagem.ShowDialog();
            this.Close();
        }
    }
}
