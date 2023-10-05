using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYMS.Models
{
    public class Compra
    {
        public int IdUsuario { get; set; }
        public int IdTipoSuscripcion { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaTerminacion { get; set; }

        public string RealizarCompra()
        {
            string respuesta;
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spRealizarCompra", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            command.Parameters.AddWithValue("@IdTipoSuscripcion", IdTipoSuscripcion);
            command.Parameters.AddWithValue("@FechaCompra", FechaCompra);
            command.Parameters.AddWithValue("@FechaTerminacion", FechaTerminacion);
            try
            {
                conx.Open();
                respuesta = command.ExecuteScalar().ToString();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Closed)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
    }
}