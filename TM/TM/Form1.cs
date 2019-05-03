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
           
        }
    }
}
