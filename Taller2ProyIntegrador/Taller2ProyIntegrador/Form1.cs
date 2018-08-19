using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2ProyIntegrador
{
    public partial class Form1 : Form
    {
        private GMap.NET.WindowsForms.GMapControl map;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void mapControl1_Load(object sender, EventArgs e)
        {
            map = mapControl1.getMap();
            map.ShowCenter = false;
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.SetPositionByKeywords("Paris, France");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
