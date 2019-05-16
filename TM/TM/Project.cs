using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace TM
{
    public class Project
    {
      
        public string name;
        public string owner;
        public string descri;
        public int noOfemp;
        public List<Employee> emps;
        public List<Task> tasks;

        public Project()
        {
            name = null;
            descri = null;
            noOfemp = 0;
            emps = new List<Employee>();
            tasks = new List<Task>();
        }
        public Project(string n, string d, string ownername)
        {
            name = n;
            descri = d;
            owner = ownername;
            emps = new List<Employee>();
            tasks = new List<Task>();
            noOfemp= 0;
        }
        public void addemployees(Employee em)
        {
            
            List<Project> projects = new List<Project>();
            FileStream fs = new FileStream("Projects.xml", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(projects.GetType());
            projects = (List<Project>)xs.Deserialize(fs);
            projects[Form1.rowi].emps.Add(em);
            projects[Form1.rowi].noOfemp++;
            fs.Close();
            fs = new FileStream("Projects.xml", FileMode.Open);
            xs.Serialize(fs, projects);
            fs.Close();
        }
        public void addtask(Task tsk)
        {
            List<Project> projects = new List<Project>();
            FileStream fs = new FileStream("Projects.xml", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(projects.GetType());
            projects = (List<Project>)xs.Deserialize(fs);
            projects[Form1.rowi].tasks.Add(tsk);
            fs.Close();
            fs = new FileStream("Projects.xml", FileMode.Open);
            xs.Serialize(fs, projects);
            fs.Close();
        }
        public static List<Project>load()
        {
            List<Project> projects = new List<Project>();
            FileStream fs = new FileStream("Projects.xml", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(projects.GetType());
            projects = (List<Project>)xs.Deserialize(fs);
            fs.Close();
            return projects;
        }
        
    }
   public class Task
    {
        public string name;
        public string comment;
        public string duration;
        public Employee emp;
        public string status;
        public Attachment attachment;
        public Task()
        {
            name = null;
            comment = null;
            duration = null;
            status = "Open";
            attachment = new Attachment();
        }
        public Task(string n,string c,string d,Employee employee)
        {
            name = n;
            comment = c;
            duration = d;
            status = "Open";
            emp = employee;
            attachment = new Attachment();
        }
        
    }
 public class Attachment
    {
        public string name,filepath;
      public  List<Employee> employees;
        public Attachment(string n,string f,List<Employee>employees)
        {
            name = n;
            filepath = f;
            this.employees = employees;
        }
        public Attachment()
        {

        }
    }
}
