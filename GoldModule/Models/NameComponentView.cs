using Infrastructure.Models.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldModule.Models
{
    public class NameComponentView: ComponentViewFlag
    {
        public static string EventCreate { get; set; } = $"Event{Create}";
        public static string EventIndex { get; set; } = $"Event{Index}";
        public static string PointEventCreate { get; set; } = $"PointEvent{Create}";
        public static string PointEventIndex { get; set; } = $"PointEvent{Index}";
    }
}
