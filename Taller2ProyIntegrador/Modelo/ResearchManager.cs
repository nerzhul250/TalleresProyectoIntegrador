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
        public ResearchManager()
        {
            researchGroups = new List<ResearchGroup>();
            randomGenerator = new Random();
        }


    }
}
