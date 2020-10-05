using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
    public class Inscripcion:BusinessEntity
    {

        public int IdAlumno { get; set; }

        public int IdCurso { get; set; }

        public string Condicion { get; set; }

        public int Nota { get; set; }
    }
}
