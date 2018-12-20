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
using PalcoNet.Historial_Cliente;
using PalcoNet.Comprar;
using PalcoNet.Support;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Abm_Grado;
using PalcoNet.Generar_Publicacion;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ESTE ES EL QUE DA INICIO

            Application.Run(new Inicio());
        }
    }
}
