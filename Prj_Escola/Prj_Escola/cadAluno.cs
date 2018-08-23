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
    public partial class cadAluno : Form
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
                dgvAluno.DataSource = bs_Alunos;
                igualar_text();
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void igualar_text()
        {
            lblMatricula.DataBindings.Add("Text", bs_Alunos, "Matricula");
            lblMatricula.DataBindings.Clear();

            txtNome.DataBindings.Add("Text", bs_Alunos, "Nome");
            txtNome.DataBindings.Clear();

            mktNasc.DataBindings.Add("Text", bs_Alunos, "Nasc");
            mktNasc.DataBindings.Clear();

            txtEndereco.DataBindings.Add("Text", bs_Alunos, "Endereco");
            txtEndereco.DataBindings.Clear();

            txtNumero.DataBindings.Add("Text", bs_Alunos, "numero");
            txtNumero.DataBindings.Clear();

            txtBairro.DataBindings.Add("Text", bs_Alunos, "bairro");
            txtBairro.DataBindings.Clear();

            txtCidade.DataBindings.Add("Text", bs_Alunos, "cidade");
            txtCidade.DataBindings.Clear();

            mktCEP.DataBindings.Add("Text", bs_Alunos, "cep");
            mktCEP.DataBindings.Clear();

            mktRg.DataBindings.Add("Text", bs_Alunos, "RG");
            mktRg.DataBindings.Clear();

            mktCPF.DataBindings.Add("Text", bs_Alunos, "cpf");
            mktCPF.DataBindings.Clear();

            mktTel.DataBindings.Add("Text", bs_Alunos, "telefone");
            mktTel.DataBindings.Clear();

            cbSexo.DataBindings.Add("Text", bs_Alunos, "sexo");
            cbSexo.DataBindings.Clear();
        }

        public cadAluno()
        {
            InitializeComponent();
        }

        private void cadAluno_Load(object sender, EventArgs e)
        {
            carregar_grid(); 
        }

        private void dgvAluno_Click(object sender, EventArgs e)
        {
            igualar_text();
        }

        private void dgvAluno_KeyUp(object sender, KeyEventArgs e)
        {
            igualar_text();
        }

        // Inicio do Controle do DGV

        private void btn_primeiro_Click(object sender, EventArgs e)
        {
            bs_Alunos.MoveFirst();
            igualar_text();
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            bs_Alunos.MoveLast();
            igualar_text();
        }

        private void btn_proximo_Click(object sender, EventArgs e)
        {

            if (bs_Alunos.Count == bs_Alunos.Position + 1)
                MessageBox.Show("Fim de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            else
                bs_Alunos.MoveNext();
            igualar_text();    
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            if (bs_Alunos.Position == 0)
                MessageBox.Show("Inicio de arquivo encontrado !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_Alunos.MovePrevious();
            igualar_text();
        }

        // Fim do controle do dgv

        // ******************** ROTINAS ****************************** //

        // Rotina para o botão limpar

        private void limpar()
        {
            lblMatricula.Text = "";
            txtNome.Clear();
            mktNasc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mktCEP.Clear();
            mktRg.Clear();
            mktCPF.Clear();
            mktTel.Clear();
            cbSexo.Text = "";
        }

        // **** Rotina criada para validar a digitação

        private bool valida()
        {
            bool erro = true;
            if (txtNome.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
            }

            else if (txtEndereco.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEndereco.Focus();
            }

            else if (cbSexo.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbSexo.Focus();
            }

            else if (mktCEP.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mktCEP.Focus();
            }

            else if (mktRg.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mktRg.Focus();
            }

            else if (mktCPF.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mktCPF.Focus();
            }

            else if (txtEndereco.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEndereco.Focus();
            }

            else if (mktTel.Text == "")
            {
                MessageBox.Show("Campo Vazio ou invalido, por favor, Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mktTel.Focus();
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
            txtNome.Focus();
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
                _query = "Insert into Alunos (Nome,Nasc,Endereco,numero,bairro,cidade,cep,RG,cpf,telefone,sexo) Values ";
                _query += "('" + txtNome.Text + "','" + mktNasc.Text + "','" + txtEndereco.Text +
                    "','" + txtNumero.Text + "','" + txtBairro.Text + "','" + txtCidade.Text +
                    "','" + mktCEP.Text + "','" + mktRg.Text + "','" + mktCPF.Text +
                    "','" + mktTel.Text + "','" + cbSexo.Text + "')";
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
                _query = "Update Alunos set Nome ='" + txtNome.Text + "',";
                _query += "Nasc = '" + mktNasc.Text + "',";
                _query += "Endereco = '" + txtEndereco.Text + "',";
                _query += "numero = '" + txtNumero.Text + "',";
                _query += "bairro = '" + txtBairro.Text + "',";
                _query += "cidade = '" + txtCidade.Text + "',";
                _query += "cep = '" + mktCEP.Text + "',";
                _query += "RG = '" + mktRg.Text + "',";
                _query += "cpf = '" + mktCPF.Text + "',";
                _query += "telefone = '" + mktTel.Text + "',";
                _query += "sexo = '" + cbSexo.Text + "'";
                _query += "where Matricula like '" + lblMatricula.Text + "'";

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
            _query = "delete from Alunos where Matricula like '" + lblMatricula.Text + "'";
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

        private void cadAluno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Conexao.fecharConexao();
            else
            {
                e.Cancel = true;
            }
        }

        private void txtPesqendereco_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Alunos where Endereco like '" + txtPesqendereco.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Alunos = _dataCommand.ExecuteReader();

            if (dr_Alunos.HasRows == true)
            {
                bs_Alunos.DataSource = dr_Alunos;
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastradas com este Endereço !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesqendereco.Text = "";
            }
        }

        private void txtPesqNomeAl_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Alunos where Nome like '" + txtPesqNomeAl.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_Alunos = _dataCommand.ExecuteReader();

            if (dr_Alunos.HasRows == true)
            {
                bs_Alunos.DataSource = dr_Alunos;
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados com este Nome !!!!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesqNomeAl.Text = "";
            }
        }

      
    }
}
