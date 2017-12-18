using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autos_Shop
{
    public partial class Main : Form
    {
        frmAll frm1 = new frmAll();
        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            login loginfrm = new login();
            loginfrm.ShowDialog(this);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel2.Text = DateTime.Now.ToString("dddd dd-MMMM-yyyy hh:mm:ss tt");
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm1.tabControl1.SelectedIndex = 0;
            frm1.Size = new Size(447, 390);
            frm1.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            frm1.tabControl1.SelectedIndex = 1;
            frm1.Size = new Size(268, 400);//451, 370
            frm1.ShowDialog(this);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            frm1.tabControl1.SelectedIndex = 3;
            frm1.ShowDialog(this);
            frm1.Size = new Size(748, 396);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            frm1.tabControl1.SelectedIndex = 2;
            frm1.ShowDialog(this);
            frm1.Size = new Size(748, 396);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("IF you need help then contact with your consultant." + Environment.NewLine + "Thanks!","Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.tabControl1.SelectedIndex = 0;
            frm1.ShowDialog(this);
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.tabControl1.SelectedIndex = 1;
            
            frm1.ShowDialog(this);
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.tabControl1.SelectedIndex = 3;
            frm1.ShowDialog(this);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.tabControl1.SelectedIndex = 2;
            frm1.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change c1 = new change();
            c1.ShowDialog(this);
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("M. Hussnain Farooq 13054119-173" + Environment.NewLine + "Aamar Siddique 13054119-138"+ Environment.NewLine+ "M. Ali Raja 13054119-147","About Us", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a management system of Autos shop.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
