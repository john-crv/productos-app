using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Web;

namespace productos_app.Models
{
    public class CategoriaProducto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        
        public int prducotId { get; set; }  

        public Producto producto { get; set; }  
    }
}