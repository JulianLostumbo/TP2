using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ComisionLogic:BusinessLogic
    {
        public Data.Database.ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public List<Plan> GetPlanes()
        {
            return ComisionData.GetPlanes();
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }

        public void Save(Business.Entities.Comision comision)
        {
            ComisionData.Save(comision);
        }

        public void Update(Business.Entities.Comision comision)
        {
            ComisionData.Update(comision);
        }
    }
}
