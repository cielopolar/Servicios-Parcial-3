using AppsParcial3.Clases;
using AppsParcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppsParcial3.Controllers
{
    [RoutePrefix("api/Evento")]
    public class EventoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXID")]
        public Evento ConsultarXID(int Id)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarXID(Id);
        }
        [HttpGet]
        [Route("ConsultarXNombre")]
        public Evento ConsultarXNombre(string Nombre)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarXNombre(Nombre);
        }
        [HttpGet]
        [Route("ConsultarXFecha")]
        public Evento ConsultarXFecha(DateTime Fecha)
        {
            clsEvento evento = new clsEvento();
            return evento.ConsultarXFecha(Fecha);
        }
        [HttpPost]
        [Route("Insertar")]
        [Authorize]
        public string Insertar([FromBody] Evento eve)
        {
            clsEvento clsEvento = new clsEvento();
            clsEvento.eventos = eve;
            return clsEvento.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Evento eve)
        {
            clsEvento clsEvento = new clsEvento();
            clsEvento.eventos = eve;
            return clsEvento.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Evento eve)
        {
            clsEvento clsEvento = new clsEvento();
            clsEvento.eventos = eve;
            return clsEvento.Eliminar();
        }
    }
}