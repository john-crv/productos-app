﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace productos_app.Models
{
    public class Producto
    {
        public int id {  get; set; }
        public string nombre { get; set; }

        public string imagen { get; set; }  

        public string descripcion { get; set; }

        public int idCategoriaProduto { get; set; } 


    }
}