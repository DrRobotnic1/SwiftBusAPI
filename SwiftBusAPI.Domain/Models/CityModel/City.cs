using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.RouteModel;

namespace SwiftBusAPI.Domain.Models.CityModel
{
     public class City
    {
        public Guid Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string? BusStopLocation { get; set; }
        public string? Province { get; set; }

        public ICollection<Route> DepartureRoutes { get; set; }
        public ICollection<Route> ArrivalRoutes { get; set; }
    }
}
