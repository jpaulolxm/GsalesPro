namespace GsalesPro
{
    partial class InstanciaLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanciaLocal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectCidade = new System.Windows.Forms.ListBox();
            this.selectEstado = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save_local_ins = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.selectCidade);
            this.panel1.Controls.Add(this.selectEstado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_save_local_ins);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 289);
            this.panel1.TabIndex = 0;
            // 
            // selectCidade
            // 
            this.selectCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectCidade.FormattingEnabled = true;
            this.selectCidade.ItemHeight = 16;
            this.selectCidade.Location = new System.Drawing.Point(131, 46);
            this.selectCidade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectCidade.Name = "selectCidade";
            this.selectCidade.Size = new System.Drawing.Size(252, 226);
            this.selectCidade.TabIndex = 37;
            // 
            // selectEstado
            // 
            this.selectEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectEstado.FormattingEnabled = true;
            this.selectEstado.ItemHeight = 16;
            this.selectEstado.Location = new System.Drawing.Point(14, 46);
            this.selectEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectEstado.Name = "selectEstado";
            this.selectEstado.Size = new System.Drawing.Size(109, 226);
            this.selectEstado.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(127, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 35;
            this.label3.Text = "Cidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Estado:";
            // 
            // btn_save_local_ins
            // 
            this.btn_save_local_ins.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save_local_ins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_local_ins.Font = new System.Drawing.Font("Arial", 12F);
            this.btn_save_local_ins.ForeColor = System.Drawing.Color.White;
            this.btn_save_local_ins.Location = new System.Drawing.Point(235, 8);
            this.btn_save_local_ins.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_save_local_ins.Name = "btn_save_local_ins";
            this.btn_save_local_ins.Size = new System.Drawing.Size(148, 34);
            this.btn_save_local_ins.TabIndex = 33;
            this.btn_save_local_ins.Text = "Salvar";
            this.btn_save_local_ins.UseVisualStyleBackColor = false;
            this.btn_save_local_ins.Click += new System.EventHandler(this.btn_save_local_ins_Click);
            // 
            // InstanciaLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 388);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "InstanciaLocal";
            this.Padding = new System.Windows.Forms.Padding(23, 74, 23, 25);
            this.Resizable = false;
            this.Text = "Região";
            this.Load += new System.EventHandler(this.InstanciaLocal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox selectCidade;
        private System.Windows.Forms.ListBox selectEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save_local_ins;
    }
}