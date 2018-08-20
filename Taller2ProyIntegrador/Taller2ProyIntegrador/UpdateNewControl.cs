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
        public Form1 Principal;

        public UpdateNewControl()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void InitializeGUIRelation(Form1 principal)
        {
            Principal = principal;
        }

        private void UpdateNewControl_Load(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
        }

        public string GetGroupCode()
        {
            return txtGrCode.Text;
        }

        public DateTime GetFoundationDate()
        {
            return dateFoundation.Value;
        }

        public string GetGroupName()
        {
            return txtGrName.Text;
        }

        public string GetDaneCode()
        {
            return txtDaneCode.Text;
        }

        public string GetGeneralResearchArea()
        {
            return txtGralArea.Text;
        }

        public string GetSpecificResearchArea()
        {
            return txtSpecificArea.Text;
        }

        public string GetCategory()
        {
            return cmbCategory.SelectedItem.ToString();
        }

        public string GetCity()
        {
            return txtCity.Text;
        }

        public string GetState()
        {
            return txtState.Text;
        }

        public String GetRegion()
        {
            return txtRegion.Text;
        }

        public bool[] GetSelectedItems()
        {
            bool [] selected= new bool[7];
            selected[0] = cbFoundDate.Checked;
            selected[1] = cbGrName.Checked;
            selected[2] = cbDaneCode.Checked;
            selected[3] = cbGralArea.Checked;
            selected[4] = cbSpcficArea.Checked;
            selected[5] = cbCategory.Checked;
            selected[6] = cbCity.Checked;


            return selected;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Principal.UpdateGroup();
        }

        private void btNewGroup_Click(object sender, EventArgs e)
        {
            Principal.NewGroup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.IPrincipal = Principal;
            frm2.Show();
        }
    }
}
