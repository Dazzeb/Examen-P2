using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_P2.Modelos.Entidades
{
    public class Ticket
    {
        public int ID { get; set; }
        public int NTicket{ get; set; }
        public DateTime Fecha{ get; set; }
        public int IdCliente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }

    }
}
