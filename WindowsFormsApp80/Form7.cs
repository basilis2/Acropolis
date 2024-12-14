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

namespace WindowsFormsApp80
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            if (checkBox1.Checked) total += 1;
            if (checkBox3.Checked) total += 1;
            if (checkBox5.Checked) total += 1;
            if (checkBox8.Checked) total += 1;
            if (checkBox9.Checked) total += 1;
            if (checkBox12.Checked) total += 1;
            if (checkBox13.Checked) total += 1;
            if (checkBox16.Checked) total += 1;
            if (checkBox17.Checked) total += 1;
            if (checkBox19.Checked) total += 1;

            string query = "UPDATE Progress2 SET Chap4 = @Chap4 WHERE Email = @Email";

            if (total >= 5)
            {
                using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OleDbParameter("@Chap4", OleDbType.Double)).Value = total;
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
            Form4 f4 = new Form4(total, "form3");
            f4.Show(); this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { checkBox2.Checked = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { checkBox1.Checked = false; }
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

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked) { checkBox9.Checked = false; }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked) { checkBox10.Checked = false; }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked) { checkBox11.Checked = false; }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked) { checkBox12.Checked = false; }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked) { checkBox13.Checked = false; }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked) { checkBox14.Checked = false; }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked) { checkBox15.Checked = false; }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked) { checkBox16.Checked = false; }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked) { checkBox17.Checked = false; }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked) { checkBox18.Checked = false; }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked) { checkBox19.Checked = false; }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked) { checkBox20.Checked = false; }
        }
    }
}
