using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class propiedad
    {
        string ncasa;
        string dpi;
        double cuota;

        public string Ncasa { get => ncasa; set => ncasa = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public double Cuota { get => cuota; set => cuota = value; }
    }
}
