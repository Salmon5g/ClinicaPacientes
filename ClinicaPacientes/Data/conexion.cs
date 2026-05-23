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
            string conexion = "server=localhost;database=paginapacientes;user=root;password=Stomas.2025;";

            return new MySqlConnection(conexion);
        }
    }
}