using Examen_P2.Modelos.Entidades;
using System;
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


        public string EmailUsuario;
       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UsuariosView vista = new UsuariosView();
            vista.MdiParent = this;
            vista.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClienteView vista = new ClienteView();
            vista.MdiParent = this;
            vista.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TipoServicio vista = new TipoServicio();
            vista.MdiParent = this;
            vista.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Estado vista = new Estado();
  
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Ticket vista = new Ticket();
            vista.MdiParent = this;
            vista.Show();

        }
    }
}
