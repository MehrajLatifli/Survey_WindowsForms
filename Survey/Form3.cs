using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Survey
{
    public partial class EditList : Form
    {
        public EditList()
        {
            InitializeComponent();
            form1 = (Survey)this.Owner;
            users = new List<User>();
   
        }
        Survey form1;
        public List<User> users;
      

        string SelectedItemToString = "";
        string[] words;
        private void Form3_Load(object sender, EventArgs e)
        {
            if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex == -1)
            {
                textBox1.Text = textBox1.Text;
                textBox2.Text = textBox2.Text;
                textBox3.Text = textBox3.Text;
                textBox4.Text = textBox4.Text;

            }

            else
            {
                SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();

                string[] words = SelectedItemToString.Split(' ');

                textBox1.Text = words[1];
                textBox2.Text = words[2];
                textBox3.Text = words[3];
                textBox4.Text = words[4];
            }
        }

        private void Saveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Remove();
            Add();
            Editsave();
        }

        public void Remove()
        {

            //SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();
            //string[] words = SelectedItemToString.Split(' ');

            //var remove = a.FirstOrDefault(r => r.FullData == SelectedItemToString);

            //a.Remove(remove);




            (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Remove(SelectedItemToString);

            foreach (var item in users)
            {

                (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Remove(item.FullData);
            }


            //   a.RemoveAll(x => x.FullData == SelectedItemToString);

            foreach (var item in users)
            {
                if(item.FullData.Equals(SelectedItemToString))
                {
                    users.Remove(item);
           
                    break;
                }
            }

        }
        public void Add()
        {


            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {

                users.Add(new User
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


            foreach (var item in users)
            {

                (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Add(item.FullData);
            }


     

     
        }

        private void EditList_FormClosed(object sender, FormClosedEventArgs e)
        {
          
          //  Editsave();
        }




        public void Editsave()
        {

            try
            {
                // SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();

                //string[] words = SelectedItemToString.Split(' ');

                //var remove = a.FirstOrDefault(r => r.Name == words[1]);
                //a.Remove(remove);

            }
            catch (Exception)
            {


            }


            //if (File.Exists($"../../Data.json"))
            //{
            //    File.Delete($"../../Data.json");

            //}


            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"../../Data.json", true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, users);



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
