using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        public Data.Database.PersonaAdapter PersonaData { get; set; }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public List<Persona> GetAll(int id)
        {
            return PersonaData.GetAll(id);
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public List<Plan> GetPlanes()
        {
            return PersonaData.GetPlanes();
        }


        public void Delete (int ID)
        {
            PersonaData.Delete(ID);
        }

        public void Save (Business.Entities.Persona persona)
        {
            PersonaData.Save(persona);
        }

        public void Update(Business.Entities.Persona persona)
        {
            PersonaData.Update(persona);
        }
    }
}
