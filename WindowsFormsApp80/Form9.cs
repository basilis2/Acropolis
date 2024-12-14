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
    public partial class Form9 : Form
    {

        String usermail;
        public Form9(String email)
        {
            InitializeComponent();usermail= email;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.email;

            // Query to retrieve all progress fields for the specified email
            string query = "SELECT Chap1, Chap2, Chap3, Chap4 FROM Progress2 WHERE Email = @Email";

            using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add the email parameter to the query
                        cmd.Parameters.AddWithValue("@Email", Form1.email);

                        // Execute the query and read all progress values
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve and set the values to labels
                                label11.Text = reader["Chap1"] != DBNull.Value ? reader["Chap1"].ToString() : "0";
                                label12.Text = reader["Chap2"] != DBNull.Value ? reader["Chap2"].ToString() : "0";
                                label13.Text = reader["Chap3"] != DBNull.Value ? reader["Chap3"].ToString() : "0";
                                label14.Text = reader["Chap4"] != DBNull.Value ? reader["Chap4"].ToString() : "0";
                                if (!reader["Chap4"].ToString().Equals("0")) label4.Text = "Revision Test";
                                else if (!reader["Chap3"].ToString().Equals("0")) label4.Text = "Chapter 3";
                                else if (!reader["Chap2"].ToString().Equals("0")) label4.Text = "Chapter 2";
                                else if (!reader["Chap1"].ToString().Equals("0")) label4.Text = "Chapter 1";
                            }
                            else
                            {
                                // Handle case where no matching record is found
                                label11.Text = "No data";
                                label12.Text = "No data";
                                label13.Text = "No data";
                                label14.Text = "No data";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
