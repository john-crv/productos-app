using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace productos_app.Models
{
    public class Producto
    {
        public int id {  get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string nombre { get; set; }

        public string imagen { get; set; }

        [Required(ErrorMessage = "descripcion es obligatorio")]

        public string descripcion { get; set; }

        [Required(ErrorMessage = "Se debe indicar la categoria")]

        public int idCategoria { get; set; } 


    }
}