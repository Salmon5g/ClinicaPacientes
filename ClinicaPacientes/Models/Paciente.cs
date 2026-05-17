namespace ClinicaPacientes.Models
{
    public class Paciente
    {
        public int idPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int edadPaciente { get; set; }
        public Boolean tienePrevision { get; set; }

        public string telefonoPaciente { get; set; }

        public string emailPaciente { get; set; }

        public string direccionPaciente { get; set; }

        public Paciente()
        {

        }
        public Paciente(int idPaciente, string nombrePaciente, DateTime fechaIngreso, int edadPaciente, Boolean tienePrevision, string telefonoPaciente, string emailPaciente, string direccionPaciente)
        {
            this.idPaciente = idPaciente;
            this.nombrePaciente = nombrePaciente;
            this.fechaIngreso = fechaIngreso;
            this.edadPaciente = edadPaciente;
            this.tienePrevision = tienePrevision;
            this.telefonoPaciente = telefonoPaciente;
            this.emailPaciente = emailPaciente;
            this.direccionPaciente = direccionPaciente;
        }
    }
}
