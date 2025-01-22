using Newtonsoft.Json;
using productos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace productos_app.Services
{
    public class CategoriaProductoServices
    {
        private HttpClient cliente = new HttpClient();
        //Cambiar ruta de acuerdo a la url de la api
        private string url = "https://localhost:44377/api";
        public async Task<List<CategoriaProducto>> GetCategoriasProducto()
        {

            List<CategoriaProducto> productos = new List<CategoriaProducto>();
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("https://localhost:44377/api/CategoriaProducto").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                productos = JsonConvert.DeserializeObject<List<CategoriaProducto>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                throw e;
            }

            return productos;
        }
    }
}