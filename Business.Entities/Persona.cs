using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
    public class Persona:BusinessEntity
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaNac { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public int Legajo { get; set; }

        public int TipoPersona { get; set; }

        public int IdPlan { get; set; }
    }
}
