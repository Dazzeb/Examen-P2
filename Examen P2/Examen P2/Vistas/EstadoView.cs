﻿using Examen_P2.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_P2.Vistas
{
    public partial class EstadoView : Form
    {
        public EstadoView()
        {
            InitializeComponent();
            EstadoController controlador = new EstadoController(this);
        }

        private void EstadoView_Load(object sender, EventArgs e)
        {

        }
    }
}
