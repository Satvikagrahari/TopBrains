using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class SupportUtility
    {
        private Dictionary<int,Queue<SupportTicket>> _data = new Dictionary<int,Queue<SupportTicket>>();

        public void AddTicket(SupportTicket support)
        {
            // TODO: Validate support
            // TODO: Handle duplicate entries
            // TODO: Add support to SortedDictionary
            if(support.SeverityLevel<1 || support.SeverityLevel > 5)
            {
                throw new InvalidSeverityException("Severity level shoould be between 1 to 5");
            }
            if (_data[support.SeverityLevel].Contains(support))
            {
                System.Console.WriteLine("Ticket with this ticketId already exsist");
            }
            else
            {
                if (_data.ContainsKey(support.SeverityLevel))
                {
                    _data[support.SeverityLevel].Enqueue(support);
                }
                else
                {
                    _data[support.SeverityLevel] = new Queue<SupportTicket>{support};
                }
            }
            System.Console.WriteLine("ticket added successfully");
        }

        public void EscalateTicket(string TicketId)
        {
            // TODO: Update support logic
           

        }

        public void Removesupport(int key)
        {
            // TODO: Remove support logic
        }

        public IEnumerable<SupportTicket> GetAll()
        {
            // TODO: Return sorted entities
            return new List<SupportTicket>();
        }
    }
}
