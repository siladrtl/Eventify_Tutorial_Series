using Eventify_Tutorial_Series.Application.Abstractions.Services;
using Eventify_Tutorial_Series.Application.DTOs;
using Eventify_Tutorial_Series.Application.RequestParameters;
using Eventify_Tutorial_Series.Domain.Entities;
using Eventify_Tutorial_Series.Domain.ValueObjects;
using Eventify_Tutorial_Series.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eventify_Tutorial_Series.Persistence.Services
{
    public class EventService : IEventService
    {
        private readonly EventifyDbContext _context; //EventService sınıfında EventifyDbContext türünde bir alan tanımlanır, bu alan _context olarak adlandırılır ve readonly olarak işaretlenir, bu sayede sadece constructor içinde atanabilir ve sonrasında değiştirilemez

        public EventService(EventifyDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(CreateEventDTO createEventDTO)
        {
            if (createEventDTO is not null)
            {
                var newEvent = new Event()
                {
                    Title = createEventDTO.Title,
                    Date = createEventDTO.Date,
                    Location = createEventDTO.location
                };
                await _context.Events.AddAsync(newEvent);
                await _context.SaveChangesAsync();
            }
            else
                throw new NullReferenceException();
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
        {
           return await _context.Events.Select(x => new EventDTO
            {
                Title = x.Title,
                Date = x.Date,
                Location = x.Location
            })
            .Skip((pagination.PageCount) * pagination.ItemCount)
            .Take(pagination.ItemCount)
            .ToListAsync();


        }
    }
}
