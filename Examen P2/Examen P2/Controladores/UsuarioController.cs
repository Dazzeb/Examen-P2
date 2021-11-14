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
    public class UsuarioController
    {
        UsuariosView Vista;
        string operacion = string.Empty;

        public UsuarioController(UsuariosView view)
        {
            Vista = view;
            Vista.bNuevo.Click += new EventHandler(Nuevo);
            Vista.bSafe.Click += new EventHandler(Guardar);
        }
        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object serder, EventArgs e)
        {
            if (Vista.textBox2.Text=="")
            {
                Vista.errorProvider1.SetError(Vista.textBox2, "Ingrese un Nombre");
                Vista.textBox2.Focus();
                return;
            }
            if (Vista.textBox2.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.textBox3, "Ingrese una Clave");
                Vista.textBox3.Focus();
                return;
            }

            UsuarioDAO userDAO = new UsuarioDAO();
            Usuario user = new Usuario();
           user.NUsuario = Vista.textBox2.Text;
            user.Clave = Vista.textBox3.Text;
            user.EsAdmin = Vista.checkBox1.Checked;

            bool insert = userDAO.InsertarNuevoUsuario(user);

            if (insert)
            {
                DeshabilitadorControles();
                MessageBox.Show("Usuario Creado", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Limpiar()
        {
            Vista.IDtb.Clear();
            Vista.textBox2.Clear();
            Vista.textBox3.Clear();
            Vista.checkBox1.Checked = false;

        }

        private void HabilitarControles()
        {
            
            Vista.textBox2.Enabled = true;
            Vista.textBox3.Enabled = true;
            Vista.checkBox1.Enabled = true;
            Vista.bSafe.Enabled = true;
            Vista.bCancelar.Enabled = true;
            Vista.bMod.Enabled = false;
            Vista.bNuevo.Enabled = false;
        }
        private void DeshabilitadorControles()
        {

            Vista.textBox2.Enabled = false;
            Vista.textBox3.Enabled = false;
            Vista.checkBox1.Enabled = false;
            Vista.bSafe.Enabled = false;
            Vista.bCancelar.Enabled = false;
            Vista.bMod.Enabled = true;
            Vista.bNuevo.Enabled = true;
        }
    }
}
