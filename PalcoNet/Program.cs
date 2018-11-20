using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int usuario = 1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            Application.Run(new Form1());
=======

       //     Application.Run(new LOGIN());
            Application.Run(new ABMCliente(usuario));
        //    Application.Run(new ABMEmpresa(usuario));
>>>>>>> d713694c05f9315480f2e64ae129a88bed515745
=======
            Application.Run(new ABMEmpresa(usuario));
>>>>>>> parent of e0d4a36... abm rol funcionando, login y seg funcionando, ver ABM usuarios!
=======
            Application.Run(new Form1());
>>>>>>> parent of e9638d7... subo cambios
        }
    }
}
