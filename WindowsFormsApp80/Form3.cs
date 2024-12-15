using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp80
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Test me"))
            {
                label2.Visible = false; groupBox2.Visible = true; button1.Text = "View Theory";
            }
            else {
                button1.Text = "Test me";
                label2.Visible = true; groupBox2.Visible = false;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) { checkBox2.Checked= false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { checkBox3.Checked = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { checkBox4.Checked = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { checkBox5.Checked = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { checkBox6.Checked = false; }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked) { checkBox7.Checked = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked) { checkBox8.Checked = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (checkBox1.Checked) total += 2;
            if(checkBox3.Checked) total += 2;
            if(checkBox6.Checked) total += 2;
            if(checkBox7.Checked) total += 2;
            if (checkBox9.Checked) total += 2;
            string query = "UPDATE Progress4 SET Chap1 = @Chap1 WHERE Email = @Email";

            if (total >= 5) {
                using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OleDbParameter("@Chap1", OleDbType.Double)).Value = total;
                            cmd.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar)).Value = Form1.email;

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("No record found for the specified email.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            Form4 f4=new Form4(total,"form3");
            f4.Show();this.Close();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { checkBox1.Checked = false; }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked) { checkBox10.Checked = false; }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked) { checkBox9.Checked = false; }
        }
    }
}
