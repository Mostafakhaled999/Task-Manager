using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace TM
{
   public abstract class Employee
    {
        public int id;
       public static int noOfemp = 0;
        public string name, password;
        
        public Employee(int i,string n,string p)
        {
            id = i;
            name = n;
            password = p;
        }
      public  Employee()
        {
            id = 0;
            name = null;
            password =null;
        }
        public abstract bool register();
        public abstract bool login(int i,string pass);
        public abstract bool comment();
        public abstract bool attach();
        public abstract bool forward();
        public abstract bool download();

    }
  public  class User : Employee
    {
        
       public User() : base()
        {

        }
        public User(int i,string s,string p) : base(i,s,p)
        {

        }
        public override bool attach()
        {
            throw new NotImplementedException();
        }

        public override bool comment()
        {
            throw new NotImplementedException();
        }

        public override bool download()
        {
            throw new NotImplementedException();
        }

        public override bool forward()
        {
            throw new NotImplementedException();
        }

        public override bool login(int i,string pass)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Employees.xml");
            XmlNodeList list = doc.GetElementsByTagName("user");

            for (int a   = 0; a < list.Count; a++)
            {
                XmlNodeList child = list[a].ChildNodes;
                if (i.Equals(int.Parse(child[0].InnerText))&&pass.Equals(child[2].InnerText))
                {
                    id = int.Parse(child[0].InnerText);
                    name = child[1].InnerText;
                    password = child[2].InnerText;
                    return true;
                }
                

            }
            return false;

        }

        public override bool register()
        {
            if (!File.Exists("Employees.xml"))
            {
                XmlWriter writer = XmlWriter.Create("Employees.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("Emloyees");

                writer.WriteStartElement("Users");

                writer.WriteStartElement("user");

                writer.WriteStartElement("ID");
                writer.WriteString(id.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Name");
                writer.WriteString(name);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(password);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                return true;
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement user = doc.CreateElement("user");

                XmlElement node = doc.CreateElement("ID");
                node.InnerText = id.ToString();
                user.AppendChild(node);

                node = doc.CreateElement("Name");
                node.InnerText = name;
                user.AppendChild(node);

                node = doc.CreateElement("Password");
                node.InnerText = password;
                user.AppendChild(node);

                doc.Load("Employees.xml");
                XmlElement root = doc.DocumentElement["Users"];
                root.AppendChild(user);

                doc.Save("Employees.xml");
                return true;
            }
        }
    }


 public   class Admin : Employee
    {
        public Admin() : base()
        {

        }
        public Admin(int i, string s, string p) : base(i, s, p)
        {

        }
        public override bool attach()
        {
            throw new NotImplementedException();
        }

        public override bool comment()
        {
            throw new NotImplementedException();
        }

        public override bool download()
        {
            throw new NotImplementedException();
        }

        public override bool forward()
        {
            throw new NotImplementedException();
        }

        public override bool login(int i, string pass)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Employees.xml");
            XmlNodeList list = doc.GetElementsByTagName("admin");

            for (int a = 0; a < list.Count; a++)
            {
                XmlNodeList child = list[a].ChildNodes;
                if (i.Equals(int.Parse(child[0].InnerText)) && pass.Equals(child[2].InnerText))
                {
                    id = int.Parse(child[0].InnerText);
                    name = child[1].InnerText;
                    password = child[2].InnerText;
                    return true;
                }


            }
            return false;
        }

        public override bool register()
        {

            if (!File.Exists("Employees.xml"))
            {
                XmlWriter writer = XmlWriter.Create("Employees.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("Emloyees");

                writer.WriteStartElement("Admins");

                writer.WriteStartElement("admin");

                writer.WriteStartElement("ID");
                writer.WriteString(id.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Name");
                writer.WriteString(name);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(password);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                return true;
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement user = doc.CreateElement("admin");

                XmlElement node = doc.CreateElement("ID");
                node.InnerText = id.ToString();
                user.AppendChild(node);

                node = doc.CreateElement("Name");
                node.InnerText = name;
                user.AppendChild(node);

                node = doc.CreateElement("Password");
                node.InnerText = password;
                user.AppendChild(node);

                doc.Load("Employees.xml");
                try
                {
                    XmlElement root = doc.DocumentElement["Admins"];
                    root.AppendChild(user);

                    doc.Save("Employees.xml");
                }
                catch (Exception)
                {

                    XmlElement root1 = doc.CreateElement("Admins");
                    root1.AppendChild(user);
                    XmlElement root0 = doc.DocumentElement;
                    root0.AppendChild(root1);
                    doc.Save("Employees.xml");
                }
               
                return true;
            }
        }
        public void createProject(string n, string d)
        {
            List<Project> projects = new List<Project>();
            Project pro = new Project(n, d, name);
           
            if (!File.Exists("Projects.xml"))
            {
                projects.Add(pro);
                FileStream fs = new FileStream("Projects.xml", FileMode.Append);
                XmlSerializer xs = new XmlSerializer(projects.GetType());
                xs.Serialize(fs, projects);
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream("Projects.xml", FileMode.Open);
                XmlSerializer xs = new XmlSerializer(projects.GetType());
                projects = (List<Project>)xs.Deserialize(fs);
                projects.Add(pro);
                fs.Close();
                fs = new FileStream("Projects.xml", FileMode.Open);
                xs.Serialize(fs, projects);
                fs.Close();
            }
           
        }
    }
}
