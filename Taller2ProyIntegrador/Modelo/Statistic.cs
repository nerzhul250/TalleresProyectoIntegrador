using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modelo
{
    public class Statistic
    {

        public const string ARTICLESROUTE = "../../../docs/articles.csv";

        public const int YEAR_FOUNDED = 0;
        public const int GEN_RES_AREA = 1;
        public const int SPCRES_AREA = 2;
        public const int CATEGORY = 3;
        public const int CITY_NAME = 4;
        public const int STATE_NAME = 5;
        public const int REGION_NAME = 6;

        private Dictionary<String, List<ResearchGroup>>[] attributeCounter;
        private int[] articles;

        public Dictionary<string, List<ResearchGroup>>[] AttributeCounter { get => attributeCounter; set => attributeCounter = value; }

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

        //<pre>:A and B are well defined(0<=A,B<=6)
        public double ProbabilityOfAttAOccurringInB (int A, int B, String valA, String valB)
        {
            double cases = 0;
            switch (A)
            {
                case YEAR_FOUNDED:
                    cases=attributeCounter[B][valB].Where(x => x.DateFounded.Year.Equals(valA)).ToList().Count;
                    break;
                case GEN_RES_AREA:
                    cases = attributeCounter[B][valB].Where(x => x.GeneralResearchArea.Equals(valA)).ToList().Count;
                    break;
                case SPCRES_AREA:
                    cases = attributeCounter[B][valB].Where(x => x.SpecificResearchArea.Equals(valA)).ToList().Count;
                    break;
                case CATEGORY:
                    cases = attributeCounter[B][valB].Where(x => x.Category.Equals(valA)).ToList().Count;
                    break;
                case CITY_NAME:
                    cases = attributeCounter[B][valB].Where(x => x.Location.CityName.Equals(valA)).ToList().Count;
                    break;
                case STATE_NAME:
                    cases = attributeCounter[B][valB].Where(x => x.Location.StateName.Equals(valA)).ToList().Count;
                    break;
                case REGION_NAME:
                    cases = attributeCounter[B][valB].Where(x => x.Location.RegionName.Equals(valA)).ToList().Count;
                    break;
                default:
                    cases = 0;
                    break;
            }
            return  cases/attributeCounter[B][valB].Count;
        }

        //<pre>:C is well defined(0<=C<=6)
        public int CountGroupsHavingAInC (String A, int C)
        {
            if (!attributeCounter[C].ContainsKey(A))
            {
                return 0;
            }
            else {
                return attributeCounter[C][A].Count;
            }
        }

        public void LoadArticles()
        {
            articles = new int[100];
            var fileStream = File.OpenRead(ARTICLESROUTE);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8, true);
            string line = streamReader.ReadLine();
            while ((line = streamReader.ReadLine()) != null && !line.Equals(""))
            {
                string[] pre = line.Trim().Split(' ');
                pre[0] = pre[0].Split(':')[2];
                for (int i = 0; i < pre.Length; i++)
                {
                    articles[Int32.Parse(pre[i])]++;
                }
            }
        }
    }
}