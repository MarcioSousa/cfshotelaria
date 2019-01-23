using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Negocio;

namespace View
{
    public partial class FrmCliente : Form
    {
        Cliente cliente;
        Aluguel aluguel;
        
        public FrmCliente(Aluguel aluguel)
        {
            InitializeComponent();
            this.aluguel = aluguel;
        }
        public FrmCliente(Aluguel aluguel, Cliente cliente)
        {
            InitializeComponent();
            this.aluguel = aluguel;
            this.cliente = cliente;
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (cliente != null)
                {
                    //EDITA CLIENTE
                    TxtCodigo.Text = cliente.Codigo.ToString();
                    TxtNome.Text = cliente.Nome;
                    TxtRg.Text = cliente.Rg;
                    TxtCpf.Text = cliente.Cpf;
                    TxtContato.Text = cliente.Contato;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dados não coletados!\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                
                if(cliente is null)
                {
                    //NOVO CLIENTE
                    cliente = new Cliente(null, TxtNome.Text, TxtRg.Text, TxtCpf.Text, TxtContato.Text, aluguel);
                    clienteNegocio.Inserir(cliente);

                    aluguel.Clientes.Add(cliente);
                }
                else
                {
                    //EDITA CLIENTE
                    cliente.Nome = TxtNome.Text;
                    cliente.Rg = TxtRg.Text;
                    cliente.Cpf = TxtCpf.Text;
                    cliente.Contato = TxtContato.Text;
                    clienteNegocio.Alterar(cliente);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gravar o Cliente.\nAviso: " + ex.Message, "Gravação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AbrirCampos()
        {
            TxtNome.Enabled = true;
            TxtRg.Enabled = true;
            TxtCpf.Enabled = true;
            TxtContato.Enabled = true;
            TxtNome.Focus();
        }
        public void LimparCampos()
        {
            TxtNome.Text = "";
            TxtRg.Text = "";
            TxtCpf.Text = "";
            TxtContato.Text = "";
        }

    }
}
