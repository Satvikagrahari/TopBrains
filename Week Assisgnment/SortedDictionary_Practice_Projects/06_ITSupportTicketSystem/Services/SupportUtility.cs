using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class SupportUtility
    {
        private SortedDictionary<int, Queue<SupportTicket>> _data =
            new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket support)
        {
            if (support.SeverityLevel < 1 || support.SeverityLevel > 5)
                throw new InvalidSeverityException("Severity must be between 1 to 5");

            // Duplicate check by TicketId
            foreach (var level in _data.Values)
            {
                foreach (var ticket in level)
                {
                    if (ticket.TicketId == support.TicketId)
                        throw new Exception("Ticket with this ID already exists");
                }
            }

            if (!_data.ContainsKey(support.SeverityLevel))
                _data[support.SeverityLevel] = new Queue<SupportTicket>();

            _data[support.SeverityLevel].Enqueue(support);

            Console.WriteLine("Ticket added successfully");
        }

        public void EscalateTicket(string id)
        {
            foreach (var level in _data)
            {
                Queue<SupportTicket> tempQueue = new Queue<SupportTicket>();
                bool found = false;

                while (level.Value.Count > 0)
                {
                    var ticket = level.Value.Dequeue();

                    if (ticket.TicketId == id)
                    {
                        found = true;

                        if (ticket.SeverityLevel == 1)
                            throw new InvalidSeverityException("Already highest priority");

                        int newSeverity = ticket.SeverityLevel - 1;
                        ticket.SeverityLevel = newSeverity;

                        if (!_data.ContainsKey(newSeverity))
                            _data[newSeverity] = new Queue<SupportTicket>();

                        _data[newSeverity].Enqueue(ticket);
                    }
                    else
                    {
                        tempQueue.Enqueue(ticket);
                    }
                }

                _data[level.Key] = tempQueue;

                if (found)
                {
                    Console.WriteLine("Ticket escalated successfully");
                    return;
                }
            }

            throw new TicketNotFoundException("Ticket not found");
        }

        public void DisplayTicket()
        {
            if (_data.Count == 0)
            {
                Console.WriteLine("No tickets available");
                return;
            }

            foreach (var level in _data)
            {
                foreach (var ticket in level.Value)
                {
                    Console.WriteLine(
                        $"{{ details: ticketid = {ticket.TicketId} issue discription = {ticket.IssueDiscription} severity level = {ticket.SeverityLevel} }}"
                    );
                }
            }
        }
    }
}
