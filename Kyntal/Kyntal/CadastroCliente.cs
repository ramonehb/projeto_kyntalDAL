using System;
using System.Windows.Forms;
using Kyntal.Conexao;
using Kyntal.Modelos;
using KyntalAPI.Controllers;

namespace Kyntal
{
    public partial class CadastroCliente : Form 
    {

        //ATRIBUTO DE ORIENTAÇÂO DO CODIGO
        private int IDCliente;
        //VERIFICAR SE É CADASTRO NOVO OU ALTERAÇÃO
        private int Teste;
        int mesa;
        public CadastroCliente()
        {
            InitializeComponent();
            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;
        }


        //POLIFORMISMO 
        public CadastroCliente(int idcliente , int teste)
        {
            InitializeComponent();
            lblUsuarioLogado.Text = Sessao.NomeUsuarioLogado;
            IDCliente = idcliente;
            txtID.Text = IDCliente.ToString();
            Teste = teste;
        }

       

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }


        public void limpar()
        {
            txtID.Text = "";
            txtNome.Text = string.Empty;
            txtNome.Focus();
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            lblUser.Text = "";
            lblEmail.Text = "";
            lblTelefone.Text = "";
            lblMesa.Text = "";
            lblData.Text = "";
            dateTimeNascimento.Value = new DateTime(2020, 1, 1, 10, 10, 10);

        }

        bool[] erro = new bool[6];
        public void VerificarCampos()
        {
            
            erro[0] = true;
            erro[1] = true;
            erro[2] = true;
            erro[3] = true;
            erro[4] = true;
            //NOME
            if (txtNome.Text == "")
            {
                lblUser.Text = "NOME EM BRANCO";
                txtNome.Focus();
                erro[0] = true;
            }
            else if (txtNome.Text.Length < 5)
            {
                lblUser.Text = "NOME MUITO CURTO";
                txtNome.Focus();
                erro[0] = true;
            }
            else
            {
                lblUser.Text = "";
                erro[0] = false;
                txtEmail.Focus();
            }
            //EMAIL

            if (txtEmail.Text == "")
            {
                lblEmail.Text = "EMAIL EM BRANCO";
                txtEmail.Focus();
                erro[1] = true;
            }
            else if (txtEmail.Text.Length < 5)
            {
                lblEmail.Text = "EMAIL MUITO CURTO";
                txtEmail.Focus();
                erro[1] = true;
            }
            else
            {
                lblEmail.Text = "";
                erro[1] = false;
            }

            //TELEFONE
            if (txtTelefone.Text.Replace("(  )       - ", "") == "")
            {
                lblTelefone.Text = "TELEFONE EM BRANCO";
                txtTelefone.Focus();
                erro[2] = true;
            }
            else if (txtTelefone.Text.Length < 17)
            {
                lblTelefone.Text = "TELEFONE MUITO CURTO";
                txtTelefone.Focus();
                erro[2] = true;
            }
            else
            {
                lblTelefone.Text = "";
                erro[2] = false;
            }

            //NUMERO DA MESA
            if (txtNumeroMesa.Text == "")
            {
                lblMesa.Text = "NUMERO DA MESA EM BRANCO";
                txtNumeroMesa.Focus();
                erro[3] = true;

            }
            else if (!int.TryParse(txtNumeroMesa.Text, out mesa))
            {
                lblMesa.Text = "SOMENTE NUMEROS SÂO VALIDOS";
                txtNumeroMesa.Focus();
                erro[3] = true;
            }
            else
            {
                lblMesa.Text = "";
                erro[3] = false;
            }

            var date = new DateTime(2020, 1, 1, 10, 10, 10);
            //DATA
            if (dateTimeNascimento.Value == date)
            {
                lblData.Text = "SELECIONE A DATA DE NASCIMENTO";
                erro[4] = true;
            }
            else
            {
                lblData.Text = "";
                erro[4] = false;
            }
        }


        //BOTAO FINALIZAR
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            bool auth = false;
            VerificarCampos();          

            //Validando todas as posições do Array Erro
            for (int c = 0; c < erro.Length; c++)
            {
                if (erro[c].Equals(true))
                {
                    auth = true;
                    break;
                } else {
                    auth = false;
                }
            }
            
            if (!auth)
            {
                //INSTANCIONADO O DATETIME PARA PREENCHER NO CADASTRO
                DateTime dateTime = new DateTime();
                dateTime = dateTimeNascimento.Value;
                //PREENCHENDO O CLIENTE
                Cliente cliente = new Cliente();
                cliente.Nome = txtNome.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Email = txtEmail.Text;
                cliente.Nascimento = dateTime;
                cliente.NumeroMesa = mesa;
                cliente.Assunto = "null";

                ClienteDAL clienteDAL = new ClienteDAL();
                //VERIFICAÇÂO DE CADASTRO OU ALTERAÇÂO
                if (txtID.Text == "")
                {
                    clienteDAL.Cadastrar(cliente);
                    MessageBox.Show("CADASTRO FINALIZADO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpar();
                }
                else
                {
                    cliente.ID = Convert.ToInt32(txtID.Text);
                    clienteDAL.Editar(cliente);
                    MessageBox.Show("CLIENTE ALTERADO COM SUCESSO", "KYNTAL D'LURDIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpar();

                }

                TelaInicial inicial = new TelaInicial();
                inicial.ShowDialog();

            }
            else
            {
                txtNome.Focus();
                return;
            }
        }
        //BOTAO VOLTAR PARA OS CLIENTES
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListandoCliente listando = new ListandoCliente();
            listando.ShowDialog();
            this.Close();
        }
        //AO CARREGAR DO FORMULARIO
        private void CadastroCliente_Load(object sender, EventArgs e)
        {

            if (Teste != 1)
            {
                txtNome.Focus();
            }
            else
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                Cliente cliente = clienteDAL.Selecionar(IDCliente);

                //PREENCHENDO OS CAMPOS DO FORMULARIO
                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtNumeroMesa.Text = cliente.NumeroMesa.ToString();
                txtTelefone.Text = cliente.Telefone;
                dateTimeNascimento.Value = cliente.Nascimento;
            }

        }
    }
}
