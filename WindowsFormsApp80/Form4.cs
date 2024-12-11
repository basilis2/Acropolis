using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp80
{
    public partial class Form4 : Form
    {
        private double totalValue;

        public Form4(double total)
        {
            InitializeComponent();

            totalValue = total;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = totalValue.ToString();
            if (totalValue < 5) {
                label3.ForeColor = Color.Red;
                label4.Text = "You failed";
                button1.Text = "Tryn again";
                button1.BackColor = Color.Blue;
                button1.ForeColor = Color.White;
            } 
            else
            {
                label3.ForeColor = Color.Green;
                label4.Text = "You passed";
                button1.Text = "Continue";
                button1.BackColor = Color.Green; button1.ForeColor = Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (totalValue < 5) this.Close();
            else { }
        }
    }
}
