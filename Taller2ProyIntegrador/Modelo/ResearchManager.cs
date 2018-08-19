using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    class ResearchManager
    {
        private Statistic statistics;
        private List<ResearchGroup> researchGroups;
        private Random randomGenerator;
        private GMap.NET map;
        public ResearchManager()
        {
            researchGroups = new List<ResearchGroup>();
            randomGenerator = new Random();
        }


    }
}
