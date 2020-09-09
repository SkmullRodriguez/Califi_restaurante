using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models
{
    public class tbl_Datos
    {
        [Key]
        public int Id_dato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        //campo de eliminacion en modo vista
        public bool Eliminacion { get; set; }

        //Relaciones
        public ICollection<tbl_Usuarios> datosUsuarios { get; set; }
        public ICollection<tbl_Votaciones> datosVotaciones { get; set; }
    }
}
