using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Location
    {
        private String cityName;
        private String stateName;
        private String regionName;
        private double latitude;
        private double longitude;

        public Location(String city, String state, String region, double lat, double longi)
        {
            CityName = city;
            StateName = state;
            RegionName = region;
            Latitude = lat;
            Longitude = longi;
        }
        public Location(String city, String state, String region)
        {
            CityName = city;
            StateName = state;
            RegionName = region;
        }

        public string CityName { get => cityName; set => cityName = value; }
        public string StateName { get => stateName; set => stateName = value; }
        public string RegionName { get => regionName; set => regionName = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
    }
}
