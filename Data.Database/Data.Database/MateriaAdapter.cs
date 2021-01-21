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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT materias.id_materia, materias.desc_materia, materias.hs_semanales, " +
                    "materias.hs_totales, materias.id_plan, planes.desc_plan FROM materias " +
                    "INNER JOIN planes ON planes.id_plan = materias.id_plan ", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mate = new Materia();
                    mate.ID = (int)drMaterias["id_materia"];
                    mate.Descripcion = (string)drMaterias["desc_materia"];
                    mate.HsSemanales = (int)drMaterias["hs_semanales"];
                    mate.HsTotales = (int)drMaterias["hs_totales"];
                    mate.IdPlan = (int)drMaterias["id_plan"];
                    mate.DescPlan = (string)drMaterias["desc_plan"];

                    materias.Add(mate);
                }
                drMaterias.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            return materias;
        }



        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT materias.id_materia, materias.desc_materia, materias.hs_semanales, " +
                    "materias.hs_totales, materias.id_plan, planes.desc_plan FROM materias " +
                    "INNER JOIN planes ON planes.id_plan = materias.id_plan where materias.id_materia = @id; ", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                    mat.DescPlan = (string)drMaterias["desc_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }

        public List<Plan> GetPlanes()
        {
            List<Plan> planes = new List<Plan>();
            this.OpenConnection();
            SqlCommand cmdPlanes = new SqlCommand("SELECT id_plan, desc_plan FROM planes", sqlConn);
            SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

            while (drPlanes.Read())
            {
                Plan pl = new Plan();
                pl.ID = (int)drPlanes["id_plan"];
                pl.Descripcion = (string)drPlanes["desc_plan"];
                planes.Add(pl);
            }

            return planes;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
                //Usuarios.Remove(this.GetOne(ID));
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Materia mat) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @HSSemanales,hs_temanales = @HSTotales, id_plan = @idPlan, " +
                    "WHERE id_materia = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdSave.Parameters.Add("@HSSemanales", SqlDbType.Int).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@HSTotales", SqlDbType.Int).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.IdPlan;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) " +
                    "values (@desc_materia,@HSSemanales,@HSTotales,@idPlan) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@HSSemanales", SqlDbType.Int).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@HSTotales", SqlDbType.Int).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.IdPlan;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                mat.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}