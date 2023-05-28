using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class CreateUserForm : Form
    {
        private DbManager<User, int> dbmanager = new DbManager<User, int>(ContextGenerator.GetUsersContext());
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (ValidationManager.IsValidString(name))
            {
                dbmanager.Create(new User(name));
                IEnumerable<User> users = dbmanager.ReadAll(false);
                int id = users.FirstOrDefault(x => x.Name == name).ID;
                textBox2.Text = id.ToString();
            }
            else
            {
                throw new Exception("not supported name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
