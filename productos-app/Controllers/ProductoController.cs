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
        public async Task<ActionResult> Catalogo()
        {   
            
            try
            {
                List<Producto> productos = await productoService.getProductos();
            }
            catch (Exception e)
            {

                throw e;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}