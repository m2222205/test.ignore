using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_dars.Model
{
    public class Event
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public List<string> Attandees { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();

    }
}
