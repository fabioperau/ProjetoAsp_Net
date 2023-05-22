using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Controllers
{   
    [ApiController]
    [Route("api/eventos")]

    public class EventosController : ControllerBase
    {   
        private readonly EventoDbContext _contexto;

        public EventosController(EventoDbContext  contexto){
            _contexto = contexto;
        }

        // Get api/eventos
        [HttpGet]
        public IActionResult GetAll(){
            var eventos = _contexto.Eventos;

            return Ok(eventos);
        }

        // Get api/eventos/1  
         [HttpGet("{id}")]
         public IActionResult GetById(int id){
            var evento = _contexto.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null){
                return NotFound();
            }

            return Ok(evento);
        }

        //Post api/eventos
        [HttpPost]
        public IActionResult Post(evento evento){
            _contexto.Eventos.Add(evento);
            return CreatedAtAction(
                nameof(GetById),
                new{ id = evento.Id},
                evento
            );
        }

        //Put api/eventos/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, evento evento){
            var eventoExistente = _contexto.Eventos.SingleOrDefault(e => e.Id == id);
            if (eventoExistente == null){
                return NotFound();
            }

            eventoExistente.Update(evento.Titulo, evento.Descricao, evento.DataInicio, evento.DataFim);
            return NoContent();
        }

        // Delete api/eventos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
             var evento = _contexto.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null){
                return NotFound();
            }

            _contexto.Eventos.Remove(evento);
            return NoContent();
        }
    }
}