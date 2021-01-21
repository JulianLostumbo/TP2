using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public List<Usuario> GetAll(int ID)
        {
            return UsuarioData.GetAll(ID);
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public List<Persona> GetPersonas()
        {
            return UsuarioData.GetPersonas();
        }

        public Business.Entities.Usuario GetOne(string user, string clave)
        {
            return UsuarioData.GetOne(user, clave);
        }
        
        /*public static bool Login2(string user, string pass)
        {
            UsuarioAdapter ud = new UsuarioAdapter();
            return ud.Login2(user, pass);
        }
        */

        public void Delete (int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Save (Business.Entities.Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public void Update(Business.Entities.Usuario usuario)
        {
            UsuarioData.Update(usuario);
        }
    }
}
