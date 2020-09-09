using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models
{
    public class tbl_Restaurantes
    {
        [Key]
        public int Id_restaurante { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        
        //manejo del horario de apertura y cierre
        public DateTime H_apertura { get; set; }
        public DateTime H_cierre { get; set; }

        // para las imagenes se almacenaran de forma externa y podremos guardar solamente la ruta de almacenamiento
        public string Logo { get; set; }
        public string Imagen_item { get; set; }
        
        //Relaciones
        public ICollection<tbl_Votaciones> restauranteVotaciones { get; set; }
    }
}
