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
    public partial class frmCadDisciplina : Form
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
                dgvDisciplina.DataSource = bs_Dis;
                igualar_text();
            }
            else
            {
                MessageBox.Show("Não temos Disciplinas cadastradas !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void igualar_text()
        {
            lblCodDis.DataBindings.Add("Text", bs_Dis, "cod_disciplina");
            lblCodDis.DataBindings.Clear();

            txtDesc.DataBindings.Add("Text", bs_Dis, "descricao");
            txtDesc.DataBindings.Clear();

            txtSigla.DataBindings.Add("Text", bs_Dis, "sigla");
            txtSigla.DataBindings.Clear();

            txtSerie.DataBindings.Add("Text", bs_Dis, "série");
            txtSerie.DataBindings.Clear();
        }


        public frmCadDisciplina()
        {
            InitializeComponent();
        }

        private void frmCadDisciplina_Load(object sender, EventArgs e)
        {
            carregar_grid(); 
        }

        private void dgvDisciplina_Click(object sender, EventArgs e)
        {
            igualar_text();
        }

        private void dgvDisciplina_KeyUp(object sender, KeyEventArgs e)
        {
            igualar_text();
        }

        private void btn_primeiro_Click(object sender, EventArgs e)
        {
            bs_Dis.MoveFirst();
            igualar_text();
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            bs_Dis.MoveLast();
            igualar_text();
        }

        private void btn_proximo_Click(object sender, EventArgs e)
        {
            if (bs_Dis.Count == bs_Dis.Position + 1)
                MessageBox.Show("Fim de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            else
                bs_Dis.MoveNext();
            igualar_text(); 
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            if (bs_Dis.Position == 0)
                MessageBox.Show("Inicio de arquivo encontrado !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_Dis.MovePrevious();
            igualar_text();
        }

        // ******************** ROTINAS ****************************** //

        // Rotina para o botão limpar

        private void limpar()
        {
            lblCodDis.Text = "";
            txtDesc.Clear();
            txtSigla.Clear();
            txtSerie.Clear();
          
        }

        // **** Rotina criada para validar a digitação

        private bool valida()
        {
            bool erro = true;
            if (txtDesc.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDesc.Focus();
            }

            else if (txtSigla.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSigla.Focus();
            }

            else if (txtSerie.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSerie.Focus();
            }
            else
            {
                erro = false;
            }
            return erro;
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            limpar();
            txtDesc.Focus();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btn_incluir_Click(object sender, EventArgs e)
        {

            bool teste;
            teste = valida();
            if (teste == false)
            {
                _query = "Insert into Disciplinas (descricao,sigla,série) Values ";
                _query += "('" + txtDesc.Text + "','" + txtSigla.Text + "','" + txtSerie.Text +"')";
                try
                {
                    OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                    _dataCommand.ExecuteNonQuery();
                    carregar_grid();
                    MessageBox.Show("Incluido com sucesso !!!!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception)
                {
                    MessageBox.Show("Problemas com a Inclusão  !!!!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            bool teste;
            teste = valida();
            if (teste == false)
            {
                _query = "Update Disciplinas set descricao ='" + txtDesc.Text + "',";
                _query += "sigla = '" + txtSigla.Text + "',";
                _query += "série = '" + txtSerie.Text + "'";
                _query += "where cod_disciplina like '" + lblCodDis.Text + "'";

                try
                {
                    OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                    _dataCommand.ExecuteNonQuery();
                    carregar_grid();

                    MessageBox.Show("Alterado com sucesso !!!!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception)
                {
                    MessageBox.Show("Problemas com a Alteração  !!!!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            _query = "delete from Disciplinas where cod_disciplina like '" + lblCodDis.Text + "'";
            try
            {
                OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                _dataCommand.ExecuteNonQuery();
                carregar_grid();
                MessageBox.Show("Excluido com sucesso !!!!", "Exclusão",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas com a Exclusão!!!!", "Exclusão",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }

        private void frmCadDisciplina_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Conexao.fecharConexao();
            else
            {
                e.Cancel = true;
            }
        }

        private void txtPesqCodDis_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Disciplinas where cod_disciplina like '" + txtPesqCodDis.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Dis = _dataCommand.ExecuteReader();

            if (dr_Dis.HasRows == true)
            {
                bs_Dis.DataSource = dr_Dis;
            }
            else
            {
                MessageBox.Show("Não temos Disciplinas cadastradas com este Codigo !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesqCodDis.Text = "";
            }
        }

        private void txtPesqSigla_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Disciplinas where sigla like '" + txtPesqSigla.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Dis = _dataCommand.ExecuteReader();

            if (dr_Dis.HasRows == true)
            {
                bs_Dis.DataSource = dr_Dis;
            }
            else
            {
                MessageBox.Show("Não temos Disciplinas cadastradas com esta Sigla !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesqSigla.Text = "";
            }
        }

    }
}
