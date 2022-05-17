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
                Tema = "Angular 11 e .NET 5",
                Local = "Porto Alegre",
                Lote = "1. Lote",
                QtdPessoas = 250,
                DataEevento = DateTime.Now.AddDays(2).ToString("dd/MM/y"),
                ImagemURL = "foto.png"
            },
                        new Evento() {
                EventoId = 2,
                Tema = "Angular e suas novidades",
                Local = "Porto Alegre",
                Lote = "2. Lote",
                QtdPessoas = 350,
                DataEevento = DateTime.Now.AddDays(3).ToString("dd/MM/y"),
                ImagemURL = "foto1.png"
            }
        };
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

    }
}
