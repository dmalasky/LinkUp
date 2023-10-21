using LinkUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkUp
{
    internal class GroupMember : UniqueItem
    {
        public string? name { get; }
        //public string? uid { get; }

        public List<CalendarEvent> events { get; private set; } = new();

        [JsonConstructor]
        public GroupMember(string name, List<CalendarEvent> events) : base(Globals.USER_UID_LENGTH)
        {
            this.name = name;
            this.events = events;
        }
        public GroupMember(string name) : base(Globals.USER_UID_LENGTH)
        {
            this.name = name;
        }

        public void addEvent(CalendarEvent calevent)
        {
            calevent.uid = getUniqueUID(events.ConvertAll(x => (UniqueItem)x));
            events.Add(calevent);
        }
    }
}
