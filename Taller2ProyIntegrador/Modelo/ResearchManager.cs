using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    class ResearchManager
    {
        public const string SERIALISABLE_PATH = "../../../docs/ResearchGroups";

        private Statistic statistics;
        private ListSerialisable<ResearchGroup> researchGroups;
        private Random randomGenerator;

        public ResearchManager()
        {
            researchGroups = new ListSerialisable<ResearchGroup>();
            randomGenerator = new Random();

        }

        public bool RegisterResearchGroup (string grCode, string Date, string grName, string daneCode, string genResAre, string spResAre,
            string categ, string cn, string sn, string rn)
        {
            bool retorno = false;
            
            if (grCode != null && !grCode.Equals("") && Date != null && !Date.Equals("") && grName != null && !grName.Equals("") && 
                daneCode != null && !daneCode.Equals("") && genResAre != null && !spResAre.Equals("") && categ != null && !categ.Equals("")
                && cn != null && !cn.Equals("") && sn != null && !sn.Equals("") && rn != null && !rn.Equals(""))
            {
                try
                {
                    ResearchGroup gr = new ResearchGroup(grCode, Convert.ToDateTime(Date), grName, daneCode, genResAre, spResAre, categ, randomGenerator);
                    gr.inicializateLocation(cn, rn, sn);
                    researchGroups.Add(gr);
                    retorno = true;

                } finally
                {
                    
                }
            }

            
            return retorno;
        }




    }
}
