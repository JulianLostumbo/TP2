using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class DocenteCursoLogic:BusinessLogic
    {
        public Data.Database.DocenteCursoAdapter DocenteCursoData { get; set; }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        public List<Curso> GetCursos()
        {
            return DocenteCursoData.GetCursos();
        }

        public List<Curso> GetCursosDocente(int ID)
        {
            return DocenteCursoData.GetCursosDocente(ID);
        }

        public List<Persona> GetDocente()
        {
            return DocenteCursoData.GetDocente();
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public void Delete (int ID)
        {
            DocenteCursoData.Delete(ID);
        }

        public void Save (Business.Entities.DocenteCurso dictado)
        {
            DocenteCursoData.Save(dictado);
        }

        public void Update(Business.Entities.DocenteCurso dictado)
        {
            DocenteCursoData.Update(dictado);
        }
    }
}
