namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {

        }
    }
}
