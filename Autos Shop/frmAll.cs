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
    public partial class frmAll : Form
    {
        int s1;
        int check;
        public frmAll()
        {
            InitializeComponent();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            this.Text = tabControl1.SelectedTab.Text;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedTab.Text == "Purchase")
            {
                this.Size = new Size(447, 390);
            }
            if (tabControl1.SelectedTab.Text == "Sale")
            {
                this.Size = new Size(268, 400);
            }
            if (tabControl1.SelectedTab.Text == "Stock")
            {
                this.Size = new Size(748, 396);
            }
            if (tabControl1.SelectedTab.Text == "Balance Sheet")
            {
                this.Size = new Size(748, 396);
            }
        }

        private void frmAll_Load(object sender, EventArgs e)
        {
            this.Text = tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedTab.Text == "Stock")
            {
                this.Size = new Size(449, 396);
            }
            if (tabControl1.SelectedTab.Text == "Puchase")
            {
                this.Size = new Size(447, 390);
            }
            if (tabControl1.SelectedTab.Text == "Sale")
            {
                this.Size = new Size(268, 400);
            }
            if (tabControl1.SelectedTab.Text == "Stock")
            {
                this.Size = new Size(748, 396);
            }
            if (tabControl1.SelectedTab.Text == "Balance Sheet")
            {
                this.Size = new Size(748, 396);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Enter a PartNo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM purchase WHERE PartNo = " + textBox1.Text.Trim();
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    check = (int)rdr["PartNo"];
                    textBox2.Text = rdr["PartName"].ToString();
                    textBox3.Text = rdr["PartDescription"].ToString();
                    textBox4.Text = rdr["AvlQuantity"].ToString();
                    textBox7.Text = DateTime.Parse(rdr["LastUpdate"].ToString()).ToString("yyyy-MM-dd");
                    textBox5.Text = rdr["UnitPrice"].ToString();
                    rdr.Close();
                    rdr.Dispose();
                    con.Close();

                }
                else
                {
                    MessageBox.Show("No Parts Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.showdata(textBox19.Text.Trim());
            if (textBox19.Text == "" || textBox13.Text == "" || textBox11.Text == "" || textBox14.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Please Enter values!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox19.Text == s1.ToString())
            {
                MessageBox.Show("Duplication!" + Environment.NewLine + "This Part is already in record. You can Update it from Update Section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{


                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO purchase (PartNo, PartName, PartDescription, PrQuantity, UnitPrice, AvlQuantity, LastUpdate) VALUES ('" + int.Parse(textBox19.Text.Trim()) + "','" + textBox14.Text.Trim() + "', '" + textBox13.Text.Trim() + "', '" + int.Parse(textBox10.Text.Trim()) + "', '" + int.Parse(textBox11.Text.Trim()) + "', '" + int.Parse(textBox10.Text.Trim()) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                cmd.ExecuteNonQuery(); 
                  con.Close();
                MessageBox.Show("Done!","Thanks",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="" && textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please Enter a PartNO and new price Or Quantity!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(Convert.ToInt16( textBox6.Text) <= 0)
            {
                MessageBox.Show("Quantity can not be 0 OR in -ve", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE purchase SET UnitPrice=" + int.Parse(textBox5.Text.Trim()) + ",PrQuantity=" + int.Parse(textBox5.Text.Trim()) + ",AvlQuantity=" + (int.Parse(textBox4.Text) + int.Parse(textBox6.Text.Trim())) + "WHERE PartNo = " + textBox1.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Upated!","Thanks",MessageBoxButtons.OK,MessageBoxIcon.Information);
                button1.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter a PartNo to Delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("There is no item", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show(textBox2.Text.Trim() + Environment.NewLine + "Are You Sure! You Want To Delete This?", textBox2.Text, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM purchase WHERE PartNo = " + textBox1.Text.Trim();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Part Deleted.", textBox2.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            
        }
        //745, 398

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Show All")
            {
                button2.Text = "Hide All";
                this.Size = new Size(745, 390);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * FROM purchase ";
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                dp.Fill(ds, "Table1");
                DataTable dt=ds.Tables["Table1"];
                dataGridView1.DataSource = dt;
                con.Close();

            }
            else
            {
                button2.Text = "Show All";
                this.Size = new Size(447, 390);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show("Please Enter a PartNo!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            else
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM purchase WHERE PartNo = " + textBox18.Text.Trim();
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        textBox17.Text = rdr["PartName"].ToString();
                        textBox16.Text = rdr["PartDescription"].ToString();
                        textBox15.Text = rdr["AvlQuantity"].ToString();
                        textBox12.Text = rdr["UnitPrice"].ToString();
                        rdr.Close();
                        rdr.Dispose();
                        con.Close();
                    }
                

                else
                {
                    MessageBox.Show("No Parts Found!");
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show("Please Enter PartNo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox8.Text == "")
            {
                MessageBox.Show("Please Enter Sale Quantity", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE purchase SET AvlQuantity=" + (int.Parse(textBox15.Text) - int.Parse(textBox8.Text.Trim())) + "WHERE PartNo = " + textBox18.Text.Trim();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into sales (PartNo, Partname, PartDescription, TotalQuantitysale, Unitprice, [Date],Totalprice) Values('" + textBox18.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox8.Text + "','" + textBox12.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + (int.Parse(textBox12.Text) * int.Parse(textBox8.Text.Trim())) + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                button9.PerformClick();


                MessageBox.Show("Total Price: " + (int.Parse(textBox12.Text) * int.Parse(textBox8.Text.Trim())) + Environment.NewLine + "Sold!", "Total", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Show All")
            {
                button7.Text = "Hide All";
                this.Size = new Size(764, 400);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * FROM sales ";
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds, "sales");
                DataTable dt = ds.Tables["sales"];
                dataGridView2.DataSource = dt;
                con.Close();
            }
           else if (button7.Text == "Hide All")
            {
                button7.Text = "Show All";
                this.Size = new Size(268, 400);
            }
            

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel2.Text = DateTime.Now.ToString("dddd dd-MMMM-yyyy hh:mm:ss tt");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void showdata(string s2)
        {
           
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@id", textBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@id", s2);
                cmd.CommandText = "SELECT * FROM purchase WHERE PartNo =@id";
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    s1 = (int)(dr["PartNo"]);
                    
                }
                con.Close();
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            this.showdata(textBox9.Text.Trim());
            if (textBox9.Text == "")
            {
                MessageBox.Show("Please Enter Item PartNo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox9.Text != s1.ToString())
            {
                MessageBox.Show("No Item Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", textBox9.Text.Trim());
                cmd.CommandText = "SELECT * FROM purchase WHERE PartNo =@id";

                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds, "Purchase1");
                DataTable dt = ds.Tables["Purchase1"];
                dataGridView3.DataSource = dt;
                con.Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM purchase";

            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dp.Fill(ds, "Purchase2");
            DataTable dt = ds.Tables["Purchase2"];
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sheikh Hussnain\Documents\Visual Studio 2013\Projects\Project\Database\project.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@start",dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end",dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            cmd.CommandText = "SELECT * FROM sales where Date BETWEEN @start AND @end";

            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dp.Fill(ds, "Purchase4");
            DataTable dt = ds.Tables["Purchase4"];
            dataGridView4.DataSource = dt;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
