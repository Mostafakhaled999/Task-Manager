using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TM
{
   public class Employee
    {
        public
        string name, id, pass, Mobile_number, Email_address, type ;
    
    }
    class Amdin:Employee
    {
        public void CreateProject(Project n)
        {

        }
    }
   public class User:Employee
    {
        public
        List<Project> projectlist { set; get; }
    }
   public class Project
    {
        public string name,id;
        List<Task> tasks;
    }
    class Task
    {
        public string name, description;
        Boolean finish;
    }

}
