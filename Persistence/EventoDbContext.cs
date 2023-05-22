using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//
using Entities;

namespace Persistence
{
    public class EventoDbContext
    {
        public EventoDbContext(){
            Eventos = new List<evento>();
        }

        public List <evento> Eventos { get; set; }
    }
}