using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Serializable]
    class ResearchGroup
    {
        public const String CAT_A1="A1";
        public const String CAT_A = "A";
        public const String CAT_B = "B";
        public const String CAT_C = "C";
        public const String CAT_D = "D";
        public const String CAT_X = "Reconocido";

        private String groupCode;
        private DateTime dateFounded;
        private String groupName;
        private String daneCode;
        private String generalResearchArea;
        private String specificResearchArea;
        private String category;
        private Location location;
        private Random randomGenerator;


 
        public string GroupCode { get => groupCode; set => groupCode = value; }
        public DateTime DateFounded { get => dateFounded; set => dateFounded = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string DaneCode { get => daneCode; set => daneCode = value; }
        public string GeneralResearchArea { get => generalResearchArea; set => generalResearchArea = value; }
        public string SpecificResearchArea { get => specificResearchArea; set => specificResearchArea = value; }
        internal Location Location { get => location; set => location = value; }
        // can throws Exception
        public string Category {
            get { return category; }
                set {if(value.Equals(CAT_A1)||value.Equals(CAT_A)
                    ||value.Equals(CAT_B)||value.Equals(CAT_C)
                    ||value.Equals(CAT_D)
                    || value.Equals(CAT_X))
                {
                    category = value;
                }
                else
                {
                    throw new Exception("Invalid Category");
                }
                    
                        }  }



        // can throws Exception
        public ResearchGroup(String groupCode,DateTime dateFounded,String groupName,String daneCode,String generalResearchArea,String specificResearchArea,String category, Random randGenerator)
        {
            GroupCode = groupCode;
            DateFounded = dateFounded;
            GroupCode = groupCode;
            DaneCode = daneCode;
            GeneralResearchArea = generalResearchArea;
            SpecificResearchArea = specificResearchArea;
            Category = category;
            randomGenerator = randGenerator;
        }

        private double[] generateRandomCoordinates(Random r, double lat, double lng)
        {
            String l = lat.ToString();
            String lo = lng.ToString();
            l = l.Substring(l.Length - 4);
            lo = lo.Substring(lo.Length - 4);

            int nlat = Int32.Parse(l);
            int nlo = Int32.Parse(lo);
            double a = (Double)r.Next(nlat, 1000 + nlat) / 100000.0;
            double b = (Double)r.Next(nlo, 1000 + nlo) / 100000.0;


            double dlat = Math.Abs(lat) - (nlat / 100000.0) + a;
            double dlo = Math.Abs(lng) - (nlo / 100000.0) + b;
            if (lat < 0)
            {
                dlat = dlat * (-1.0);
            }
            if (lng < 0)
            {
                dlo = dlo * (-1.0);
            }
            double[] retorno = new double[2];
            retorno[0] = dlat;
            retorno[1] = dlo;
            return retorno;
        }

        public void inicializateLocation(String city, String region, String state, double cityLat, double cityLng)
        {
            double[] coordinates = generateRandomCoordinates(randomGenerator, cityLat, cityLng);
            location = new Location(city, state, region, coordinates[0], coordinates[1]);
        }

        public void inicializateLocation(double groupLat,double groupLng,String city, String region, String state)
        {
            location = location = new Location(city, state, region, groupLat, groupLng);
        }
        public void inicializateLocation(String city, String region, String state)
        {
            location = location = new Location(city, state, region, 0, 0);
        }
        //can throws exception
        public void generateAndSetRandomCoordinates(double cityLat, double cityLng)
        {
            double[] coordinates = generateRandomCoordinates(randomGenerator, cityLat, cityLng);
            try
            {
                location.Latitude = coordinates[0];
                location.Longitude = coordinates[1];
            }catch(Exception e)
            {
                throw new Exception("No location exists");
            }
        }

        /**
         * Pos[0]= groupCode
         * [1]= dateFounded;
         * [2]= groupName
         * [3] daneCode
         * [4] generalResearchArea;
         * [5] specificResearchArea
         * [6] category
         * 
         * */
        public bool checkParameters(String[] attributes, bool[] toCompare)
        {
            bool toReturn = true;
            if (toCompare[0])
            {
               toReturn &= this.GroupCode.Equals(attributes[0]);
            }
            if (toCompare[1])
            {
                toReturn &= this.DateFounded.Equals(attributes[1]);
            }
            if (toCompare[2])
            {
                toReturn &= this.GroupName.Equals(attributes[2]);
            }
            if (toCompare[3])
            {
                toReturn &= this.DateFounded.Equals(attributes[3]);
            }
            if (toCompare[4])
            {
                toReturn &= this.GeneralResearchArea.Equals(attributes[4]);
            }
            if (toCompare[5])
            {
                toReturn &= this.SpecificResearchArea.Equals(attributes[5]);
            }
            if (toCompare[6])
            {
                toReturn &= this.Category.Equals(attributes[6]);
            }
            return toReturn;
        }
    }
}
