namespace View
{
    partial class FrmEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxProduto = new System.Windows.Forms.GroupBox();
            this.CbxEstoque = new System.Windows.Forms.CheckBox();
            this.TxtQtde = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigoProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.DgvProduto = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTDEATUAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.GbxEntrada = new System.Windows.Forms.GroupBox();
            this.LblCodigoEntrada = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DtpVencimento = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.DtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.TxtQtdeEntrada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnConfirmarEntrada = new System.Windows.Forms.Button();
            this.BtnCancelaEntrada = new System.Windows.Forms.Button();
            this.BtnExcluiEntrada = new System.Windows.Forms.Button();
            this.BtnEditaEntrada = new System.Windows.Forms.Button();
            this.BtnNovaEntrada = new System.Windows.Forms.Button();
            this.DgvEntrada = new System.Windows.Forms.DataGridView();
            this.CODIGOENTRADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATAENTRADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VENCIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbxSaida = new System.Windows.Forms.GroupBox();
            this.DgvSaida = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CODIGOUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATASAIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALORUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTDEUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbxProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduto)).BeginInit();
            this.GbxEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntrada)).BeginInit();
            this.GbxSaida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaida)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxProduto
            // 
            this.GbxProduto.Controls.Add(this.CbxEstoque);
            this.GbxProduto.Controls.Add(this.TxtQtde);
            this.GbxProduto.Controls.Add(this.label5);
            this.GbxProduto.Controls.Add(this.TxtValor);
            this.GbxProduto.Controls.Add(this.label4);
            this.GbxProduto.Controls.Add(this.TxtNome);
            this.GbxProduto.Controls.Add(this.label3);
            this.GbxProduto.Controls.Add(this.TxtCodigoProduto);
            this.GbxProduto.Controls.Add(this.label2);
            this.GbxProduto.Controls.Add(this.BtnConfirmar);
            this.GbxProduto.Controls.Add(this.BtnCancelar);
            this.GbxProduto.Controls.Add(this.BtnExcluir);
            this.GbxProduto.Controls.Add(this.BtnEditar);
            this.GbxProduto.Controls.Add(this.BtnNovo);
            this.GbxProduto.Controls.Add(this.DgvProduto);
            this.GbxProduto.Controls.Add(this.label20);
            this.GbxProduto.Location = new System.Drawing.Point(12, 40);
            this.GbxProduto.Name = "GbxProduto";
            this.GbxProduto.Size = new System.Drawing.Size(395, 633);
            this.GbxProduto.TabIndex = 0;
            this.GbxProduto.TabStop = false;
            // 
            // CbxEstoque
            // 
            this.CbxEstoque.AutoSize = true;
            this.CbxEstoque.Checked = true;
            this.CbxEstoque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEstoque.Location = new System.Drawing.Point(283, 20);
            this.CbxEstoque.Name = "CbxEstoque";
            this.CbxEstoque.Size = new System.Drawing.Size(65, 17);
            this.CbxEstoque.TabIndex = 80;
            this.CbxEstoque.Text = "Estoque";
            this.CbxEstoque.UseVisualStyleBackColor = true;
            this.CbxEstoque.CheckedChanged += new System.EventHandler(this.CbxEstoque_CheckedChanged);
            // 
            // TxtQtde
            // 
            this.TxtQtde.Enabled = false;
            this.TxtQtde.Location = new System.Drawing.Point(162, 71);
            this.TxtQtde.MaxLength = 6;
            this.TxtQtde.Name = "TxtQtde";
            this.TxtQtde.Size = new System.Drawing.Size(48, 20);
            this.TxtQtde.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "Qtde";
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(52, 71);
            this.TxtValor.MaxLength = 10;
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(63, 20);
            this.TxtValor.TabIndex = 77;
            this.TxtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValor_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Valor";
            // 
            // TxtNome
            // 
            this.TxtNome.Enabled = false;
            this.TxtNome.Location = new System.Drawing.Point(162, 45);
            this.TxtNome.MaxLength = 30;
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(227, 20);
            this.TxtNome.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Nome";
            // 
            // TxtCodigoProduto
            // 
            this.TxtCodigoProduto.Enabled = false;
            this.TxtCodigoProduto.Location = new System.Drawing.Point(52, 45);
            this.TxtCodigoProduto.MaxLength = 6;
            this.TxtCodigoProduto.Name = "TxtCodigoProduto";
            this.TxtCodigoProduto.Size = new System.Drawing.Size(63, 20);
            this.TxtCodigoProduto.TabIndex = 73;
            this.TxtCodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Código";
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.AutoSize = true;
            this.BtnConfirmar.Enabled = false;
            this.BtnConfirmar.Location = new System.Drawing.Point(243, 69);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(70, 23);
            this.BtnConfirmar.TabIndex = 71;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AutoSize = true;
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Location = new System.Drawing.Point(319, 69);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(70, 23);
            this.BtnCancelar.TabIndex = 70;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(168, 16);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluir.TabIndex = 69;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(87, 16);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(75, 23);
            this.BtnEditar.TabIndex = 68;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(6, 16);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 67;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // DgvProduto
            // 
            this.DgvProduto.AllowUserToAddRows = false;
            this.DgvProduto.AllowUserToDeleteRows = false;
            this.DgvProduto.AllowUserToResizeColumns = false;
            this.DgvProduto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.NOME,
            this.VALOR,
            this.QTDEATUAL});
            this.DgvProduto.Location = new System.Drawing.Point(6, 127);
            this.DgvProduto.MultiSelect = false;
            this.DgvProduto.Name = "DgvProduto";
            this.DgvProduto.ReadOnly = true;
            this.DgvProduto.RowHeadersVisible = false;
            this.DgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProduto.Size = new System.Drawing.Size(383, 500);
            this.DgvProduto.TabIndex = 65;
            this.DgvProduto.SelectionChanged += new System.EventHandler(this.DgvProduto_SelectionChanged);
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODIGO.DefaultCellStyle = dataGridViewCellStyle2;
            this.CODIGO.HeaderText = "Codigo";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 80;
            // 
            // NOME
            // 
            this.NOME.DataPropertyName = "Nome";
            this.NOME.HeaderText = "Produto";
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            this.NOME.Width = 160;
            // 
            // VALOR
            // 
            this.VALOR.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Format = "C";
            this.VALOR.DefaultCellStyle = dataGridViewCellStyle3;
            this.VALOR.HeaderText = "Valor";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            this.VALOR.Width = 80;
            // 
            // QTDEATUAL
            // 
            this.QTDEATUAL.DataPropertyName = "Qtdeatual";
            this.QTDEATUAL.HeaderText = "Qtde";
            this.QTDEATUAL.Name = "QTDEATUAL";
            this.QTDEATUAL.ReadOnly = true;
            this.QTDEATUAL.Width = 40;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(114, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 20);
            this.label20.TabIndex = 64;
            this.label20.Text = "Lista de Produtos";
            // 
            // GbxEntrada
            // 
            this.GbxEntrada.Controls.Add(this.LblCodigoEntrada);
            this.GbxEntrada.Controls.Add(this.label8);
            this.GbxEntrada.Controls.Add(this.DtpVencimento);
            this.GbxEntrada.Controls.Add(this.label11);
            this.GbxEntrada.Controls.Add(this.DtpDataEntrada);
            this.GbxEntrada.Controls.Add(this.TxtQtdeEntrada);
            this.GbxEntrada.Controls.Add(this.label9);
            this.GbxEntrada.Controls.Add(this.label10);
            this.GbxEntrada.Controls.Add(this.BtnConfirmarEntrada);
            this.GbxEntrada.Controls.Add(this.BtnCancelaEntrada);
            this.GbxEntrada.Controls.Add(this.BtnExcluiEntrada);
            this.GbxEntrada.Controls.Add(this.BtnEditaEntrada);
            this.GbxEntrada.Controls.Add(this.BtnNovaEntrada);
            this.GbxEntrada.Controls.Add(this.DgvEntrada);
            this.GbxEntrada.Location = new System.Drawing.Point(437, 40);
            this.GbxEntrada.Name = "GbxEntrada";
            this.GbxEntrada.Size = new System.Drawing.Size(395, 633);
            this.GbxEntrada.TabIndex = 1;
            this.GbxEntrada.TabStop = false;
            // 
            // LblCodigoEntrada
            // 
            this.LblCodigoEntrada.AutoSize = true;
            this.LblCodigoEntrada.Location = new System.Drawing.Point(249, 20);
            this.LblCodigoEntrada.Name = "LblCodigoEntrada";
            this.LblCodigoEntrada.Size = new System.Drawing.Size(77, 13);
            this.LblCodigoEntrada.TabIndex = 98;
            this.LblCodigoEntrada.Text = "EntradaCodigo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 20);
            this.label8.TabIndex = 97;
            this.label8.Text = "Lista de Entrada do Produto";
            // 
            // DtpVencimento
            // 
            this.DtpVencimento.Enabled = false;
            this.DtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpVencimento.Location = new System.Drawing.Point(191, 45);
            this.DtpVencimento.Name = "DtpVencimento";
            this.DtpVencimento.Size = new System.Drawing.Size(89, 20);
            this.DtpVencimento.TabIndex = 96;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(150, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 95;
            this.label11.Text = "Venc.";
            // 
            // DtpDataEntrada
            // 
            this.DtpDataEntrada.Enabled = false;
            this.DtpDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDataEntrada.Location = new System.Drawing.Point(55, 45);
            this.DtpDataEntrada.Name = "DtpDataEntrada";
            this.DtpDataEntrada.Size = new System.Drawing.Size(89, 20);
            this.DtpDataEntrada.TabIndex = 94;
            // 
            // TxtQtdeEntrada
            // 
            this.TxtQtdeEntrada.Enabled = false;
            this.TxtQtdeEntrada.Location = new System.Drawing.Point(322, 45);
            this.TxtQtdeEntrada.Name = "TxtQtdeEntrada";
            this.TxtQtdeEntrada.Size = new System.Drawing.Size(67, 20);
            this.TxtQtdeEntrada.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Qtde";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 88;
            this.label10.Text = "Receb.";
            // 
            // BtnConfirmarEntrada
            // 
            this.BtnConfirmarEntrada.AutoSize = true;
            this.BtnConfirmarEntrada.Enabled = false;
            this.BtnConfirmarEntrada.Location = new System.Drawing.Point(243, 69);
            this.BtnConfirmarEntrada.Name = "BtnConfirmarEntrada";
            this.BtnConfirmarEntrada.Size = new System.Drawing.Size(70, 23);
            this.BtnConfirmarEntrada.TabIndex = 85;
            this.BtnConfirmarEntrada.Text = "Confirmar";
            this.BtnConfirmarEntrada.UseVisualStyleBackColor = true;
            this.BtnConfirmarEntrada.Click += new System.EventHandler(this.BtnConfirmarEntrada_Click);
            // 
            // BtnCancelaEntrada
            // 
            this.BtnCancelaEntrada.AutoSize = true;
            this.BtnCancelaEntrada.Enabled = false;
            this.BtnCancelaEntrada.Location = new System.Drawing.Point(319, 69);
            this.BtnCancelaEntrada.Name = "BtnCancelaEntrada";
            this.BtnCancelaEntrada.Size = new System.Drawing.Size(70, 23);
            this.BtnCancelaEntrada.TabIndex = 84;
            this.BtnCancelaEntrada.Text = "Cancelar";
            this.BtnCancelaEntrada.UseVisualStyleBackColor = true;
            this.BtnCancelaEntrada.Click += new System.EventHandler(this.BtnCancelaEntrada_Click);
            // 
            // BtnExcluiEntrada
            // 
            this.BtnExcluiEntrada.Enabled = false;
            this.BtnExcluiEntrada.Location = new System.Drawing.Point(168, 16);
            this.BtnExcluiEntrada.Name = "BtnExcluiEntrada";
            this.BtnExcluiEntrada.Size = new System.Drawing.Size(75, 23);
            this.BtnExcluiEntrada.TabIndex = 83;
            this.BtnExcluiEntrada.Text = "Excluir";
            this.BtnExcluiEntrada.UseVisualStyleBackColor = true;
            this.BtnExcluiEntrada.Click += new System.EventHandler(this.BtnExcluiEntrada_Click);
            // 
            // BtnEditaEntrada
            // 
            this.BtnEditaEntrada.Enabled = false;
            this.BtnEditaEntrada.Location = new System.Drawing.Point(87, 16);
            this.BtnEditaEntrada.Name = "BtnEditaEntrada";
            this.BtnEditaEntrada.Size = new System.Drawing.Size(75, 23);
            this.BtnEditaEntrada.TabIndex = 82;
            this.BtnEditaEntrada.Text = "Editar";
            this.BtnEditaEntrada.UseVisualStyleBackColor = true;
            this.BtnEditaEntrada.Click += new System.EventHandler(this.BtnEditaEntrada_Click);
            // 
            // BtnNovaEntrada
            // 
            this.BtnNovaEntrada.Location = new System.Drawing.Point(6, 16);
            this.BtnNovaEntrada.Name = "BtnNovaEntrada";
            this.BtnNovaEntrada.Size = new System.Drawing.Size(75, 23);
            this.BtnNovaEntrada.TabIndex = 81;
            this.BtnNovaEntrada.Text = "Novo";
            this.BtnNovaEntrada.UseVisualStyleBackColor = true;
            this.BtnNovaEntrada.Click += new System.EventHandler(this.BtnNovaEntrada_Click);
            // 
            // DgvEntrada
            // 
            this.DgvEntrada.AllowUserToAddRows = false;
            this.DgvEntrada.AllowUserToDeleteRows = false;
            this.DgvEntrada.AllowUserToResizeColumns = false;
            this.DgvEntrada.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvEntrada.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGOENTRADA,
            this.DATAENTRADA,
            this.VENCIMENTO,
            this.QTDE});
            this.DgvEntrada.Location = new System.Drawing.Point(6, 127);
            this.DgvEntrada.MultiSelect = false;
            this.DgvEntrada.Name = "DgvEntrada";
            this.DgvEntrada.ReadOnly = true;
            this.DgvEntrada.RowHeadersVisible = false;
            this.DgvEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEntrada.Size = new System.Drawing.Size(383, 500);
            this.DgvEntrada.TabIndex = 66;
            this.DgvEntrada.SelectionChanged += new System.EventHandler(this.DgvEntrada_SelectionChanged);
            // 
            // CODIGOENTRADA
            // 
            this.CODIGOENTRADA.DataPropertyName = "Codigo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODIGOENTRADA.DefaultCellStyle = dataGridViewCellStyle5;
            this.CODIGOENTRADA.HeaderText = "Entrada";
            this.CODIGOENTRADA.Name = "CODIGOENTRADA";
            this.CODIGOENTRADA.ReadOnly = true;
            this.CODIGOENTRADA.Width = 80;
            // 
            // DATAENTRADA
            // 
            this.DATAENTRADA.DataPropertyName = "DataEntrada";
            this.DATAENTRADA.HeaderText = "Data";
            this.DATAENTRADA.Name = "DATAENTRADA";
            this.DATAENTRADA.ReadOnly = true;
            this.DATAENTRADA.Width = 110;
            // 
            // VENCIMENTO
            // 
            this.VENCIMENTO.DataPropertyName = "DataVencimento";
            this.VENCIMENTO.HeaderText = "Vencimento";
            this.VENCIMENTO.Name = "VENCIMENTO";
            this.VENCIMENTO.ReadOnly = true;
            this.VENCIMENTO.Width = 110;
            // 
            // QTDE
            // 
            this.QTDE.DataPropertyName = "Qtde";
            this.QTDE.HeaderText = "Qtde";
            this.QTDE.Name = "QTDE";
            this.QTDE.ReadOnly = true;
            this.QTDE.Width = 60;
            // 
            // GbxSaida
            // 
            this.GbxSaida.Controls.Add(this.DgvSaida);
            this.GbxSaida.Location = new System.Drawing.Point(861, 40);
            this.GbxSaida.Name = "GbxSaida";
            this.GbxSaida.Size = new System.Drawing.Size(395, 633);
            this.GbxSaida.TabIndex = 1;
            this.GbxSaida.TabStop = false;
            // 
            // DgvSaida
            // 
            this.DgvSaida.AllowUserToAddRows = false;
            this.DgvSaida.AllowUserToDeleteRows = false;
            this.DgvSaida.AllowUserToResizeColumns = false;
            this.DgvSaida.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvSaida.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSaida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSaida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGOUM,
            this.DATASAIDA,
            this.VALORUM,
            this.QTDEUM});
            this.DgvSaida.Location = new System.Drawing.Point(6, 16);
            this.DgvSaida.MultiSelect = false;
            this.DgvSaida.Name = "DgvSaida";
            this.DgvSaida.RowHeadersVisible = false;
            this.DgvSaida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSaida.Size = new System.Drawing.Size(383, 611);
            this.DgvSaida.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Cadastro de Produtos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(542, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Histórico de Entrada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(982, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 68;
            this.label7.Text = "Histórico de Saída";
            // 
            // CODIGOUM
            // 
            this.CODIGOUM.DataPropertyName = "Codigo";
            this.CODIGOUM.HeaderText = "Codigo";
            this.CODIGOUM.Name = "CODIGOUM";
            this.CODIGOUM.ReadOnly = true;
            // 
            // DATASAIDA
            // 
            this.DATASAIDA.DataPropertyName = "DataPedido";
            this.DATASAIDA.HeaderText = "DataPedido";
            this.DATASAIDA.Name = "DATASAIDA";
            this.DATASAIDA.ReadOnly = true;
            this.DATASAIDA.Width = 110;
            // 
            // VALORUM
            // 
            this.VALORUM.DataPropertyName = "Valor";
            this.VALORUM.HeaderText = "Valor";
            this.VALORUM.Name = "VALORUM";
            this.VALORUM.ReadOnly = true;
            this.VALORUM.Width = 90;
            // 
            // QTDEUM
            // 
            this.QTDEUM.DataPropertyName = "Qtde";
            this.QTDEUM.HeaderText = "Qtde";
            this.QTDEUM.Name = "QTDEUM";
            this.QTDEUM.ReadOnly = true;
            this.QTDEUM.Width = 60;
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 685);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GbxSaida);
            this.Controls.Add(this.GbxEntrada);
            this.Controls.Add(this.GbxProduto);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque de Produtos";
            this.Load += new System.EventHandler(this.FrmEstoque_Load);
            this.GbxProduto.ResumeLayout(false);
            this.GbxProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduto)).EndInit();
            this.GbxEntrada.ResumeLayout(false);
            this.GbxEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEntrada)).EndInit();
            this.GbxSaida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxProduto;
        private System.Windows.Forms.GroupBox GbxEntrada;
        private System.Windows.Forms.GroupBox GbxSaida;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtQtde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigoProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.DataGridView DgvProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CbxEstoque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DtpVencimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DtpDataEntrada;
        private System.Windows.Forms.TextBox TxtQtdeEntrada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnConfirmarEntrada;
        private System.Windows.Forms.Button BtnCancelaEntrada;
        private System.Windows.Forms.Button BtnExcluiEntrada;
        private System.Windows.Forms.Button BtnEditaEntrada;
        private System.Windows.Forms.Button BtnNovaEntrada;
        private System.Windows.Forms.DataGridView DgvEntrada;
        private System.Windows.Forms.DataGridView DgvSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTDEATUAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGOENTRADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATAENTRADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn VENCIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTDE;
        private System.Windows.Forms.Label LblCodigoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGOUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATASAIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALORUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTDEUM;
    }
}