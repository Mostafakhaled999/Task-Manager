using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

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
        }
        public void addemployee(Employee em)
        {
            emps.Add(em);
        }
        public void addtask(Task tsk)
        {
            tasks.Add(tsk);
        }
    }
   public class Task
    {
        public string name;
        public string comment;
        public string duration;
        public Employee emp;
        public bool status;
        public Task()
        {
            name = null;
            comment = null;
            duration = null;
            status = true;
        }
        public Task(string n,string c,string d)
        {
            name = n;
            comment = c;
            duration = d;
            status = true;
        }
    }
}
