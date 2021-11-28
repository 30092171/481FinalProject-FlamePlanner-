using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlamePlanner
{
    /// <summary>
    /// Event Class. Has name,details,locations,date,startime,endtime.
    /// </summary>
    public class EventObject
    {
        public string eventName = ""; //name of event
        public string eventDetails = ""; //details of event
        public string eventLocation = "";//location of event
        public Uri eventImage = new Uri("EricNamEvent.jpg", UriKind.Relative); // uri to appropriate image for the event
        public string[] eventLinks = new string[0]; // array of any hyperlinks

        public DateTime startDate = new DateTime(2001,01,01); //= new DateTime(year,month,day)
        public DateTime endDate = new DateTime(2001, 01, 01);
        public int startTime = 0;  //24 hr 1300 = 1:00pm and so on
        public int endTime = 0; //24 hr 900 = 9:00am and so on

        public EventFilter filterID = EventFilter.NONE; //0 = no filter, integer used to identify filter criteria in iterinary
        
        // not sure where this is used
        public bool isVisible = true; //boolean to represent whether or not event should be displayed

        /// <summary>
        /// Default Event class Constructor all values are defaultly populated
        /// </summary>
        public EventObject() { } //Default constructor, values are all default

        /// <summary>
        /// Constructor for Event Class which populates all fields for specific date/time
        /// </summary>
        /// <param name="name">Represents Event Name as a string</param>
        /// <param name="details">Represents Event Details as a string</param>
        /// <param name="location">Represents location of event as a string</param>
        /// <param name="date">Represents Date of Event as a DateType Object</param>
        /// <param name="sTime">start time as an int (24hrs)</param>
        /// <param name="eTime">end time as an int (24hrs)</param>
        public EventObject(string name, string details, string location, DateTime date, int sTime, int eTime)
        {
            this.eventName = name;
            this.eventDetails = details;
            this.eventLocation = location;
            this.startDate = date;
            this.startTime = sTime;
            this.endTime = eTime;
        }

        #region Setters
        public EventObject SetEventName(string name)
        {
            eventName = name;
            return this;
        }
        public EventObject SetEventDetails(string details)
        {
            eventDetails = details;
            return this;
        }
        public EventObject SetLocation(string location)
        {
            eventLocation = location;
            return this;
        }
        public EventObject SetImage(Uri uri)
        {
            eventImage = uri;
            return this;
        }
        public EventObject SetLinks(params string[] links)
        {
            eventLinks = links;
            return this;
        }
        public EventObject SetStartDate(DateTime start)
        {
            startDate = start;
            return this;
        }
        public EventObject SetEndDate(DateTime end)
        {
            endDate = end;
            return this;
        }
        public EventObject SetStartTime(int start)
        {
            startTime = start;
            return this;
        }
        public EventObject SetEndTime(int end)
        {
            endTime = end;
            return this;
        }
        public EventObject SetFilter(EventFilter filter)
        {
            filterID = filter;
            return this;
        }
        #endregion

        public EventObject Copy()
        {
            return this;
        }
    }
    public enum EventFilter
    {
        NONE, Family, Concert, Food, Special, Video, Exhibit, Shop, Sport, Theatre
    }
}
