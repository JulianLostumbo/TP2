using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        public Data.Database.EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }

        public void Save(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }

        public void Update(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Update(esp);
        }
    }
}
