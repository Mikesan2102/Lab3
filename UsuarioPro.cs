﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class UsuarioPro
    {
        string nombre;
        string apellido;
        string no;
        double mantenimiento;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string No { get => no; set => no = value; }
        public double Mantenimiento { get => mantenimiento; set => mantenimiento = value; }
    }
}
