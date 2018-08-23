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
    public partial class frm_Cons_Cad_Aluno : Form
    {

        //Conectar através da classe Conexao
        OleDbConnection conn = Conexao.obterConexao();
        //Declare o DataReader  -- tabela virtual somente leitura
        OleDbDataReader dr_Alunos;
        //Declare o BindingSource -- tabela virtual editável
        BindingSource bs_Alunos = new BindingSource();
        // cria a variavel que receberá a query (comando sql)
        String _query;


        private void carregar_grid()
        {
            //Determine a query desejada
            _query = "Select * from Alunos";
            //declare o objeto DataCommand passando a query e o objeto de conexão
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            //execute o método ExecuteReader que retornará um DataReader preenchido com a query
            dr_Alunos = _dataCommand.ExecuteReader();
            //Teste para verificar se retornaram linhas
            if (dr_Alunos.HasRows == true)
            {
                bs_Alunos.DataSource = dr_Alunos;
                dgvAlunoI.DataSource = bs_Alunos;              
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frm_Cons_Cad_Aluno()
        {
            InitializeComponent();
        }

        private void frm_Cons_Cad_Aluno_Load(object sender, EventArgs e)
        {        
            carregar_grid(); 
        }

        private void txt_Pesq_TextChanged(object sender, EventArgs e)
        {          

            if (cmb_Escolha.Text == "Codigo Aluno")
            {
                _query = "Select * from Alunos where Matricula like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Nome")
            {
                _query = "Select * from Alunos where Nome like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Nascimento")
            {
                _query = "Select * from Alunos where Nasc like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Endereco")
            {
                _query = "Select * from Alunos where Endereco like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Numero")
            {
                _query = "Select * from Alunos where numero like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Bairro")
            {
                _query = "Select * from Alunos where bairro like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Cidade")
            {
                _query = "Select * from Alunos where cidade like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "CEP")
            {
                _query = "Select * from Alunos where cep like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "RG")
            {
                _query = "Select * from Alunos where RG like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Telefone")
            {
                _query = "Select * from Alunos where telefone like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "CPF")
            {
                _query = "Select * from Alunos where cpf like '" + txt_Pesq.Text + "%'";
            }

            else if (cmb_Escolha.Text == "Sexo")
            {
                _query = "Select * from Alunos where sexo like '" + txt_Pesq.Text + "%'";
            }

            else{
                MessageBox.Show("Escolha um Campo para Pesquisar !!!!", "Atenção",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_Escolha.Focus();
            }

            txt_Pesq.Focus();
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Alunos = _dataCommand.ExecuteReader();

            if (dr_Alunos.HasRows == true)
            {
                bs_Alunos.DataSource = dr_Alunos;
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados com este Parametro !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Pesq.Text = "";
            }
        }

        private void btn_QuantSelecionados_Click(object sender, EventArgs e)
        {
            int a = bs_Alunos.Count;
            MessageBox.Show("Quantidade: " + a, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void frm_Cons_Cad_Aluno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Conexao.fecharConexao();
            else
            {
                e.Cancel = true;
            }
        }

        private void prDocAluno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow linha;
            linha = dgvAlunoI.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("logo-etec.PNG"), 50, 25); // Coluna - Linha
            e.Graphics.DrawImage(Image.FromFile("r.JPEG"), 300, 500);
            // texto = objimpressao.DrawString(string,fonte,cor,coluna,linha)
            e.Graphics.DrawString("FICHA INDIVIDUAL DO ALUNO", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Red, 400, 85);
            //linha – cor, espessura, posição x – ponto inicial(coluna e linha), posição y – ponto final (coluna e linha)

            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 110, 800, 110);
           
            e.Graphics.DrawString("CÓDIGO DO ALUNO: " + linha.Cells["Matricula"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 130);

            e.Graphics.DrawString("NOME: " + linha.Cells["Nome"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 150);
       
            e.Graphics.DrawString("NASCIMENTO: " + linha.Cells["Nasc"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 170);

            e.Graphics.DrawString("ENDERECO:  " + linha.Cells["Endereco"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 190);

            e.Graphics.DrawString("NUMERO: " + linha.Cells["numero"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 210);
       
            e.Graphics.DrawString("BAIRRO: " + linha.Cells["bairro"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 230);

            e.Graphics.DrawString("CIDADE: " + linha.Cells["cidade"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 250);

            e.Graphics.DrawString("CEP: " + linha.Cells["cep"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 270);
       
            e.Graphics.DrawString("RG: " + linha.Cells["RG"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 290);

            e.Graphics.DrawString("TELEFONE: " + linha.Cells["Telefone"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 310);

            e.Graphics.DrawString("CPF: " + linha.Cells["CPF"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 330);
       
            e.Graphics.DrawString("SEXO: " + linha.Cells["Sexo"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 350);

            e.Graphics.DrawString("Assinatura do Professor", new System.Drawing.Font("Segoe Print", 14, FontStyle.Bold), Brushes.Black, 50, 1100);
            e.Graphics.DrawLine(new Pen(Color.Red, 1), 50, 1100, 300, 1100);

            e.Graphics.DrawString("Assinatura do Coordenador", new System.Drawing.Font("Segoe Print", 14, FontStyle.Bold), Brushes.Black, 520, 1100);
            e.Graphics.DrawLine(new Pen(Color.Red, 1), 500, 1100, 800, 1100);

            // Marca d'agua
            //Graphics g = e.Graphics;
            //g.TranslateTransform(200, 200);
            //g.RotateTransform(e.PageSettings.Landscape ? 30 : 60);
            //g.DrawString("Teste", new Font("Arial", 75, FontStyle.Bold),
                        // new SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0);

            
        }

        private void btn_Visualizar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Text = " Visualizando a impressão";   // título da janela
            printPreviewDialog1.WindowState = FormWindowState.Maximized;  // status da janela do preview
            printPreviewDialog1.PrintPreviewControl.Columns = 2;   //  quantas páginas serão mostradas na tela
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.6;   //  zoom inicial do preview
            printPreviewDialog1.ShowDialog();

        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            prDocAluno.Print();                             

        }
    }
}
                          