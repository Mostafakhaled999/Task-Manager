using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TM
{
     
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Admin admin = new Admin(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
                if (admin.register())
                {
                    Employee.noOfemp++;
                    MessageBox.Show("User added successfuly");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }

            }
            else if(radioButton4.Checked)
            {
                User user = new User(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
                if (user.register())
                {
                    Employee.noOfemp++;
                    MessageBox.Show("User added successfuly");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Admin admin = new Admin();
                if (admin.login(int.Parse(textBox4.Text), textBox6.Text))
                {
                    MessageBox.Show("Login successfuly :D");
                }
                else
                {
                    MessageBox.Show("<<<Login Faild>>>");
                }
            }
            else if(radioButton2.Checked)
            {
                User user = new User();
                if (user.login(int.Parse(textBox4.Text), textBox6.Text))
                {
                    MessageBox.Show("Login successfuly :D");
                }
                else
                {
                    MessageBox.Show("<<<Login Faild>>>");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
