using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
namespace TM
{
     
    public partial class Form1 : Form
    {
        Admin admin;
         User user;
        List<Project> pros;
        public Form1()
        {
            InitializeComponent();
            try
            {
                pros = new List<Project>();
                FileStream fs = new FileStream("Projects.xml", FileMode.Open);
                XmlSerializer xs = new XmlSerializer(pros.GetType());
                pros = (List<Project>)xs.Deserialize(fs);
                fs.Close();
                for (int i = 0; i < pros.Count; i++)
                {
                    dataGridView1.Rows.Add(pros[i].name, pros[i].owner);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                 admin = new Admin(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
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
                 user = new User(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
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
                 admin = new Admin();
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
                 user = new User();
                
                if (user.login(int.Parse(textBox4.Text), textBox6.Text))
                {
                    MessageBox.Show("Login successfuly :D");
                }
                else
                {
                    MessageBox.Show("<<<Login Faild>>>");
                }
            }
            panel1.Visible = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           admin.createProject(textBox5.Text, textBox7.Text);
            textBox5.Clear();
            textBox7.Clear();
            nProjectpanel.Visible = false;
            try
            {
                pros = new List<Project>();
                FileStream fs = new FileStream("Projects.xml", FileMode.Open);
                XmlSerializer xs = new XmlSerializer(pros.GetType());
                pros = (List<Project>)xs.Deserialize(fs);
                fs.Close();
                for (int i = 0; i < pros.Count; i++)
                {
                    dataGridView1.Rows.Add(pros[i].name, pros[i].owner);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // panel1.Visible = false;
            nProjectpanel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowi = dataGridView1.CurrentRow.Index;
            label10.Text = pros[rowi].name;
            textBox8.Text = pros[rowi].descri;

            //loading employers into the datagridview
            //XmlDocument doc = new XmlDocument();
            //doc.Load("Employees.xml");
            //XmlNodeList list = doc.GetElementsByTagName("user");
            //XmlNodeList list2 = doc.GetElementsByTagName("admin");
            //for (int a = 0; a < list.Count; a++)
            //{
            //    XmlNodeList child = list[a].ChildNodes;               
            //    dataGridView2.Rows.Add(child[0].InnerText, child[1].InnerText);     
            //}
            //for (int i = 0; i < list2.Count; i++)
            //{
            //    XmlNodeList child = list2[i].ChildNodes;
            //    dataGridView2.Rows.Add(child[0].InnerText, child[1].InnerText);
            //}


            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = dataGridView4.CurrentRow.Cells[0].ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load("Employees.xml");
            XmlNodeList list = doc.GetElementsByTagName("user");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                if (child[0].InnerText.Equals(name))
                {
                    
                }
            }
           // admin.createtask()
        }
    }
}
