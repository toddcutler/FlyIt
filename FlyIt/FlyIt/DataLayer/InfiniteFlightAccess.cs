using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyIt.DataLayer
{
    public static class InfiniteFlightAccess
    {
        public static async Task<List<SessionInfo>> GetSessionInfo()
        {
            List<SessionInfo> data = new List<SessionInfo>();
            try 
            {
                data = await Dbase.GetAPiData<List<SessionInfo>>(Globals.sessionsURL, "");
            }
            catch(Exception ex)
            {
            }

            return data;
        }

        public static async Task<List<FlightInfo>> GetFlights(string serverId)
        {
            List<FlightInfo> data = new List<FlightInfo>();
            try
            {

                string param = string.Format(@"sessionid={0}&t={1}", serverId, DateTime.Now.Ticks);
                data = await Dbase.GetAPiData<List<FlightInfo>>(Globals.flightsURL, param);
            }
            catch (Exception ex)
            {
            }

            return data;
        }
    }
}
