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
    public partial class UpdateNewControl : UserControl
    {
        public UpdateNewControl()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UpdateNewControl_Load(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
        }
    }
}
