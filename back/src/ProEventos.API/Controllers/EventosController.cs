﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    { 
        private readonly IEventoService _eventoService;
        
        public EventosController(IEventoService eventoService)
        {           
            _eventoService = eventoService;
            
        }
            
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null)
                    return NotFound("Nenhum evento encontrado.");
                
                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            }         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {            
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento == null)
                    return NotFound("Evento por Id não encontrado.");
                
                return Ok(evento);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            } 
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {            
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (eventos == null)
                    return NotFound("Eventos por tema não encontrados.");
                
                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            } 
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var eventos = await _eventoService.AddEventos(model);
                if (eventos == null)
                    return BadRequest("Erro ao tentar adicionar evento.");
                
                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar evento. Erro: {ex.Message}" );
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var eventos = await _eventoService.UpdateEventos(id, model);
                if (eventos == null)
                    return BadRequest("Erro ao tentar alterar evento.");
                
                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar alterar evento. Erro: {ex.Message}" );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                return  await  _eventoService.DeleteEventos(id) ?
                     Ok("Deletado") : 
                     BadRequest("Evento não deletado.");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar evento. Erro: {ex.Message}" );
            }
        }

    }
}
