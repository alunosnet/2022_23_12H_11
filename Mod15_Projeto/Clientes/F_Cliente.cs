using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod15_Projeto.Clientes
{
    public partial class F_Cliente : Form
    {
        BaseDados bd;
        string nCliente_Selecionado;
        public F_Cliente(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
            btnRemover.Visible = false;
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnAdicionar.Visible = true;
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //validar dados
            string Nome = txtNome.Text;
            if (Nome == "" || Nome.Length < 3 || Nome.Contains(' ') == false)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                txtNome.Focus();
                return;
            }
            string Nif = txtNIF.Text;
            if (Nif == "" || Nif.Length != 9 )
            {
                MessageBox.Show("NIF tem de ter 9 digitos.");
                txtNIF.Focus();
                return;
            }
            string Email = txtEmail.Text;
            Regex regex = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$"
, RegexOptions.IgnoreCase);
            var combinou = regex.Match(Email);
            if (combinou.Success == false)
            {
                MessageBox.Show("Email no formato inválido.");
                txtEmail.Focus();
                return;
            }
            
            string cp = txtCP.Text;
            if (cp == "" || cp.Length != 8|| cp.IndexOf("-") != 4)
            {
                MessageBox.Show("Codigo Postal no formato inválido.");
                txtCP.Focus();
                return;
            }
            DateTime Datanasc = dtpDatanasc.Value;
            if (Datanasc > DateTime.Now)
            {
                MessageBox.Show("Data de nascimento tem de ser menor ou igual a data atual");
                dtpDatanasc.Focus();
                return;
            }

            Cliente cliente = new Cliente();

            cliente.ClienteID = "C" + Cliente.nultimocliente(bd) + 1;
            cliente.Nome = txtNome.Text;
            cliente.NIF = txtNIF.Text;
            cliente.Email = txtEmail.Text;
            cliente.CP = txtCP.Text;
            cliente.DataNasc = dtpDatanasc.Value;
            cliente.Adicionar(bd);

            LimparForm();
            AtualizarGrelha();


        }
        //cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnRemover.Visible = false;
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnAdicionar.Visible = true;
            LimparForm();
        }
        //limpar form
        private void LimparForm()
        {
            txtNome.Text = "";
            txtNIF.Text = "";
            txtEmail.Text = "";
            txtCP.Text = "";
            dtpDatanasc.Value = DateTime.Now;
        }
        //update dgv
        private void AtualizarGrelha()
        {
            dgvClientes.DataSource = Cliente.ListarTodos(bd);
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
        }
        //cellclick dgv
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdicionar.Visible = false;
            btnEditar.Visible = true;
            btnRemover.Visible = true;
            int linha = dgvClientes.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            string clienteid = dgvClientes.Rows[linha].Cells[0].Value.ToString();
            Cliente selecionado = new Cliente();
            nCliente_Selecionado = clienteid;
            selecionado.ProcurarNrCliente(bd, clienteid);
            txtNome.Text = selecionado.Nome;
            txtNIF.Text = selecionado.NIF;
            txtEmail.Text = selecionado.Email;
            txtCP.Text = selecionado.CP;
            dtpDatanasc.Value = selecionado.DataNasc;
        }
        //fechar form
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            ApagarCliente();
            btnCancelar_Click(sender, e);
        }
        private void ApagarCliente()
        {
            if (nCliente_Selecionado == "")
            {
                MessageBox.Show("Tem de selecionar um Cliente primeiro. Clique com o botão esquerdo.");
                return;
            }
            //Confirmar delete
            if (MessageBox.Show("Tem a certeza que pretende eliminar o Cliente selecionado?",
            "Confirmar",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                Cliente.Apagar(bd, nCliente_Selecionado);
            }
            Cliente.Apagar(bd, nCliente_Selecionado);
            AtualizarGrelha();

        }
        //Editar
        private void EditarCliente()
        {
            //validar dados
            string Nome = txtNome.Text;
            if (Nome == "" || Nome.Length < 3 || Nome.Contains(' ') == false)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                txtNome.Focus();
                return;
            }
            string Nif = txtNIF.Text;
            if (Nif == "" || Nif.Length != 9)
            {
                MessageBox.Show("NIF tem de ter 9 digitos.");
                txtNIF.Focus();
                return;
            }
            string Email = txtEmail.Text;
            Regex regex = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$"
, RegexOptions.IgnoreCase);
            var combinou = regex.Match(Email);
            if (combinou.Success == false)
            {
                MessageBox.Show("Email no formato inválido.");
                txtEmail.Focus();
                return;
            }

            string cp = txtCP.Text;
            if (cp == "" || cp.Length != 8 || cp.IndexOf("-") != 4)
            {
                MessageBox.Show("Codigo Postal no formato inválido.");
                txtCP.Focus();
                return;
            }
            DateTime Datanasc = dtpDatanasc.Value;
            if (Datanasc > DateTime.Now)
            {
                MessageBox.Show("Data de nascimento tem de ser menor ou igual a data atual");
                dtpDatanasc.Focus();
                return;
            }
            Cliente cliente = new Cliente();
            cliente.ClienteID = nCliente_Selecionado;
            cliente.Nome = Nome;
            cliente.NIF = Nif;
            cliente.Email = Email;
            cliente.CP = cp;
            cliente.DataNasc = Datanasc;

            cliente.Atualizar(bd);

            //limpar form
            LimparForm();
            //atualizar os botoes
            btnRemover.Visible = false;
            btnEditar.Visible = true;
            btnAdicionar.Visible = true;

            //atualizar grelha
            AtualizarGrelha();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }

        private void computadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Computadores.F_Comp f_Comp = new Computadores.F_Comp(bd);
            f_Comp.Show();
            this.Close();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendas.F_Venda f_venda = new Vendas.F_Venda(bd);
            f_venda.Show();
            this.Close();
        }

        private void reparaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparacoes.F_Reparacao f_reparacao = new Reparacoes.F_Reparacao(bd);
            f_reparacao.Show();
            this.Close();
        }
    }
}
