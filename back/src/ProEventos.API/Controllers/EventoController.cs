using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    { 
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {           
            this._context = context;
        }
            
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;            
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);            
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de POST";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de PUT com id = {id}";
        }

        [HttpDelete("{id}/{nome}")]
        public string Delete(int id, string nome)
        {
            return $"Exemplo de DELETE com id = {id} e nome = {nome}";
        }

    }
}
