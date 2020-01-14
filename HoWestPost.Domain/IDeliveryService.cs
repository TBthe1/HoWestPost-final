using System;
using System.Collections.Generic;
using System.Text;
using HoWestPost.Domain;

namespace HoWestPost.Domain
{
    public delegate void DeliveryAddedDelegate(object sender, DeliveryEventArgs e);
    public interface IDeliveryService
    {
        void AddDelivery(Delivery delivery);
        void DeleteDelivery(Delivery delivery);
        HashSet<Delivery> StandardDeliverySet { get; set; }
        HashSet<Delivery> PrioritizedDeliverySet { get; set; }
        Delivery GetById(int id);
    }
}
