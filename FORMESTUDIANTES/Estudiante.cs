using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORMESTUDIANTES
{
    public class Estudiante
    {
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Responsables { get; set; }

        // Constructor
        public Estudiante(string carnet, string nombre, DateTime fechaNacimiento, string correo, string responsables)
        {
            Carnet = carnet;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Correo = correo;
            Responsables = responsables;
        }
    }
}

