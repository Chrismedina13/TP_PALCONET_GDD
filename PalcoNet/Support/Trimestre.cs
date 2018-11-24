using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Support
{
    class Trimestre
    {
        public int diaInicio { get; set; }
        public int mesInicio { get; set; }
        public int diaFin { get; set; }
        public int mesFin { get; set; }
        public String nombre { get; set; }

        public Trimestre(int diaI, int mesI, int diaF, int mesF, String nombre)
        {
            this.diaInicio = diaI;
            this.mesInicio = mesI;
            this.diaFin = diaF;
            this.mesFin = mesF;
            this.nombre = nombre;
        }


    }
}
