using productos_app.Models;
using productos_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
                ViewBag.Productos = productos;
            }
            catch (Exception e)
            {

                throw e;
            }
            return View();
        }

        public ActionResult AdministrarProducto()
        {
            List<Producto> productos = productoService.GetProductos().Result;
            List<CategoriaProducto> categoriasProducto = categoriaProductoService.GetCategoriasProducto().Result;
            ViewBag.Productos = productos;
            ViewBag.CategoriasProducto = categoriasProducto;

            return View();
        }
    }
}