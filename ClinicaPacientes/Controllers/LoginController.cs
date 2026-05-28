using ClinicaPacientes.Data;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ClinicaPacientes.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login
        public IActionResult Index()
        {
            // Si ya está logueado como admin, lo manda directo al panel
            if (HttpContext.Session.GetString("Usuario") != null)
                return RedirectToAction("Index", "Administracion");

            return View();
        }

        // POST: /Login/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                ViewBag.Error = "Por favor ingrese usuario y contraseña.";
                return View("Index");
            }

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombreUsuario, esAdmin FROM usuario " +
                               "WHERE nombreUsuario = @nombre AND contrasena = @pass";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cmd.Parameters.AddWithValue("@pass", contrasena);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int esAdmin = reader.GetInt32("esAdmin");

                        if (esAdmin == 1)
                        {
                            // Es administrador: guardar sesión y redirigir al panel
                            HttpContext.Session.SetString("Usuario", reader.GetString("nombreUsuario"));
                            HttpContext.Session.SetInt32("EsAdmin", 1);
                            return RedirectToAction("Index", "Administracion");
                        }
                        else
                        {
                            // Usuario existe pero no es admin
                            ViewBag.Error = "No tienes permisos de administrador.";
                            return View("Index");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Usuario o contraseña incorrectos.";
                        return View("Index");
                    }
                }
            }
        }


        // GET: /Login/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}