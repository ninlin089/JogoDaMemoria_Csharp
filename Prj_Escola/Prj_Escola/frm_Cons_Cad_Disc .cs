using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace Prj_Escola
{
    public partial class frm_Cons_Cad_Disc : Form
    {

        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_Dis;
        BindingSource bs_Dis = new BindingSource();
        String _query;


        private void carregar_grid()
        {
            _query = "Select * from Disciplinas";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Dis = _dataCommand.ExecuteReader();
            if (dr_Dis.HasRows == true)
            {
                bs_Dis.DataSource = dr_Dis;
                dgvDisciplinaI.DataSource = bs_Dis;
            }
            else
            {
                MessageBox.Show("Não temos Disciplinas cadastradas !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       

        public frm_Cons_Cad_Disc()
        {
            InitializeComponent();
        }

        private void frm_Cons_Cad_Disc_Load(object sender, EventArgs e)
        {
            carregar_grid(); 
        }

        private void txt_Pesq_TextChanged(object sender, EventArgs e)
        {
            if (cmb_Escolha.Text == "Sigla") {
                _query = "Select * from Disciplinas where sigla like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Código da Disciplina") {
                _query = "Select * from Disciplinas where cod_disciplina like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Descrição") {
                _query = "Select * from Disciplinas where descricao like '" + txt_Pesq.Text + "%'";
            }

            else{
                MessageBox.Show("Escolha um Campo para Pesquisar !!!!", "Atenção",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_Escolha.Focus();
            }

            txt_Pesq.Focus();
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Dis = _dataCommand.ExecuteReader();

            if (dr_Dis.HasRows == true)
            {
                bs_Dis.DataSource = dr_Dis;
            }
            else
            {
                MessageBox.Show("Não temos Disciplinas cadastradas com este Paramentro !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Pesq.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = bs_Dis.Count;
            MessageBox.Show("Quantidade: " + a, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void frm_Cons_Cad_Disc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Conexao.fecharConexao();
            else
            {
                e.Cancel = true;
            }
        }

        private void prDocDis_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow linha;
            linha = dgvDisciplinaI.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("logo-etec.PNG"), 50, 25);
            e.Graphics.DrawImage(Image.FromFile("r.JPEG"), 300, 500);
            // texto = objimpressao.DrawString(string,fonte,cor,coluna,linha)
            e.Graphics.DrawString("FICHA INDIVIDUAL DE DISCIPLINA", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Red, 400, 85);
            //linha – cor, espessura, posição x – ponto inicial(coluna e linha), posição y – ponto final (coluna e linha)

            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 110, 800, 110);
            // código
            e.Graphics.DrawString("CÓDIGO DA DISCIPLINA:  " + linha.Cells["cod_disciplina"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 130);
            // descrição
            e.Graphics.DrawString("DESCRIÇÃO:   " + linha.Cells["descricao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 150);
            // sigla
            e.Graphics.DrawString("SIGLA : " + linha.Cells["sigla"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 170);

            e.Graphics.DrawString("Assinatura do Professor", new System.Drawing.Font("Segoe Print", 14, FontStyle.Bold), Brushes.Black, 50, 1100);
            e.Graphics.DrawLine(new Pen(Color.Red, 1), 50, 1100, 300, 1100);

            e.Graphics.DrawString("Assinatura do Coordenador", new System.Drawing.Font("Segoe Print", 14, FontStyle.Bold), Brushes.Black, 520, 1100);
            e.Graphics.DrawLine(new Pen(Color.Red, 1), 500, 1100, 800, 1100);

        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            prDocDis.Print();                             

        }

        private void btn_Visualizar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Text = " Visualizando a impressão";         // Título da janela
            printPreviewDialog1.WindowState = FormWindowState.Maximized;   // Status da janela do preview
            printPreviewDialog1.PrintPreviewControl.Columns = 2;          // Quantas páginas serão mostradas na tela
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.6;          // Zoom inicial do preview
            printPreviewDialog1.ShowDialog();

        }
    }
}
