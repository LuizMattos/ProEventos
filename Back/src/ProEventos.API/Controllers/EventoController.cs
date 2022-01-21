using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       public IEnumerable<Evento> _evento = new Evento[] {
          new Evento() {
                  EventoId = 1,
                  Tema = "Angular",
                  Local = "BH",
                  Lote = "1 Lote",
                  QtdPessoas = 250,
                  DataEvento = DateTime.Now.AddDays(2).ToString(),
                  ImageURL = "foto1.jpg"
              },
              new Evento() {
                  EventoId = 2,
                  Tema = "Delphi",
                  Local = "SP",
                  Lote = "2 Lote",
                  QtdPessoas = 120,
                  DataEvento = DateTime.Now.AddDays(1).ToString(),
                  ImageURL = "foto2.jpg"
              }
       };
        private readonly ILogger<EventoController> _logger;

        public EventoController()
        {

        }

        [HttpPost]
        public string Post()
        {
           return "value - Post";
        }
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _evento.Where(e => e.EventoId == id);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           return $"value = {id}";
        }
        
       
    }
}
