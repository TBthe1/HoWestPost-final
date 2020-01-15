using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HoWestPost.Domain
{
    public static class DeliveryService
    {
        #region Fields
        private static int nextIndex = 1;

        private static List<Delivery> _deliveries = new List<Delivery>();
        public static List<Delivery> Deliveries
        {
            get => _deliveries;
            set => _deliveries = value;
        }
        #endregion

        #region Public Methods
        public static void AddDelivery(Delivery delivery)
        {
            delivery.Id = nextIndex++;

            _deliveries.Add(delivery);

            _deliveries.Sort();

            DeliveryProcessor.Start(ref _deliveries);
        }

        /// <summary>
        /// Upgrades standard deliveries if in state of starvation
        /// </summary>
        /// <param name="elapsedTime">Current Elapsed time</param>
        public static void EvaluatePriorities(TimeSpan elapsedTime)
        {
            foreach (Delivery delivery in _deliveries)
            {
                if (delivery.IsWaitingTooLong(elapsedTime))
                {
                    delivery.Priority = true;
                }
            }
        }

        public static Delivery GetById(int id)
        {
            foreach (Delivery delivery in Deliveries)
            {
                if (delivery.Id == id)
                {
                    return delivery;
                }
            }
            return null;
        }
        #endregion
    }
}
