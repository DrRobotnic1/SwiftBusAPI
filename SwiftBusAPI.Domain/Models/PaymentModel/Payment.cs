using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBusAPI.Domain.Models.TicketModel;

public class Payment
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }

    public Ticket Ticket { get; set; }
}
