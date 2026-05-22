using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace ClinicaPacientes.Data
{
    public class conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string conexion = "server=localhost;database=paginapacientes;user=root;password=Joaquin#2006;";

            return new MySqlConnection(conexion);
        }
    }
}