using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYMS.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionDeRutina{ get; set; }
        public static List<Asistencia> ListaAsistencia(int idUsuario)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spListaAsistencias", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);
            SqlDataReader dr;
            Asistencia a;
            List<Asistencia> lista = new List<Asistencia>();
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                a = new Asistencia();
                a.Id = dr.GetInt32(0);
                a.Nombre = dr.GetString(1);
                a.Fecha = dr.GetDateTime(2);
                a.DescripcionDeRutina = dr.GetString(3);
                lista.Add(a);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}