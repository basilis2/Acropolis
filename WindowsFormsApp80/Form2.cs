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
    public partial class Form2 : Form
    {

        String chap1 = "0";
        String chap2 = "0";
        String chap3 = "0";
        String chap4 = "0";




        String emailUser;
        public Form2(String email)
        {
            InitializeComponent();
            emailUser = email;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            button1.ForeColor = System.Drawing.Color.White;
            label1.Text = "Introduction to "+"\n"+"Greek Culture" + "\n" + "and History";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = System.Drawing.Color.Green;
            label1.Text = "Start your first" + "\n" + "chapter!";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            if (!chap1.Equals("0"))
            {
                button2.BackColor = Color.Green;
                button2.ForeColor = System.Drawing.Color.White;
                label1.Text = "Lets GO!!!";
            }
            else {
                button2.BackColor = Color.Red;
                button2.ForeColor = System.Drawing.Color.White;
                label1.Text = "Locked chapter";
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (!chap1.Equals("0"))
            {
                button2.BackColor = Color.White;
                button2.ForeColor = System.Drawing.Color.Green;
            }
            else {
                button2.BackColor = Color.White;
                button2.ForeColor = System.Drawing.Color.Red;
            }
            label1.Text = "Hello my friend!!";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (!chap2.Equals("0"))
            {
                button3.BackColor = Color.Green;
                button3.ForeColor = System.Drawing.Color.White;
                label1.Text = "Lets GO!!!";
            }
            else
            {
                button3.BackColor = Color.Red;
                button3.ForeColor = System.Drawing.Color.White;
                label1.Text = "Locked chapter";
            }

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if(!chap2.Equals("0"))
            {
                button3.BackColor = Color.White;
                button3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                button3.BackColor = Color.White;
                button3.ForeColor = System.Drawing.Color.Red;
            }
            //label1.Text = "Hello my friend!!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form= new Form6();form.Show(); this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //label1.Text = "Hello my friend!!";
            string query = "SELECT Chap1, Chap2, Chap3, Chap4 FROM Progress4 WHERE Email = @Email";

            using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar)).Value = Form1.email;

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                chap1 = reader["Chap1"]?.ToString() ?? "0";
                                chap2 = reader["Chap2"]?.ToString() ?? "0";
                                chap3 = reader["Chap3"]?.ToString() ?? "0";
                                chap4 = reader["Chap4"]?.ToString() ?? "0";


                            }
                            if (!chap4.Equals("0"))
                            {
                                button5.Visible = true;
                                button3.Enabled = true;
                                button3.ForeColor = Color.Green;
                                button2.Enabled = true;
                                button2.ForeColor = Color.Green;
                               label1.Text = "You have finished\n the test!!!";
                            }
                            else if (!chap3.Equals("0"))
                            {
                                button5.Visible = true;
                                button3.Enabled = true;
                                button3.ForeColor = Color.Green;
                                button2.Enabled = true;
                                button2.ForeColor = Color.Green;
                                label1.Text = "Final Test\n Unlocked!!!";
                            }
                            else if (!chap2.Equals("0"))
                            {
                                button5.Visible = false;
                                button3.Enabled = true;
                                button3.ForeColor = Color.Green;
                                button2.Enabled = true;
                                button2.ForeColor = Color.Green;
                                label1.Text = "Chapter3 is"+"\n"+"waiting for you.";
                            }
                            else if (!chap1.Equals("0"))
                            {
                                button5.Visible = false;
                                button2.Enabled = true;
                                button2.ForeColor = Color.Green;
                                label1.Text = "Nice to see you"+"\n"+"my friend";
                            }
                            else
                            {
                                // Default state if no progress has been made
                                button5.Visible = false;
                                label1.Text = "Start your first"+"\n"+"chapter!";

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = $"Error: {ex.Message}";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3=new Form3();f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5=new Form5();f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 f7=new Form7();f7.Show();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            label3.Visible = true;this.Cursor = Cursors.Hand;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false; this.Cursor = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form9 form=new Form9(emailUser);form.Show();
        }
    }
}
