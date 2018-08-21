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
            BuildRegion_NameChart();

            BuildList_View();
        }

        private void BuildList_View()
        {
            Statistic alv = IPrincipal.Manager.Statistics;
            Dictionary<int,int>[] bests = alv.MostRepeated();
            for(int i = 0; i < 10; i++)
            {
            ListViewItem lista = new ListViewItem(i+1+ "");
                List<int> p = bests[i].Keys.ToList();
                lista.SubItems.Add(p[0]+"");
                lista.SubItems.Add(bests[i][p[0]]+"");
            listView1.Items.Add(lista);
            }
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
            chart7.ChartAreas[0].AxisX.Title = "Regions";
            chart7.ChartAreas[0].AxisY.Title = "# Research groups";
        }

        private void BuildState_NameChart(string entrada)
        {
            chart6.Series["Series1"].Points.Clear();
            Statistic stt = IPrincipal.Manager.Statistics;
            try
            {
                List<string> departments = new List<string>(stt.AttributeCounter[Statistic.STATE_NAME].Keys);
                departments = departments.OrderBy(x => x).ToList();
                for (int i = 0; i < departments.Count; i++)
                {
                    string dep = departments[i];
                    int count = stt.CountAGivenB(dep, entrada, Statistic.STATE_NAME, Statistic.REGION_NAME);
                    if (count != 0)
                        chart6.Series["Series1"].Points.AddXY(dep, count);
                }
                chart6.ChartAreas[0].AxisX.Title = "States from region of " + entrada;
                chart6.ChartAreas[0].AxisY.Title = "# Research groups";
            }
            catch (Exception e)
            {
                MessageBox.Show("Region not found");
            }
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
                chart5.ChartAreas[0].AxisX.Title = "Cities from state of " + entrada;
                chart5.ChartAreas[0].AxisY.Title = "# Research groups";
            }
            catch (Exception e)
            {
                MessageBox.Show("State not found");
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
            chart4.ChartAreas[0].AxisX.Title = "Category";
            chart4.ChartAreas[0].AxisY.Title = "# Research groups";
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
            chart3.ChartAreas[0].AxisX.Title = "Specific areas of knowledge of "+ entrada;
            chart3.ChartAreas[0].AxisY.Title = "# Research groups";
            }
            catch (Exception e)
            {
                MessageBox.Show("General area not found");
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
            chart2.ChartAreas[0].AxisX.Title = "General area of knowledge";
            chart2.ChartAreas[0].AxisY.Title = "# Research groups";
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
            chart1.ChartAreas[0].AxisX.Title = "Years";
            chart1.ChartAreas[0].AxisY.Title = "# Research groups";
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            String entrada = Interaction.InputBox("Write the General area to show its specific areas", "Specific areas", "Ciencias naturales");
            BuildSpc_Res_AreaChart(entrada);
        }

        private void chart5_Click(object sender, EventArgs e)
        {
            String entrada = Interaction.InputBox("Write the state which you want to see its cities", "Cities", "Cauca");
            BuildCity_NameChart(entrada);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistic alv = IPrincipal.Manager.Statistics;
            double result = alv.ProbabilityOfAttAOccurringInB(comboBox1.SelectedIndex, comboBox2.SelectedIndex, textBox1.Text, textBox2.Text);
            label4.Text = result * 100 + "%";
        }

        private void chart6_Click(object sender, EventArgs e)
        {
            String entrada = Interaction.InputBox("Write the region which you want to see its states", "States", "Eje Cafetero");
            BuildState_NameChart(entrada);
        }
    }
}
