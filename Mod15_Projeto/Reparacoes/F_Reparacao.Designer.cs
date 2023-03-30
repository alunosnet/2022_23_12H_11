namespace Mod15_Projeto.Reparacoes
{
    partial class F_Reparacao
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
            this.computadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efetuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblComent = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblReparado = new System.Windows.Forms.Label();
            this.checkReparado = new System.Windows.Forms.CheckBox();
            this.btnReparado = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computadorToolStripMenuItem,
            this.clienteToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // computadorToolStripMenuItem
            // 
            this.computadorToolStripMenuItem.Name = "computadorToolStripMenuItem";
            this.computadorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.computadorToolStripMenuItem.Text = "Computador";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // efetuarToolStripMenuItem
            // 
            this.efetuarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendaToolStripMenuItem});
            this.efetuarToolStripMenuItem.Name = "efetuarToolStripMenuItem";
            this.efetuarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.efetuarToolStripMenuItem.Text = "Efetuar";
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.vendaToolStripMenuItem.Text = "Venda";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(40, 43);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(39, 13);
            this.lblMotivo.TabIndex = 2;
            this.lblMotivo.Text = "Motivo";
            // 
            // lblComent
            // 
            this.lblComent.AutoSize = true;
            this.lblComent.Location = new System.Drawing.Point(19, 87);
            this.lblComent.Name = "lblComent";
            this.lblComent.Size = new System.Drawing.Size(60, 13);
            this.lblComent.TabIndex = 3;
            this.lblComent.Text = "Comentário";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(85, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(183, 158);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 5;
            // 
            // lblReparado
            // 
            this.lblReparado.AutoSize = true;
            this.lblReparado.Location = new System.Drawing.Point(19, 267);
            this.lblReparado.Name = "lblReparado";
            this.lblReparado.Size = new System.Drawing.Size(54, 13);
            this.lblReparado.TabIndex = 6;
            this.lblReparado.Text = "Reparado";
            // 
            // checkReparado
            // 
            this.checkReparado.AutoSize = true;
            this.checkReparado.Location = new System.Drawing.Point(85, 267);
            this.checkReparado.Name = "checkReparado";
            this.checkReparado.Size = new System.Drawing.Size(15, 14);
            this.checkReparado.TabIndex = 7;
            this.checkReparado.UseVisualStyleBackColor = true;
            // 
            // btnReparado
            // 
            this.btnReparado.Location = new System.Drawing.Point(279, 304);
            this.btnReparado.Name = "btnReparado";
            this.btnReparado.Size = new System.Drawing.Size(75, 23);
            this.btnReparado.TabIndex = 9;
            this.btnReparado.Text = "Reparado";
            this.btnReparado.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(336, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(452, 241);
            this.dataGridView1.TabIndex = 8;
            // 
            // F_Reparacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReparado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkReparado);
            this.Controls.Add(this.lblReparado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblComent);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F_Reparacao";
            this.Text = "F_Reparacao";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efetuarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblComent;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblReparado;
        private System.Windows.Forms.CheckBox checkReparado;
        private System.Windows.Forms.Button btnReparado;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}