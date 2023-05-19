using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [RoutePrefix("Api/Ejemplo")]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header", SupportsCredentials = true)]
    
    public class unicoController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("GetUsuarios")]
        public IHttpActionResult GetUsuarios()
        {
            try
            {
                UsuariosBLL usuarios = new UsuariosBLL();
                return Content(HttpStatusCode.OK, usuarios.obtenerUsuarios());
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Fallo en la conexion");
            }
        }  
      
    }
}
