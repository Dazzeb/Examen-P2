using Examen_P2.Modelos.DAO;
using Examen_P2.Modelos.Entidades;
using Examen_P2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_P2.Controladores
{
    public class EstadoController
    {
        Estado Vista;
        EstadoDAO soporteDAO = new EstadoDAO();
        Estado soporte = new Estado();
        string operacion = string.Empty;

        public EstadoController(EstadoView view)
        {
          

        }
    }

}
