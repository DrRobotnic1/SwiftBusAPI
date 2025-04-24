using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.CityModel;
using SwiftBusAPI.Domain.Models.TicketModel;


namespace SwiftBusAPI.Domain.Models.RouteModel
{
    public class Route
    {
        public Guid Id { get; set; }
        public Guid DepartureCityId { get; set; }
        public Guid ArrivalCityId { get; set; }
        public decimal DistanceKm { get; set; }
        public decimal TollCost { get; set; }

        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
