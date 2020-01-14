using System;
using System.Collections.Generic;
using System.Text;

namespace HoWestPost.Domain
{
    public class DeliveryService : IDeliveryService
    {
        public HashSet<Delivery> StandardDeliverySet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HashSet<Delivery> PrioritizedDeliverySet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Delivery AddDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        //TO DO
        //make it possible to remove deliveries
        public void DeleteDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetAllNormal()
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetAllPrioritized()
        {
            throw new NotImplementedException();
        }

        public Delivery GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IDeliveryService.AddDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}
