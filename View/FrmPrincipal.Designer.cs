namespace View {
    partial class FrmPrincipal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pbxQuarto1 = new System.Windows.Forms.PictureBox();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnQuarto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQuarto1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxQuarto1
            // 
            this.pbxQuarto1.Location = new System.Drawing.Point(486, 68);
            this.pbxQuarto1.Name = "pbxQuarto1";
            this.pbxQuarto1.Size = new System.Drawing.Size(73, 64);
            this.pbxQuarto1.TabIndex = 0;
            this.pbxQuarto1.TabStop = false;
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(138, 316);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(75, 23);
            this.btnProduto.TabIndex = 1;
            this.btnProduto.Text = "Produto";
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnQuarto
            // 
            this.btnQuarto.Location = new System.Drawing.Point(226, 154);
            this.btnQuarto.Name = "btnQuarto";
            this.btnQuarto.Size = new System.Drawing.Size(75, 23);
            this.btnQuarto.TabIndex = 2;
            this.btnQuarto.Text = "Quarto";
            this.btnQuarto.UseVisualStyleBackColor = true;
            this.btnQuarto.Click += new System.EventHandler(this.btnQuarto_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuarto);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.pbxQuarto1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxQuarto1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxQuarto1;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnQuarto;
        private System.Windows.Forms.Button button1;
    }
}