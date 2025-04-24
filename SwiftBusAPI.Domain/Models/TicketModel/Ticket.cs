using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.UserModel;
using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.RouteModel;

namespace SwiftBusAPI.Domain.Models.TicketModel
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BusId { get; set; }
        public Guid RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal BasePrice { get; set; }
        

        public User User { get; set; }
        public Bus Bus { get; set; }
        public Route Route { get; set; }
        public Payment Payment { get; set; }
    }
}
