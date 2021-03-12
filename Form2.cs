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

namespace Lab3
{
    public partial class Form2 : Form
    {
        List<persona> per = new List<persona>();
        Boolean h = false;
        int c = 0;
        public Form2()
        {
            InitializeComponent();
        }

        void leerpro()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                persona p = new persona();
                p.Dpi = reader.ReadLine();
                p.Nombre = reader.ReadLine();
                p.Apellido = reader.ReadLine();
                per.Add(p);
            }
            reader.Close();
        }

        void duplicados()
        {
            while (h == false && c < per.Count)
            {
                if (per[c].Dpi.CompareTo(textBox1.Text) == 0)
                {
                    h = true;
                }
                else
                {
                    c++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                leerpro();
                Form1 f2 = new Form1();
                persona p = new persona();
                p.Dpi = textBox1.Text;
                duplicados();
                if (h)
                {
                    f2.dpi = textBox1.Text;
                    f2.name = per[c].Nombre;
                    f2.surname = per[c].Apellido;
                    textBox1.Clear();
                    h = false;
                    c = 0;
                }
                else
                {
                    f2.dpi = textBox1.Text;
                    f2.textBox2.Enabled = true;
                    f2.textBox2.Focus();
                    f2.textBox3.Enabled = true;
                    textBox1.Clear();
                    c = 0;
                }
                f2.Show();
                f2.button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Porfavor introduzca el Número de DPI");
            }
        }
    }
}
