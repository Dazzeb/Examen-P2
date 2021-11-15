using Examen_P2.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_P2.Modelos.DAO
{
    public class SoporteDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool InsertarNuevoTipoSoporte(TipoSoporte tiposoporte)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO [Tipo de Soporte] ");
                sql.Append(" VALUES (@Descrpcion, @Precio); ");

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 50).Value = tiposoporte.Descripcion;
                comando.Parameters.Add("@Precio", SqlDbType.NVarChar, 50).Value = tiposoporte.Precio;
                comando.ExecuteNonQuery();
                inserto = true;
                Miconexion.Close();
            }
            catch (Exception)
            {
                inserto = false;
            }
            return inserto;
        }

        public DataTable GetSoporte()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM [Tipo de Soporte] ");

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                Miconexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }

        public bool EliminarTipoSoporte(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM [Tipo de Soporte] ");
                sql.Append(" WHERE ID = @ID; ");

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                modifico = true;
                Miconexion.Close();

            }
            catch (Exception)
            {
                return modifico;
            }
            return modifico;
        }

    }
}
