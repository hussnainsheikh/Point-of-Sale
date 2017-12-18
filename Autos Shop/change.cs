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

namespace Autos_Shop
{
    public partial class change : Form
    {
        string s1;
        public change()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.CommandText = "Select * from login where Password = @id ";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s1 = dr["Password"].ToString();
            }
            if(textBox1.Text==s1)
            {
                label2.Show();
                textBox2.Show();
                textBox3.Show();
                button1.Show();
                label3.Show();
                label4.Show();
                
            }
            else
            {
                MessageBox.Show("Please Enter correct Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void change_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            label2.Hide();
            textBox2.Hide();
            textBox3.Hide();
            button1.Hide();
            label3.Hide();
            label4.Hide();
            this.AcceptButton=Verify;
            this.CancelButton = button2;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update login SET Password = '" + textBox2.Text.Trim() + "' Where Password = '" + textBox1.Text.Trim() + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated!","Thanks",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Password Mismatch!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
