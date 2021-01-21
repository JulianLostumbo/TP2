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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("SELECT dc.id_dictado, dc.cargo, personas.nombre, personas.apellido, dc.id_curso, dc.id_docente " +
                    "FROM docentes_cursos dc " +
                    "INNER JOIN cursos on dc.id_curso = cursos.id_curso " +
                    "INNER JOIN personas on dc.id_docente = personas.id_persona"
                     , sqlConn);
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocentesCursos["id_dictado"];
                    dc.IdCurso = (int)drDocentesCursos["id_curso"];
                    dc.IdDocente = (int)drDocentesCursos["id_docente"];
                    dc.Cargo = (Business.Entities.DocenteCurso.TiposCargos)drDocentesCursos["cargo"];
                    dc.Apellido = (string)drDocentesCursos["apellido"];
                    dc.Nombre = (string)drDocentesCursos["nombre"];

                    docentesCursos.Add(dc);
                }
                drDocentesCursos.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de los dictados", Ex);
                throw ExcepcionManejada;
            }
            return docentesCursos;
        }



        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCursos = new SqlCommand("SELECT dc.id_curso, dc.id_docente, dc.cargo, " +
                    "personas.nombre, personas.apellido " +
                    "FROM docentes_cursos dc " +
                    "INNER JOIN cursos on dc.id_curso = cursos.id_curso " +
                    "INNER JOIN personas on dc.id_docente = personas.id_persona " +
                    "WHERE dc.id_dictado = @id", sqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();
                while (drDocenteCursos.Read())
                {
                    dc.ID = (int)drDocenteCursos["id_dictado"];
                    dc.IdCurso = (int)drDocenteCursos["id_curso"];
                    dc.IdDocente = (int)drDocenteCursos["id_docente"];
                    dc.Cargo = (Business.Entities.DocenteCurso.TiposCargos)drDocenteCursos["cargo"];
                    dc.Apellido = (string)drDocenteCursos["apellido"];
                    dc.Nombre = (string)drDocenteCursos["nombre"];
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        public List<Curso> GetCursos()
        {
            List<Curso> cursos = new List<Curso>();
            this.OpenConnection();
            SqlCommand cmdCursos = new SqlCommand("SELECT cur.id_curso, materias.id_materia, comisiones.id_comision, comisiones.desc_comision, materias.desc_materia, cupo, anio_calendario " +
            "FROM cursos cur " +
            "INNER JOIN  materias on materias.id_materia = cur.id_materia " +
            "INNER JOIN comisiones on comisiones.id_comision = cur.id_comision ", sqlConn);
            SqlDataReader drCursos = cmdCursos.ExecuteReader();

            while (drCursos.Read())
            {
                Curso cur = new Curso();
                cur.ID = (int)drCursos["id_curso"];
                cur.IdComision = (int)drCursos["id_comision"];
                cur.DescComision = (string)drCursos["desc_comision"];
                cur.IdMateria = (int)drCursos["id_materia"];
                cur.DescMateria = (string)drCursos["desc_materia"];
                cur.Cupo = (int)drCursos["cupo"];
                cur.AnioCalendario = (int)drCursos["anio_calendario"];

                cursos.Add(cur);
            }

            return cursos;
        }


        public List<Curso> GetCursosDocente(int ID)
        {
            List<Curso> cursos = new List<Curso>();
            this.OpenConnection();
            SqlCommand cmdCursos = new SqlCommand("SELECT cur.id_curso, materias.id_materia, comisiones.id_comision, comisiones.desc_comision, materias.desc_materia, cupo, anio_calendario " +
            "FROM cursos cur " +
            "INNER JOIN  materias on materias.id_materia = cur.id_materia " +
            "INNER JOIN comisiones on comisiones.id_comision = cur.id_comision " +
            "INNER JOIN docentes_cursos dc on dc.id_docente = cur.id_docente " +
            "where dc.id_docente=@id", sqlConn);
            cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            SqlDataReader drCursos = cmdCursos.ExecuteReader();

            while (drCursos.Read())
            {
                Curso cur = new Curso();
                cur.ID = (int)drCursos["id_curso"];
                cur.IdComision = (int)drCursos["id_comision"];
                cur.DescComision = (string)drCursos["desc_comision"];
                cur.IdMateria = (int)drCursos["id_materia"];
                cur.DescMateria = (string)drCursos["desc_materia"];
                cur.Cupo = (int)drCursos["cupo"];
                cur.AnioCalendario = (int)drCursos["anio_calendario"];

                cursos.Add(cur);
            }

            return cursos;
        }

        public List<Persona> GetDocente()
        {
            List<Persona> docentes = new List<Persona>();
            this.OpenConnection();
            SqlCommand cmdDocentes = new SqlCommand("SELECT id_persona, nombre, apellido FROM personas " +
                "WHERE tipo_persona = 0", sqlConn);
            SqlDataReader drDocentes = cmdDocentes.ExecuteReader();
            while (drDocentes.Read())
            {
                Persona per = new Persona();
                per.ID = (int)drDocentes["id_persona"];
                per.Apellido = (string)drDocentes["apellido"];
                docentes.Add(per);
            }
            return docentes;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_docente=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(DocenteCurso dc) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_docente = @id_docente, cargo = @cargo, id_curso = @IDcurso " +
                    "WHERE id_dictado = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdSave.Parameters.Add("@IDcurso", SqlDbType.Int).Value = dc.IdCurso;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos(id_docente, id_curso, cargo) " +
                    "values (@cargo,@IDCurso,@IDDocente) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdSave.Parameters.Add("@IDDocente", SqlDbType.Int).Value = dc.IdDocente;
                cmdSave.Parameters.Add("@IDcurso", SqlDbType.Int).Value = dc.IdCurso;
                dc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dictado)
        {
            if (dictado.State == BusinessEntity.States.New)
            {
                this.Insert(dictado);
            }
            else if (dictado.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dictado.ID);
            }
            else if (dictado.State == BusinessEntity.States.Modified)
            {
                this.Update(dictado);
            }
            dictado.State = BusinessEntity.States.Unmodified;
        }
    }
}