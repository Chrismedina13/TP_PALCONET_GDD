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
    }
}
