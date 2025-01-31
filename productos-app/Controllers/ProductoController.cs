﻿using Newtonsoft.Json;
using productos_app.Models;
using productos_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace productos_app.Controllers
{
    public class ProductoController : Controller
    {

        private ProductoServices productoService = new ProductoServices();
        private CategoriaProductoServices categoriaProductoService = new CategoriaProductoServices();
        public ActionResult Catalogo()
        {   
            
            try
            {
                List<Producto> productos = productoService.GetProductos().Result;
                List<CategoriaProducto> categoriasProducto = categoriaProductoService.GetCategoriasProducto().Result;
                ViewBag.Productos = productos;
                ViewBag.CategoriasProducto = categoriasProducto;
            }
            catch (Exception e)
            {

                throw e;
            }
            return View();
        }


        [HttpPost]
        public string CrearProducto(Producto producto)
        {
            string result = "";
            try
            {
               Producto nuevoProducto = productoService.CreateProducto(producto).Result;
                result = JsonConvert.SerializeObject(nuevoProducto);
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;

        }

        [HttpDelete]
        public bool EliminarProducto(int id)
        {
            bool result = false;
            try
            {
               result = productoService.EliminarProducto(id).Result;
               
            }
            catch (Exception e)
            {

                throw e;
            }

            return result;
        }


        [HttpGet]
        public string GetProducto(int id)
        {
            string result = "";
            try
            {
                Producto producto = productoService.GetProducto(id).Result;
                result = JsonConvert.SerializeObject(producto);
            }
            catch (Exception e)
            {

                throw e;
            }

            return result;
        }

        [HttpPut]

        public bool EditarProducto(int id, Producto producto)
        {
            bool result = false;
            try
            {
                result = productoService.EditarProducto(id, producto).Result;
            }
            catch (Exception e)
            {

                throw e;
            }

            return false;
        }
    }

}