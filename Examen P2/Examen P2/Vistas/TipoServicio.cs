using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen_P2.Controladores;


namespace Examen_P2.Vistas
{
    public partial class TipoServicio : Form
    {
        public TipoServicio()
        {
            InitializeComponent();
            TipoSoporteController controlador = new TipoSoporteController(this);
        }

        private void TipoServicio_Load(object sender, EventArgs e)
        {

        }
    }
}
