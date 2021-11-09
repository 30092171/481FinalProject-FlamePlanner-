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
        public DateTime startDate = new DateTime(2001,01,01); //= new DateTime(year,month,day)
        public int startTime = 0;  //24 hr 1300 = 1:00pm and so on
        public int endTime = 0; //24 hr 900 = 9:00am and so on

        /// <summary>
        /// Default Event class Constructor all values are defaultly populated
        /// </summary>
        public EventObject()
        {
            //Default constructor, values are all default
            
        }

        /// <summary>
        /// Constructor for Event Class which populates all fields
        /// </summary>
        /// <param name="name">Represents Event Name as a string</param>
        /// <param name="details">Represents Event Details as a string</param>
        /// <param name="location">Represents location of event as a string</param>
        /// <param name="date">Represents Date of Event as a DateType Object</param>
        /// <param name="sTime">start time as an int (24hrs)</param>
        /// <param name="eTime">end time as an int (24hrs)</param>
        public EventObject(string name, string details,string location, DateTime date, int sTime, int eTime)
        {
            this.eventName = name;
            this.eventDetails = details;
            this.eventLocation = location;
            this.startDate = date;
            this.startTime = sTime;
            this.endTime = eTime;
        }


    }
}
