using Microsoft.AspNet.SignalR.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Survey
{
    public partial class Survey : Form
    {
        public Survey()
        {
            InitializeComponent();



      

        }

     
        private void Addguna2Button1_Click(object sender, EventArgs e)
        {
            AddList form2 = new AddList();

            this.Hide();


            form2.ShowDialog(this);
            this.Show();
        }

        private void Editguna2Button1_Click(object sender, EventArgs e)
        {
          
                Editguna2Button1.Enabled = true;
                EditList form3 = new EditList();

                this.Hide();


                form3.ShowDialog(this);
                this.Show();
            

         
        }

        private void Deleteguna2Button1_Click(object sender, EventArgs e)
        {
            AddList form2 = new AddList();

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
       


        }

        private void Survey_Load(object sender, EventArgs e)
        {
            if (File.Exists($"../../Data.json"))
            {
                File.Delete($"../../Data.json");

            }



        }

        private void Survey_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
