namespace Mod15_Projeto.Computadores
{
    partial class F_Comp
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
            this.lbMarca = new System.Windows.Forms.Label();
            this.lbCpu = new System.Windows.Forms.Label();
            this.lbGpu = new System.Windows.Forms.Label();
            this.lbRam = new System.Windows.Forms.Label();
            this.lbSO = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCpu = new System.Windows.Forms.TextBox();
            this.txtGpu = new System.Windows.Forms.TextBox();
            this.txtRam = new System.Windows.Forms.TextBox();
            this.txtSO = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgvComputadores = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efetuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reparaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMarca
            // 
            this.lbMarca.AutoSize = true;
            this.lbMarca.Location = new System.Drawing.Point(89, 37);
            this.lbMarca.Name = "lbMarca";
            this.lbMarca.Size = new System.Drawing.Size(37, 13);
            this.lbMarca.TabIndex = 0;
            this.lbMarca.Text = "Marca";
            // 
            // lbCpu
            // 
            this.lbCpu.AutoSize = true;
            this.lbCpu.Location = new System.Drawing.Point(97, 64);
            this.lbCpu.Name = "lbCpu";
            this.lbCpu.Size = new System.Drawing.Size(29, 13);
            this.lbCpu.TabIndex = 1;
            this.lbCpu.Text = "CPU";
            // 
            // lbGpu
            // 
            this.lbGpu.AutoSize = true;
            this.lbGpu.Location = new System.Drawing.Point(96, 91);
            this.lbGpu.Name = "lbGpu";
            this.lbGpu.Size = new System.Drawing.Size(30, 13);
            this.lbGpu.TabIndex = 2;
            this.lbGpu.Text = "GPU";
            // 
            // lbRam
            // 
            this.lbRam.AutoSize = true;
            this.lbRam.Location = new System.Drawing.Point(95, 121);
            this.lbRam.Name = "lbRam";
            this.lbRam.Size = new System.Drawing.Size(31, 13);
            this.lbRam.TabIndex = 3;
            this.lbRam.Text = "RAM";
            // 
            // lbSO
            // 
            this.lbSO.AutoSize = true;
            this.lbSO.Location = new System.Drawing.Point(33, 148);
            this.lbSO.Name = "lbSO";
            this.lbSO.Size = new System.Drawing.Size(93, 13);
            this.lbSO.TabIndex = 4;
            this.lbSO.Text = "Sistema Operativo";
            // 
            // lbPreco
            // 
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(91, 175);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(35, 13);
            this.lbPreco.TabIndex = 5;
            this.lbPreco.Text = "Preço";
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(82, 212);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(35, 13);
            this.lbStock.TabIndex = 6;
            this.lbStock.Text = "Stock";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(132, 31);
            this.txtMarca.MaxLength = 8;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 7;
            // 
            // txtCpu
            // 
            this.txtCpu.Location = new System.Drawing.Point(132, 57);
            this.txtCpu.MaxLength = 25;
            this.txtCpu.Name = "txtCpu";
            this.txtCpu.Size = new System.Drawing.Size(100, 20);
            this.txtCpu.TabIndex = 8;
            // 
            // txtGpu
            // 
            this.txtGpu.Location = new System.Drawing.Point(132, 88);
            this.txtGpu.MaxLength = 25;
            this.txtGpu.Name = "txtGpu";
            this.txtGpu.Size = new System.Drawing.Size(100, 20);
            this.txtGpu.TabIndex = 9;
            // 
            // txtRam
            // 
            this.txtRam.Location = new System.Drawing.Point(132, 118);
            this.txtRam.MaxLength = 3;
            this.txtRam.Name = "txtRam";
            this.txtRam.Size = new System.Drawing.Size(100, 20);
            this.txtRam.TabIndex = 10;
            // 
            // txtSO
            // 
            this.txtSO.Location = new System.Drawing.Point(132, 146);
            this.txtSO.MaxLength = 12;
            this.txtSO.Name = "txtSO";
            this.txtSO.Size = new System.Drawing.Size(100, 20);
            this.txtSO.TabIndex = 11;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(132, 172);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(100, 20);
            this.txtPreco.TabIndex = 12;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(132, 209);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 13;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(12, 266);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(142, 31);
            this.btnAdicionar.TabIndex = 14;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dgvComputadores
            // 
            this.dgvComputadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComputadores.Location = new System.Drawing.Point(351, 20);
            this.dgvComputadores.Name = "dgvComputadores";
            this.dgvComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComputadores.Size = new System.Drawing.Size(432, 332);
            this.dgvComputadores.TabIndex = 15;
            this.dgvComputadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComputadores_CellClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(188, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 31);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(12, 320);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(142, 31);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(188, 266);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(142, 31);
            this.btnRemover.TabIndex = 18;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.verToolStripMenuItem,
            this.efetuarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 19;
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
            this.clienteToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // efetuarToolStripMenuItem
            // 
            this.efetuarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendaToolStripMenuItem,
            this.reparaçãoToolStripMenuItem});
            this.efetuarToolStripMenuItem.Name = "efetuarToolStripMenuItem";
            this.efetuarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.efetuarToolStripMenuItem.Text = "Efetuar";
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendaToolStripMenuItem.Text = "Venda";
            this.vendaToolStripMenuItem.Click += new System.EventHandler(this.vendaToolStripMenuItem_Click);
            // 
            // reparaçãoToolStripMenuItem
            // 
            this.reparaçãoToolStripMenuItem.Name = "reparaçãoToolStripMenuItem";
            this.reparaçãoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reparaçãoToolStripMenuItem.Text = "Reparação";
            this.reparaçãoToolStripMenuItem.Click += new System.EventHandler(this.reparaçãoToolStripMenuItem_Click);
            // 
            // F_Comp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 364);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvComputadores);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtSO);
            this.Controls.Add(this.txtRam);
            this.Controls.Add(this.txtGpu);
            this.Controls.Add(this.txtCpu);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lbStock);
            this.Controls.Add(this.lbPreco);
            this.Controls.Add(this.lbSO);
            this.Controls.Add(this.lbRam);
            this.Controls.Add(this.lbGpu);
            this.Controls.Add(this.lbCpu);
            this.Controls.Add(this.lbMarca);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F_Comp";
            this.Text = "F_Comp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMarca;
        private System.Windows.Forms.Label lbCpu;
        private System.Windows.Forms.Label lbGpu;
        private System.Windows.Forms.Label lbRam;
        private System.Windows.Forms.Label lbSO;
        private System.Windows.Forms.Label lbPreco;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCpu;
        private System.Windows.Forms.TextBox txtGpu;
        private System.Windows.Forms.TextBox txtRam;
        private System.Windows.Forms.TextBox txtSO;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvComputadores;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efetuarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reparaçãoToolStripMenuItem;
    }
}