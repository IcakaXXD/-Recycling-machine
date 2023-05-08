using BusinessLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class CheckUserForm : Form
    {
        private DbManager<User, int> dbmanager = new DbManager<User, int>(ContextGenerator.GetUsersContext());
        public CheckUserForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            User user = dbmanager.Read(id);
            textBox2.Text = user.Name;
            textBox3.Text = user.Money.ToString();
        }
    }
}
