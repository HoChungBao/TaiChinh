using Gold.Core.Interfaces;
using Gold.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldModule.Extensions
{
    public static class ServicesGoldExtension
    {
        public static void AddServicesGold(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IPointEventService,PointEventService>();
        }
    }
}
