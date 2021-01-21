using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion: BusinessEntity
    {
        public string Condicion { get; set; }

        public string DescMateria { get; set; }

        public string DescComision { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int IDAlumno { get; set; }

        public int IDCurso { get; set; }

        public int Nota { get; set; }
    }
}
