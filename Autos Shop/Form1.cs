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
    public partial class login : Form
    {

        private bool _dragging = false;
        private Point p;
        private Point _start_point = new Point(0, 0);

        Main m1 = new Main();
        string s1, s2;
        public login()
        {
            InitializeComponent();
        }
        public void check()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id",user_tb.Text);
            cmd.Parameters.AddWithValue("@pass",pass_tb.Text);
            cmd.CommandText = "Select * from login where Name = @id ";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               s1=dr["Name"].ToString();
                s2=dr["Password"].ToString();
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Enter your login detail to access the Software.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application will help you to have your record in a manner way");
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            this.check();
            if (user_tb.Text == "" || pass_tb.Text=="")
            {
                MessageBox.Show("Please Enter correct User Name or password.","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (user_tb.Text == s1 && pass_tb.Text == s2)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Your User Or Password is incorrect.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void login_Load(object sender, EventArgs e)
        {
            
            pass_tb.PasswordChar = '*';
            this.AcceptButton = log_button;
            this.CancelButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                p = PointToScreen(e.Location);
                this.Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void pass_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
