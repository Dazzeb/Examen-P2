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
        UsuarioDAO userDAO = new UsuarioDAO();
        Usuario user = new Usuario();

        public UsuarioController(UsuariosView view)
        {
            Vista = view;
            Vista.bNuevo.Click += new EventHandler(Nuevo);
            Vista.bSafe.Click += new EventHandler(Guardar);
            Vista.Load += new EventHandler(Load);
            Vista.bMod.Click += new EventHandler(Modificar);
            Vista.bEliminar.Click += new EventHandler(Eliminar);
        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (Vista.dataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = userDAO.EliminarUsuario(Convert.ToInt32(Vista.dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DeshabilitadorControles();
                    Limpiar();

                    MessageBox.Show("Usuario Eliminado Exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarUsuarios();
                }
            }
        }
        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }
        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (Vista.dataGridView1.SelectedRows.Count > 0)
            {
                Vista.IDtb.Text = Vista.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                Vista.textBox2.Text = Vista.dataGridView1.CurrentRow.Cells["NUsuario"].Value.ToString();
                Vista.textBox3.Text = Vista.dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                Vista.checkBox1.Checked = Convert.ToBoolean(Vista.dataGridView1.CurrentRow.Cells["EsAdmin"].Value);

                HabilitarControles();
            }
        }
        private void Load(object serder, EventArgs e)
        {
            ListarUsuarios();
        }
        private void Guardar(object serder, EventArgs e)
        {
            if (Vista.textBox2.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.textBox2, "Ingrese un nombre");
                Vista.textBox2.Focus();
                return;
            }

            if (Vista.textBox3.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.textBox3, "Ingrese una clave");
                Vista.textBox3.Focus();
                return;
            }

            user.NUsuario = Vista.textBox2.Text;
            user.Clave = Vista.textBox3.Text;
            user.EsAdmin = Vista.checkBox1.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = userDAO.InsertarNuevoUsuario(user);

                if (inserto)
                {
                    DeshabilitadorControles();
                    Limpiar();

                    MessageBox.Show("Usuario Creado Exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el usuario", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                user.ID = Convert.ToInt32(Vista.IDtb.Text);
                bool modifico = userDAO.ActualizarUsuario(user);
                if (modifico)
                {
                    DeshabilitadorControles();
                    Limpiar();

                    MessageBox.Show("Usuario Modificado Exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el usuario", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
        private void ListarUsuarios()
            {
            Vista.dataGridView1.DataSource = userDAO.GetUsuarios();
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
