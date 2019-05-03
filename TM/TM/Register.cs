using System;
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
    
    public partial class Register : Form
    {
        Signin s;
        List<Employee> emp = new List<Employee>();
        List<User> userlist = new List<User>();
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            s = new Signin(); 
            User u = new User();
            u.id = textBox1.Text;
            u.name = textBox2.Text;
            u.pass = textBox3.Text;
            u.Email_address = textBox4.Text;
            u.Mobile_number = textBox5.Text;
            userlist.Add(u);
            FileStream fs = new FileStream("Employee.xml", FileMode.Append);
            XmlSerializer ser = new XmlSerializer(userlist.GetType());
            ser.Serialize(fs, userlist);
            MessageBox.Show("" + u.name + "  Has been added Successfuly");
            fs.Close();
            this.Visible = false;
            s.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = new Signin();
            this.Hide();
            s.Show();
        }
    }
}
