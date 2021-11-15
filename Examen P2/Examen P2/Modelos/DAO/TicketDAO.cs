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
    public class TicketDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevaFactura(Ticket ticket, List<DetalleTicket> detalleTickets)
        {
            bool inserto = false;

            comando.Connection = Miconexion;
            Miconexion.Open();

            SqlTransaction transaction = Miconexion.BeginTransaction();

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO Ticket ");
                sql.Append(" VALUES (@NTicket, @Fecha, @IdCliente, @SubTotal, @Isv,  @Total); ");
                sql.Append(" SELECT SCOPE_IDENTITY() ");

                StringBuilder sqlD = new StringBuilder();
                sql.Append(" INSERT INTO DetalleTicket ");
                sql.Append(" VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio, @Total); ");

                comando.Transaction = transaction;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ticket.Fecha;
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = ticket.IdCliente;
                comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = ticket.Subtotal;
                comando.Parameters.Add("@Isv", SqlDbType.Decimal).Value = ticket.Isv;
                comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = ticket.Total;

                int IdTicket = Convert.ToInt32(comando.ExecuteScalar());

                foreach (var item in detalleTickets)
                {
                    comando.Parameters.Add("@IDSoporte", SqlDbType.Int).Value = item.IDSoporte;
                    comando.Parameters.Add("@IDEstado", SqlDbType.Int).Value = item.IDEstado;
                    comando.Parameters.Add("@IDTicket", SqlDbType.Int).Value = IdTicket;
                    comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = item.Total;
                    comando.ExecuteNonQuery();
                }
                transaction.Commit();
                Miconexion.Close();
            }
            catch (Exception )
            {
                inserto = false;
                transaction.Rollback();
            }
            return inserto;
        }



    }
}
