using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                EventoId = 1,
                Local = "Belo Horizonte",
                DataEvento = DateTime.Now.AddDays(2),
                Tema = "Angular 11 e .NET 5",
                QtdPessoas = 250,
                Lote = "1º Lote",
                ImagemURL = "foto.jpg"
            },
            new Evento(){
                EventoId = 2,
                Local = "São Paulo",
                DataEvento = DateTime.Now.AddDays(3),
                Tema = "Angular e .NET Core",
                QtdPessoas = 350,
                Lote = "2º Lote",
                ImagemURL = "foto.jpg"
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
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);            
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
