using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {

        public int IdCurso { get; set; }

        public int IdDocente { get; set; }

        public enum TiposCargos
        {
            Auxiliar,
            Profesor
        }

        public TiposCargos Cargo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

    }
}
