namespace View
{
    partial class FrmLimpeza
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
            this.label1 = new System.Windows.Forms.Label();
            this.NudQuartoNumero = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDataLimpeza = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.DtpHoraLimpeza = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudQuartoNumero)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quarto Nº";
            // 
            // NudQuartoNumero
            // 
            this.NudQuartoNumero.Enabled = false;
            this.NudQuartoNumero.Location = new System.Drawing.Point(126, 54);
            this.NudQuartoNumero.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NudQuartoNumero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudQuartoNumero.Name = "NudQuartoNumero";
            this.NudQuartoNumero.ReadOnly = true;
            this.NudQuartoNumero.Size = new System.Drawing.Size(107, 26);
            this.NudQuartoNumero.TabIndex = 1;
            this.NudQuartoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudQuartoNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data Limpeza";
            // 
            // DtpDataLimpeza
            // 
            this.DtpDataLimpeza.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDataLimpeza.Location = new System.Drawing.Point(126, 88);
            this.DtpDataLimpeza.Name = "DtpDataLimpeza";
            this.DtpDataLimpeza.Size = new System.Drawing.Size(107, 26);
            this.DtpDataLimpeza.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCodigo);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnConfirmar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpHoraLimpeza);
            this.groupBox1.Controls.Add(this.NudQuartoNumero);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DtpDataLimpeza);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Location = new System.Drawing.Point(10, 20);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(223, 19);
            this.TxtCodigo.TabIndex = 5;
            this.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AutoSize = true;
            this.BtnCancelar.Location = new System.Drawing.Point(6, 156);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 30);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.AutoSize = true;
            this.BtnConfirmar.Location = new System.Drawing.Point(156, 156);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(88, 30);
            this.BtnConfirmar.TabIndex = 0;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // DtpHoraLimpeza
            // 
            this.DtpHoraLimpeza.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpHoraLimpeza.Location = new System.Drawing.Point(126, 122);
            this.DtpHoraLimpeza.Name = "DtpHoraLimpeza";
            this.DtpHoraLimpeza.Size = new System.Drawing.Size(107, 26);
            this.DtpHoraLimpeza.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hora Limpeza";
            // 
            // FrmLimpeza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 209);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLimpeza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Limpeza";
            this.Load += new System.EventHandler(this.FrmLimpeza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudQuartoNumero)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudQuartoNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDataLimpeza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.DateTimePicker DtpHoraLimpeza;
        private System.Windows.Forms.Label label3;
    }
}