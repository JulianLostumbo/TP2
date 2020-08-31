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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(com);
                }
                drComisiones.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            return comisiones;
        }



        public Business.Entities.Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
                //Usuarios.Remove(this.GetOne(ID));
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Comision comision) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update comisiones set desc_comision= @desc_comision, anio_especialidad= @anio_especialidad," +
                                                  "id_plan= @id_plan " +
                                                  "where id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision, anio_especialidad, id_plan)" +
                                                   "values (@desc_comision, @anio_especialidad, @id_plan) " +
                                                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
