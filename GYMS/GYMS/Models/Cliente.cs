using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYMS.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Verificador { get; set; }
        public string Verificado { get; set; }



        public string Guardar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@op", 2);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
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

        public string Editar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@op", 6);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }

        //llenar tabla
        public static List<Cliente> ListaClientes(string idNombre)
        {
            SqlConnection con = Models.Clconexion.Conectar();
            SqlCommand comando = new SqlCommand("spGuardarCliente", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@IdNombre", idNombre);
            SqlDataReader dr;
            List<Cliente> lista = new List<Cliente>();
            Cliente c;
            con.Open();
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                c = new Cliente();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Direccion = dr.GetString(2);
                c.Telefono = dr.GetString(3);
                c.Correo = dr.GetString(4);
                c.Contraseña = dr.GetString(5);
                
                //c.FechaNacimiento = dr.GetDateTime(3).ToShortDateString();
                lista.Add(c);
            }

            dr.Close();
            con.Close();
            return lista;
        }

        public static List<Cliente> Cargar(int id)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@op", 4);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr;
            List<Cliente> lista = new List<Cliente>();
            Cliente c;
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c = new Cliente();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Direccion = dr.GetString(2);
                c.Telefono = dr.GetString(3);
                c.Correo = dr.GetString(4);
                c.Contraseña = dr.GetString(5);
               
                //c.FechaNacimiento = dr.GetDateTime(3).ToString("dd/MMMM/yyyy");
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }

        //borrar cliente
        public string Borrar()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@op", 3);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public static int Siguiente()
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarCliente", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@op", 5);
            conx.Open();
            int siguiente;
            siguiente = int.Parse(command.ExecuteScalar().ToString());
            conx.Close();
            return siguiente;
        }
        public static Cliente ValidarCorreo(string correo, string contraseña)
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spValidarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Correo", correo);
            command.Parameters.AddWithValue("@Contraseña", contraseña);
            SqlDataReader dr;
            Cliente c=new Cliente();
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Direccion = dr.GetString(2);
                c.Telefono = dr.GetString(3);
                c.Correo = dr.GetString(4);
                c.Contraseña = dr.GetString(5);
                c.Verificador = dr.GetString(6);
                c.Verificado = dr.GetString(7);
            }
            dr.Close();
            conx.Close();
            return c;
        }
        //Este método es cuando le das al boton registrar consulta un uniqueidentifier,
        //y lo asigna a la variable Verificador, se guarda en la tabla, se guarda con una N cuando no esta verificado
        //al mismo tiempo te manda el mensaje, cuando le das click en aquí se verificado y se modifica la N por una S
        public static string ConsultarVerificador()
        {
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarVerificador", conx);
            command.CommandType = CommandType.StoredProcedure;
            conx.Open();
            string verificador = command.ExecuteScalar().ToString();
            conx.Close();
            return verificador;
        }

        //Este método es cuando te registras
        public string RegistrarUsuario()
        {
            string respuesta = "Ok";
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spRegistrarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
            command.Parameters.AddWithValue("@Verificador", Verificador);
            command.Parameters.AddWithValue("@Verificado", Verificado);
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

        public string VerificarUsuario()
        {
            string respuesta = "<script>location.href='http://aplicacionmovil.somee.com/Verificado.html'</script>";//Con esta línea te manda a esta página
            //pero se ejecute el otro método que modifica la N por la S
            SqlConnection conx = Models.Clconexion.Conectar();
            SqlCommand command = new SqlCommand("spVerificarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Verificador", Verificador);
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
    }
}