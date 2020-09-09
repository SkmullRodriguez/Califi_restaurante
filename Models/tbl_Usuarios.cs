using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models
{
    public class tbl_Usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        
        //campos de referencia de relaciones
        public int Id_dato { get; set; }
        public int Id_rol { get; set; }

        public string Usuario { get; set; }
        public string Clave { get; set; }

        //campo que funcionara como activo o inactivo
        public bool Estado { get; set; }

        //Relaciones
        public tbl_Datos usuariosDatos { get; set; }
        public tbl_Roles usuarioRoles { get; set; }
    }
}
