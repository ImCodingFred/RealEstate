using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class ad
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public (double lat,double longi) LatLong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Seller { get; set; }
        public int Category { get; set; }

        public ad(int id, int rooms, (double,double) latlong,
            int floors, int area,string description,
            bool freeofcharge, string imageurl,
            DateTime createdat, int sellerid, int categoryid) 
        {
            this.Id = id;
            this.Rooms = rooms;
            this.LatLong = latlong;
            this.Floors = floors;
            this.Area = area;
            this.Description = description;
            this.FreeOfCharge = freeofcharge;
            this.ImageUrl = imageurl;
            this.CreatedAt = createdat;
            this.Seller = sellerid;
            this.Category = categoryid;
        }

        public double DistanceTo(double lat, double longi) 
        {
            double distance = Math.Pow((this.LatLong.lat - lat), 2) + Math.Pow((this.LatLong.longi - longi), 2);
            distance = Math.Sqrt(distance);
            return distance;
        }
    }
}
