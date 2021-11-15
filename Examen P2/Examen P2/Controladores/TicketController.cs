using Examen_P2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_P2.Modelos.DAO;
using Examen_P2.Modelos.Entidades;

namespace Examen_P2.Controladores
{
    public class TicketController
    {
        Vistas.TicketView Vista;
        TicketDAO ticketDAO = new TicketDAO();
        Modelos.Entidades.Ticket factura = new Modelos.Entidades.Ticket();

        public string _EmailUsuario;

        public TicketController(Vistas.TicketView view, string usuario)
        {
            Vista = view;
            _EmailUsuario = usuario;
            Vista.Load += new EventHandler(Load);

        }

        private void Load(object sender, EventArgs e)
        {
            Vista.Usuariotb.Text = _EmailUsuario;
        }
    }
}
