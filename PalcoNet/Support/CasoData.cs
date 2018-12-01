using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Support;

namespace PalcoNet.Support
{
    class CasoData
    {
        public static String obtenerStringPrimeraCelda(DataTable dt)
        {
            return dt.Rows[0][0].ToString();
        }
    }
}
