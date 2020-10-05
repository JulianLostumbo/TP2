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
    public class DictadoAdapter : Adapter
    {
        public List<Dictado> GetAll()
        {
            List<Dictado> dictados = new List<Dictado>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDictados = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDictados = cmdDictados.ExecuteReader();
                while (drDictados.Read())
                {
                    Dictado dic = new Dictado();
                    dic.ID = (int)drDictados["id_dictado"];
                    dic.IdDocente = (int)drDictados["id_docente"];
                    dic.IdCurso = (int)drDictados["id_curso"];
                    dic.Cargo = (string)drDictados["cargo"];
                    dictados.Add(dic);
                }
                drDictados.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de los dictados", Ex);
                throw ExcepcionManejada;
            }
            return dictados;
        }



        public Business.Entities.Dictado GetOne(int ID)
        {
            Dictado dic = new Dictado();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDictados = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDictados.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDictados = cmdDictados.ExecuteReader();
                if (drDictados.Read())
                {
                    dic.ID = (int)drDictados["id_dictado"];
                    dic.IdDocente = (int)drDictados["id_docente"];
                    dic.IdCurso = (int)drDictados["id_curso"];
                    dic.Cargo = (string)drDictados["cargo"];
                }
                drDictados.Close();
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
            return dic;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
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
        public void Update(Dictado dictado) //protected
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update docentes_cursos set id_curso= @id_curso, id_docente= @id_docente," +
                                                  "cargo= @cargo " +
                                                  "where id_dictado=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dictado.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = dictado.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dictado.Cargo;
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

        protected void Insert(Dictado dictado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos (id_curso, id_docente," +
                                                  "cargo)" +
                                                   "values (@id_curso, @id_docente," +
                                                  "@cargo) " +
                                                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dictado.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = dictado.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dictado.Cargo;
                dictado.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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

        public void Save(Dictado dictado)
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