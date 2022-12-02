using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Observer
{
    public class TicketChange
    {
        public int Amount { get; private set; }
        public int ArtistId { get; private set; }

        public TicketChange(int artistId, int amount)
        {
            Amount = amount;
            ArtistId = artistId;
        }

        
    }

    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observer = new();

        public void AddObserver(ITicketChangeListener observer)
        {
            _observer.Add(observer);
        }

        public void RemoveObserver(ITicketChangeListener observer)
        {
            _observer.Remove(observer);
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach(var observer in _observer)
            {
                observer.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }
    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId,int amount)
        {
            Console.WriteLine($"{nameof(OrderService)} is changing its state");

            Console.WriteLine($"{nameof(OrderService)} is notifying observers");
            Notify(new TicketChange(artistId, amount));
        }
    }

    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }

    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }
}
