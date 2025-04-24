using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.RouteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BusModel
{
    public class BusAvailability
    {
        public Route Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Bus Bus { get; set; }
        public BusPricing Pricing { get; set; }
    }
}
