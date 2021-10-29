using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApp.Models
{
    public class FlightCrew
    {
        public int flightID { get; set; }

        public List<Crew> CrewMembers { get; set; }
    }

}