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
using System.Xml.Serialization;

namespace Survey
{
    public partial class AddList : Form
    {
        public AddList()
        {
            InitializeComponent();
            form1 = (Survey)this.Owner;
            users = new List<User>();
            a = users.Distinct().ToList();
        }
            Survey form1 ;
        public List<User> users;

        public List<User> a;

        private void UnSaveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
   
        }

        private void Saveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            

            Add();

        }

        public void Add()
        {
        

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                a.Add(new User
                {
                    Name = textBox1.Text,
                    LastName = textBox2.Text,
                    Age = int.Parse(textBox3.Text),
                    Mobilnumber = int.Parse(textBox4.Text),

                });
            }

            else
            {
                MessageBox.Show($"Least one textbox is empty");
            }



            foreach (var item in a)
            {
               

                    (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Add(item.FullData);
                
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            //if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex == -1)
            //{
            //    textBox1.Text = textBox1.Text;
            //    textBox2.Text = textBox2.Text;
            //    textBox3.Text = textBox3.Text;
            //    textBox4.Text = textBox4.Text;

            //}

            //else
            //{
            //    string SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();

            //    string[] words = SelectedItemToString.Split(' ');

            //    textBox1.Text = words[1];
            //    textBox2.Text = words[2];
            //    textBox3.Text = words[3];
            //    textBox4.Text = words[4];
            //}

        }

        public void AddList_FormClosed(object sender, FormClosedEventArgs e)
        {


            save();


        }

        public void save()
        {
        

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"../../Data.json", true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, a);
                }
            }


            User[] arrayuser = null;
            var serializer2 = new JsonSerializer();

            using (var sr = new StreamReader($"../../Data.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    arrayuser = serializer2.Deserialize<User[]>(jr);
                }
          
            }

            
        }
    }

}
