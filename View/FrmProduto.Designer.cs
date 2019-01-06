namespace View
{
    partial class FrmProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAdicionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtQtdeAtual = new System.Windows.Forms.TextBox();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.DgvProduto = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(6, 672);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 9;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AutoSize = true;
            this.BtnCancelar.Location = new System.Drawing.Point(87, 672);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(97, 23);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar/Fechar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.AutoSize = true;
            this.BtnFinalizar.Location = new System.Drawing.Point(275, 672);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(93, 23);
            this.BtnFinalizar.TabIndex = 6;
            this.BtnFinalizar.Text = "Finalizar/Fechar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtQtdeAtual);
            this.panel1.Controls.Add(this.TxtValor);
            this.panel1.Controls.Add(this.TxtNome);
            this.panel1.Location = new System.Drawing.Point(6, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 135);
            this.panel1.TabIndex = 5;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(272, 12);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(75, 23);
            this.BtnEditar.TabIndex = 11;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(191, 12);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 10;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Location = new System.Drawing.Point(62, 15);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(116, 20);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Enabled = false;
            this.BtnLimpar.Location = new System.Drawing.Point(62, 98);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpar.TabIndex = 5;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome";
            // 
            // BtnAdicionar
            // 
            this.BtnAdicionar.Enabled = false;
            this.BtnAdicionar.Location = new System.Drawing.Point(272, 98);
            this.BtnAdicionar.Name = "BtnAdicionar";
            this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.BtnAdicionar.TabIndex = 4;
            this.BtnAdicionar.Text = "Adicionar";
            this.BtnAdicionar.UseVisualStyleBackColor = true;
            this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Qtde Atual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Valor";
            // 
            // TxtQtdeAtual
            // 
            this.TxtQtdeAtual.Enabled = false;
            this.TxtQtdeAtual.Location = new System.Drawing.Point(258, 70);
            this.TxtQtdeAtual.Name = "TxtQtdeAtual";
            this.TxtQtdeAtual.ReadOnly = true;
            this.TxtQtdeAtual.Size = new System.Drawing.Size(89, 20);
            this.TxtQtdeAtual.TabIndex = 9;
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(62, 70);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.ReadOnly = true;
            this.TxtValor.Size = new System.Drawing.Size(116, 20);
            this.TxtValor.TabIndex = 2;
            // 
            // TxtNome
            // 
            this.TxtNome.Enabled = false;
            this.TxtNome.Location = new System.Drawing.Point(62, 42);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.ReadOnly = true;
            this.TxtNome.Size = new System.Drawing.Size(285, 20);
            this.TxtNome.TabIndex = 1;
            // 
            // DgvProduto
            // 
            this.DgvProduto.AllowUserToAddRows = false;
            this.DgvProduto.AllowUserToDeleteRows = false;
            this.DgvProduto.AllowUserToResizeColumns = false;
            this.DgvProduto.AllowUserToResizeRows = false;
            this.DgvProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.NOME,
            this.RG,
            this.CPF});
            this.DgvProduto.Location = new System.Drawing.Point(6, 191);
            this.DgvProduto.MultiSelect = false;
            this.DgvProduto.Name = "DgvProduto";
            this.DgvProduto.ReadOnly = true;
            this.DgvProduto.RowHeadersVisible = false;
            this.DgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProduto.Size = new System.Drawing.Size(362, 475);
            this.DgvProduto.TabIndex = 10;
            this.DgvProduto.SelectionChanged += new System.EventHandler(this.DgvProduto_SelectionChanged);
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "Codigo";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODIGO.DefaultCellStyle = dataGridViewCellStyle22;
            this.CODIGO.HeaderText = "Codigo";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 50;
            // 
            // NOME
            // 
            this.NOME.DataPropertyName = "Nome";
            this.NOME.HeaderText = "Nome";
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            this.NOME.Width = 150;
            // 
            // RG
            // 
            this.RG.DataPropertyName = "Valor";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "C";
            this.RG.DefaultCellStyle = dataGridViewCellStyle23;
            this.RG.HeaderText = "Valor";
            this.RG.Name = "RG";
            this.RG.ReadOnly = true;
            this.RG.Width = 70;
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "Qtdeatual";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CPF.DefaultCellStyle = dataGridViewCellStyle24;
            this.CPF.HeaderText = "QtdeAtual";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            this.CPF.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.BtnExcluir);
            this.groupBox1.Controls.Add(this.DgvProduto);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnFinalizar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 701);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Produto(s)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(391, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 701);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 31);
            this.label6.TabIndex = 11;
            this.label6.Text = "Entradas Produtos";
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAdicionar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtQtdeAtual;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.DataGridView DgvProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
    }
}