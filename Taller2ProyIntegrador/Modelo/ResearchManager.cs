using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    class ResearchManager
    {
        public const string SERIALISABLE_PATH = "../../../docs/ResearchGroups";
        public const string TXT_PATH = "../../../docs/txtInvestigacion.txt";

        private Statistic statistics;
        private ListSerialisable<ResearchGroup> researchGroups;
        private Random randomGenerator;

        public ResearchManager()
        {
            researchGroups = new ListSerialisable<ResearchGroup>();
            randomGenerator = new Random();
            LoadResearchGroup();

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

        public bool LoadResearchGroup()
        {
            bool retorno = false;

            BinaryFormatter formateador = new BinaryFormatter();

            Stream str = null;
            try
            {
                str = new FileStream(SERIALISABLE_PATH, FileMode.Open, FileAccess.Read, FileShare.None);
                researchGroups = (ListSerialisable<ResearchGroup>)formateador.Deserialize(str);
                retorno = true;
            } catch (FileNotFoundException e)
            {
                retorno = true;
                var fileStream = File.OpenRead(TXT_PATH);
                var streamReader = new StreamReader(fileStream, Encoding.UTF8, true);
                string line = streamReader.ReadLine();
                while ((line = streamReader.ReadLine())!= null && !line.Equals("") && retorno)
                {
                    string[] cityData = line.Split('\t');
                    string grCode = cityData[2];
                    string Date = cityData[4];
                    string grName = cityData[3];
                    string daneCode = cityData[9];
                    string genResAre = cityData[12];
                    string spResArea = cityData[11];
                    string categ = cityData[13];
                    string cn = cityData[5];
                    string sn = cityData[6];
                    string rn = cityData[8];

                    retorno = RegisterResearchGroup(grCode, Date, grName, daneCode, genResAre, spResArea, categ, cn, sn, rn);
                }

                if (retorno)
                {
                    str = new FileStream(SERIALISABLE_PATH, FileMode.Create, FileAccess.Read, FileShare.None);
                    formateador.Serialize(str, researchGroups);
                }
                fileStream.Close();
                streamReader.Close();
            }
            str.Close();

            return retorno;
        }

        public List<ResearchGroup> GetGroups(string [] atr, bool [] toCompare)
        {
            List<ResearchGroup> groups = new List<ResearchGroup>();
            foreach (ResearchGroup gr in researchGroups)
            {
                if (gr.checkParameters(atr, toCompare))
                {
                    groups.Add(gr);
                }
            }


            return groups;
        }




    }
}
