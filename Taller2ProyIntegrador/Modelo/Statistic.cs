using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

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
        public int[] Articles { get => articles; set => articles = value; }

        public Statistic (List<ResearchGroup> groups)
        {
            attributeCounter = new Dictionary<string, List<ResearchGroup>>[7];
            attributeCounter[CATEGORY] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[YEAR_FOUNDED] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[GEN_RES_AREA] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[SPCRES_AREA] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[CITY_NAME] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[STATE_NAME] = new Dictionary<string, List<ResearchGroup>>();
            attributeCounter[REGION_NAME] = new Dictionary<string, List<ResearchGroup>>();
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

                if (attributeCounter[CATEGORY].ContainsKey(x.Category))
                {
                    List<ResearchGroup> alv = attributeCounter[CATEGORY][x.Category];
                    alv.Add(x);
                }
                else
                {
                    List<ResearchGroup> alv = new List<ResearchGroup>();
                    alv.Add(x);
                    attributeCounter[CATEGORY].Add(x.Category, alv);
                }
            }
            LoadArticles();
        }

        public Dictionary<int,int>[] MostRepeated()
        {
            Dictionary<int,int> a = new Dictionary<int,int>();
            for(int i=0; i< articles.Length;i++)
            {
                    a.Add(i, articles[i]);
            }
            List<int> val = a.Values.OrderBy(x => x).ToList();
            Dictionary<int,int>[] bestArticlesEvah = new Dictionary<int,int>[10];
            for(int i = 0; i<10; i++)
            {
                bestArticlesEvah[i] = new Dictionary<int, int>();
            }
            List<int> keys = a.Keys.ToList();
            foreach (int x in keys)
            {
                     if (a[x] == val[val.Count - 1]&& !bestArticlesEvah[0].Any())
                    bestArticlesEvah[0].Add(x, a[x]);
                else if (a[x] == val[val.Count - 2] && !bestArticlesEvah[1].Any())
                    bestArticlesEvah[1].Add(x,a[x]);
                else if (a[x] == val[val.Count - 3] && !bestArticlesEvah[2].Any())
                    bestArticlesEvah[2].Add(x, a[x]);
                else if (a[x] == val[val.Count - 4] && !bestArticlesEvah[3].Any())
                    bestArticlesEvah[3].Add(x, a[x]);
                else if (a[x] == val[val.Count - 5] && !bestArticlesEvah[4].Any())
                    bestArticlesEvah[4].Add(x, a[x]);
                else if (a[x] == val[val.Count - 6] && !bestArticlesEvah[5].Any())
                    bestArticlesEvah[5].Add(x, a[x]);
                else if (a[x] == val[val.Count - 7] && !bestArticlesEvah[6].Any())
                    bestArticlesEvah[6].Add(x, a[x]);
                else if (a[x] == val[val.Count - 8] && !bestArticlesEvah[7].Any())
                    bestArticlesEvah[7].Add(x, a[x]);
                else if (a[x] == val[val.Count - 9] && !bestArticlesEvah[8].Any())
                    bestArticlesEvah[8].Add(x, a[x]);
                else if (a[x] == val[val.Count - 10] && !bestArticlesEvah[9].Any())
                    bestArticlesEvah[9].Add(x,a[x]);
            }
            return bestArticlesEvah;
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

        public int CountAGivenB (string valA, string valB, int A, int B)
        {
            int cases = 0;
            switch (A)
            {
                case YEAR_FOUNDED:
                    cases = attributeCounter[B][valB].Where(x => x.DateFounded.Year.Equals(valA)).ToList().Count;
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
            return cases;
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
    //En proceso de mejora
    internal class Comparator : IComparer
    {

        int IComparer.Compare(object x, object y)
        {
            char[] a = x.ToString().ToCharArray();
            char[] b = y.ToString().ToCharArray();
            int retorno = 0;
            for(int i = 0; i<a.Length; i++)
            {
                if(a[i]<127 && a[i] > 31)
                {
                    if(a[i]!=b[i])
                        retorno = -1;
                }
            }
            return retorno;
        }
    }
}