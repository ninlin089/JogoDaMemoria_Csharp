﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Prj_Escola
{
    class Conexao
    {
        private static string connString = @"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=BD_Escola.accdb";
        private static OleDbConnection conn = null;



        public static OleDbConnection obterConexao()
        {
            conn = new OleDbConnection(connString);

            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                conn = null;
                MessageBox.Show("Conexão não estabelecida!!");

            }

            return conn;
        }

        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}
