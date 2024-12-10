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

        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\lenovo\\Documents\\Database3.mdb";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Create Account
        {
            string email = textBox1.Text.Trim();  // Get email from the TextBox
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
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Insert the user data into the database
        private bool InsertUserIntoDatabase(string email, string password)
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the "Users" table exists
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, "Users", null });

                    if (schemaTable != null && schemaTable.Rows.Count > 0)
                    {
                        return; // Table exists, no need to create
                    }

                    // If table does not exist, create it
                    string createTableQuery = @"
                CREATE TABLE Users (
                    [ID] AUTOINCREMENT PRIMARY KEY,
                    [Email] TEXT(255) NOT NULL,
                    [Password] TEXT(255) NOT NULL
                )";
                    OleDbCommand cmd = new OleDbCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim(); // Email from the TextBox
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
                MessageBox.Show("Login successful!");
                // Optionally, navigate to the next form or show user-specific data
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

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND [Password] = @Password";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }

}
