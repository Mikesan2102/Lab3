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
    public partial class Form1 : Form
    {
        List<persona> per = new List<persona>();
        List<propiedad> pro = new List<propiedad>();
        List<CuotaMayot> cuo = new List<CuotaMayot>();
        List<NoPro> nop = new List<NoPro>();
        List<UsuarioPro> usu = new List<UsuarioPro>();
        int cP = 1;
        public string dpi;
        public string name;
        public string surname;
        Boolean hallarPd = false;
        int Pd = 0;
        Boolean hallarPr = false;
        int Pr = 0;
        Boolean hallarUP = false;
        int Up = 0;
        Boolean hallarCP = false;
        int cont = 0;
        Boolean hallarM = false;
        int cm = 0;
        public Form1()
        {
            InitializeComponent();
        }

        void escribirPropietarios()
        {
            FileStream stream = new FileStream("propietarios.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var p in per)
            {
                write.WriteLine(p.Dpi);
                write.WriteLine(p.Nombre);
                write.WriteLine(p.Apellido);
            }
            write.Close();
        }

        void leerPropietarios()
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

        void escribirPropiedades()
        {
            FileStream stream = new FileStream("propiedades.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var p in pro)
            {
                write.WriteLine(p.Dpi);
                write.WriteLine(p.Ncasa);
                write.WriteLine(p.Cuota);
            }
            write.Close();
        }

        void leerPropiedades()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                propiedad p = new propiedad();
                p.Dpi = read.ReadLine();
                p.Ncasa = read.ReadLine();
                p.Cuota = Convert.ToDouble(read.ReadLine());
                pro.Add(p);
            }
            read.Close();
        }

        void escribirUP()
        {
            FileStream stream = new FileStream("usp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var u in usu)
            {
                write.WriteLine(u.Nombre);
                write.WriteLine(u.Apellido);
                write.WriteLine(u.No);
                write.WriteLine(u.Mantenimiento);
            }
            write.Close();
        }

        void leerUP()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "usp.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                UsuarioPro u = new UsuarioPro();
                u.Nombre = reader.ReadLine();
                u.Apellido = reader.ReadLine();
                u.No = reader.ReadLine();
                u.Mantenimiento = Convert.ToDouble(reader.ReadLine());
                usu.Add(u);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = usu;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidosPd()
        {
            while (hallarPd == false && Pd < pro.Count)
            {
                if (pro[Pd].Ncasa.CompareTo(textBox4.Text) == 0)
                {
                    hallarPd = true;
                }
                else
                {
                    Pd++;
                }
            }
        }

        void repetidosPr()
        {
            while (hallarPr == false && Pr < per.Count)
            {
                if (per[Pr].Dpi.CompareTo(textBox1.Text) == 0)
                {
                    hallarPr = true;
                }
                else
                {
                    Pr++;
                }
            }
        }

        void repetidosUP()
        {
            while (hallarUP == false && Up < usu.Count)
            {
                if (usu[Up].No.CompareTo(textBox4.Text) == 0)
                {
                    hallarUP = true;
                }
                else
                {
                    Up++;
                }
            }
        }

        void repetidosCP()
        {
            while (hallarCP == false && cont < nop.Count)
            {
                if (nop[cont].Nombre.CompareTo(textBox2.Text) == 0 && nop[cont].Apellido.CompareTo(textBox3.Text) == 0)
                {
                    hallarCP = true;
                }
                else
                {
                    cont++;
                }
            }
        }

        void escribirCantidad()
        {
            FileStream stream = new FileStream("cantidad.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var c in nop)
            {
                write.WriteLine(c.Nombre);
                write.WriteLine(c.Apellido);
                write.WriteLine(c.Cantidad);
            }
            write.Close();
        }

        void leerCantidad()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "cantidad.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                NoPro c = new NoPro();
                c.Nombre = read.ReadLine();
                c.Apellido = read.ReadLine();
                c.Cantidad = Convert.ToInt32(read.ReadLine());
                nop.Add(c);
            }
            read.Close();
        }

        void escribirMayor()
        {
            FileStream stream = new FileStream("mayor.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var m in cuo)
            {
                write.WriteLine(m.Npmbre);
                write.WriteLine(m.Apellido);
                write.WriteLine(m.Mante);
            }
            write.Close();
        }

        void leerMayor()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "mayor.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);
            while (read.Peek() > -1)
            {
                CuotaMayot m = new CuotaMayot();
                m.Npmbre = read.ReadLine();
                m.Apellido = read.ReadLine();
                m.Mante = Convert.ToDouble(read.ReadLine());
                cuo.Add(m);
            }
            read.Close();
        }

        void repetidosMayor()
        {
            while (hallarM == false && cm < cuo.Count)
            {
                if (cuo[cm].Npmbre.CompareTo(textBox2.Text) == 0 && cuo[cm].Apellido.CompareTo(textBox3.Text) == 0)
                {
                    hallarM = true;
                }
                else
                {
                    cm++;
                }
            }
        }

        void mayor()
        {
            if (nop.Count >= 1)
            {
                textBox6.Clear();
                nop = nop.OrderByDescending(c => c.Cantidad).ToList();
                textBox6.AppendText(nop[0].Nombre + " " + nop[0].Apellido);
            }
        }

        void mayorM()
        {
            if (pro .Count >= 3)
            {
                listBox1.Items.Clear();
                pro = pro.OrderByDescending(p => p.Cuota).ToList();
                listBox1.Items.Insert(0, pro[0].Cuota);
                listBox1.Items.Insert(1, pro[1].Cuota);
                listBox1.Items.Insert(2, pro[2].Cuota);
            }
        }

        void menorM()
        {
            if (pro.Count >= 3)
            {
                listBox2.Items.Clear();
                pro= pro.OrderBy(p => p.Cuota).ToList();
                listBox2.Items.Insert(0, pro[0].Cuota);
                listBox2.Items.Insert(1, pro[1].Cuota);
                listBox2.Items.Insert(2, pro[2].Cuota);
            }
        }

        void mayorT()
        {
            if (cuo.Count >= 1)
            {
                label12.Text.Remove(0);
                cuo = cuo.OrderByDescending(m => m.Mante).ToList();
                label12.Text = cuo[0].Npmbre + " " + cuo[0].Apellido + " es el propietario con la cuota de mantenimiento más alta con " +
                    cuo[0].Mante;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                NoPro c = new NoPro();
                repetidosPr();
                if (hallarPr)
                {
                    repetidosCP();
                    if (hallarCP)
                    {
                        c.Nombre = textBox2.Text;
                        c.Apellido = textBox3.Text;
                        nop[cont].Cantidad += 1;
                        c.Cantidad = nop[cont].Cantidad;
                        nop.Add(c);
                        nop.RemoveAt(cont);
                        escribirCantidad();
                        hallarCP = false;
                        cont = 0;
                    }
                    else
                    {
                        cont = 0;
                    }

                    hallarPr = false;
                    Pr = 0;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                }
                else
                {
                    persona p = new persona();
                    p.Dpi = textBox1.Text;
                    p.Nombre = textBox2.Text;
                    p.Apellido = textBox3.Text;
                    per.Add(p);
                    escribirPropietarios();
                    c.Nombre = textBox2.Text;
                    c.Apellido = textBox3.Text;
                    c.Cantidad = cP;
                    nop.Add(c);
                    escribirCantidad();
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    Pr = 0;
                }
                textBox4.Focus();
                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = dpi;
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox2.Focus();
            leerPropietarios();
            leerPropiedades();
            leerUP();
            leerCantidad();
            leerMayor();
            if (nop.Count >= 1)
            {
                mayor();
            }
            if (pro.Count >= 3)
            {
                mayorM();
                menorM();
            }

            if (cuo.Count >= 1)
            {
                mayorT();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && Convert.ToDouble(textBox5.Text) > 0)
            {
                propiedad p = new propiedad();
                UsuarioPro us = new UsuarioPro();
                CuotaMayot m = new CuotaMayot();
                p.Ncasa = textBox4.Text;
                repetidosUP();
                if (hallarUP)
                {
                    MessageBox.Show("El número de casa introducido ya no está disponible");
                    textBox4.Clear();
                    hallarUP = false;
                    Up = 0;
                }
                else
                {
                    p.Dpi = textBox1.Text;
                    p.Cuota = Convert.ToDouble(textBox5.Text);
                    pro.Add(p);
                    escribirPropiedades();
                    us.Nombre = textBox2.Text;
                    us.Apellido = textBox3.Text;
                    us.No = textBox4.Text;
                    us.Mantenimiento = Convert.ToDouble(textBox5.Text);
                    usu.Add(us);
                    escribirUP();
                    repetidosMayor();
                    if (hallarM)
                    {
                        m.Npmbre = textBox2.Text;
                        m.Apellido = textBox3.Text;
                        m.Mante= cuo[cm].Mante + Convert.ToDouble(textBox5.Text);
                        cuo.Add(m);
                        cuo.RemoveAt(cm);
                        escribirMayor();
                        hallarM = false;
                        cm = 0;
                    }
                    else
                    {
                        m.Npmbre = textBox2.Text;
                        m.Apellido = textBox3.Text;
                        m.Mante = Convert.ToDouble(textBox5.Text);
                        cuo.Add(m);
                        escribirMayor();
                        cm = 0;
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = usu  ;
                    dataGridView1.Refresh();
                    MessageBox.Show("Propiedad asignada exitósamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    button2.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            mayor();
            mayorM();
            menorM();
            mayorT();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usu = usu.OrderByDescending(u => u.Mantenimiento).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = usu;
            dataGridView1.Refresh();
        }
    }
}
