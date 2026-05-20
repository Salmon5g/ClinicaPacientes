using Microsoft.CodeAnalysis;
using static Mysqlx.Crud.Order.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicaPacientes.Models
{
    public class Paciente
    {
        public int idPaciente { get; set; }
        public string nombrePaciente { get; set; }

        public string rutPaciente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int edadPaciente { get; set; }

        public string telefonoPaciente { get; set; }

        public string emailPaciente { get; set; }

        public string direccionPaciente { get; set; }

        public string motivoConsulta { get; set; }

        public Paciente()
        {

        }
        public Paciente(int idPaciente, string nombrePaciente,string rutPaciente, DateTime fechaIngreso, int edadPaciente, string telefonoPaciente, string emailPaciente, string direccionPaciente, string motivoConsulta)
        {
            this.idPaciente = idPaciente;
            this.nombrePaciente = nombrePaciente;
            this.rutPaciente = rutPaciente;
            this.fechaIngreso = fechaIngreso;
            this.edadPaciente = edadPaciente;
            this.telefonoPaciente = telefonoPaciente;
            this.emailPaciente = emailPaciente;
            this.direccionPaciente = direccionPaciente;
            this.motivoConsulta = motivoConsulta;

        }
    }
}
