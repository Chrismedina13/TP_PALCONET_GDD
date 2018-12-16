using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Support;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PalcoNet.Support
{
    class AyudaExtra
    {
        /*
        public bool fecha1EsMayorQueFecha2(String fecha1, String fecha2)
        {
            return true;
        
        }
        */

        public bool esFechaHoy(DateTime dt) {
            DateTime hoy = DateTime.Today;
            if (hoy.Year == dt.Year && hoy.Month == dt.Month && hoy.Day == dt.Day) {
                return true;
            }
            return false;
        }

        public static bool esStringVacio(String a) {
            return a == "";
        }
        
        public static bool fechaMenorQueActual(DateTime fecha) {
            return fecha < DateTime.Today;
        }

        public static bool fechaIgualQueActual(DateTime fecha) {
            return fecha == DateTime.Today;
        }

        public static bool esStringConLetraONumero(String a) {
            return (Regex.Matches(a, @"[a-zA-Z]").Count > 1) || a.Any(c => char.IsDigit(c));
        }

        public static bool esStringConLetraONumeroYSinEspacio(String a) {
            return esStringConLetraONumero(a) == true && esStringConEspacio(a) == true;
        }

        public static bool esStringConEspacio(String a) {
            return a.Any(char.IsWhiteSpace) == true;
        }

        public static bool CUILYNroDocSeCorresponden(String nro, String cuil)
        {
            int n = nro.Length;
            String cuilnro = cuil.Substring(2, n);
            return cuilnro.Contains(nro);
        }

        public static bool CUILYContraseniaParecenRespetarTamanios(String nro, String cuil) {
            return nro.Length +3 <= cuil.Length;
        }

         public static bool esStringNumerico(String s) { 
            int n;
            return int.TryParse(s, out n);
        }

        public static bool esStringLetra(String input) {
            return input.All(Char.IsLetter);
        }

        public static bool esStringConAlgunaLetra(String input)
        {
            return input.Any(Char.IsLetter);
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

        public String fechaObtenerMinuto(String fecha) {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
                res += parte + "-";
                dia = parte;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);

                res += parte + "-";
                mes = parte;
                anio = restoFecha;
            }
            String minuto;
            aux = fechaAux.IndexOf(":");
            String primerAnio = anio.Substring(0, 4);
            minuto = anio.Substring(aux, 2);
            res = primerAnio + "-" + mes + "-" + dia + " 0:00:00.000";

            return minuto;
        }

        public String fechaObtenerHora(String fecha) {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
                res += parte + "-";
                dia = parte;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);

                res += parte + "-";
                mes = parte;
                anio = restoFecha;
            }
            String hora;
                aux = fechaAux.IndexOf(":");
                String primerAnio = anio.Substring(0, 4);
                 hora = anio.Substring(5, 2);
                res = primerAnio + "-" + mes + "-" + dia + " 0:00:00.000";
            
            return hora;
        }

        public String fechaObtenerDia(String fecha) {
            String res = "", fechaAux = fecha, dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);
                dia = parte;
            }
            return dia;
        }

        public String fechaObtenerMes(String fecha) {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                parte = fechaAux.Substring(0, aux);
                mes = parte;
            }
            return mes;
        }

        public String fechaObtenerAnio(String fecha) {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
                res += parte + "-";
                dia = parte;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                anio = restoFecha;
            }
            return anio.Substring(0, 4);
        }

        public static String stringAFormatoFechaSQLDateSinHora(String fecha) {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia = "", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/"))
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
                res += parte + "-";
                dia = parte;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);

                res += parte + "-";
                mes = parte;
                anio = restoFecha;
            }
            if (anio.Contains(":"))
            {
                String primerAnio = anio.Substring(0, 4);
                res = primerAnio + "-" + mes + "-" + dia;
            }
            MessageBox.Show(res);
            return res;
        }

        public static String stringAFormatoFechaSQLDate(String fecha) 
        {
            String res = "", fechaAux = fecha, anio = "", mes = "", dia="", parte = "", restoFecha = "";
            int aux;
            if (fechaAux.Contains("/")) 
            {
                aux = fecha.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux + 1, fechaAux.Length - aux - 1);
                fechaAux = restoFecha;
                res += parte + "-";
                dia = parte;
            }
            if (fechaAux.Contains("/"))
            {
                aux = fechaAux.IndexOf("/");
                parte = fechaAux.Substring(0, aux);

                restoFecha = fechaAux.Substring(aux+1, fechaAux.Length - aux-1);

                res += parte + "-";
                mes = parte;
                anio = restoFecha;
            }
            if (anio.Contains(":"))
            {
                String primerAnio = anio.Substring(0, 4);
                res = primerAnio + "-" + mes + "-" + dia + " 0:00:00.000";
            }
            else {
                res = anio + "-" + mes + "-" + dia + " 0:00:00.000";
            }
            MessageBox.Show(res);
            return res;
        }

        public static bool intPerteneceADataTable(int aBuscar, DataTable tabla) {
            int cant = tabla.Rows.Count;
            int n = 0;
            for (n = 0; n < cant; n++) {
                if (aBuscar == Convert.ToInt32(tabla.Rows[0][n].ToString())) {
                    return true;
                }
            }
            return false;
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
