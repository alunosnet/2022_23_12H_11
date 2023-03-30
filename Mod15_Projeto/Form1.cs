using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod15_Projeto
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_Projeto");
        public Form1()
        {
            InitializeComponent();
        }

        private void computadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Computadores.F_Comp f_Comp = new Computadores.F_Comp(bd);
            f_Comp.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes.F_Cliente f_Clientes = new Clientes.F_Cliente(bd);
            f_Clientes.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendas.F_Venda f_venda = new Vendas.F_Venda(bd);
            f_venda.Show();
        }

        private void reparaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparacoes.F_Reparacao f_reparacao = new Reparacoes.F_Reparacao(bd);
            f_reparacao.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
