using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM
{
    class Project
    {
        public string name;
        public string descri;
        public int id;
        public int noOfemp;
        List<Employee> emps;
        List<Task> tasks;
        
        public Project()
        {
            name = null;
            descri = null;
            id = 0;
            noOfemp = 0;
            emps= null;
            tasks = null;
        }
        public Project(string n,string d,int i,List<Employee>employees,List<Task>task)
        {
            name = n;
            descri = d;
            id = i;
            noOfemp = 0;
            emps = employees;
            tasks = task;
        }
    }
    class Task
    {
        public string name;
        public string comment;
        public Task()
        {
            name = null;
            comment = null;
        }
        public Task(string n,string c)
        {
            name = n;
            comment = c;
        }
    }
}
