using Eventify_Tutorial_Series.Application.DTOs;
using Eventify_Tutorial_Series.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify_Tutorial_Series.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDTO createEventDTO); //geriye değer döndürmeyen bir metot, asenkron olarak çalışacak, metot adı CreateEventAsync ve parametre olarak CreateEventDTO alacak, veritabanına dto'daki bilgileri kullanarak yeni bir etkinlik oluşturacak
        Task <IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination); //geriye değer döndüren bir metot, döndürdüğü değer bir IEnumerable<EventDTO> türünde olacak, bu türdeki değerler asenkron olarak döndürülecek, metot adı GetAllEventsAsync ve parametre olarak Pagination alacak

    }
}
