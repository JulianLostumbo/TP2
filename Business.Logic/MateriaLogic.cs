using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class MateriaLogic:BusinessLogic
    {
        public Data.Database.MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public List<Plan> GetPlanes()
        {
            return MateriaData.GetPlanes();
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public void Save(Business.Entities.Materia materia)
        {
            MateriaData.Save(materia);
        }

        public void Update(Business.Entities.Materia materia)
        {
            MateriaData.Update(materia);
        }
    }
}
