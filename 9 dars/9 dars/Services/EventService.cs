using _9_dars.Model;

namespace _9_dars.Services
{
    public class EventService
    {
        List<Event> events;
        public EventService()
        {
            events = new List<Event>();
        }

        public void FrontEnd()
        {
            while ()
            {
                Console.WriteLine("1. Add event");
                Console.WriteLine("2. Delete event");
                Console.WriteLine("3. Update event");
                Console.WriteLine("4. Get all ");
                Console.WriteLine("5. Get by id");
                Console.WriteLine("6. Get all Event by location");
                Console.WriteLine("7. Get popular event");
                Console.WriteLine("8. Add person to event");
                Console.WriteLine("9. Get most Tagged event");
                Console.WriteLine("Enter you option");
                var option = int.Parse(Console.ReadLine());
                if(option == 1)
                {
                    Console.WriteLine("Title of Event");
                    var Event.Title = Console.ReadLine();
                }




            }
        }





        public Event AddEvent(Event newevent)
        {
            newevent.ID = Guid.NewGuid();
            events.Add(newevent);
            return newevent;
        }

        public Event GetByid(Guid id)
        {
            var Isexist = id;
            foreach (var i in events)
            {
                if (i.ID == id)
                {
                    return i;
                }
            }
            return null;
        }

        public bool DeleteEvent(Guid id)
        {
            var isexist = GetByid(id);
            if (isexist == null)
            {
                return false;
            }
            events.Remove(isexist);
            return true;
        }

        public bool UpdateEvent(Guid id, Event updatedEvent)
        {
            var exist = GetByid(id);
            if (exist == null)
            {
                return false;
            }
            var Index = events.IndexOf(exist);
            events[Index] = updatedEvent;
            return true;
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public List<Event> GetAllEventsByLocation(string location)
        {
            var SameLocation = new List<Event>();
            foreach (var i in events)
            {
                if (i.Location == location)
                {
                    SameLocation.Add(i);

                }
            }
            return SameLocation;
        }

        public List<Event> GetPopularEvent()
        {
            var PopularEvent = new List<Event>();
            var MostPopular = 0;
            Event MostPopularEvent = null;
            for (var i = 0; i < events.Count; i++)
            {
                if (events[i].Attandees.Count > MostPopular)
                {
                    MostPopular = events[i].Attandees.Count;
                    MostPopularEvent = events[i];
                }
                if (MostPopular != 0)
                {
                    PopularEvent.Add(MostPopularEvent);
                }
            }
            return PopularEvent;
        }

        public bool AddPersonToEvent(string personName, Guid id)
        {
            var exist = GetByid(id);
            if (exist == null)
            {
                return false;
            }
            var result = exist;
            result.Attandees.Add(personName);
            return true;

        }

        public List<Event> GetMaxTaggedEvent()
        {
            var MaxTaggedEvent = new List<Event>();
            Event MaxTagged = null;
            for (var i = 0; i < events.Count; i++)
            {
                if (events[i].Tags.Count > events[0].Tags.Count)
                {
                    MaxTagged = events[i];
                }
            }
            MaxTaggedEvent.Add(MaxTagged);
            return MaxTaggedEvent;
        }

    }
}
