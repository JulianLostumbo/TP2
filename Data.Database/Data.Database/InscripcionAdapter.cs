using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll(int IDcur)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, coalesce(ai.nota,0) as nota, " +
                    "personas.nombre, personas.apellido " +
                    "FROM alumnos_inscripciones ai " +
                    "INNER JOIN personas on personas.id_persona = ai.id_alumno " +
                    "WHERE ai.id_curso = @id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = IDcur;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Nombre = (string)drInscripciones["nombre"];
                    ins.Apellido = (string)drInscripciones["apellido"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            return inscripciones;
        }

        public List<AlumnoInscripcion> GetInscripciones(int ID)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT id_inscripcion, id_alumno, alumnos_inscripciones.id_curso, condicion " +
                "FROM alumnos_inscripciones INNER JOIN cursos ON cursos.id_curso = alumnos_inscripciones.id_curso WHERE id_alumno = @id", sqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            SqlDataReader drIns = cmd.ExecuteReader();
            while (drIns.Read())
            {
                AlumnoInscripcion aluIns = new AlumnoInscripcion();
                aluIns.ID = (int)drIns["id_inscripcion"];
                aluIns.IDCurso = (int)drIns["id_curso"];
                aluIns.IDAlumno = (int)drIns["id_alumno"];
                aluIns.Condicion= (string)drIns["condicion"];
                inscripciones.Add(aluIns);
            }
            drIns.Close();
            CloseConnection();
            return inscripciones;
        }

        public List<Business.Entities.AlumnoInscripcion> GetEstadoAcademico(int ID)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("SELECT ai.id_inscripcion, ai.id_curso, ai.condicion, coalesce(ai.nota, 0) as nota, com.desc_comision, m.desc_materia " +
                    "FROM alumnos_inscripciones ai " +
                    "INNER JOIN cursos c on c.id_curso = ai.id_curso " +
                    "INNER JOIN materias m on c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com on c.id_comision = com.id_comision " +
                    "where ai.id_alumno = @id", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripcion.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.DescMateria = (string)drInscripciones["desc_materia"];
                    ins.DescComision = (string)drInscripciones["desc_comision"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
            return inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, coalesce(ai.nota,0) as nota " +
                    "FROM alumnos_inscripciones ai " +
                    "WHERE ai.id_inscripcion = @id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del estado academico", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }

        public List<Curso> GetCursosAlumno(int IDalum)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT cur.id_curso, cur.id_materia, cur.id_comision, " +
                    "cur.anio_calendario, cur.cupo, materias.desc_materia, comisiones.desc_comision FROM cursos cur " +
                    "INNER JOIN materias ON materias.id_materia = cur.id_materia " +
                    "INNER JOIN comisiones ON comisiones.id_comision = cur.id_comision " +
                    "LEFT JOIN alumnos_inscripciones on alumnos_inscripciones.id_curso = cur.id_curso " +
                    "WHERE alumnos_inscripciones.id_alumno != @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = IDalum;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.DescComision = (string)drCursos["desc_comision"];
                    cur.DescMateria = (string)drCursos["desc_materia"];

                    cursos.Add(cur);
                }
                drCursos.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de cursos", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
                //Usuarios.Remove(this.GetOne(ID));
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(AlumnoInscripcion ins) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET nota = @nota, condicion = @condicion " +
                    "WHERE id_inscripcion = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = ins.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = ins.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion) values (@id_alumno," +
              "@id_curso, @condicion); " +
              "UPDATE cursos SET cupo = cupo-1 WHERE id_curso = @id_curso", sqlConn);
                cmd.Parameters.Add("@id_alumno", SqlDbType.Int).Value = ins.IDAlumno;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = ins.IDCurso;
                cmd.Parameters.Add("@condicion", SqlDbType.VarChar).Value = ins.Condicion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}