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
    public partial class BoxForm : Form
    {
        private DbManager<Box, int> dbmanager = new DbManager<Box, int>(ContextGenerator.GetBoxesContext());

        public BoxForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
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
                if (ValidationManager.IsValidBoxTypeSize(type, size))
                {
                    double price = Price(type, size, amaunt);
                    Box boxes = new Box(type, size, amaunt, price, id);
                    dbmanager.Create(boxes);
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
                    if (Size == 's') return (0.2 * Amaunt);
                    else if (Size == 'm') return (0.5 * Amaunt);
                    else if (Size == 'b') return (0.8 * Amaunt);
                    else if (Size == 'h') return (1 * Amaunt);
                    break;
                case 'c':
                    if (Size == 's') return (0.03 * Amaunt);
                    else if (Size == 'm') return (0.05 * Amaunt);
                    else if (Size == 'b') return (0.09 * Amaunt);
                    else if (Size == 'h') return (0.12 * Amaunt);
                    break;
                case 'w':
                    if (Size == 's') return (0.60 * Amaunt);
                    else if (Size == 'm') return (0.90 * Amaunt);
                    else if (Size == 'b') return (1.29 * Amaunt);
                    else if (Size == 'h') return (1.55 * Amaunt);
                    break;
            }
            return 0;
        }
    }
}
