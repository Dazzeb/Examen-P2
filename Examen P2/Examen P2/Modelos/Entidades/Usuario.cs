using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_P2.Modelos.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Clave { get; set; }
        public string NUsuario{ get; set; }
        public bool EsAdmin { get; set; }
    }
}
