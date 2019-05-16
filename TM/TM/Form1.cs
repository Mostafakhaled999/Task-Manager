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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
namespace TM
{
     
    public partial class Form1 : Form
    {
        Employee employee;
        List<Employee> employees;
        List<Project> pros;
        List<Project> pros2;
        Project project;
        Project project2;
        Task task;
        List<Task> tasks;
        bool user;
       public static int rowi;
        public static int rowi2;
        public Form1()
        {
            InitializeComponent();
            try
            {
                employees = new List<Employee>();
                employees = Employee.load();
                pros = new List<Project>();
             //   pros = Project.load();
                tasks = new List<Task>();
                
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
                 employee = new Employee(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text,"admin");
                if (employee.register())
                {
                    
                    MessageBox.Show("User added successfuly");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }

            }
            else if(radioButton4.Checked)
            {
                 employee = new Employee(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text,"user");
                if (employee.register())
                {
                    
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
                 employee = new Employee();
                if (employee.login(int.Parse(textBox4.Text), textBox6.Text,"admin")!=null)
                {
                    employee = employee.login(int.Parse(textBox4.Text), textBox6.Text, "admin");
                    MessageBox.Show("Login successfuly :D");
                    intro.Visible = true;
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < pros.Count; i++)
                    {
                        dataGridView1.Rows.Add(pros[i].name, pros[i].owner);

                    }
                }
                else
                {
                    MessageBox.Show("<<<Login Faild>>>");
                }
            }
            else if(radioButton2.Checked)
            {
                 employee = new Employee();
                 user = true;
                pros2 = new List<Project>();
                if (employee.login(int.Parse(textBox4.Text), textBox6.Text,"user")!=null)
                {
                    employee = employee.login(int.Parse(textBox4.Text), textBox6.Text, "user");
                    MessageBox.Show("Login successfuly :D");
                    intro.Visible = true;

                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < pros.Count; i++)
                    {
                        dataGridView1.Rows.Add(pros[i].name, pros[i].owner);

                    }
                    button3.Visible = false;
                    button5.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button14.Visible = false;
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

        private void button6_Click(object sender, EventArgs e)
        {
            
           employee.createproject(textBox5.Text, textBox7.Text);
            textBox5.Clear();
            textBox7.Clear();
            newProject.Visible = false;
            try
            {

                pros = new List<Project>();
                pros = Project.load();
                dataGridView1.Rows.Clear();
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
            newProject.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            bool found=false;
                rowi = dataGridView1.CurrentRow.Index;
                label10.Text = pros[rowi].name;
                textBox8.Text = pros[rowi].descri;
                project = new Project();
                project = pros[rowi];
                if (user)
                {
                    for (int i = 0; i < pros[rowi].emps.Count; i++)
                    {
                        if (pros[rowi].emps[i].name.Equals(employee.name))
                        {
                        found = true;
                        break;
                        }
                    }
                if (found)
                {
                    dataGridView2.Rows.Clear();
                    dataGridView3.Rows.Clear();
                    for (int a = 0; a < project.emps.Count; a++)
                    {
                        dataGridView2.Rows.Add(project.emps[a].id, project.emps[a].name);
                    }

                    for (int b = 0; b < pros[rowi].tasks.Count; b++)
                    {
                        dataGridView3.Rows.Add(pros[rowi].tasks[b].name, pros[rowi].tasks[b].duration, pros[rowi].tasks[b].emp.name, pros[rowi].tasks[b].comment, pros[rowi].tasks[b].status);
                    }
                    openProject.Visible = true;

                }
                else
                {
                    MessageBox.Show("you are not in that project");
                }

            }
            //loading employers into the datagridview
            else
            {
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                for (int i = 0; i < project.emps.Count; i++)
                {
                    dataGridView2.Rows.Add(project.emps[i].id, project.emps[i].name);
                }

                for (int i = 0; i < pros[rowi].tasks.Count; i++)
                {
                    dataGridView3.Rows.Add(pros[rowi].tasks[i].name, pros[rowi].tasks[i].duration, pros[rowi].tasks[i].emp.name, pros[rowi].tasks[i].comment, pros[rowi].tasks[i].status);
                }
                openProject.Visible = true;

            }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
            for (int a = 0; a < employees.Count; a++)
            {              
                dataGridView5.Rows.Add(employees[a].id,employees[a].name);
            }
            addMembers.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            for (int i = 0; i < pros[rowi].emps.Count; i++)
            {
                dataGridView4.Rows.Add(pros[rowi].emps[i].id, pros[rowi].emps[i].name);
            }
            newTask.Visible = true;
            button12.Visible = true;
            button15.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
           
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                if (dataGridView5.Rows[i].Cells[2].Value!=null&& dataGridView5.Rows[i].Cells[2].Value.ToString() =="True")
                {
                    project.addemployees(employees[i]);
                }
            }
            pros = Project.load();
            dataGridView2.Rows.Clear();
            for (int i = 0; i < pros[rowi].emps.Count; i++)
            {
                dataGridView2.Rows.Add(pros[rowi].emps[i].id, pros[rowi].emps[i].name);
            }
            addMembers.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            task = new Task(textBox9.Text, textBox11.Text, textBox10.Text, pros[rowi].emps[dataGridView4.CurrentRow.Index]);
            project.addtask(task);
            dataGridView3.Rows.Clear();
            pros = Project.load();
            for (int i = 0; i < pros[rowi].tasks.Count; i++)
            {
            dataGridView3.Rows.Add(pros[rowi].tasks[i].name, pros[rowi].tasks[i].duration, pros[rowi].tasks[i].emp.name, pros[rowi].tasks[i].comment, pros[rowi].tasks[i].status);
            }
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            newTask.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
           employee.closetask( dataGridView3.CurrentRow.Index);
            pros = Project.load();
            dataGridView3.Rows.Clear();
            for (int i = 0; i < pros[rowi].tasks.Count; i++)
            {
                dataGridView3.Rows.Add(pros[rowi].tasks[i].name, pros[rowi].tasks[i].duration, pros[rowi].tasks[i].emp.name, pros[rowi].tasks[i].comment, pros[rowi].tasks[i].status);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            employee.deleteemployee(dataGridView2.CurrentRow.Index);
            pros = Project.load();
            project = new Project();
            project = pros[rowi];
            //loading employers into the datagridview
            dataGridView2.Rows.Clear();
            for (int i = 0; i < project.emps.Count; i++)
            {
                dataGridView2.Rows.Add(project.emps[i].id, project.emps[i].name);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            newTask.Visible = true;
            button15.Visible = true;
            button12.Visible = false;
            dataGridView5.Rows.Clear();
            for (int i = 0; i < pros[rowi].emps.Count; i++)
            {
                dataGridView4.Rows.Add(pros[rowi].emps[i].id, pros[rowi].emps[i].name);
            }
            textBox9.Text = pros[rowi].tasks[dataGridView3.CurrentRow.Index].name;
            textBox10.Text = pros[rowi].tasks[dataGridView3.CurrentRow.Index].duration;
            textBox11.Text = pros[rowi].tasks[dataGridView3.CurrentRow.Index].comment;
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            employee.edittask(dataGridView3.CurrentRow.Index, textBox9.Text, textBox11.Text, textBox10.Text, pros[rowi].emps[dataGridView4.CurrentRow.Index]);
            newTask.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee.deleteproject(dataGridView1.CurrentRow.Index);
            pros = Project.load();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < pros.Count; i++)
            {
                dataGridView1.Rows.Add(pros[i].name, pros[i].owner);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openProject.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (pros[rowi].tasks[dataGridView3.CurrentRow.Index].emp.name.Equals(employee.name))
            {
                employee.forward(dataGridView3.CurrentRow.Index, pros[rowi].emps[dataGridView2.CurrentRow.Index]);
                pros = Project.load();
                dataGridView3.Rows.Clear();
                for (int i = 0; i < pros[rowi].tasks.Count; i++)
                {
                    dataGridView3.Rows.Add(pros[rowi].tasks[i].name, pros[rowi].tasks[i].duration, pros[rowi].tasks[i].emp.name, pros[rowi].tasks[i].comment, pros[rowi].tasks[i].status);
                }
            }
            else
            {
                MessageBox.Show("you can't forward this task");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            List<Employee> emps = new List<Employee>();
            
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                emps.Add(employee);
                if (employee.upload(dataGridView3.CurrentRow.Index, ofd.SafeFileName, ofd.FileName, emps))
                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
        }

            private void button18_Click(object sender, EventArgs e)
        {
            if (employee.download(dataGridView3.CurrentRow.Index))
            {
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("failed");
            }
           
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ReportDocument cryrpt = new ReportDocument();
            cryrpt.Load("C:\\Users\\Sneijder\\Documents\\GitHub\\Task-Manager\\TM\\TM\\CrystalReport1.rpt");
            
            

        }
    }
}
