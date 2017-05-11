using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSPersonas.DAL;

namespace WSPersonas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSPersonas : IPersonasDao
    {
       private dbTestPersonaEntities db = new dbTestPersonaEntities();
        public string Actualizar(Persona p)
        {
            try
            {
                if(!Existe(p.idPersona))
                {
                    return "Error, No se encuenta el registro";
                }

                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Se ha actualizado a la persona";

            }
            catch (Exception ex)
            {
                return "Error, no se pudo crear el registro " + ex.ToString();
            }
           
        }
        public bool Existe(int id)
        {
            if((db.Persona.Find(id).idPersona>0))
            {
                return true;
             }
            else
            {
                return false;
            }
        }

        public Persona BuscarId(int id)
        {
            if (!Existe(id))
            {
                return null;
            }
            return db.Persona.Find(id);
        }

        public string Crear(Persona p)
        {
            try
            {
                if (!Existe(p.idPersona))
                {
                    return "Error, No se encuenta el registro";
                }

                db.Entry(p).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return "Se ha actualizado a la persona";

            }
            catch (Exception ex)
            {
                return "Error, no se pudo crear el registro " + ex.ToString();
            }
        }

        public string Eliminar(int id)
        {
            if(!Existe(id))
            {
                return "Error, no se encontro el registro";

            }
            Persona p= db.Persona.Find(id);
            db.Persona.Remove(p);
            return "Se ha eliminado el registro";
        }

        public List<Persona> Listar()
        {
            return db.Persona.ToList();
        }
    }
}
