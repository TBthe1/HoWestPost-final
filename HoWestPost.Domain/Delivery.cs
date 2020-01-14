using System;
using System.Collections.Generic;
using System.Text;

namespace HoWestPost.Domain
{
    public class Delivery
    {
        public int TravelTime;
        public string PackageType;
        public int Id;
        public bool Priority;


        public override bool Equals(object obj)
        {
            return this.Id.Equals(((Delivery)obj).Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{PackageType} package - {TravelTime} min - Id: {Id}";
        }
    }
}
