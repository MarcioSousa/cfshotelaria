namespace Hotelaria
{
    partial class FrmQuarto
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuarto));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvQuarto = new System.Windows.Forms.DataGridView();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalidade = new System.Windows.Forms.TextBox();
            this.txtValorDiaria = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.gbxDados = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.epNumero = new System.Windows.Forms.ErrorProvider(this.components);
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDiaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCALIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarto)).BeginInit();
            this.gbxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvQuarto);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvQuarto
            // 
            this.dgvQuarto.AllowUserToAddRows = false;
            this.dgvQuarto.AllowUserToDeleteRows = false;
            this.dgvQuarto.AllowUserToResizeColumns = false;
            this.dgvQuarto.AllowUserToResizeRows = false;
            this.dgvQuarto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuarto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuarto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMERO,
            this.ValorDiaria,
            this.LOCALIDADE});
            this.dgvQuarto.Location = new System.Drawing.Point(6, 19);
            this.dgvQuarto.MultiSelect = false;
            this.dgvQuarto.Name = "dgvQuarto";
            this.dgvQuarto.RowHeadersVisible = false;
            this.dgvQuarto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuarto.Size = new System.Drawing.Size(430, 384);
            this.dgvQuarto.TabIndex = 0;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.AutoSize = true;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(346, 57);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(76, 23);
            this.btnCadastrar.TabIndex = 3;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(255, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Localidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor da Diária";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número";
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidade.Location = new System.Drawing.Point(258, 31);
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.Size = new System.Drawing.Size(164, 20);
            this.txtLocalidade.TabIndex = 2;
            this.txtLocalidade.TextChanged += new System.EventHandler(this.txtLocalidade_TextChanged);
            // 
            // txtValorDiaria
            // 
            this.txtValorDiaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDiaria.Location = new System.Drawing.Point(115, 31);
            this.txtValorDiaria.Name = "txtValorDiaria";
            this.txtValorDiaria.Size = new System.Drawing.Size(118, 20);
            this.txtValorDiaria.TabIndex = 1;
            this.txtValorDiaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDiaria.TextChanged += new System.EventHandler(this.txtValorDiaria_TextChanged);
            this.txtValorDiaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDiaria_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(20, 31);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(70, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // gbxDados
            // 
            this.gbxDados.Controls.Add(this.label1);
            this.gbxDados.Controls.Add(this.btnCadastrar);
            this.gbxDados.Controls.Add(this.btnExcluir);
            this.gbxDados.Controls.Add(this.btnAlterar);
            this.gbxDados.Controls.Add(this.txtValorDiaria);
            this.gbxDados.Controls.Add(this.txtNumero);
            this.gbxDados.Controls.Add(this.txtLocalidade);
            this.gbxDados.Controls.Add(this.label3);
            this.gbxDados.Controls.Add(this.label2);
            this.gbxDados.Location = new System.Drawing.Point(12, 12);
            this.gbxDados.Name = "gbxDados";
            this.gbxDados.Size = new System.Drawing.Size(442, 90);
            this.gbxDados.TabIndex = 0;
            this.gbxDados.TabStop = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(103, 57);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(76, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(21, 57);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(76, 23);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // epNumero
            // 
            this.epNumero.ContainerControl = this;
            // 
            // NUMERO
            // 
            this.NUMERO.DataPropertyName = "numero";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.NUMERO.DefaultCellStyle = dataGridViewCellStyle1;
            this.NUMERO.HeaderText = "Número";
            this.NUMERO.Name = "NUMERO";
            this.NUMERO.ReadOnly = true;
            // 
            // ValorDiaria
            // 
            this.ValorDiaria.DataPropertyName = "valordiaria";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ValorDiaria.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValorDiaria.HeaderText = "Valor Diária";
            this.ValorDiaria.Name = "ValorDiaria";
            this.ValorDiaria.ReadOnly = true;
            // 
            // LOCALIDADE
            // 
            this.LOCALIDADE.DataPropertyName = "localidade";
            this.LOCALIDADE.HeaderText = "Localidade";
            this.LOCALIDADE.Name = "LOCALIDADE";
            this.LOCALIDADE.ReadOnly = true;
            this.LOCALIDADE.Width = 200;
            // 
            // FrmQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 529);
            this.Controls.Add(this.gbxDados);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuarto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário de Cadastro de Quartos";
            this.Load += new System.EventHandler(this.FrmQuarto_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarto)).EndInit();
            this.gbxDados.ResumeLayout(false);
            this.gbxDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNumero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvQuarto;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalidade;
        private System.Windows.Forms.TextBox txtValorDiaria;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.GroupBox gbxDados;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.ErrorProvider epNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDiaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCALIDADE;
    }
}