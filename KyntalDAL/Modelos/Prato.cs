using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyntal.Modelos
{
    public class Prato 
    {
        public int IDPrato { get; set; }

        public int IDTamanho { get; set; }

        public string Nome{ get; set; }

        public string Ingredientes { get; set; }

        public int FlStatus { get; set; }
    }


}
