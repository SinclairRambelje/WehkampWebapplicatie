using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseTestWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "User Id=dbi324175;Password=wgSZJnGDZe;Data Source=fhictora01.fhict.local:1521/fhictora;";
            


            string ConString1 = connectionstring;
            using (OracleConnection con = new OracleConnection(ConString1))
            {
                con.Open();
                string query = "select id from product where id = 1";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            button1.Text = reader["ID"].ToString();
                        }
                    }
                }
            }

        }
    }
}
