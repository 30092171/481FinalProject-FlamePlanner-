using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlamePlanner
{
    /// <summary>
    /// This class provides TEMPLATES for several events.
    /// </summary>
    public static class AllEvents
    {
        public static EventObject EricNam = new EventObject()
            .SetEventName("Eric Nam Before We Begin World Tour")
            .SetEventDetails("A regular in Korea's music scene, Eric has promoted two mini albums and multiple singles in Korea.\nHe has charted at #1 on several occasions and held shows in the U.A.E., Australia, Canada, Malaysia, Morocco, and the United States.")
            .SetLocation("MacEwan Hall (402 Collegiate Blvd NW, Calgary, AB T2N 1N4)")
            .SetStartDate(new DateTime(2021, 09, 05))
            .SetStartTime(2000)
            .SetEndTime(2300)
            .SetFilter(EventFilter.Concert);
        public static EventObject Stampede = new EventObject()
            .SetEventName("Calgary Stampede")
            .SetImage(new Uri("CalgaryStampedeEvent.jpg", UriKind.Relative))
            .SetEventDetails("At the heart of the Calgary Stampede, you’ll find more than 2,500 dedicated volunteers. They embody western values by hosting events across the city, supporting community celebrations and making the Calgary Stampede The Greatest Outdoor Show on Earth. In addition, the Board of Directors are unpaid volunteers who contribute their time to govern the affairs of the Calgary Stampede.")
            .SetLocation("Stampede Grounds (1410 Olympic Way SE, Calgary, AB T2G 2W1)")
            .SetStartDate(new DateTime(2021, 7, 3))
            .SetEndDate(new DateTime(2021, 7, 12))
            .SetStartTime(1100)
            .SetEndTime(0000)
            .SetLinks("https://www.calgarystampede.com/")
            .SetFilter(EventFilter.Special);
        public static EventObject Thriller = new EventObject()
            .SetEventName("Halloween Thriller")
            .SetImage(new Uri("HalloweenEvent.jpg", UriKind.Relative))
            .SetEventDetails("CALGARY'S OFFICIAL HALLOWEEN MEGA PARTY !\n★ CALGARY HALLOWEEN THRILLER 2021 ★\n@ Chakalaka Bar - Sunday October 31st (18+) \nTHE BIGGEST HALLOWEEN PARTY IN CALGARY !\nOFFICIAL MEGA PARTY // SOLD OUT YEARLY\nPRIZES FOR BEST MALE & FEMALE COSTUMES !\nEVERYONE IS WELCOMED ! \n● LIMITED $10.00 TICKETS ARE AVAILABLE\nCLUB ANTHEMS / TOP 40 / HIP HOP / HOUSE / MASHUPS\nProfessional Photographer / Videographer in Attendance\n*** PURCHASE ADVANCE TICKETS FOR GUARANTEED ENTRY ! ***\nPROOF OF VACCINATION NEEDED\n1410 17 AVE SW")
            .SetLocation("Chakalaka (1410 17 Ave SW, Calgary, AB T2T 5S8)")
            .SetStartDate(new DateTime(2021, 10, 04))
            .SetStartTime(2100)
            .SetEndTime(200)
            .SetLinks("https://www.eventbrite.ca/e/calgary-halloween-thriller-2021-sun-oct-31-official-mega-party-tickets-177438101137")
            .SetFilter(EventFilter.Special);
    }
}
