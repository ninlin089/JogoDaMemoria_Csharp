namespace Prj_Escola
{
    partial class frm_Cons_Cad_Aluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Cons_Cad_Aluno));
            this.btn_QuantSelecionados = new System.Windows.Forms.Button();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_Visualizar = new System.Windows.Forms.Button();
            this.dgvAlunoI = new System.Windows.Forms.DataGridView();
            this.txt_Pesq = new System.Windows.Forms.TextBox();
            this.cmb_Escolha = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.prDocAluno = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlunoI)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_QuantSelecionados
            // 
            this.btn_QuantSelecionados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_QuantSelecionados.Location = new System.Drawing.Point(171, 19);
            this.btn_QuantSelecionados.Name = "btn_QuantSelecionados";
            this.btn_QuantSelecionados.Size = new System.Drawing.Size(95, 62);
            this.btn_QuantSelecionados.TabIndex = 15;
            this.btn_QuantSelecionados.Text = "Quantidade de Selecionados";
            this.btn_QuantSelecionados.UseVisualStyleBackColor = false;
            this.btn_QuantSelecionados.Click += new System.EventHandler(this.btn_QuantSelecionados_Click);
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Imprimir.Location = new System.Drawing.Point(90, 19);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(75, 62);
            this.btn_Imprimir.TabIndex = 14;
            this.btn_Imprimir.Text = "Imprimir";
            this.btn_Imprimir.UseVisualStyleBackColor = false;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // btn_Visualizar
            // 
            this.btn_Visualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Visualizar.Location = new System.Drawing.Point(6, 19);
            this.btn_Visualizar.Name = "btn_Visualizar";
            this.btn_Visualizar.Size = new System.Drawing.Size(75, 62);
            this.btn_Visualizar.TabIndex = 13;
            this.btn_Visualizar.Text = "Visualizar";
            this.btn_Visualizar.UseVisualStyleBackColor = false;
            this.btn_Visualizar.Click += new System.EventHandler(this.btn_Visualizar_Click);
            // 
            // dgvAlunoI
            // 
            this.dgvAlunoI.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvAlunoI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlunoI.Location = new System.Drawing.Point(32, 122);
            this.dgvAlunoI.Name = "dgvAlunoI";
            this.dgvAlunoI.Size = new System.Drawing.Size(465, 150);
            this.dgvAlunoI.TabIndex = 12;
            // 
            // txt_Pesq
            // 
            this.txt_Pesq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_Pesq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pesq.Location = new System.Drawing.Point(345, 28);
            this.txt_Pesq.Name = "txt_Pesq";
            this.txt_Pesq.Size = new System.Drawing.Size(126, 20);
            this.txt_Pesq.TabIndex = 11;
            this.txt_Pesq.TextChanged += new System.EventHandler(this.txt_Pesq_TextChanged);
            // 
            // cmb_Escolha
            // 
            this.cmb_Escolha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmb_Escolha.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Escolha.FormattingEnabled = true;
            this.cmb_Escolha.Items.AddRange(new object[] {
            "Codigo Aluno",
            "Nome",
            "Nascimento",
            "Endereco",
            "Numero",
            "Bairro",
            "Cidade",
            "CEP",
            "RG",
            "CPF",
            "Telefone",
            "Sexo"});
            this.cmb_Escolha.Location = new System.Drawing.Point(201, 27);
            this.cmb_Escolha.Name = "cmb_Escolha";
            this.cmb_Escolha.Size = new System.Drawing.Size(121, 23);
            this.cmb_Escolha.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Escolha o Campo a ser pesquisado";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btn_QuantSelecionados);
            this.groupBox1.Controls.Add(this.btn_Imprimir);
            this.groupBox1.Controls.Add(this.btn_Visualizar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(134, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 98);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controle";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_Escolha);
            this.groupBox2.Controls.Add(this.txt_Pesq);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 69);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisar";
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.prDocAluno;
            this.printDialog1.UseEXDialog = true;
            // 
            // prDocAluno
            // 
            this.prDocAluno.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prDocAluno_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.prDocAluno;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frm_Cons_Cad_Aluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(547, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAlunoI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Cons_Cad_Aluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Aluno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Cons_Cad_Aluno_FormClosing);
            this.Load += new System.EventHandler(this.frm_Cons_Cad_Aluno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlunoI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_QuantSelecionados;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Visualizar;
        private System.Windows.Forms.DataGridView dgvAlunoI;
        private System.Windows.Forms.TextBox txt_Pesq;
        private System.Windows.Forms.ComboBox cmb_Escolha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument prDocAluno;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}