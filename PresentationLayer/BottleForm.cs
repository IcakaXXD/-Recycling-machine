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
    public partial class BottleForm : Form
    {
        private DbManager<Bottle, int> dbmanager = new DbManager<Bottle , int>(ContextGenerator.GetBottlesContext());

        public BottleForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                char type = textBox2.Text.Trim().ToLower().ToCharArray()[0];
                char size = textBox3.Text.Trim().ToLower().ToCharArray()[0];
                int amaunt = int.Parse(textBox4.Text);
                if(ValidationManager.IsValidTypeSize(type,size))
                {
                    double price = Price(type,size,amaunt);
                    Bottle bottles = new Bottle(type,size,amaunt,price,id);
                    dbmanager.Create(bottles);
                }
                this.Close();
        }
            catch (Exception ex) 
            {
                throw ex;       
            }
}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private double Price(char Type, char Size, int Amaunt)
        {
            switch (Type)
            {
                case 'p':
                    if (Size == 's') return (0.02 * Amaunt);
                    else if (Size == 'b') return (0.05 * Amaunt);
                    break;
                case 'g':
                    if (Size == 's') return (0.07 * Amaunt);
                    else if (Size == 'b') return (0.15 * Amaunt);
                    else if (Size == 'l') return (0.20 * Amaunt);
                    break;
                case 'c':
                    if (Size == 's') return (0.03 * Amaunt);
                    else if (Size == 'b') return (0.06 * Amaunt);
                    else if (Size == 'l') return (0.09 * Amaunt);
                    break;
            }
            return 0;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
