using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp80
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // SQL query to fetch chapter values for the given email
            string query = "SELECT Chap1, Chap2, Chap3 FROM Progress4 WHERE Email = @Email";

            using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open(); // Open the database connection

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add the email parameter to the query
                        cmd.Parameters.AddWithValue("@Email", Form1.email);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Check if data exists for the given email
                            {
                                // Retrieve chapter values
                                int chap1 = Convert.ToInt32(reader["Chap1"]);
                                int chap2 = Convert.ToInt32(reader["Chap2"]);
                                int chap3 = Convert.ToInt32(reader["Chap3"]);

                                // Determine the highest value among the chapters
                                int maxValue = Math.Max(chap1, Math.Max(chap2, chap3));

                                string message = "";
                                string details = "";
                                string careerPathLink = "";

                                // Determine the career path and corresponding link
                                if (maxValue == chap1)
                                {
                                    message = "INTRODUCTION TO GREEK CULTURE AND HISTORY";
                                    details = "This path explores the rich heritage of Greek civilization, including its art, philosophy, and historical milestones.";
                                    careerPathLink = "https://www.britannica.com/place/ancient-Greece";
                                }
                                else if (maxValue == chap2)
                                {
                                    message = "ANALYSIS OF ACROPOLIS MONUMENTS";
                                    details = "This path focuses on the detailed study of iconic monuments of the Acropolis, their history, architecture, and cultural significance.";
                                    careerPathLink = "https://whc.unesco.org/en/list/404/";
                                }
                                else if (maxValue == chap3)
                                {
                                    message = "CULTURAL HERITAGE AND MODERN CHALLENGES";
                                    details = "This path examines the challenges of preserving cultural heritage in a rapidly modernizing world, emphasizing sustainability and global awareness.";
                                    careerPathLink = "https://www.ias.edu/ideas/2023/challenges-cultural-heritage-greece";
                                }

                                // Set the TextBox content to the career path recommendation in uppercase
                              /*  textBox1.Multiline = true;
                                textBox1.Text = "CONGRATULATIONS!" + "\n" +
                                                "BASED ON YOUR ACHIEVEMENTS, WE RECOMMEND THE FOLLOWING CAREER PATH:" + "\n\n" +
                                                message + "\n" +
                                                details + "\n" +
                                                "KEEP UP THE GREAT WORK AND CONTINUE EXPLORING YOUR PASSION FOR GREEK CULTURE!";*/
                                label7.MaximumSize = new Size(500, 0);
                                label7.Text = message+"\n"+details;
                                // Set label2 to display the career path link in uppercase
                                label2.Text = "Useful Link For Your Carrer";// Make it look like a hyperlink
                                label2.Cursor = Cursors.Hand; // Change cursor to hand for hyperlink effect

                                // Store the link in the label's Tag property for later use
                                label2.Tag = careerPathLink;

                                // Add a click event to open the link
                                label2.Click += (s, args) =>
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                    {
                                        FileName = careerPathLink,
                                        UseShellExecute = true // Opens the URL in the default browser
                                    });
                                };
                                
                                path_uPDATE(message.ToLower());
                            }
                            else
                            {
                                // Handle case where no data is found for the given email
                                label7.Text = "NO DATA FOUND FOR THE SPECIFIED EMAIL. PLEASE MAKE SURE YOU HAVE COMPLETED THE NECESSARY CHAPTERS.";
                                label2.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display any database errors in the TextBox
                    label7.Text = $"AN ERROR OCCURRED WHILE RETRIEVING YOUR DATA:\n{ex.Message}";
                    label2.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void path_uPDATE(String path) {
            // SQL query to update the Path column for the specified email
            string updateQuery = "UPDATE Users4 SET Path = @Path WHERE Email = @Email";

            using (OleDbConnection conn = new OleDbConnection(Form1.connectionString))
            {
                try
                {
                    conn.Open(); // Open the database connection

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Path", path);  // Set the path (career path title)
                        cmd.Parameters.AddWithValue("@Email", Form1.email); // Use the email parameter (assumed to be stored in Form1.email)

                        // Execute the update command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Optionally, handle the outcome (e.g., confirm success or failure)
                        if (rowsAffected > 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("No record updated. Please check the email.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the update
                    MessageBox.Show($"An error occurred while updating the career path: {ex.Message}");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    } 

}
