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
        public static void Main(string[] text)
        {
            FrontEnd();

        }
        public void FrontEnd()
        {
            while (true)
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

                else if (option == 1)
                {
                    List<Event> events = new List<Event>();
                    Event event1 = new Event();
                    Console.WriteLine("Title of Event");
                    event1.Title = Console.ReadLine();
                    Console.WriteLine("Enter Location of Event");
                    event1.Location = Console.ReadLine();
                    event1.DateTime = DateTime.Now;
                    Console.WriteLine("Enter a Description");
                    event1.Description = Console.ReadLine();
                    Console.WriteLine("Enter Attandees seperated by space");
                    string elements = Console.ReadLine();
                    event1.Attandees.AddRange(elements.Split(' '));
                    Console.WriteLine("Enter a tags seperated by space");
                    string el = Console.ReadLine();
                    event1.Tags.AddRange(el.Split(' '));
                    AddEvent(event1);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter id for deleting the event");
                    var id = Guid.Parse((Console.ReadLine()));
                    var result = DeleteEvent(id);
                    if (result is true)
                    {
                        Console.WriteLine("The Event is Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Error: not Deleted");
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Enter the ID of old Event");
                    Guid id = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Enter New event");
                    Event NewEvent = new Event();
                    Console.WriteLine("Enter a Title of event");
                    NewEvent.Title = Console.ReadLine();
                    Console.WriteLine("Title of Event");
                    NewEvent.Location = Console.ReadLine();
                    NewEvent.DateTime = DateTime.Now;
                    Console.WriteLine("Enter a Description");
                    NewEvent.Description = Console.ReadLine();
                    Console.WriteLine("Enter Attandees seperated by space");
                    string elements = Console.ReadLine();
                    NewEvent.Attandees.AddRange(elements.Split(' '));
                    Console.WriteLine("Enter a tags seperated by space");
                    string el = Console.ReadLine();
                    NewEvent.Tags.AddRange(el.Split(' '));
                    bool check = UpdateEvent(id, NewEvent);
                    if (check is true)
                    {
                        Console.WriteLine("The was Updated");
                    }
                    else
                    {
                        Console.WriteLine("Error; Not Updated");
                    }
                }
                else if (option == 4)
                {

                    GetAllEvents();
                }
                else if (option == 5)
                {
                    Console.WriteLine("Enter the Id");
                    var Id = Guid.Parse(Console.ReadLine());
                    var result = GetByid(Id);
                    if (result is null)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                else if (option == 6)
                {
                    Console.WriteLine("Enter Location");
                    var Location = Console.ReadLine();
                    List<Event> SameLocation = GetAllEventsByLocation(Location);
                    if (SameLocation is null)
                    {
                        Console.WriteLine("Error there is Events with such Location");
                    }
                    else
                    {
                        Console.WriteLine(SameLocation);
                    }
                }
                else if (option == 7)
                {
                    List<Event> MostPopular = GetPopularEvent();
                    Console.WriteLine(MostPopular);
                }
                else if (option == 8)
                {
                    Console.WriteLine("Enter Person name");
                    var Name = Console.ReadLine();
                    Console.WriteLine("Enter events ID");
                    var ID = Guid.Parse(Console.ReadLine());
                    var check = AddPersonToEvent(Name, ID);
                    if (check is true)
                    {
                        Console.WriteLine("Person Added");
                    }
                    else
                    {
                        Console.WriteLine("Error not added");
                    }
                }
                else if (option == 9)
                {
                    var MostTaged = new List<Event>();
                    MostTaged = GetMaxTaggedEvent();
                    if (MostTaged != null)
                    {
                        Console.WriteLine(MostTaged);
                    }
                    else
                    {
                        Console.WriteLine("Error there is No most Taged event");
                    }
                }
                Console.ReadKey();
                Console.Clear();
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
                else
                {
                    if (i.Location != location)
                    {
                        SameLocation = null;
                    }
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
