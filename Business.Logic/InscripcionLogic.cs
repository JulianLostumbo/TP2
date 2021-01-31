using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class InscripcionLogic:BusinessLogic
    {
        public Data.Database.InscripcionAdapter InscripcionData { get; set; }

        public CursoAdapter CursoData { get; set; }

        public InscripcionLogic()
        {
            InscripcionData = new Data.Database.InscripcionAdapter();
            CursoData= new Data.Database.CursoAdapter();
        }

        public List<AlumnoInscripcion> GetAll(int id)
        {
            return InscripcionData.GetAll(id);
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            return InscripcionData.GetOne(ID);
        }

        public List<Curso> GetCursosAlumno(Persona p)
        {
            List<Curso> cursos = new List<Curso>();
            List<Curso> disp = new List<Curso>();
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            inscripciones = InscripcionData.GetInscripciones(p.ID);
            cursos = CursoData.GetAll();
            disp = (from Curso in cursos where 
                    (Curso.AnioCalendario == DateTime.Now.Year && Curso.Cupo > 0 && 
                    inscripciones.All(p2 => p2.IDCurso != Curso.ID)) 
                    select Curso).ToList();
            return disp;

        }
        public List<Business.Entities.AlumnoInscripcion> GetEstadoAcademico(int ID)
        {
            return InscripcionData.GetEstadoAcademico(ID);
        }

        public void Delete (int ID)
        {
            InscripcionData.Delete(ID);
        }

        public void Save (Business.Entities.AlumnoInscripcion inscripcion)
        {
            InscripcionData.Save(inscripcion);
        }

        public void Update(Business.Entities.AlumnoInscripcion inscripcion)
        {
            InscripcionData.Update(inscripcion);
        }
    }
}
