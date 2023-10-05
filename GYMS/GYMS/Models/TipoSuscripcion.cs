using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYMS.Models
{
    public class TipoSuscripcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tiempo { get; set; }
        public decimal Precio { get; set; }
        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarTipoSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Tiempo", Tiempo);
            command.Parameters.AddWithValue("@Precio", Precio);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public string Borrar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public static List<TipoSuscripcion> ListaTipoSuscripcion(string idNombre)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spListaTipoSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdNombre", idNombre);
            TipoSuscripcion ts;
            SqlDataReader dr;
            List<TipoSuscripcion> lista = new List<TipoSuscripcion>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ts = new TipoSuscripcion();
                ts.Id = dr.GetInt32(0);
                ts.Nombre = dr.GetString(1);
                ts.Tiempo = dr.GetInt32(2);
                ts.Precio = dr.GetDecimal(3);
                lista.Add(ts);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static TipoSuscripcion Cargar(int id)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr;
            TipoSuscripcion ts=new TipoSuscripcion();
            conx.Open();
            dr = command.ExecuteReader();
            if(dr.Read())
            {
                ts.Id = dr.GetInt32(0);
                ts.Nombre = dr.GetString(1);
                ts.Tiempo = dr.GetInt32(2);
                ts.Precio = dr.GetDecimal(3);
            }
            dr.Close();
            conx.Close();
            return ts;
        }
        public static int Siguiente()
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spSiguienteSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            int siguiente;
            siguiente = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguiente;
        }
        public static TipoSuscripcion CargarSuscripcion(int idSuscripcion)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spCargarCompraSuscripcion", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdSuscripcion", idSuscripcion);
            TipoSuscripcion ts=new TipoSuscripcion();
            SqlDataReader dr;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                ts.Id = dr.GetInt32(0);
                ts.Nombre = dr.GetString(1);
                ts.Tiempo = dr.GetInt32(2);
                ts.Precio = dr.GetDecimal(3);
            }
            dr.Close();
            conx.Close();
            return ts;
        }
    }
}