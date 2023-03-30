using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod15_Projeto.Computadores
{
    public partial class F_Comp : Form
    {
        BaseDados bd;
        int nComputador_escolhido;
        public F_Comp(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
            btnRemover.Visible = false;
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnAdicionar.Visible = true;
        }
        //Adicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Validar dados
            string Marca = txtMarca.Text;
            if (Marca == "" || Marca.Length < 3 || Marca.Contains(' ') == false)
            {
                MessageBox.Show("Marca tem de ter pelo menos 3 letras.");
                txtMarca.Focus();
                return;
            }
            string Cpu = txtCpu.Text;
            if (Cpu == "" || Cpu.Length < 4)
            {
                MessageBox.Show("CPU tem de ter pelo menos 4 letras.");
                txtCpu.Focus();
                return;
            }
            string Gpu = txtGpu.Text;
            if (Gpu == "" || Gpu.Length < 5)
            {
                MessageBox.Show("GPU tem de ter pelo menos 5 letras.");
                txtGpu.Focus();
                return;
            }
            string Ram = txtRam.Text;
            //falta validar q tem de terminar com "%G"
            if (Ram == "" || Ram.Length != 3 )
            {
                MessageBox.Show("Ram tem de ter 3 letras.");
                txtRam.Focus();
                return;
            } 
            if (Ram.Substring(Ram.Length - 1).ToUpper() != "G")
            {
                MessageBox.Show("Ram tem de ter a letra G no final.");
                txtRam.Focus();
                return;
            }
            string SO = txtSO.Text;
            if (SO == "" || SO.Length < 5) 
            {
                MessageBox.Show("Sistema Operativo tem de ter pelo 5 letras.");
                txtSO.Focus();
                return;
            }
            decimal preco;
            if (decimal.TryParse(txtPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero");
                txtPreco.Focus();
                return;
            }
            if (preco < 0)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero");
                txtPreco.Focus();
                return;
            }

            //Criar objeto livro

            Computador computador = new Computador(0, txtMarca.Text, txtCpu.Text, txtGpu.Text, txtRam.Text, txtSO.Text, decimal.Parse(txtPreco.Text),int.Parse(txtStock.Text));

            //Guardar na bd
            computador.Adicionar(bd);

            //Limpar form
            LimparForm();
            AtualizarGrelha();
        }
        //Remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            ApagarComputador();
            btnCancelar_Click(sender, e);

        }
        private void ApagarComputador()
        {
            if (nComputador_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um Computador primeiro. Clique com o botão esquerdo.");
                return;
            }
            //Confirmar delete
            if (MessageBox.Show("Tem a certeza que pretende eliminar o computador selecionado?",
            "Confirmar",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                Computador.Apagar(bd, nComputador_escolhido);
            }
            Computador.Apagar(bd, nComputador_escolhido);
            AtualizarGrelha();
            
        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarComputador();
        }
        private void EditarComputador()
        {
            //Validar dados
            string Marca = txtMarca.Text;
            if (Marca == "" || Marca.Length < 3 || Marca.Contains(' ') == false)
            {
                MessageBox.Show("Marca tem de ter pelo menos 3 letras.");
                txtMarca.Focus();
                return;
            }
            string Cpu = txtCpu.Text;
            if (Cpu == "" || Cpu.Length < 4)
            {
                MessageBox.Show("CPU tem de ter pelo menos 4 letras.");
                txtCpu.Focus();
                return;
            }
            string Gpu = txtGpu.Text;
            if (Gpu == "" || Gpu.Length < 5)
            {
                MessageBox.Show("GPU tem de ter pelo menos 5 letras.");
                txtGpu.Focus();
                return;
            }
            string Ram = txtRam.Text;
            //falta validar q tem de terminar com "%G"
            if (Ram == "" || Ram.Length != 3)
            {
                MessageBox.Show("Ram tem de ter 3 letras.");
                txtRam.Focus();
                return;
            }
            if (Ram.Substring(Ram.Length - 1).ToUpper() != "G")
            {
                MessageBox.Show("Ram tem de ter a letra G no final.");
                txtRam.Focus();
                return;
            }
            string SO = txtSO.Text;
            if (SO == "" || SO.Length < 5)
            {
                MessageBox.Show("Sistema Operativo tem de ter pelo 5 letras.");
                txtSO.Focus();
                return;
            }
            decimal preco;
            if (decimal.TryParse(txtPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero");
                txtPreco.Focus();
                return;
            }
            if (preco < 0)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero");
                txtPreco.Focus();
                return;
            }
            int stock = int.Parse(txtStock.Text);
            //Criar objeto livro
            Computador computador = new Computador();

            //Preencher o form
            computador.Computadorid = nComputador_escolhido;
            computador.Marca = Marca;
            computador.Cpu = Cpu;
            computador.Gpu = Gpu;
            computador.Ram = Ram;
            computador.SO = SO;
            computador.Preco = preco;
            computador.Stock = stock;

            //atualizar na bd
            computador.Atualizar(bd);

            //limpar form
            LimparForm();
            //atualizar os botoes
            btnRemover.Visible = false;
            btnEditar.Visible = true;
            btnAdicionar.Visible = true;

            //atualizar grelha
            AtualizarGrelha();
        }
        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnRemover.Visible = false;
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnAdicionar.Visible = true;
            LimparForm();
        }
        //LimparForm
        private void LimparForm()
        {
            txtMarca.Text = "";
            txtCpu.Text = ""; 
            txtGpu.Text = ""; 
            txtRam.Text = ""; 
            txtSO.Text = "";
            txtPreco.Text = "";
            txtStock.Text = "";
        }
        //Update DGV
        private void AtualizarGrelha()
        {
            dgvComputadores.DataSource = Computador.ListarTodos(bd);
            dgvComputadores.AllowUserToAddRows = false;
            dgvComputadores.AllowUserToDeleteRows = false;
            dgvComputadores.ReadOnly = true;
        }
        //Cellclickdgv
        private void dgvComputadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdicionar.Visible = false;
            btnEditar.Visible = true;
            btnRemover.Visible = true;

            int linha = dgvComputadores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int computadorid = int.Parse(dgvComputadores.Rows[linha].Cells[0].Value.ToString());
            Computador escolhido = new Computador();
            escolhido.ProcurarNrComputador(bd,computadorid);
            
            txtMarca.Text = escolhido.Marca;
            txtCpu.Text = escolhido.Cpu;
            txtGpu.Text = escolhido.Gpu;
            txtRam.Text = escolhido.Ram;
            txtSO.Text = escolhido.SO;
            txtPreco.Text = escolhido.Preco.ToString();
            txtStock.Text = escolhido.Stock.ToString();
            nComputador_escolhido = escolhido.Computadorid;
        }
        //fechar form
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes.F_Cliente f_Cliente = new Clientes.F_Cliente(bd);
            f_Cliente.Show();
            this.Close();

        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendas.F_Venda f_Venda = new Vendas.F_Venda(bd);
            f_Venda.Show();
            this.Close();
        }

        private void reparaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparacoes.F_Reparacao f_Reparacao = new Reparacoes.F_Reparacao(bd);
            f_Reparacao.Show();
            this.Close();
        }
    }
}
