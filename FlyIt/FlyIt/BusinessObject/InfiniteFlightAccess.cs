using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyIt.DataLayer;

namespace FlyIt.BusinessObject
{
    public static class InfiniteFlightAccess
    {
        public static async Task<List<SessionInfo>> GetSessionInfo()
        {
            return await DataLayer.InfiniteFlightAccess.GetSessionInfo();
        }

        public static async Task<List<FlightInfo>> GetFlights(string serverId)
        {
            return await DataLayer.InfiniteFlightAccess.GetFlights(serverId);
        }
    }
}
