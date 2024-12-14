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
        private String location;

        public Form4(double total, String form)
        {
            InitializeComponent();

            totalValue = total;location=form;

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
            Form2 f2 = new Form2("");f2.Show(); this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (totalValue < 5){
                if (location.Equals("form3"))
                {
                    Form3 f3 = new Form3(); f3.Show(); this.Close();
                }
                else if (location.Equals("form5"))
                {
                    Form5 form5 = new Form5(); form5.Show(); this.Close();
                }
                else {
                    Form6 form6 = new Form6(); form6.Show(); this.Close();
                }
            }
            else {
                if (location.Equals("form3"))
                {
                    Form5 form5 = new Form5(); form5.Show(); this.Close();
                }
                else if (location.Equals("form5"))
                {
                    Form6 form6 = new Form6(); form6.Show(); this.Close();
                }
                else
                {
                    Form7 form7 = new Form7(); form7.Show(); this.Close();
                }
            }
        }
    }
}
