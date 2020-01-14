using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoWestPost.Domain
{
    public class MockingDeliveryService : IDeliveryService
    {
        private static int nextIndex = 1;

        public HashSet<Delivery> StandardDeliverySet { get; set; } = new HashSet<Delivery>();

        public HashSet<Delivery> PrioritizedDeliverySet { get; set; } = new HashSet<Delivery>();

        public HashSet<Delivery> CombinedDeliverySet { get; set; } = new HashSet<Delivery>();

        // TODO implement Dictionaries to allow storing <ID, Delivery>

        public event DeliveryAddedDelegate OnDeliveryAdded;

        public void AddDelivery(Delivery delivery)
        {
            delivery.Id = nextIndex++;

            if (delivery.Priority == true)
            {
                PrioritizedDeliverySet.Add(delivery);
                CombinedDeliverySet.UnionWith(PrioritizedDeliverySet);
            } else
            {
                StandardDeliverySet.Add(delivery);
                CombinedDeliverySet.UnionWith(StandardDeliverySet);
            }

            OnDeliveryAdded?.Invoke(this, new DeliveryEventArgs() { NewDelivery = delivery });
        }

        public void DeleteDelivery(Delivery order)
        {
            CombinedDeliverySet.Remove(order);
        }

        public Delivery GetById(int id)
        {
            foreach (var order in CombinedDeliverySet)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }
    }
}
