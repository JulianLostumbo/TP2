using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloAdapter: Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulo = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drModulo = cmdModulo.ExecuteReader();
                while (drModulo.Read())
                {
                    Modulo mod = new Modulo();
                    mod.Descripcion = (string)drModulo["descripcion"];
                    modulo.Add(mod);
                }
                drModulo.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }

        public Business.Entities.Modulo GetOne(string Descripcion)
        {
            Modulo mod = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("select * from modulos where descripcion=@descripcion", sqlConn);
                cmdModulo.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = Descripcion;
                SqlDataReader drModulo = cmdModulo.ExecuteReader();
                if (drModulo.Read())
                {
                    mod.Descripcion = (string)drModulo["descripcion"];
                }

                drModulo.Close();
            }

            catch (Exception Ex)

            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return mod;

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Modulo mod) /*protected*/
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo = @descripcion, " +
                    "WHERE id_modulo = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mod.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = mod.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Modulo mod)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into modulos(desc_modulo) " +
                    "values (@descripcion) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = mod.Descripcion;
                mod.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo mod)
        {
            if (mod.State == BusinessEntity.States.New)
            {
                this.Insert(mod);
            }
            else if (mod.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mod.ID);
            }
            else if (mod.State == BusinessEntity.States.Modified)
            {
                this.Update(mod);
            }
            mod.State = BusinessEntity.States.Unmodified;
        }
    }
}
