﻿using System;
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


            
            DateTime dt = DateTime.ParseExact("25/12/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ComprarPrincipal dac = new ComprarPrincipal(usuario, null, null, DateTime.Today, dt);
            Application.Run(dac);
            DBConsulta.conexionCerrar();

       //     Application.Run(new LOGIN());
    //        Historial hs = new Historial(usuario);
    //        Application.Run(hs);
     //       Application.Run(new ABMCliente(usuario));
     //      Application.Run(new tablaPaginada());
      //     Application.Run(new ABMEmpresa(usuario));
/*
        //    Application.Run(new ABMCliente(usuario));
           Application.Run(new canjePuntos(usuario));
*/
       //     Application.Run(new Form1());
          //  Application.Run(new ListadoEstadistico());

        }
    }
}
