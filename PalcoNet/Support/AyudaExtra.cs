using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Support;

namespace PalcoNet.Support
{
    class AyudaExtra
    {
        public static bool CUILYNroDocSeCorresponden(String nro, String cuil)
        {
            int n = nro.Length;
            String cuilnro = cuil.Substring(2, n);
            return cuilnro.Contains(nro);
        }

         public static bool esStringNumerico(String s) { 
            int n;
            return int.TryParse(s, out n);
        }

        public static bool esStringLetra(String input) {
            return input.All(Char.IsLetter);
        }

        public static bool esStringLetraOEspacio(String input) {
            return input.All(c => Char.IsLetter(c) || c == '_');
        }

        public static bool esUnMail(String mail)
        {
            return mail.Contains("@") && mail.Contains(".com");
        }

        public static String FechaEnSQLDate(DateTime myDateTime) {
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }

    class autogenerarContrasenia { 
        public static int generar()
        {
            Random rnd = new Random();
            return rnd.Next(1000000, 9999999);
        }

        public static String contraGeneradaAString() {
            return generar().ToString();
        }
    }
}
