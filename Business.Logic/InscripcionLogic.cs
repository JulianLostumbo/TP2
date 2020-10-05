using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class InscripicionLogic:BusinessLogic
    {
        public Data.Database.InscripcionAdapter InscripcionData { get; set; }

        public InscripicionLogic()
        {
            InscripcionData = new Data.Database.InscripcionAdapter();
        }

        public List<Inscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public Business.Entities.Inscripcion GetOne(int ID)
        {
            return InscripcionData.GetOne(ID);
        }

        public void Delete (int ID)
        {
            InscripcionData.Delete(ID);
        }

        public void Save (Business.Entities.Inscripcion inscripcion)
        {
            InscripcionData.Save(inscripcion);
        }

        public void Update(Business.Entities.Inscripcion inscripcion)
        {
            InscripcionData.Update(inscripcion);
        }
    }
}
