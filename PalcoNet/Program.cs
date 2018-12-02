using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Cliente;
using PalcoNet.Login_y_seguridad;
using PalcoNet.Listado_Estadistico;
using PalcoNet.Canje_Puntos;

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
            int usuario = 291;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

       //     Application.Run(new LOGIN());
<<<<<<< HEAD
            Application.Run(new ABMCliente(usuario));
     //      Application.Run(new tablaPaginada());
      //     Application.Run(new ABMEmpresa(usuario));
=======
        //    Application.Run(new ABMCliente(usuario));
           Application.Run(new canjePuntos(usuario));
>>>>>>> 6adf0cff75221cde3bda23c70c77062ce7c74dd1
       //     Application.Run(new Form1());
          //  Application.Run(new ListadoEstadistico());

        }
    }
}
