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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
            label1.Text = "Hello my friend!!";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            button2.ForeColor = System.Drawing.Color.White;
            label1.Text = "Locked chapter";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = System.Drawing.Color.Red; label1.Text = "Hello my friend!!";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            button3.ForeColor = System.Drawing.Color.White;
            label1.Text = "Locked chapter";

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = System.Drawing.Color.Red; label1.Text = "Hello my friend!!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form= new Form6();form.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Hello my frind!!";
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
    }
}
