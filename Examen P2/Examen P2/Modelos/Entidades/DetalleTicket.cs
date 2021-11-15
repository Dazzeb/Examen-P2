using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_P2.Modelos.Entidades
{
    public class DetalleTicket
    {
        public int ID { get; set; }
        public int IDSoporte { get; set; }
        public int IDTicket { get; set; }
        public int IDEstado { get; set; }
        public decimal Total { get; set; }

    }
}
