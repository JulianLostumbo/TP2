using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloLogic: BusinessLogic
    {
        public ModuloAdapter ModuloData { get; set; }

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public Business.Entities.Modulo GetOne(string deesc)
        {
            return ModuloData.GetOne(deesc);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public void Save(Business.Entities.Modulo modulo)
        {
            ModuloData.Save(modulo);
        }

        public void Update(Business.Entities.Modulo modulo)
        {
            ModuloData.Update(modulo);
        }

        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }

    }
}
