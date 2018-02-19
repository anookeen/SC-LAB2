using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        String s;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = comboBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new  MySqlConnection("Server=localhost;Database=library_databse;UID=root;Password=seecs@123");
            String query = "";
            String y = textBox1.Text;
           
            if (s == "genre")
            {
                query = "SELECT name FROM artifact WHERE genre LIKE '" + y + "%'";
            }
            if (s == "name")
            {
                query = "SELECT name FROM artifact WHERE name LIKE '" + y + "%'";
            }
            if (s == "author")
            {
                query = "SELECT name FROM artifact WHERE author LIKE '" + y + "%'";
            }
            
           
           
            try
            {

                con.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
              
                 DataSet ds = new DataSet();
           adapter.Fill(ds, "library");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "library";
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
