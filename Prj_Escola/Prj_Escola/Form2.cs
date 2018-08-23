using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prj_Escola
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora : " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblData.Text = "Data : " + DateTime.Now.ToString("dd/MM/yyyy");

            lblHora.Text = "Hora : " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadAluno frmAluno = new cadAluno();
            frmAluno.MdiParent = this;

            frmAluno.Show();
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadDisciplina frmDis = new frmCadDisciplina();
            frmDis.MdiParent = this;

            frmDis.Show();
        }

        private void btnCadDisciplina_Click(object sender, EventArgs e)
        {
            frmCadDisciplina frmDis = new frmCadDisciplina();
            frmDis.MdiParent = this;

            frmDis.Show();
        }

        private void btnCadAluno_Click(object sender, EventArgs e)
        {
            cadAluno frmAluno = new cadAluno();
            frmAluno.MdiParent = this;

            frmAluno.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Conexao.fecharConexao();
            else
            {
                e.Cancel = true;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Cons_Cad_Disc frmconDis = new frm_Cons_Cad_Disc();
            frmconDis.MdiParent = this;

            frmconDis.Show();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Cons_Cad_Aluno frmconAlu = new frm_Cons_Cad_Aluno();
            frmconAlu.MdiParent = this;

            frmconAlu.Show();
        }

        private void btnConsultaAluno_Click(object sender, EventArgs e)
        {
            frm_Cons_Cad_Aluno frmconAlu = new frm_Cons_Cad_Aluno();
            frmconAlu.MdiParent = this;

            frmconAlu.Show();
        }

        private void desenvolvedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmSobre = new frmSobre();
            frmSobre.MdiParent = this;

            frmSobre.Show();
        }
    }
}
