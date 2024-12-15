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
    public partial class Form6 : Form
    {
        public Form6()
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
                textBox1.Visible = false; groupBox2.Visible = true; button1.Text = "View Theory";
            }
            else
            {
                button1.Text = "Test me";
                textBox1.Visible = true; groupBox2.Visible = false;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = "The preservation of cultural heritage is one of the greatest challenges of our time. Monuments such as the Parthenon face ongoing threats from natural factors like climate change, air pollution, and seismic activity. Additionally, human activities, including urbanization and mass tourism, exert significant pressure on these historic sites, often leading to wear and damage.\r\n\r\nA critical issue in cultural heritage is the debate over the restitution of artifacts. The case of the Parthenon Sculptures, removed in the early 19th century and currently housed in the British Museum, has become a global symbol of the struggle for repatriation. Greece argues that these sculptures are an integral part of the Parthenon and its cultural identity, advocating for their return to Athens to be reunited with the monument.\r\n\r\nInternational efforts, including UNESCO’s conventions and cultural diplomacy, aim to balance the preservation of heritage with the rights of nations to reclaim their history. These challenges demand innovative conservation techniques, global cooperation, and ethical approaches to ensure that cultural heritage is protected and respected for future generations.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (checkBox1.Checked) total += 2;
            if (checkBox3.Checked) total += 2;
            if (checkBox6.Checked) total += 2;
            if (checkBox7.Checked) total += 2;
            if (checkBox9.Checked) total += 2;
            string query = "UPDATE Progress4 SET Chap3 = @Chap3 WHERE Email = @Email";

            if (total >= 5)
            {
                using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OleDbParameter("@Chap3", OleDbType.Double)).Value = total;
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
            Form4 f4 = new Form4(total, "form6");
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
