using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlyIt
{
    public class View
    {
        public string ViewName { get; set; }
        public int Radius { get; set; }
        public int Zoom { get; set; }
        public bool CanZoom { get; set; }
    }

    public class Airport
    {
		public string Region { get; set; }
        public string IcaoCode { get; set; }
		public string ImageName { get; set; }
		public double CenterLat { get; set; }
		public double CenterLng { get; set; }
		public double SouthWestLat { get; set; }
		public double SouthWestLng { get; set; }
		public double NorthEastLat { get; set; }
		public double NorthEastLng { get; set; }
		public double FreqGround { get; set; }
		public double FreqTower { get; set; }
		public double FreqApproach { get; set; }
		public double FreqDeparture { get; set; }
        public double FreqCenter { get; set; }
    }

    public class Fix
    {
        public double Latitude { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
    }

    public class Vor
    {
        public double Latitude { get; set; }
        public string Name { get; set; }
	    public string Type{ get; set; }
        public double Longitude { get; set; }
    }

    public class SessionInfo
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaxUsers { get; set; }
        public int Type { get; set; }
        public int UserCount { get; set; }
    }

    public class FlightInfo
    {
      public string IconClass { get; set; }
      public string FlightID { get; set; }
      public double VerticalSpeed { get; set; }
      public string DisplayName { get; set; }
      public ulong LastReportUTC { get; set; }
      public double Track { get; set; }
      public double Altitude { get; set; }
      public string UserID { get; set; }
      public double Longitude { get; set; }
      public string Livery { get; set; }
      public string Aircraft { get; set; }
      public string CallSign { get; set; }
      public double Latitude { get; set; }
      public double Speed { get; set; }
    }

    public class ATCMessage
    {
        public string Text { get; set; }
    }


    public class ATCMessageList : APIResponse
    {
        public ATCMessage[] ATCMessages { get; set; }
    }
    

    public class APIWaypoint
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }


    public class APIFlightPlan : APIResponse
    {
        public APIWaypoint[] Waypoints { get; set; }
    }


    public class APIFrequencyInfo
    {
        public string Type { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public int IntegerFrequency { get; set; }

        public Guid FrequencyID { get; set; }

        public string FacilityCode { get; set; }
    }


    public class APIFrequencyInfoList : APIResponse
    {
        public APIFrequencyInfo[] Frequencies { get; set; }
    }


    public class APIServerInfo
    {
        public string Address { get; set; }

        public int Port { get; set; }
    }


    public class IFAPIStatus : APIResponse
    {
        public string AppVersion { get; set; }

        public string ApiVersion { get; set; }

        public string LoggedInUser { get; set; }

        public int DisplayWidth { get; set; }

        public int DisplayHeight { get; set; }

        public string DeviceName { get; set; }
    }


    public class APIATCMessage : APIResponse
    {
        public bool Received { get; set; }

        public Guid EmitterID { get; set; }

        public string EmitterUserName { get; set; }

        public string EmitterCallsign { get; set; }

        public string Message { get; set; }

        public string SynthesizableMessage { get; set; }

        public Guid FrequencyID { get; set; }

        public string FrequencyName { get; set; }
    }


    public enum APIResult
    {
        OK,
        Error
    }

    public class APIResponse
    {
        public APIResult Result { get; set; }

        public string Type { get; set; }

        public APIResponse()
        {
            Type = this.GetType().ToString();
        }
    }
    

    public class FacilityList : APIResponse
    {
        public FacilityInfo[] Facilities { get; set; }
    }


    public class FacilityInfo
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public int IntegerFrequency { get; set; }

        public string AirportName { get; set; }

        public Guid ID { get; set; }

        public string Username { get; set; }

        public Guid UserID { get; set; }

        public DateTime StartTimeUTC { get; set; }
    }
    

    public class AirplaneInfo
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public float Altitude { get; set; }

        public float VerticalSpeed { get; set; }

        public double Heading { get; set; }

        public double Velocity { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string CallSign { get; set; }

        public Guid AircraftID { get; set; }

        public Guid LiveryID { get; set; }

        public string DeviceName { get; set; }

        public Guid FlightID { get; set; }

        public string AppVersion { get; set; }
    }


    public class LiveAirplaneList : APIResponse
    {
        public AirplaneInfo[] Airplanes { get; set; }
    }


    public class GetValueResponse : APIResponse
    {
        public CallParameter[] Parameters { get; set; }
    }

    public class Coordinate
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class CallParameter
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }

    public class APICall
    {
        public string Command { get; set; }

        public CallParameter[] Parameters { get; set; }
    }


    public enum GearState
    {
        Unknown,
        Down,
        Up,
        Moving,
        MovingDown,
        MovingUp
    }


    public enum SpoilersPosition
    {
        Retracted,
        Flight,
        Full
    }

    public class APIAircraftState : APIResponse
    {
        public float AltitudeAGL { get; set; }

        public float AltitudeMSL { get; set; }

        public float Bank { get; set; }

        public float CourseTrue { get; set; }

        public GearState GearState { get; set; }

        public float GForce { get; set; }

        public float GroundSpeed { get; set; }

        public float GroundSpeedKts { get; set; }

        public float HeadingMagnetic { get; set; }

        public float HeadingTrue { get; set; }

        public float IndicatedAirspeed { get; set; }

        public float IndicatedAirspeedKts { get; set; }

        public bool IsAutopilotOn { get; set; }

        public bool IsCrashed { get; set; }

        public bool IsLanded { get; set; }

        public bool IsOnGround { get; set; }

        public bool IsOverLandingWeight { get; set; }

        public bool IsOverTakeoffWeight { get; set; }

        public bool IsPushbackActive { get; set; }

        public Coordinate Location { get; set; }

        public float MachNumber { get; set; }

        public float MagneticDeviation { get; set; }

        public float Pitch { get; set; }

        public bool ReverseThrustState { get; set; }

        public float SideForce { get; set; }

        public SpoilersPosition SpoilersPosition { get; set; }

        public bool Stalling { get; set; }

        public float StallProximity { get; set; }

        public bool StallWarning { get; set; }

        public float TrueAirspeed { get; set; }

        public float Velocity { get; set; }

        public float VerticalSpeed { get; set; }

        public float Weight { get; set; }

        public float WeightPercentage { get; set; }
    }
}
