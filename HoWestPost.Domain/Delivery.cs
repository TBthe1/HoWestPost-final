using System;
using System.Collections.Generic;
using System.Text;

namespace HoWestPost.Domain
{
    public class Delivery : IComparable
    {
        public double TravelTime;
        public PackageType PackageType;
        public PackageType PriorType;
        public bool Priority;
        public int Id;

        public override bool Equals(object obj)
        {
            return this.Id.Equals(((Delivery)obj).Id);
        }

        //--> (waiting time + estimated run time) / estimated run time = 1 + (waiting time / estimated run time)
        public bool IsWaitingTooLong(TimeSpan ts)
        {
            double waitingTime = ts.TotalMinutes;

            return ((waitingTime + TravelTime) / TravelTime == 1 + waitingTime / TravelTime) ? true : false;
        }


        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            string isPriorOrNot = Priority ? "priority" : "no priority";

            //StringBuilder prior = new StringBuilder(PriorType.ToString());

            StringBuilder type = new StringBuilder(PackageType.ToString());
            if (9 - type.Length != 0)
            {
                type.Append("\t");
            }

            return $"{type.ToString()}  {isPriorOrNot.ToString()} - {TravelTime} min - Id: {Id}";
        }

        public int CompareTo(object obj)
        {
            Delivery delivery = obj as Delivery;

            return delivery.Priority.CompareTo(Priority);
        }
    }
}