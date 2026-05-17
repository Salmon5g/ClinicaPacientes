using ClinicaPacientes.Data;
using ClinicaPacientes.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ClinicaPacientes.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Index()
        {
            List<Paciente> lista = new List<Paciente>();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM paciente";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Paciente()
                    {
                        idPaciente = reader.GetInt32("idPaciente"),
                        nombrePaciente = reader.GetString("nombrePaciente"),
                        fechaIngreso = reader.GetDateTime("fechaIngreso"),
                        edadPaciente = reader.GetInt32("edadPaciente"),
                        tienePrevision = reader.GetBoolean("tienePrevision"),
                        telefonoPaciente = reader.GetString("telefonoPaciente"),
                        emailPaciente = reader.GetString("emailPaciente"),
                        direccionPaciente = reader.GetString("direccionPaciente")
                    });
                }
            }

            return View(lista);
        }
    }
}
