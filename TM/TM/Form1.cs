﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace TM
{
<<<<<<< HEAD
    public partial class Signin : Form
    {
        Register r;
        public Signin()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r = new Register();
            this.Hide();            
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
=======
     
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(int.Parse(textBox1.Text),textBox2.Text,textBox3.Text);
            
            if (user.register())
            {
                Employee.noOfemp++;
                MessageBox.Show("User added successfuly");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (user.login(int.Parse(textBox4.Text),textBox6.Text))
            {
                MessageBox.Show("Login successfuly :D");
            }
            else
            {
                MessageBox.Show("<<<Login Faild>>>");
            }
>>>>>>> master
        }
    }
}
