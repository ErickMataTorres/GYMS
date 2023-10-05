using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace GYMS.Models
{
    public class Clconexion
    {
        public static SqlConnection Conectar()
        {
            string cs = "Data Source=A;Initial Catalog=Gyms;Integrated Security=True";
            //var cs = "SERVER = GymsDatabase.mssql.somee.com; DATABASE = GymsDatabase; USER ID = Abcdefghijxa_SQLLogin_1; PWD = hbl5mf35c2;";
            SqlConnection conx = new SqlConnection(cs);
            return conx;
        }
    }
}