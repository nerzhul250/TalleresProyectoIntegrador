using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using GMap;
using GMap.NET.WindowsForms;

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
            statistics = new Statistic();
            randomGenerator = new Random();
            LoadResearchGroup();

        }

        public bool RegisterResearchGroup (string grCode, DateTime Date, string grName, string daneCode, string genResAre, string spResAre,
            string categ, string cn, string sn, string rn)
        {
            bool retorno = false;
            
            if (grCode != null && !grCode.Equals("") && Date != null && !Date.Equals("") && grName != null && !grName.Equals("") && 
                daneCode != null && !daneCode.Equals("") && genResAre != null && !spResAre.Equals("") && categ != null && !categ.Equals("")
                && cn != null && !cn.Equals("") && sn != null && !sn.Equals("") && rn != null && !rn.Equals(""))
            {
                try
                {
                    ResearchGroup gr = new ResearchGroup(grCode, Date, grName, daneCode, genResAre, spResAre, categ, randomGenerator);
                    gr.inicializateLocation(cn, rn, sn);
                    researchGroups.Add(gr);
                    retorno = true;

                } finally
                {
                    
                }
            }

            
            return retorno;
        }


        public bool RegisterResearchGroup(string grCode, DateTime Date, string grName, string daneCode, string genResAre, string spResAre,
           string categ, string cn, string sn, string rn, double lat, double lng)
        {
            bool retorno = false;

            if (grCode != null && !grCode.Equals("") && Date != null && !Date.Equals("") && grName != null && !grName.Equals("") &&
                daneCode != null && !daneCode.Equals("") && genResAre != null && !spResAre.Equals("") && categ != null && !categ.Equals("")
                && cn != null && !cn.Equals("") && sn != null && !sn.Equals("") && rn != null && !rn.Equals(""))
            {
                try
                {
                    ResearchGroup gr = new ResearchGroup(grCode, Date, grName, daneCode, genResAre, spResAre, categ, randomGenerator);
                    gr.inicializateLocation(cn, rn, sn, lat, lng);
                    researchGroups.Add(gr);
                    retorno = true;

                }
                finally
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

                    GMapControl gmap = new GMapControl();
                    gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                    gmap.SetPositionByKeywords(cn + ", " + sn);

                    double lat = gmap.Position.Lat;
                    double lng = gmap.Position.Lng;

                    retorno = RegisterResearchGroup(grCode, Convert.ToDateTime(Date), grName, daneCode, genResAre, spResArea, categ, cn, sn, rn, lat, lng);
                }

                if (retorno)
                {
                    str = new FileStream(SERIALISABLE_PATH, FileMode.Create, FileAccess.Write, FileShare.None);
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
        public bool RefreshGroup(String GroupCode, String[] atrToChange, bool[] toCompare)
        {
            bool refreshed = true;
            string[] toSearch = new string[7];
            bool[] toLook = new bool[7];

            toSearch[0] = GroupCode;
            toCompare[0] = true;

            List<ResearchGroup> group = GetGroups(toSearch, toLook);
            ResearchGroup toUpdate = group.ElementAt(0);

            if (toCompare[0])
            {
                if (atrToChange[0] != null && !atrToChange[0].Equals(""))
                {
                    toUpdate.GroupCode = atrToChange[0];
                } else
                {
                    refreshed = false;
                }
            } 
            if (refreshed && toCompare[1])
            {
                try
                {
                    DateTime date = Convert.ToDateTime(toCompare[1]);
                    toUpdate.DateFounded = date;

                } catch
                {
                    refreshed = false;
                }
            }
            if (refreshed && toCompare[2])
            {
                if (atrToChange[2] != null && !atrToChange[2].Equals(""))
                {
                    toUpdate.GroupName = atrToChange[2];
                }
                else
                {
                    refreshed = false;
                }
            }
            if (refreshed && toCompare[3])
            {
                if (atrToChange[3] != null && !atrToChange[3].Equals(""))
                {
                    toUpdate.DaneCode = atrToChange[3];
                }
                else
                {
                    refreshed = false;
                }
            }
            if (refreshed && toCompare[4])
            {
                if (atrToChange[4] != null && !atrToChange[4].Equals(""))
                {
                    toUpdate.GeneralResearchArea = atrToChange[4];
                }
                else
                {
                    refreshed = false;
                }
            }
            if (refreshed && toCompare[5])
            {
                if (atrToChange[5] != null && !atrToChange[5].Equals(""))
                {
                    toUpdate.SpecificResearchArea = atrToChange[5];
                }
                else
                {
                    refreshed = false;
                }
            }
            if (refreshed && toCompare[6])
            {
                if (atrToChange[6] != null && !atrToChange[6].Equals(""))
                {
                    toUpdate.Category = atrToChange[6];
                }
                else
                {
                    refreshed = false;
                }
            }




            return refreshed;
        }

        public void SaveGroups()
        {
            BinaryFormatter formateador = new BinaryFormatter();

            Stream str = new FileStream(SERIALISABLE_PATH, FileMode.Create, FileAccess.Write, FileShare.None);
            formateador.Serialize(str, researchGroups);

            str.Close();
        }



    }
}
