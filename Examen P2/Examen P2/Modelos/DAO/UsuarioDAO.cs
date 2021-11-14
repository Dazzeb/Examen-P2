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
    public class UsuarioDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool ValidarUsuario(Usuario user)
        {
            bool Valido = false;
            

            try
            {
                StringBuilder sql = new StringBuilder();
              sql.Append(" SELECT 1 FROM NUsuario WHERE NUsuario =@NUsuario AND Clave = @Clave ").ToString();

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@NUsuario", SqlDbType.NVarChar, 50).Value = user.NUsuario;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 50).Value = user.Clave;
                Valido = Convert.ToBoolean(comando.ExecuteScalar());
            }
            catch (Exception)
            {

            }
            return Valido;


        }

       public bool InsertarNuevoUsuario(Usuario user)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO NUsuario ");
                sql.Append(" VALUES (@NUsuario, @Clave, @EsAdmin); ");

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@NUsuario", SqlDbType.NVarChar, 50).Value = user.NUsuario;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 50).Value = user.Clave;
                comando.Parameters.Add("@EsAdmin", SqlDbType.Bit).Value = user.EsAdmin;
                comando.ExecuteNonQuery();
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable GetUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM NUsuario ");

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

        public bool ActualizarUsuario(Usuario user)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE NUsuario ");
                sql.Append(" SET NUsuario = @NUsuario, Clave = @Clave, EsAdmin = @EsAdmin  ");
                sql.Append(" WHERE ID = @ID; ");

                comando.Connection = Miconexion;
                Miconexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = user.ID;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = user.NUsuario;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 50).Value = (user.Clave);
                comando.Parameters.Add("@EsAdministrador", SqlDbType.Bit).Value = user.EsAdmin;
                comando.ExecuteNonQuery();
                modifico = true;
                Miconexion.Close();

            }
            catch (Exception ex)
            {
                return modifico;
            }
            return modifico;
        }

        public bool EliminarUsuario(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM NUsuario ");
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
            catch (Exception ex)
            {
                return modifico;
            }
            return modifico;
        }
    }
}
