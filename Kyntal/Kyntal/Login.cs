using Kyntal.Conexao;
using Kyntal.Modelos;
using System;
using System.Windows.Forms;

namespace Kyntal
{
    public partial class Login : Form 
    {
        public Login()
        {
            InitializeComponent();
        }

        bool[] erro = new bool[2];


        public void VerificarCampos()
        {
            erro[0] = true;
            erro[1] = true;
            if (txtUsuario.Text == "")
            {
                lblUser.Text = "PREENCHER USUÁRIO";
                txtUsuario.Focus();
                erro[0] = true;
            }
            else if (txtUsuario.Text.Length < 3)
            {
                lblUser.Text = "USUÁRIO COM POUCOS CARACTERES";
                txtUsuario.Focus();
                erro[0] = true;
            }
            else
            {
                lblUser.Text = "";
                erro[0] = false;
                txtSenha.Focus();
            }
            //SENHA

            if (txtSenha.Text == "")
            {
                lblSenha.Text = "PREENCHER SENHA";
                txtSenha.Focus();
                erro[1] = true;
            }
            else if (txtSenha.Text.Length < 3)
            {
                lblSenha.Text = "SENHA COM POUCOS CARACTERES ";
                txtSenha.Focus();
                erro[1] = true;
            }
            else
            {
                lblSenha.Text = "";
                erro[1] = false;
            }
            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                lblUser.Text = "PREENCHER USUÁRIO";
                lblSenha.Text = "PREENCHER SENHA";
                txtUsuario.Focus();
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VerificarCampos();
            if ((erro[0] == false) && (erro[1] == false))
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                //chamando o metodo VerificarLogin
                Usuario usuarioLogin = usuarioDAL.VerificarLogin(txtUsuario.Text, txtSenha.Text);

                if (usuarioLogin != null)
                {
     
                    //GRAVANDO OS DADOS DO LOGIN NA CLASSE SESSAO PARA FICAR VISIVEL EM QUALQUER LUGAR DO SISTEMA
                    Sessao.IDUsuarioLogado = usuarioLogin.IDUsuario;
                    Sessao.NomeUsuarioLogado = usuarioLogin.Nome;
                    Sessao.IDTipoUsuario = usuarioLogin.IDTipoUsuario;
                    //Instanciando a tela inicial para inicializar apos o preenchendo dos dados
                    TelaInicial telaInicial = new TelaInicial();
                    telaInicial.ShowDialog();
                    //FECHANDO A TELA DE LOGIN
                    this.Close(); 
                    
                    
                }
                else
                {
                    MessageBox.Show("USUÁRIO OU SENHA INVÁLIDO", "KYNTAL D'LURDIS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    limpar();
                }
            }

        }
        public void limpar()
        {
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            lblUser.Text = "";
            lblSenha.Text = "";
            txtUsuario.Focus();
            return;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//FECHA O PROGRAMA TODO / FECHAR APLICAÇÂO
        }

    }
}
