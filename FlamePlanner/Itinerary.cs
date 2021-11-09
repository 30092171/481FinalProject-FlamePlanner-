using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlamePlanner
{
    /// <summary>
    /// Itinerary Class. Has a title and list of Events
    /// </summary>
    public class Itinerary
    {
        public List<EventObject> eventList;
        public string itineraryTitle = "";

        
        /// <summary>
        /// Constructor for itinerary class
        /// EventList field is intialized empty
        /// event title is intilaized based on argument passed to constructor
        /// </summary>
        /// <param name="title">Title/Name of Itinerary</param>
        public Itinerary(string title)
        {
            this.eventList = new List<EventObject>();
            this.itineraryTitle = title;
        }
    }
}
