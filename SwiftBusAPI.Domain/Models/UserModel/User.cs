﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.TicketModel;

namespace SwiftBusAPI.Domain.Models.UserModel
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
