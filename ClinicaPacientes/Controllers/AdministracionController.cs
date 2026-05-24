using ClinicaPacientes.Data;
using ClinicaPacientes.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ClinicaPacientes.Controllers
{
    public class AdministracionController : Controller
    {
 
        // GET: Carga la vista con la lista de pacientes
 
        public ActionResult Index()
        {
            
            if (HttpContext.Session.GetString("Usuario") == null ||
                HttpContext.Session.GetInt32("EsAdmin") != 1)
            {
                return RedirectToAction("Index", "Login");
            }
            List<Paciente> listaPacientes = new List<Paciente>();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM paciente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaPacientes.Add(new Paciente
                    {
                        idPaciente = reader.GetInt32("idPaciente"),
                        nombrePaciente = reader.GetString("nombrePaciente"),
                        rutPaciente = reader.GetString("rutPaciente"),
                        fechaIngreso = reader.GetDateTime("fechaIngreso"),
                        edadPaciente = reader.GetInt32("edadPaciente"),
                        telefonoPaciente = reader.GetString("telefonoPaciente"),
                        emailPaciente = reader.GetString("emailPaciente"),
                        direccionPaciente = reader.GetString("direccionPaciente"),
                        motivoConsulta = reader.GetString("motivoConsulta")
                    });
                }
            }

            return View(listaPacientes);
        }

    
        // POST: Registrar nuevo paciente
     
        [HttpPost]
        public ActionResult Registrar(Paciente paciente)
        {
            
            if (HttpContext.Session.GetString("Usuario") == null ||
                HttpContext.Session.GetInt32("EsAdmin") != 1)
            {
                return RedirectToAction("Index", "Login");
            }
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO paciente 
                    (nombrePaciente, rutPaciente, fechaIngreso, 
                     edadPaciente, telefonoPaciente, emailPaciente, 
                     direccionPaciente, motivoConsulta)
                    VALUES 
                    (@nombrePaciente, @rutPaciente, @fechaIngreso,
                     @edadPaciente, @telefonoPaciente, @emailPaciente,
                     @direccionPaciente, @motivoConsulta)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombrePaciente", paciente.nombrePaciente);
                cmd.Parameters.AddWithValue("@rutPaciente", paciente.rutPaciente);
                cmd.Parameters.AddWithValue("@fechaIngreso", paciente.fechaIngreso);
                cmd.Parameters.AddWithValue("@edadPaciente", paciente.edadPaciente);
                cmd.Parameters.AddWithValue("@telefonoPaciente", paciente.telefonoPaciente);
                cmd.Parameters.AddWithValue("@emailPaciente", paciente.emailPaciente);
                cmd.Parameters.AddWithValue("@direccionPaciente", paciente.direccionPaciente);
                cmd.Parameters.AddWithValue("@motivoConsulta", paciente.motivoConsulta);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

      
        // POST: Modificar paciente existente
       
        [HttpPost]
        public ActionResult Modificar(Paciente paciente)
        {
           
            if (HttpContext.Session.GetString("Usuario") == null ||
                HttpContext.Session.GetInt32("EsAdmin") != 1)
            {
                return RedirectToAction("Index", "Login");
            }
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE paciente SET
                    nombrePaciente    = @nombrePaciente,
                    rutPaciente       = @rutPaciente,
                    fechaIngreso      = @fechaIngreso,
                    edadPaciente      = @edadPaciente,
                    telefonoPaciente  = @telefonoPaciente,
                    emailPaciente     = @emailPaciente,
                    direccionPaciente = @direccionPaciente,
                    motivoConsulta    = @motivoConsulta
                    WHERE idPaciente  = @idPaciente";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", paciente.idPaciente);
                cmd.Parameters.AddWithValue("@nombrePaciente", paciente.nombrePaciente);
                cmd.Parameters.AddWithValue("@rutPaciente", paciente.rutPaciente);
                cmd.Parameters.AddWithValue("@fechaIngreso", paciente.fechaIngreso);
                cmd.Parameters.AddWithValue("@edadPaciente", paciente.edadPaciente);
                cmd.Parameters.AddWithValue("@telefonoPaciente", paciente.telefonoPaciente);
                cmd.Parameters.AddWithValue("@emailPaciente", paciente.emailPaciente);
                cmd.Parameters.AddWithValue("@direccionPaciente", paciente.direccionPaciente);
                cmd.Parameters.AddWithValue("@motivoConsulta", paciente.motivoConsulta);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

      
        // POST: Eliminar paciente
      
        [HttpPost]
        public ActionResult Eliminar(int idPaciente)
        {
            
            if (HttpContext.Session.GetString("Usuario") == null ||
                HttpContext.Session.GetInt32("EsAdmin") != 1)
            {
                return RedirectToAction("Index", "Login");
            }
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM paciente WHERE idPaciente = @idPaciente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}