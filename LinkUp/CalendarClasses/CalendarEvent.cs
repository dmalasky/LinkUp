using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp
{
    public class CalendarEvent : UniqueItem
    {
        public CalendarEvent() : base(Globals.CALEVENT_UID_LENGTH) { }

        public enum EventType
        {
            AVAILABLE,
            BUSY,
        }
        public EventType eventType { get; set; }

        public string? name { get; set; }
        public string? description { get; set; }

        //string repeat = "";
        public DateTime dStart { get; set; }
        public DateTime dEnd { get; set; }
    }
}
