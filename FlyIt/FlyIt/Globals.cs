
using System.Collections.Generic;
namespace FlyIt
{
    public static class Globals
    {
        public static SessionInfo SelectedSession = null;

        public static string sessionsURL = "http://infinite-flight-public-api.cloudapp.net/v1/GetSessionsInfo.aspx";
        public static string flightsURL = "http://infinite-flight-public-api.cloudapp.net/v1/flights.aspx";
        public static string flightDetailsURL = "http://liveflightapp.com/api/flightInfo";
        public static string atcFacilitiesURL = "http://liveflightapp.com/api/atc";
        public static string userDetailsURL = "http://liveflightapp.com/api/user";
        public static string aircraftDetailsURL = "http://liveflightapp.com/api/aircraft";

        public static List<View> ViewList = new List<View>() 
            {
                new View() {ViewName = "Ground", Radius = 10, Zoom = 6, CanZoom = false},
                new View() {ViewName = "Tower", Radius = 25, Zoom = 10, CanZoom = false},
                new View() {ViewName = "Approach/Departure", Radius = 70, Zoom = 15, CanZoom = false},
                new View() {ViewName = "Center", Radius = 150, Zoom = 20, CanZoom = true}
            };
    }
}
