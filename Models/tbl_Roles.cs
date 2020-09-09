using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models
{
    public class tbl_Roles
    {
        [Key]
        public int Id_rol { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }

        //Relaciones
        public ICollection<tbl_Usuarios> rolesUsuarios { get; set; }
    }
}
