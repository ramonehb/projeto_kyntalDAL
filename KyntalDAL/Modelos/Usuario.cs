using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyntal.Modelos
{
    public class Usuario // REPRESENTA A TABELA USUARIO NO BANCO DE DADOS
    {
        //CLASSE ANÊMICA = UMA CLASSE SEM METODOS SOMENTE ATRIBUTOS
        public int IDUsuario { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public int IDTipoUsuario { get; set; }

        public string TipoUsuario { get; set; }


        public int FlStatus { get; set; }

    }
}
