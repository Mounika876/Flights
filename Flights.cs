using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApp.Models
{
    public class Flights
    {
        public int flightID { get; set; }
        
        public string flightName { get; set; }

        public DateTime flightArrival { get; set; }

        public DateTime flightDeparture { get; set; }

        public int Passenger { get; set; }

        public int CaptainID { get; set; }
        public List<Crew> CrewDetails{ get; set; }


    }
}