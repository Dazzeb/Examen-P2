﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_P2.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UsuariosView vista = new UsuariosView();
            vista.Show();
        }
    }
}
