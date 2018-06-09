using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jogo_da_memoria
{
    public partial class FrmMemoria : Form
    {
        public FrmMemoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memoria frmcap = new memoria();
            frmcap.MdiParent = this;
            frmcap.Show();

            btnJogar.Visible = false;
            btnRegras.Visible = false;
        }

        private void btnRegras_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
