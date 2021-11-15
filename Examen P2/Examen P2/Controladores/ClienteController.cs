using Examen_P2.Modelos.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen_P2.Vistas;
using Examen_P2.Modelos.Entidades;

namespace Examen_P2.Controladores
{
    public class ClienteController
    {
        ClienteView Vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        Cliente cliente = new Cliente();
        string operacion = string.Empty;

        public ClienteController(ClienteView view)
        {
            Vista = view;
            Vista.bNuevo.Click += new EventHandler(Nuevo);
            Vista.bSafe.Click += new EventHandler(Guardar);
            Vista.bMod.Click += new EventHandler(Modificar);
            Vista.Load += new EventHandler(Load);
            Vista.bEliminar.Click += new EventHandler(Eliminar);
            Vista.bCancelar.Click += new EventHandler(Cancelar);

        }

        private void Cancelar(object sender, EventArgs e)
        {
            DeshabilitadorControles();
            Limpiar();
            cliente = null;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (Vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarUsuario(Convert.ToInt32(Vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            Vista.ClientesDataGridView.DataSource = clienteDAO.GetClientes();
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (Vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                Vista.IdTextBox.Text = Vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                Vista.IdentidadTextBox.Text = Vista.ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                Vista.NombreTextBox.Text = Vista.ClientesDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                Vista.EmailTextBox.Text = Vista.ClientesDataGridView.CurrentRow.Cells["Email"].Value.ToString();
                Vista.DireccionTextBox.Text = Vista.ClientesDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }

        }

      
        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (Vista.IdentidadTextBox.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.IdentidadTextBox, "Ingrese una identidad");
                Vista.IdentidadTextBox.Focus();
                return;
            }
            if (Vista.NombreTextBox.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.NombreTextBox, "Ingrese un nombre");
                Vista.NombreTextBox.Focus();
                return;
            }
            if (Vista.EmailTextBox.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.EmailTextBox, "Ingrese un email");
                Vista.EmailTextBox.Focus();
                return;
            }
            if (Vista.DireccionTextBox.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.DireccionTextBox, "Ingrese unu dirección");
                Vista.DireccionTextBox.Focus();
                return;
            }
            try
            {
                cliente.Identidad = Vista.IdentidadTextBox.Text;
                cliente.Nombre = Vista.NombreTextBox.Text;
                cliente.Email = Vista.EmailTextBox.Text;
                cliente.Direccion = Vista.DireccionTextBox.Text;


                if (operacion == "Nuevo")
                {
                    bool inserto = clienteDAO.InsertarNuevoCliente(cliente);
                    if (inserto)
                    {
                        DeshabilitadorControles();
                        Limpiar();
                        MessageBox.Show("Cliente creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo insertar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "Modificar")
                {
                    cliente.ID = Convert.ToInt32(Vista.IdTextBox.Text);
                    bool modifico = clienteDAO.ActualizarCliente(cliente);
                    if (modifico)
                    {
                        DeshabilitadorControles();
                        Limpiar();
                        MessageBox.Show("Cliente modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
            }




        }
        private void Limpiar()
        {
            Vista.IdTextBox.Clear();
            Vista.IdentidadTextBox.Clear();
            Vista.NombreTextBox.Clear();
            Vista.EmailTextBox.Clear();
            Vista.DireccionTextBox.Clear();

        }
        private void HabilitarControles()
        {

           Vista.IdTextBox.Enabled = true;
            Vista.IdentidadTextBox.Enabled = true;
            Vista.NombreTextBox.Enabled = true;
            Vista.EmailTextBox.Enabled = true;
            Vista.DireccionTextBox.Enabled = true;
            Vista.bNuevo.Enabled = true;
            Vista.bMod.Enabled = true;
            Vista.bSafe.Enabled = false;
            Vista.bEliminar.Enabled = false;
        }
        private void DeshabilitadorControles()
        {

            Vista.IdTextBox.Enabled = false;
            Vista.IdentidadTextBox.Enabled = false;
            Vista.NombreTextBox.Enabled = false;
            Vista.EmailTextBox.Enabled = false;
            Vista.DireccionTextBox.Enabled = false;
            Vista.bNuevo.Enabled = false;
            Vista.bMod.Enabled = false;
            Vista.bSafe.Enabled = true;
            Vista.bEliminar.Enabled = true;
        }
    }
}
