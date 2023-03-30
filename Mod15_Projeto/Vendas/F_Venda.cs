using Mod15_Projeto.Clientes;
using Mod15_Projeto.Computadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod15_Projeto.Vendas
{
    public partial class F_Venda : Form
    {
        BaseDados bd;
        int n_venda_escolhida;
        public F_Venda(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
            btnDevolver.Visible = false;
            btnEditar.Visible = false;
            btnVenda.Visible = true;
            btnCompor.Visible = false;
            AtualizarCBComputadores();
            AtualizarCBClientes();
        }
        private void AtualizarCBComputadores()
        {
            cbComputador.Items.Clear();
            DataTable dados = Computador.ListarDisponiveis(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Computador pc = new Computador();
                pc.Computadorid = int.Parse(dr["Computadorid"].ToString());
                pc.Marca = dr["Marca"].ToString();
                pc.Preco = decimal.Parse(dr["Preco"].ToString());
                cbComputador.Items.Add(pc);
            }
        }
        private void AtualizarCBClientes()
        {
            cbCliente.Items.Clear();
            DataTable dados = Cliente.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Cliente cli = new Cliente();
                cli.ClienteID = dr["Clienteid"].ToString();
                cli.Nome = dr["Nome"].ToString();
                cbCliente.Items.Add(cli);
            }
        }
        private void cbComputador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Computador comp = cbComputador.SelectedItem as Computador;
            if (comp == null)
            {
                MessageBox.Show("Precisa de escolher algum computador.");
            }
            else
            {
                txtPrecoPc.Text = comp.Preco.ToString();
            }
        }
        private void checkGarantia_Click(object sender, EventArgs e)
        {
            if(checkGarantia.Checked == true)
            {
                txtTotal.Text = (decimal.Parse(txtPrecoPc.Text) + 30).ToString();
            }
            else
            {
                txtTotal.Text = txtPrecoPc.Text;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        private void Editar()
        {
            int compID = int.Parse(cbComputador.Text.ToString());
            string cliID = cbCliente.Text;
            bool garantia = checkGarantia.Checked;
            bool funciona = checkFunciona.Checked;
            decimal computador_preco = decimal.Parse(txtPrecoPc.Text.ToString());
            decimal total = decimal.Parse(txtTotal.Text.ToString());
            Venda compor = new Venda();
            compor.VendaID = n_venda_escolhida;
            compor.Computadorid = compID;
            compor.ClienteID = cliID ;
            compor.Garantia = garantia;
            compor.Funciona = funciona;
            compor.Computador_Preco = computador_preco;
            compor.Total = total;
            compor.Atualizar(bd);

            //limpar form
            LimparForm();
            btnDevolver.Visible = false;
            btnEditar.Visible = true;
            btnVenda.Visible = true;
            //atualizar grelha
            AtualizarGrelha();
        }
        private void btnVenda_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda();
            Cliente cliente=cbCliente.SelectedItem as Cliente;
            venda.ClienteID =cliente.ClienteID;
            Computador comp = cbComputador.SelectedItem as Computador;
            venda.Computadorid = comp.Computadorid;
            venda.Garantia = checkGarantia.Checked;
            venda.Funciona = checkFunciona.Checked;
            venda.Computador_Preco = comp.Preco;
            venda.Total = decimal.Parse(txtTotal.Text.ToString());
            venda.Adicionar(bd);

            LimparForm();
            btnDevolver.Visible = false;
            btnEditar.Visible = true;
            btnVenda.Visible = true;
            AtualizarGrelha();
        }
        private void AtualizarGrelha()
        {
            dgvVendas.DataSource = Venda.ListarTodos(bd);
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.ReadOnly = true;
        }
        private void LimparForm()
        {
            cbCliente.Text = "";
            cbComputador.Text = "";
            checkFunciona.Checked = true;
            checkGarantia.Checked = false;
            txtPrecoPc.Text = "";
            txtTotal.Text = "";
        }
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            DevolverVenda();
        }
        private void DevolverVenda()
        {
            if (n_venda_escolhida < 1 )
            {
                MessageBox.Show("Tem de selecionar uma venda primeiro. Clique com o botão esquerdo.");
                return;
            }
            //Confirmar delete
            if (MessageBox.Show("Tem a certeza que pretende eliminar a Venda selecionado?",
            "Confirmar",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                Venda.Apagar(bd, n_venda_escolhida);
            }
            Venda.Apagar(bd, n_venda_escolhida);
            AtualizarGrelha();
        }
        private void dgvVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDevolver.Visible = true;
            btnEditar.Visible = true;
            btnVenda.Visible = false;
            int linha = dgvVendas.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int VendaID = int.Parse(dgvVendas.Rows[linha].Cells[0].Value.ToString());
            Venda escolhida = new Venda();
            n_venda_escolhida = VendaID;
            escolhida.ProcurarNrVenda(bd, VendaID);
            cbComputador.Text = escolhida.Computadorid.ToString();
            cbCliente.Text = escolhida.ClienteID;
            checkGarantia.Checked = escolhida.Garantia;
            checkFunciona.Checked = escolhida.Funciona;
            txtPrecoPc.Text = escolhida.Computador_Preco.ToString();
            txtTotal.Text = escolhida.Total.ToString();
            
        }
        private void btnCompor_Click(object sender, EventArgs e)
        {
            
            MandarCompor();

        }
        private void MandarCompor()
        {

            if (n_venda_escolhida < 1)
            {
                MessageBox.Show("Tem de selecionar uma Venda primeiro. Clique com o botão esquerdo.");
                return;
            }
            //Confirmar update
            if (MessageBox.Show("Tem a certeza que pretende mandar o computador selecionado para reparação?",
            "Confirmar",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                checkFunciona.Checked = false;
                Venda.Compor(bd, n_venda_escolhida);
            }
            
            Venda.Compor(bd, n_venda_escolhida);
            AtualizarGrelha();
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void computadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Computadores.F_Comp f_Comp = new Computadores.F_Comp(bd);
            f_Comp.Show();
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes.F_Cliente f_Clientes = new Clientes.F_Cliente(bd);
            f_Clientes.Show();
            this.Close();
        }

        private void recuperacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparacoes.F_Reparacao f_reparacao = new Reparacoes.F_Reparacao(bd);
            f_reparacao.Show();
            this.Close();
        }
    }
}
