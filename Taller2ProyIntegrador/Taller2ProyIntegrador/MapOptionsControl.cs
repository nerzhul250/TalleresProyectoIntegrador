using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2ProyIntegrador
{
    public partial class MapOptionsControl : UserControl
    {
        private Form1 principal;

        public Form1 Principal { get => principal; set => principal = value; }

        public MapOptionsControl()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            principal.searchGroupByCode();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void MapOptionsControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal.FilterGroups();
        }
    }
}
