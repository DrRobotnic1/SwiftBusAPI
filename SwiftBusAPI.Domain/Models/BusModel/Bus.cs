using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.TicketModel;


namespace SwiftBusAPI.Domain.Models.BusModel
{
    public class Bus
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int NumBuses { get; set; }
        public int StandardSpeed { get; set; }

        public Company Company { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
