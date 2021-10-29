using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class FlightController : Controller
    {
        public static List<Flights> FList = new List<Flights>();
        public static List<Crew> CList = new List<Crew>();
        static FlightController()
        {


            Crew c1 = new Crew { CrewID = 1, CrewDesig = "Doctor", CrewName = "Mounika" };

            Crew c2 = new Crew { CrewID = 2, CrewDesig = "Attender", CrewName = "Shipla" };

            Crew c3 = new Crew { CrewID = 3, CrewDesig = "Captain", CrewName = "Varma" };

            Crew c4 = new Crew { CrewID = 4, CrewDesig = "Supplier", CrewName = "Harsha" };

            Crew c7 = new Crew { CrewID = 7, CrewDesig = "Inspector", CrewName = "Maneesh" };
            Crew c8 = new Crew { CrewID = 8, CrewDesig = "Inspector", CrewName = "Viswa" };
            Crew c5 = new Crew { CrewID = 5, CrewDesig = "Inspector", CrewName = "Ram" };
            Crew c9 = new Crew { CrewID = 9, CrewDesig = "Inspector", CrewName = "Shannu" };
            Crew c10 = new Crew { CrewID = 10, CrewDesig = "Doctor", CrewName = "Priya" };
            Crew c6= new Crew { CrewID = 6, CrewDesig = "Doctor", CrewName = "Kesava" };

            FlightCrew fc = new FlightCrew();
            fc.flightID = 1;
            fc.CrewMembers = new List<Crew> { c7, c1, c3 };

            FlightCrew fc1 = new FlightCrew();
            fc1.flightID = 1;
            fc1.CrewMembers = new List<Crew> { c8, c2, c4 };

            FlightCrew fc2 = new FlightCrew();
            fc2.flightID = 1;
            fc2.CrewMembers = new List<Crew> { c9, c2, c5 };

            FlightCrew fc3 = new FlightCrew();
            fc3.flightID = 1;
            fc3.CrewMembers = new List<Crew> { c10, c1, c6 };





            FList.Add(new Flights { flightID = 101, flightName = "Indigo", flightArrival = new DateTime(2012, 12, 12), flightDeparture = new DateTime(2012, 12,12), Passenger = 40, CaptainID = 1,CrewDetails=fc.CrewMembers});

            FList.Add(new Flights { flightID = 102, flightName = "Jet", flightArrival = new DateTime(2012, 11, 11), flightDeparture = new DateTime(2012,11,11), Passenger = 21, CaptainID = 2, CrewDetails = fc.CrewMembers });

            FList.Add(new Flights { flightID = 103, flightName = "AirIndia", flightArrival = new DateTime(2012, 09, 26), flightDeparture = new DateTime(2012, 09, 26), Passenger = 20, CaptainID = 3, CrewDetails = fc.CrewMembers });

            FList.Add(new Flights { flightID = 101, flightName = "SpiceJet", flightArrival = new DateTime(2012, 08, 28), flightDeparture = new DateTime(2012, 08,28), Passenger = 55, CaptainID = 4, CrewDetails = fc.CrewMembers });







        }
        // GET: Flight
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListFlights()
        {

            return View(FList);
        }

        public ActionResult Details(int ID)
        {
            var FlightDetails = FList.Find(fl => fl.flightID == ID);
            ViewBag.CrewDetails = FlightDetails.CrewDetails;
            return View(FlightDetails);
        }
        public ActionResult AddFlight()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddFlight(Flights flight)
        {
            FList.Add(new Flights { flightID = flight.flightID, flightName = flight.flightName, flightArrival = flight.flightArrival, flightDeparture = flight.flightDeparture, CaptainID = flight.CaptainID, Passenger = flight.Passenger });

                return View();
        }
        public ActionResult UpdateFlight(int ID)
        {
           var FlightToUpdate=FList.Find(f => f.flightID == ID);
            

            return View(FlightToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateFlight(int ID,Flights f)
        {

            var FlightToUpdate = FList.Find(fl => fl.flightID == ID);
            FlightToUpdate.flightName = f.flightName;
            FlightToUpdate.flightArrival = f.flightArrival;
            FlightToUpdate.flightDeparture = f.flightDeparture;
            FlightToUpdate.Passenger = f.Passenger;
            FlightToUpdate.CaptainID = f.CaptainID;


            return View("ListFlights");
        }
        public ActionResult DeleteFlight(int ID)
        {
            var DelF = FList.Find(fl => fl.flightID == ID);
          
            return View(DelF);
        }
        [HttpPost]
        public ActionResult DeleteFlight(int ID,Flights f)

        {

            var Delf = FList.Find(fl => fl.flightID == ID);
            FList.Remove(Delf);
            return View("ListFlights");
        }




    }
}