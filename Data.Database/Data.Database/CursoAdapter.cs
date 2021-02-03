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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT cur.id_curso, cur.id_comision, comisiones.desc_comision, materias.id_materia, materias.desc_materia, " +
                    "cur.anio_calendario, cur.cupo FROM cursos cur " +
                    "INNER JOIN materias ON materias.id_materia = cur.id_materia " +
                    "INNER JOIN comisiones ON comisiones.id_comision = cur.id_comision", sqlConn);
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
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            return cursos;
        }



        public Business.Entities.Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT cur.id_curso, cur.id_materia, cur.id_comision, " +
                   "cur.anio_calendario, cur.cupo, materias.desc_materia, comisiones.desc_comision FROM cursos cur " +
                   "INNER JOIN materias ON materias.id_materia = cur.id_materia " +
                   "INNER JOIN comisiones ON comisiones.id_comision = cur.id_comision " +
                   "WHERE cur.id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.DescComision = (string)drCursos["desc_comision"];
                    cur.DescMateria = (string)drCursos["desc_materia"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public List<Materia> GetMaterias()
        {
            List<Materia> materias = new List<Materia>();
            this.OpenConnection();
            SqlCommand cmdMaterias = new SqlCommand("SELECT id_materia, desc_materia FROM materias", sqlConn);
            SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

            while (drMaterias.Read())
            {
                Materia ml = new Materia();
                ml.ID = (int)drMaterias["id_materia"];
                ml.Descripcion = (string)drMaterias["desc_materia"];
                materias.Add(ml);
            }

            return materias;
        }

        public List<Comision> GetComisiones()
        {
            List<Comision> comisiones = new List<Comision>();
            this.OpenConnection();
            SqlCommand cmdComisiones = new SqlCommand("SELECT id_comision, desc_comision FROM comisiones", sqlConn);
            SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

            while (drComisiones.Read())
            {
                Comision cl = new Comision();
                cl.ID = (int)drComisiones["id_comision"];
                cl.Descripcion = (string)drComisiones["desc_comision"];
                comisiones.Add(cl);
            }

            return comisiones;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso cur) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET cupo = @cupo, anio_calendario = @AnioCalendario, " +
                    "id_materia = @IDMateria, id_comision = @IDComision " +
                    "WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = cur.ID;
                cmdSave.Parameters.Add("@Cupo", SqlDbType.Int).Value = cur.Cupo;
                cmdSave.Parameters.Add("@AnioCalendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@IDMateria", SqlDbType.Int).Value = cur.IdMateria;
                cmdSave.Parameters.Add("@IDComision", SqlDbType.Int).Value = cur.IdComision;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(cupo, anio_calendario,id_materia, id_comision) " +
                    "values (@Cupo,@AnioCalendario,@IDMateria,@IDComision) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@Cupo", SqlDbType.Int).Value = cur.Cupo;
                cmdSave.Parameters.Add("@AnioCalendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@IDMateria", SqlDbType.Int).Value = cur.IdMateria;
                cmdSave.Parameters.Add("@IDComision", SqlDbType.Int).Value = cur.IdComision;
                cur.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}