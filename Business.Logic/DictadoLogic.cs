using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class DictadoLogic:BusinessLogic
    {
        public Data.Database.DictadoAdapter DictadoData { get; set; }

        public DictadoLogic()
        {
            DictadoData = new Data.Database.DictadoAdapter();
        }

        public List<Dictado> GetAll()
        {
            return DictadoData.GetAll();
        }

        public Business.Entities.Dictado GetOne(int ID)
        {
            return DictadoData.GetOne(ID);
        }

        public void Delete (int ID)
        {
            DictadoData.Delete(ID);
        }

        public void Save (Business.Entities.Dictado dictado)
        {
            DictadoData.Save(dictado);
        }

        public void Update(Business.Entities.Dictado dictado)
        {
            DictadoData.Update(dictado);
        }
    }
}
