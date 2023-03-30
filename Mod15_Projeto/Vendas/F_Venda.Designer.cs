namespace Mod15_Projeto.Vendas
{
    partial class F_Venda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efetuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recuperacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbComputador = new System.Windows.Forms.ComboBox();
            this.lblComputadorID = new System.Windows.Forms.Label();
            this.lblClienteID = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblGarantia = new System.Windows.Forms.Label();
            this.checkGarantia = new System.Windows.Forms.CheckBox();
            this.checkFunciona = new System.Windows.Forms.CheckBox();
            this.lblFunciona = new System.Windows.Forms.Label();
            this.lblPrecoPC = new System.Windows.Forms.Label();
            this.txtPrecoPc = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnVenda = new System.Windows.Forms.Button();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCompor = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.verToolStripMenuItem,
            this.efetuarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computadoresToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // computadoresToolStripMenuItem
            // 
            this.computadoresToolStripMenuItem.Name = "computadoresToolStripMenuItem";
            this.computadoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.computadoresToolStripMenuItem.Text = "Computadores";
            this.computadoresToolStripMenuItem.Click += new System.EventHandler(this.computadoresToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // efetuarToolStripMenuItem
            // 
            this.efetuarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recuperacaoToolStripMenuItem});
            this.efetuarToolStripMenuItem.Name = "efetuarToolStripMenuItem";
            this.efetuarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.efetuarToolStripMenuItem.Text = "Efetuar";
            // 
            // recuperacaoToolStripMenuItem
            // 
            this.recuperacaoToolStripMenuItem.Name = "recuperacaoToolStripMenuItem";
            this.recuperacaoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recuperacaoToolStripMenuItem.Text = "Recuperação";
            this.recuperacaoToolStripMenuItem.Click += new System.EventHandler(this.recuperacaoToolStripMenuItem_Click);
            // 
            // cbComputador
            // 
            this.cbComputador.FormattingEnabled = true;
            this.cbComputador.Location = new System.Drawing.Point(164, 48);
            this.cbComputador.Name = "cbComputador";
            this.cbComputador.Size = new System.Drawing.Size(121, 21);
            this.cbComputador.TabIndex = 1;
            this.cbComputador.SelectedIndexChanged += new System.EventHandler(this.cbComputador_SelectedIndexChanged);
            // 
            // lblComputadorID
            // 
            this.lblComputadorID.AutoSize = true;
            this.lblComputadorID.Location = new System.Drawing.Point(50, 51);
            this.lblComputadorID.Name = "lblComputadorID";
            this.lblComputadorID.Size = new System.Drawing.Size(108, 13);
            this.lblComputadorID.TabIndex = 2;
            this.lblComputadorID.Text = "Computador Escolher";
            // 
            // lblClienteID
            // 
            this.lblClienteID.AutoSize = true;
            this.lblClienteID.Location = new System.Drawing.Point(61, 79);
            this.lblClienteID.Name = "lblClienteID";
            this.lblClienteID.Size = new System.Drawing.Size(97, 13);
            this.lblClienteID.TabIndex = 4;
            this.lblClienteID.Text = "Cliente Interessado";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(164, 75);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(121, 21);
            this.cbCliente.TabIndex = 3;
            // 
            // lblGarantia
            // 
            this.lblGarantia.AutoSize = true;
            this.lblGarantia.Location = new System.Drawing.Point(111, 112);
            this.lblGarantia.Name = "lblGarantia";
            this.lblGarantia.Size = new System.Drawing.Size(47, 13);
            this.lblGarantia.TabIndex = 5;
            this.lblGarantia.Text = "Garantia";
            // 
            // checkGarantia
            // 
            this.checkGarantia.AutoSize = true;
            this.checkGarantia.Location = new System.Drawing.Point(164, 112);
            this.checkGarantia.Name = "checkGarantia";
            this.checkGarantia.Size = new System.Drawing.Size(15, 14);
            this.checkGarantia.TabIndex = 7;
            this.checkGarantia.UseVisualStyleBackColor = true;
            this.checkGarantia.Click += new System.EventHandler(this.checkGarantia_Click);
            // 
            // checkFunciona
            // 
            this.checkFunciona.AutoSize = true;
            this.checkFunciona.Checked = true;
            this.checkFunciona.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFunciona.Location = new System.Drawing.Point(164, 140);
            this.checkFunciona.Name = "checkFunciona";
            this.checkFunciona.Size = new System.Drawing.Size(15, 14);
            this.checkFunciona.TabIndex = 9;
            this.checkFunciona.UseVisualStyleBackColor = true;
            // 
            // lblFunciona
            // 
            this.lblFunciona.AutoSize = true;
            this.lblFunciona.Location = new System.Drawing.Point(107, 140);
            this.lblFunciona.Name = "lblFunciona";
            this.lblFunciona.Size = new System.Drawing.Size(51, 13);
            this.lblFunciona.TabIndex = 8;
            this.lblFunciona.Text = "Funciona";
            // 
            // lblPrecoPC
            // 
            this.lblPrecoPC.AutoSize = true;
            this.lblPrecoPC.Location = new System.Drawing.Point(12, 166);
            this.lblPrecoPC.Name = "lblPrecoPC";
            this.lblPrecoPC.Size = new System.Drawing.Size(146, 13);
            this.lblPrecoPC.TabIndex = 10;
            this.lblPrecoPC.Text = "Computador escolhido Preço:";
            // 
            // txtPrecoPc
            // 
            this.txtPrecoPc.Location = new System.Drawing.Point(165, 163);
            this.txtPrecoPc.Name = "txtPrecoPc";
            this.txtPrecoPc.ReadOnly = true;
            this.txtPrecoPc.Size = new System.Drawing.Size(120, 20);
            this.txtPrecoPc.TabIndex = 11;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(84, 198);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total a Pagar:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(165, 190);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(120, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // btnVenda
            // 
            this.btnVenda.Location = new System.Drawing.Point(12, 238);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(143, 36);
            this.btnVenda.TabIndex = 14;
            this.btnVenda.Text = "Venda\r\n";
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            // 
            // dgvVendas
            // 
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(403, 27);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(382, 247);
            this.dgvVendas.TabIndex = 15;
            this.dgvVendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendas_CellClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(210, 238);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(143, 36);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(15, 287);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(140, 36);
            this.btnDevolver.TabIndex = 17;
            this.btnDevolver.Text = "Devolução";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnCompor
            // 
            this.btnCompor.Location = new System.Drawing.Point(210, 287);
            this.btnCompor.Name = "btnCompor";
            this.btnCompor.Size = new System.Drawing.Size(143, 36);
            this.btnCompor.TabIndex = 18;
            this.btnCompor.Text = "Compor";
            this.btnCompor.UseVisualStyleBackColor = true;
            this.btnCompor.Click += new System.EventHandler(this.btnCompor_Click);
            // 
            // F_Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 335);
            this.Controls.Add(this.btnCompor);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvVendas);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtPrecoPc);
            this.Controls.Add(this.lblPrecoPC);
            this.Controls.Add(this.checkFunciona);
            this.Controls.Add(this.lblFunciona);
            this.Controls.Add(this.checkGarantia);
            this.Controls.Add(this.lblGarantia);
            this.Controls.Add(this.lblClienteID);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblComputadorID);
            this.Controls.Add(this.cbComputador);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F_Venda";
            this.Text = "F_Venda";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efetuarToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbComputador;
        private System.Windows.Forms.Label lblComputadorID;
        private System.Windows.Forms.Label lblClienteID;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblGarantia;
        private System.Windows.Forms.CheckBox checkGarantia;
        private System.Windows.Forms.CheckBox checkFunciona;
        private System.Windows.Forms.Label lblFunciona;
        private System.Windows.Forms.Label lblPrecoPC;
        private System.Windows.Forms.TextBox txtPrecoPc;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnCompor;
        private System.Windows.Forms.ToolStripMenuItem computadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recuperacaoToolStripMenuItem;
    }
}