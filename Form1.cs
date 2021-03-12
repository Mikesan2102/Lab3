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
        int contNop = 1;
        public string dpi;
        public string name;
        public string surname;
        Boolean hPd = false;
        int ContPd = 0;
        Boolean hPro = false;
        int ContPro = 0;
        Boolean hUsu = false;
        int ContUsu = 0;
        Boolean hNop = false;
        int cont = 0;
        Boolean hCuo = false;
        int contCuo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        void escribirPropietarios()
        {
            FileStream stream = new FileStream("propietarios.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var o in per)
            {
                write.WriteLine(o.Dpi);
                write.WriteLine(o.Nombre);
                write.WriteLine(o.Apellido);
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
                propiedad propi = new propiedad();
                propi.Dpi = read.ReadLine();
                propi.Ncasa = read.ReadLine();
                propi.Cuota = Convert.ToDouble(read.ReadLine());
                pro.Add(propi);
            }
            read.Close();
        }

        void escribirUP()
        {
            FileStream stream = new FileStream("Usuariospro.txt", FileMode.OpenOrCreate, FileAccess.Write);
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
            string fileName = "Usuariospro.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                UsuarioPro usua = new UsuarioPro();
                usua.Nombre = reader.ReadLine();
                usua.Apellido = reader.ReadLine();
                usua.No = reader.ReadLine();
                usua.Mantenimiento = Convert.ToDouble(reader.ReadLine());
                usu.Add(usua);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = usu;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidosPd()
        {
            while (hPd == false && ContPd < pro.Count)
            {
                if (pro[ContPd].Ncasa.CompareTo(textBox4.Text) == 0)
                {
                    hPd = true;
                }
                else
                {
                    ContPd++;
                }
            }
        }

        void repetidosPr()
        {
            while (hPro == false && ContPro < per.Count)
            {
                if (per[ContPro].Dpi.CompareTo(textBox1.Text) == 0)
                {
                    hPro = true;
                }
                else
                {
                    ContPro++;
                }
            }
        }

        void repetidosUP()
        {
            while (hUsu == false && ContUsu < usu.Count)
            {
                if (usu[ContUsu].No.CompareTo(textBox4.Text) == 0)
                {
                    hUsu = true;
                }
                else
                {
                    ContUsu++;
                }
            }
        }

        void repetidosCP()
        {
            while (hNop == false && cont < nop.Count)
            {
                if (nop[cont].Nombre.CompareTo(textBox2.Text) == 0 && nop[cont].Apellido.CompareTo(textBox3.Text) == 0)
                {
                    hNop = true;
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
                NoPro cant = new NoPro();
                cant.Nombre = read.ReadLine();
                cant.Apellido = read.ReadLine();
                cant.Cantidad = Convert.ToInt32(read.ReadLine());
                nop.Add(cant);
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
                CuotaMayot may = new CuotaMayot();
                may.Npmbre = read.ReadLine();
                may.Apellido = read.ReadLine();
                may.Mante = Convert.ToDouble(read.ReadLine());
                cuo.Add(may);
            }
            read.Close();
        }

        void repetidosMayor()
        {
            while (hCuo == false && contCuo < cuo.Count)
            {
                if (cuo[contCuo].Npmbre.CompareTo(textBox2.Text) == 0 && cuo[contCuo].Apellido.CompareTo(textBox3.Text) == 0)
                {
                    hCuo = true;
                }
                else
                {
                    contCuo++;
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
                if (hPro)
                {
                    repetidosCP();
                    if (hNop)
                    {
                        c.Nombre = textBox2.Text;
                        c.Apellido = textBox3.Text;
                        nop[cont].Cantidad += 1;
                        c.Cantidad = nop[cont].Cantidad;
                        nop.Add(c);
                        nop.RemoveAt(cont);
                        escribirCantidad();
                        hNop = false;
                        cont = 0;
                    }
                    else
                    {
                        cont = 0;
                    }

                    hPro = false;
                    ContPro = 0;
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
                    c.Cantidad = contNop;
                    nop.Add(c);
                    escribirCantidad();
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    ContPro = 0;
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
                if (hUsu)
                {
                    MessageBox.Show("El número de casa introducido ya no está disponible");
                    textBox4.Clear();
                    hUsu = false;
                    ContUsu = 0;
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
                    if (hCuo)
                    {
                        m.Npmbre = textBox2.Text;
                        m.Apellido = textBox3.Text;
                        m.Mante= cuo[contCuo].Mante + Convert.ToDouble(textBox5.Text);
                        cuo.Add(m);
                        cuo.RemoveAt(contCuo);
                        escribirMayor();
                        hCuo = false;
                        contCuo = 0;
                    }
                    else
                    {
                        m.Npmbre = textBox2.Text;
                        m.Apellido = textBox3.Text;
                        m.Mante = Convert.ToDouble(textBox5.Text);
                        cuo.Add(m);
                        escribirMayor();
                        contCuo = 0;
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
