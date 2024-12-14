using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace WindowsFormsApp80
{
    public partial class Form1 : Form
    {
        public static string email;

        

        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Vasilis\\Source\\Repos\\Acropolis2\\WindowsFormsApp80\\Database\\Database3.mdb";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Create Account
        {
            email = textBox1.Text.Trim();  // Get email from the TextBox
            string password = textBox2.Text.Trim();  // Get password from the TextBox

            // Validate the inputs (e.g., check for empty fields)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Check if email already exists in the database
            if (IsEmailAlreadyRegistered(email))
            {
                MessageBox.Show("Email already registered.");
                return;
            }


            // Insert the new user into the database
            bool isInserted = InsertUserIntoDatabase(email, password);

            if (isInserted)
            {
                MessageBox.Show("User registered successfully!");
            }
            else
            {
                MessageBox.Show("Failed to register user.");
            }
        }

        // Check if email already exists in the database
        private bool IsEmailAlreadyRegistered(string email)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users2 WHERE Email = @Email";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Insert the user data into the database
        /*  private bool InsertUserIntoDatabase(string email, string password)
          {
              using (OleDbConnection conn = new OleDbConnection(connectionString))
              {
                  conn.Open();
                  // Surround [Password] with square brackets
                  string query = "INSERT INTO Users (Email, [Password]) VALUES (@Email, @Password)";
                  OleDbCommand cmd = new OleDbCommand(query, conn);

                  cmd.Parameters.AddWithValue("@Email", email);
                  cmd.Parameters.AddWithValue("@Password", password);

                  int rowsAffected = cmd.ExecuteNonQuery();
                  return rowsAffected > 0;
              }
          }*/


        private bool InsertUserIntoDatabase(string email, string password)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Use a transaction to ensure both INSERT operations are atomic
                OleDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert into Users table
                    string userQuery = "INSERT INTO Users2 (Email, [Password]) VALUES (@Email, @Password)";
                    using (OleDbCommand cmd = new OleDbCommand(userQuery, conn, transaction))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar)).Value = email;
                        cmd.Parameters.Add(new OleDbParameter("@Password", OleDbType.VarChar)).Value = password;

                        cmd.ExecuteNonQuery();
                    }

                    // Insert into Progress table
                    string progressQuery = "INSERT INTO Progress2 (Email, Chap1, Chap2, Chap3, Chap4) VALUES (@Email, @Chap1, @Chap2, @Chap3, @Chap4)";
                    using (OleDbCommand cmd = new OleDbCommand(progressQuery, conn, transaction))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar)).Value = email;
                        cmd.Parameters.Add(new OleDbParameter("@Chap1", OleDbType.Integer)).Value = 0;
                        cmd.Parameters.Add(new OleDbParameter("@Chap2", OleDbType.Integer)).Value = 0;
                        cmd.Parameters.Add(new OleDbParameter("@Chap3", OleDbType.Integer)).Value = 0;
                        cmd.Parameters.Add(new OleDbParameter("@Chap4", OleDbType.Integer)).Value = 0;

                        cmd.ExecuteNonQuery();
                    }

                    // Commit transaction if both operations succeed
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    // Rollback transaction if any operation fails
                    transaction.Rollback();
                    throw;
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the "Users" table exists
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, "Users2", null });

                    if (schemaTable == null || schemaTable.Rows.Count == 0)
                    {
                        // If table does not exist, create it
                        string createUsersTableQuery = @"
                    CREATE TABLE Users2 (
                        [ID] AUTOINCREMENT PRIMARY KEY,
                        [Email] TEXT(255) NOT NULL,
                        [Password] TEXT(255) NOT NULL
                    )";
                        OleDbCommand cmd = new OleDbCommand(createUsersTableQuery, conn);
                        cmd.ExecuteNonQuery();
                    }

                    // Check if the "Progress" table exists
                    DataTable progressSchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, "Progress2", null });

                    if (progressSchemaTable == null || progressSchemaTable.Rows.Count == 0)
                    {
                        // If table does not exist, create it
                        string createProgressTableQuery = @"
                    CREATE TABLE Progress2 (
                        [ID] AUTOINCREMENT PRIMARY KEY,
                        [Email] TEXT(255) NOT NULL,
                        [Chap1] INTEGER DEFAULT 0,
                        [Chap2] INTEGER DEFAULT 0,
                        [Chap3] INTEGER DEFAULT 0,
                        [Chap4] INTEGER DEFAULT 0
                    )";
                        OleDbCommand cmd = new OleDbCommand(createProgressTableQuery, conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text.Trim(); // Email from the TextBox
            string password = textBox2.Text.Trim(); // Password from the TextBox

            // Validate the inputs (e.g., check for empty fields)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Authenticate the user
            bool isAuthenticated = AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                Form2 F2 = new Form2(email);
                F2.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private bool AuthenticateUser(string email, string password)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users2 WHERE Email = @Email AND [Password] = @Password";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor= Color.Green;
            button1.ForeColor= Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Green;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form8  f8=new Form8();f8.Show();
        }
    }

}
