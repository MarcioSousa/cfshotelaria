namespace View
{
    partial class FrmCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblAluguel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.TxtRg = new System.Windows.Forms.TextBox();
            this.TxtCpf = new System.Windows.Forms.TextBox();
            this.TxtContato = new System.Windows.Forms.TextBox();
            this.BtnAdicionar = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.DgvCliente = new System.Windows.Forms.DataGridView();
            this.CODALU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Location = new System.Drawing.Point(62, 20);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(94, 20);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // LblAluguel
            // 
            this.LblAluguel.AutoSize = true;
            this.LblAluguel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAluguel.Location = new System.Drawing.Point(70, 6);
            this.LblAluguel.Name = "LblAluguel";
            this.LblAluguel.Size = new System.Drawing.Size(96, 20);
            this.LblAluguel.TabIndex = 2;
            this.LblAluguel.Text = "Aluguel Nº 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cpf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Rg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Contato";
            // 
            // TxtNome
            // 
            this.TxtNome.Enabled = false;
            this.TxtNome.Location = new System.Drawing.Point(62, 47);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.ReadOnly = true;
            this.TxtNome.Size = new System.Drawing.Size(285, 20);
            this.TxtNome.TabIndex = 1;
            // 
            // TxtRg
            // 
            this.TxtRg.Enabled = false;
            this.TxtRg.Location = new System.Drawing.Point(62, 75);
            this.TxtRg.Name = "TxtRg";
            this.TxtRg.ReadOnly = true;
            this.TxtRg.Size = new System.Drawing.Size(116, 20);
            this.TxtRg.TabIndex = 2;
            // 
            // TxtCpf
            // 
            this.TxtCpf.Enabled = false;
            this.TxtCpf.Location = new System.Drawing.Point(224, 75);
            this.TxtCpf.Name = "TxtCpf";
            this.TxtCpf.ReadOnly = true;
            this.TxtCpf.Size = new System.Drawing.Size(123, 20);
            this.TxtCpf.TabIndex = 9;
            // 
            // TxtContato
            // 
            this.TxtContato.Enabled = false;
            this.TxtContato.Location = new System.Drawing.Point(62, 103);
            this.TxtContato.Name = "TxtContato";
            this.TxtContato.ReadOnly = true;
            this.TxtContato.Size = new System.Drawing.Size(116, 20);
            this.TxtContato.TabIndex = 3;
            // 
            // BtnAdicionar
            // 
            this.BtnAdicionar.Enabled = false;
            this.BtnAdicionar.Location = new System.Drawing.Point(272, 132);
            this.BtnAdicionar.Name = "BtnAdicionar";
            this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.BtnAdicionar.TabIndex = 4;
            this.BtnAdicionar.Text = "Adicionar";
            this.BtnAdicionar.UseVisualStyleBackColor = true;
            this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Enabled = false;
            this.BtnLimpar.Location = new System.Drawing.Point(15, 132);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpar.TabIndex = 5;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // DgvCliente
            // 
            this.DgvCliente.AllowUserToAddRows = false;
            this.DgvCliente.AllowUserToDeleteRows = false;
            this.DgvCliente.AllowUserToResizeColumns = false;
            this.DgvCliente.AllowUserToResizeRows = false;
            this.DgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODALU,
            this.CODIGO,
            this.NOME,
            this.RG,
            this.CPF,
            this.CONTATO});
            this.DgvCliente.Location = new System.Drawing.Point(12, 211);
            this.DgvCliente.MultiSelect = false;
            this.DgvCliente.Name = "DgvCliente";
            this.DgvCliente.ReadOnly = true;
            this.DgvCliente.RowHeadersVisible = false;
            this.DgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCliente.Size = new System.Drawing.Size(362, 126);
            this.DgvCliente.TabIndex = 4;
            this.DgvCliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCliente_CellDoubleClick);
            // 
            // CODALU
            // 
            this.CODALU.HeaderText = "codAluguel";
            this.CODALU.Name = "CODALU";
            this.CODALU.ReadOnly = true;
            this.CODALU.Visible = false;
            // 
            // CODIGO
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODIGO.DefaultCellStyle = dataGridViewCellStyle1;
            this.CODIGO.HeaderText = "Codigo";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 70;
            // 
            // NOME
            // 
            this.NOME.HeaderText = "Nome";
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            this.NOME.Width = 150;
            // 
            // RG
            // 
            this.RG.HeaderText = "Rg";
            this.RG.Name = "RG";
            this.RG.ReadOnly = true;
            // 
            // CPF
            // 
            this.CPF.HeaderText = "Cpf";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            // 
            // CONTATO
            // 
            this.CONTATO.HeaderText = "Contato";
            this.CONTATO.Name = "CONTATO";
            this.CONTATO.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnEditar);
            this.panel1.Controls.Add(this.BtnNovo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtCodigo);
            this.panel1.Controls.Add(this.BtnLimpar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BtnAdicionar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtContato);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtCpf);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TxtRg);
            this.panel1.Controls.Add(this.TxtNome);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 173);
            this.panel1.TabIndex = 0;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(272, 17);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(75, 23);
            this.BtnEditar.TabIndex = 11;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(191, 17);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 10;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.AutoSize = true;
            this.BtnFinalizar.Location = new System.Drawing.Point(281, 347);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(93, 23);
            this.BtnFinalizar.TabIndex = 1;
            this.BtnFinalizar.Text = "Finalizar/Fechar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AutoSize = true;
            this.BtnCancelar.Location = new System.Drawing.Point(93, 347);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(97, 23);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar/Fechar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(12, 347);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 3;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 378);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvCliente);
            this.Controls.Add(this.LblAluguel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblAluguel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.TextBox TxtRg;
        private System.Windows.Forms.TextBox TxtCpf;
        private System.Windows.Forms.TextBox TxtContato;
        private System.Windows.Forms.Button BtnAdicionar;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.DataGridView DgvCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODALU;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTATO;
    }
}