﻿using Newtonsoft.Json;
using productos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace productos_app.Services
{
    //Esta clase es el intermediario entre el controller y api-prodcutos
    public class ProductoServices
    {
        private HttpClient cliente = new HttpClient();
        //Cambiar ruta de acuerdo a la url de la api
        private string url = "https://localhost:44377/api";
        public async Task<List<Producto>> GetProductos() { 
        
            List<Producto> productos = new List<Producto>();
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("https://localhost:44377/api/Productos").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                productos = JsonConvert.DeserializeObject<List<Producto>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e )
            { 

                throw e;
            }

            return productos;
        } 
    }
}