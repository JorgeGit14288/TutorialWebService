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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPersonasDao

    {
        /**La clase data contract y sus data members fueron movidas a DAL, persona para tener 
      un mejor orden
        */

        [OperationContract]
        string Crear(Persona p);
        [OperationContract]
        string Actualizar(Persona p);
        [OperationContract]
        string Eliminar(int id);
        [OperationContract]
        List<Persona> Listar();
        [OperationContract]
        Persona BuscarId(int id);
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
   
    
}
