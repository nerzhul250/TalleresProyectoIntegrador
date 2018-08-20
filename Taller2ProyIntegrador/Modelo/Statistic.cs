using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Statistic
    {
        public static int YEAR_FOUNDED = 0;
        public static int GEN_RES_AREA = 1;
        public static int SPCRES_AREA = 2;
        public static int CATEGORY = 3;
        public static int CITY_NAME = 4;
        public static int STATE_NAME = 5;
        public static int REGION_NAME = 6;

        private Dictionary<String, List<ResearchGroup>>[] attributeCounter;

        public Statistic (List<ResearchGroup> groups)
        {
            attributeCounter = new Dictionary<string, List<ResearchGroup>>[7];

            attributeCounter[CATEGORY] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_A, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_A)).ToList());
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_A1, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_A1)).ToList());
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_B, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_B)).ToList());
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_C, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_C)).ToList());
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_D, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_D)).ToList());
            attributeCounter[CATEGORY].Add(ResearchGroup.CAT_X, groups.Where(x => x.Category.Equals(ResearchGroup.CAT_X)).ToList());

            attributeCounter[YEAR_FOUNDED] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups) {
                if (attributeCounter[YEAR_FOUNDED].ContainsKey(x.DateFounded.Year.ToString()))
                {
                    List<ResearchGroup> alv = attributeCounter[YEAR_FOUNDED][x.DateFounded.Year.ToString()];
                    alv.Add(x);
                }
                else {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[YEAR_FOUNDED].Add(x.DateFounded.Year.ToString(), alv);
                }
            }
                attributeCounter[GEN_RES_AREA] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups)
            {
                if (attributeCounter[GEN_RES_AREA].ContainsKey(x.GeneralResearchArea))
                {
                    List<ResearchGroup> alv = attributeCounter[GEN_RES_AREA][x.GeneralResearchArea];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[GEN_RES_AREA].Add(x.GeneralResearchArea, alv);
                }
            }
            attributeCounter[SPCRES_AREA] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups)
            {
                if (attributeCounter[SPCRES_AREA].ContainsKey(x.SpecificResearchArea))
                {
                    List<ResearchGroup> alv = attributeCounter[SPCRES_AREA][x.SpecificResearchArea];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[SPCRES_AREA].Add(x.SpecificResearchArea, alv);
                }
            }
            attributeCounter[CITY_NAME] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups)
            {
                if (attributeCounter[CITY_NAME].ContainsKey(x.Location.CityName))
                {
                    List<ResearchGroup> alv = attributeCounter[CITY_NAME][x.Location.CityName];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[CITY_NAME].Add(x.Location.CityName, alv);
                }
            }
            attributeCounter[STATE_NAME] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups)
            {
                if (attributeCounter[STATE_NAME].ContainsKey(x.Location.StateName))
                {
                    List<ResearchGroup> alv = attributeCounter[STATE_NAME][x.Location.StateName];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[STATE_NAME].Add(x.Location.StateName, alv);
                }
            }
            attributeCounter[REGION_NAME] = new Dictionary<string, List<ResearchGroup>>();
            foreach (ResearchGroup x in groups)
            {
                if (attributeCounter[REGION_NAME].ContainsKey(x.Location.RegionName))
                {
                    List<ResearchGroup> alv = attributeCounter[REGION_NAME][x.Location.RegionName];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[REGION_NAME].Add(x.Location.RegionName, alv);
                }
            }
        }

        public double ProbabilityOfAttAOccurringInB (int A, int B, String valA, String valB)
        {

            return 0;
        }

        public int CountGroupsHavingAInC (String A, int C)
        {
            return 0;
        }

        public void LoadArticles ()
        {

        }
    }
}
