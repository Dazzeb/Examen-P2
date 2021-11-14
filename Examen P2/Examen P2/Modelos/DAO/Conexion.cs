using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Examen_P2.Modelos.DAO
{
    public class Conexion
    {
        protected SqlConnection Miconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["UserConexion"].ConnectionString);
    }
}
