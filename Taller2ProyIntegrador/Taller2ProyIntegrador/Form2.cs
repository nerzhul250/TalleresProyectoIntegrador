using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Microsoft.VisualBasic;

namespace Taller2ProyIntegrador
{
    public partial class Form2 : Form
    {
        public Form1 IPrincipal { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BuildYearFoundedChart();
            BuildGen_Res_AreaChart();
            
            BuildCategoryChart();
            
            BuildState_NameChart();
            BuildRegion_NameChart();

            BuildList_View();
        }

        private void BuildList_View()
        {
          

        }

        private void BuildRegion_NameChart()
        {
            Statistic stt = IPrincipal.Manager.Statistics;
            List<string> regions = new List<string>(stt.AttributeCounter[Statistic.REGION_NAME].Keys);
            regions = regions.OrderBy(x => x).ToList();
            for (int i = 0; i < regions.Count; i++)
            {
                string reg = regions[i];
                int count = stt.CountGroupsHavingAInC(reg, Statistic.REGION_NAME);
                chart7.Series["Series1"].Points.AddXY(reg, count);
            }
            chart7.ChartAreas[0].AxisX.Title = "Regiones";
            chart7.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }

        private void BuildState_NameChart()
        {
            Statistic stt = IPrincipal.Manager.Statistics;
            List<string> states = new List<string>(stt.AttributeCounter[Statistic.STATE_NAME].Keys);
            states = states.OrderBy(x => x).ToList();
            for (int i = 0; i < states.Count; i++)
            {
                string reg = states[i];
                int count = stt.CountGroupsHavingAInC(reg, Statistic.STATE_NAME);
                chart6.Series["Series1"].Points.AddXY(reg, count);
            }
            chart6.ChartAreas[0].AxisX.Title = "Departamentos";
            chart6.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }

        private void BuildCity_NameChart(string entrada)
        {
            chart5.Series["Series1"].Points.Clear();
            Statistic stt = IPrincipal.Manager.Statistics;
            try
            {
                List<string> municipios = new List<string>(stt.AttributeCounter[Statistic.CITY_NAME].Keys);
                municipios = municipios.OrderBy(x => x).ToList();
                for (int i = 0; i < municipios.Count; i++)
                {
                    string muni = municipios[i];
                    int count = stt.CountAGivenB(muni, entrada, Statistic.CITY_NAME, Statistic.STATE_NAME);
                    if (count != 0)
                        chart5.Series["Series1"].Points.AddXY(muni, count);
                }
                chart5.ChartAreas[0].AxisX.Title = "Municipios del departamento de " + entrada;
                chart5.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
            }
            catch (Exception e)
            {
                MessageBox.Show("Gran Área no encontrada");
            }
        }

        private void BuildCategoryChart()
        {
            Statistic stt = IPrincipal.Manager.Statistics;
            List<string> category = new List<string>(stt.AttributeCounter[Statistic.CATEGORY].Keys);
            category = category.OrderBy(x => x).ToList();
            for (int i = 0; i < category.Count; i++)
            {
                string cat = category[i];
                int count = stt.CountGroupsHavingAInC(cat, Statistic.CATEGORY);
                chart4.Series["Series1"].Points.AddXY(cat, count);
            }
            chart4.ChartAreas[0].AxisX.Title = "Categorías";
            chart4.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }

        private void BuildSpc_Res_AreaChart(string entrada)
        {
            chart3.Series["Series1"].Points.Clear();
            Statistic stt = IPrincipal.Manager.Statistics;
            try
            {
                List<string> areas = new List<string>(stt.AttributeCounter[Statistic.SPCRES_AREA].Keys);
                areas = areas.OrderBy(x => x).ToList();
                for (int i = 0; i < areas.Count; i++)
                {
                    string area = areas[i];
                    int count = stt.CountAGivenB(area, entrada, Statistic.SPCRES_AREA, Statistic.GEN_RES_AREA);
                    if (count != 0)
                        chart3.Series["Series1"].Points.AddXY(area, count);
                }
            chart3.ChartAreas[0].AxisX.Title = "Áreas específicas de conocimiento de "+ entrada;
            chart3.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
            }
            catch (Exception e)
            {
                MessageBox.Show("Gran Área no encontrada");
            }
        }

        private void BuildGen_Res_AreaChart()
        {
            Statistic stt = IPrincipal.Manager.Statistics;
            List<string> areas = new List<string>(stt.AttributeCounter[Statistic.GEN_RES_AREA].Keys);
            areas = areas.OrderBy(x => x).ToList();
            for (int i = 0; i < areas.Count; i++)
            {
                string area = areas[i];
                int count = stt.CountGroupsHavingAInC(area, Statistic.GEN_RES_AREA);
                chart2.Series["Series1"].Points.AddXY(area, count);
            }
            chart2.ChartAreas[0].AxisX.Title = "Gran área de conocimiento";
            chart2.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }

        private void BuildYearFoundedChart() {
            Statistic stt = IPrincipal.Manager.Statistics;
            List<string> years = new List<string>(stt.AttributeCounter[Statistic.YEAR_FOUNDED].Keys);
            years = years.OrderBy(x => Int32.Parse(x)).ToList();
            int min = Int32.Parse(years[0]);
            int max = Int32.Parse(years[years.Count - 1]);
            int step = (int)((max - min) / 5.0);
            int A1 = min;
            int A2 = min + step;
            for (int i = 0; i < 4; i++)
            {
                string intervalo = A1 + "-" + (A2 - 1);
                int count = 0;
                for (int j = A1; j < A2; j++)
                {
                    count += stt.CountGroupsHavingAInC("" + j, Statistic.YEAR_FOUNDED);
                }
                chart1.Series["Series1"].Points.AddXY(intervalo, count);
                A1 += step;
                A2 += step;
            }
            string inte = A1 + "-" + max;
            int co = 0;
            for (int j = A1; j <= max; j++)
            {
                co += stt.CountGroupsHavingAInC("" + j, Statistic.YEAR_FOUNDED);
            }
            chart1.Series["Series1"].Points.AddXY(inte, co);
            chart1.ChartAreas[0].AxisX.Title = "Años";
            chart1.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            String entrada = Interaction.InputBox("Escriba la gran área para mostrar sus áreas específicas", "Áreas específicas", "Ciencias naturales");
            BuildSpc_Res_AreaChart(entrada);
        }

        private void chart5_Click(object sender, EventArgs e)
        {
            String entrada = Interaction.InputBox("Escriba el departamento al cual se le quiere ver sus municipios", "Municipios", "Cauca");
            BuildCity_NameChart(entrada);
        }
    }
}
