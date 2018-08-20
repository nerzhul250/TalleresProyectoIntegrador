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
            //BuildGen_Res_AreaChart();
            //BuildSpc_Res_AreaChart();
            //BuildCategoryChart();
            //BuildCity_NameChart();
            //BuildState_NameChart();
            //BuildRegion_NameChart();
        }

        private void BuildRegion_NameChart()
        {
            throw new NotImplementedException();
        }

        private void BuildState_NameChart()
        {
            throw new NotImplementedException();
        }

        private void BuildCity_NameChart()
        {
            throw new NotImplementedException();
        }

        private void BuildCategoryChart()
        {
            throw new NotImplementedException();
        }

        private void BuildSpc_Res_AreaChart()
        {
            throw new NotImplementedException();
        }

        private void BuildGen_Res_AreaChart()
        {
            throw new NotImplementedException();
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
            string inte = A1 + "-" + A2;
            int co = 0;
            for (int j = A1; j <= max; j++)
            {
                co += stt.CountGroupsHavingAInC("" + j, Statistic.YEAR_FOUNDED);
            }
            chart1.Series["Series1"].Points.AddXY(inte, co);
            chart1.ChartAreas[0].AxisX.Title = "Años";
            chart1.ChartAreas[0].AxisY.Title = "#Grupos de investigacion";
        }
    }
}
