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

    public class TipoSoporteController
    {
        TipoServicio Vista;
        SoporteDAO soporteDAO = new SoporteDAO();
        TipoSoporte soporte= new TipoSoporte();
        string operacion = string.Empty;

        public TipoSoporteController(TipoServicio view)
        {
            Vista = view;
            Vista.bAgregar.Click += new EventHandler(Agregar);
            Vista.Load += new EventHandler(Load);
            Vista.bEliminar.Click += new EventHandler(Eliminar);
            Vista.bCancelar.Click += new EventHandler(Cancelar);

        }
        private void Cancelar(object sender, EventArgs e)
        {
            DeshabilitadorControles();
            Limpiar();
            soporte = null;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (Vista.SoporteDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = soporteDAO.EliminarTipoSoporte(Convert.ToInt32(Vista.SoporteDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    MessageBox.Show("Tipo de Soporte eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("El Tipo de Soporte no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Agregar(object sender, EventArgs e)
        {
            if (Vista.comboBox1.Text == "")
            {
                Vista.errorProvider1.SetError(Vista.comboBox1, "Elija un Tipo de Soporte");
                Vista.comboBox1.Focus();
                return;
            }

        }


            private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            Vista.SoporteDataGridView.DataSource = soporteDAO.GetSoporte();
        }

        private void Limpiar()
        {
            Vista.comboBox1.ResetText();
            Vista.textBox2.Clear();

        }
        private void HabilitarControles()
        {

            Vista.bAgregar.Enabled =true;
            Vista.bEliminar.Enabled = false;
        }
        private void DeshabilitadorControles()
        {

            Vista.bAgregar.Enabled = false;
            Vista.bEliminar.Enabled = true;
        }
    }

}
