using Data.Core;
using Gold.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gold.Core.Interfaces
{
    public interface IEventService : IBaseService<Event, long>
    {
        Task<List<Event>> GetEventFromDateToDate(DateTime datefrom, DateTime dateto);
    }
}
