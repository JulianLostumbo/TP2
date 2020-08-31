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
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                    materias.Add(mat);
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
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
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
        public void Update(Materia materia) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update materias set desc_materia= @desc_materia, hs_semanales= @hs_semanales," +
                                                  "hs_totales= @hs_totales, id_plan= @id_plan " +
                                                  "where id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
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

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into materias (desc_materia, hs_semanales, hs_totales, id_plan)" +
                                                   "values (@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                                                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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