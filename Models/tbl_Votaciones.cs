using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models
{
    public class tbl_Votaciones
    {
        [Key]
        public int Id_votacion { get; set; }

        //campos de referencia de relaciones
        public int Id_restaurante { get; set; }
        public int Id_dato { get; set; }

        public double Votacion { get; set; }

        //Relaciones
        public tbl_Restaurantes votacionesRestaurantes { get; set; }
        public tbl_Datos votacionesDatos { get; set; }

    }
}
