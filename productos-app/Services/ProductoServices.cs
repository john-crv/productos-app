using Newtonsoft.Json;
using productos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace productos_app.Services
{
    //Esta clase es el intermediario entre el controller y api-prodcutos
    public class ProductoServices
    {
        private HttpClient cliente = new HttpClient();
        //Cambiar ruta de acuerdo a la url de la api
        private string puerto = "44377";
        public async Task<List<Producto>> GetProductos() { 
        
            List<Producto> productos = new List<Producto>();
            try
            {
                HttpResponseMessage response = await cliente.GetAsync($"https://localhost:{puerto}/api/Productos").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                productos = JsonConvert.DeserializeObject<List<Producto>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e )
            { 

                throw e;
            }

            return productos;
        } 

        public async Task<Producto> CreateProducto(Producto producto)
        {
            Producto nuevoProducto = new Producto();
            try
            {
                string jsonData = JsonConvert.SerializeObject(producto);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync($"https://localhost:{puerto}/api/Productos", content).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                nuevoProducto = JsonConvert.DeserializeObject<Producto>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {

                throw e;
            }

            return nuevoProducto;
        }

        public async Task<bool> EliminarProducto(int id)
        {
            bool result = false;
            try
            {
                HttpResponseMessage response = await cliente.DeleteAsync($"https://localhost:{puerto}/api/Productos/{id}").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                result = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }


        public async Task<Producto> GetProducto(int id)
        {
            Producto producto = new Producto();
            try
            {
                HttpResponseMessage response = await cliente.GetAsync($"https://localhost:{puerto}/api/Productos/{id}").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                producto = JsonConvert.DeserializeObject<Producto>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {

                throw e;
            }

            return producto;
        }

        public async Task<bool> EditarProducto(int id, Producto producto)
        {
            bool result = false;
            try
            {
                string jsonData = JsonConvert.SerializeObject(producto);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PutAsync($"https://localhost:{puerto}/api/Productos/{id}", content).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                result = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }
    }
}