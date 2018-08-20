using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using Modelo;

namespace Taller2ProyIntegrador
{
    public partial class Form1 : Form
    {
        private GMap.NET.WindowsForms.GMapOverlay markers;

        public ResearchManager Manager { get; set; }

        private GMap.NET.WindowsForms.GMapControl map;
        public Form1()
        {
            InitializeComponent();
            markers = new GMap.NET.WindowsForms.GMapOverlay("markers");

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
            
            map.Overlays.Add(markers);

    

        }
        public void searchGroupByCode()
        {
            String code = mapOptionsControl1.TxtCode;
            String[] attributes = { code, null, null, null, null, null, null };
            bool[] toCompare = { true, false, false, false, false, false, false };
            List< ResearchGroup> found = Manager.GetGroups(attributes, toCompare);
            if (found.Count == 0)
            {
                MessageBox.Show("No group found with that code");
            }
            else
            {
            ResearchGroup r=found.First();
            mapOptionsControl1.Name = r.GroupName;
            mapOptionsControl1.TxtCode = r.GroupCode;
            mapOptionsControl1.TxtDane = r.DaneCode;
            mapOptionsControl1.TxtDate = r.DateFounded.ToString();
            mapOptionsControl1.TxtCategory = r.Category;
            mapOptionsControl1.TxtGeneral = r.GeneralResearchArea;
            mapOptionsControl1.TxtSpecific = r.SpecificResearchArea;
            double[] coor = r.getLatLng();
                map.Position = new GMap.NET.PointLatLng(coor[0], coor[1]);
                map.Zoom = 22;
            
                

            }
        }
        public void loadMarkers()
        {
            List<ResearchGroup> researchGroups = Manager.getAllResearchGroup();
            if (researchGroups != null)
            {
                foreach (var g in researchGroups)
                {
                    double[] coordinates = g.getLatLng();
                    GMap.NET.WindowsForms.GMapMarker marker =
        new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
            new GMap.NET.PointLatLng(coordinates[0], coordinates[1]),
            GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
                    marker.ToolTipText = "Nombre:\n" + g.GroupName+"\nCode:\n"+g.GroupCode;
                    //MessageBox.Show(g.GroupCode);
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                    markers.Markers.Add(marker);
                }
                map.Refresh();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Manager = new ResearchManager();
            loadMarkers();
           
        }

        private void UpdateGroup()
        {
            string codToUpdate = updateNewControl1.GetGroupCode();
            string[] information = new string[9];
            information[0] = updateNewControl1.GetFoundationDate().ToString();
            information[1] = updateNewControl1.GetGroupName();
            information[2] = updateNewControl1.GetDaneCode();
            information[3] = updateNewControl1.GetGeneralResearchArea();
            information[4] = updateNewControl1.GetSpecificResearchArea();
            information[5] = updateNewControl1.GetCategory();
            information[6] = updateNewControl1.GetCity();
            information[7] = updateNewControl1.GetState();
            information[8] = updateNewControl1.GetRegion();

            bool[] selected = updateNewControl1.GetSelectedItems();

            bool updated = Manager.UpdateGroup(codToUpdate, information, selected);
            if (updated)
            {
                MessageBox.Show("Se ha actualizado el grupo con el código indicado", "Actualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Error durante la actualizacion. Asegurese que la ciudad y" +
                    "el estado estén bien, el grupo del codigo exista y no tenga campos vacíos" +
                    "seleccionados", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void newGroup()
        {
            
            string grCode = updateNewControl1.GetGroupCode();
            DateTime foundation = updateNewControl1.GetFoundationDate();
            string grName = updateNewControl1.GetGroupName();
            string daneCode = updateNewControl1.GetDaneCode();
            string gralArea = updateNewControl1.GetGeneralResearchArea();
            string spcificArea = updateNewControl1.GetSpecificResearchArea();
            string category = updateNewControl1.GetCategory();
            string city = updateNewControl1.GetCity();
            string state = updateNewControl1.GetState();
            string region = updateNewControl1.GetRegion();

            GMapControl gmap = new GMapControl();
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords(updateNewControl1.GetCity() + ", " + updateNewControl1.GetState());

            double lat = gmap.Position.Lat;
            double lng = gmap.Position.Lng;

            bool added = Manager.RegisterResearchGroup(grCode, foundation, grName, daneCode, gralArea, spcificArea, category,
                city, state, region, lat, lng);

            if (added)
            {
                markers.Clear();
                loadMarkers();

                MessageBox.Show("Se ha agregado correctamente el grupo de investigación", "Agregado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Error al agregar el grupo. Asegurese que la ciudad y" +
                    "el estado estén bien, además de tener todos los campos llenos.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mapOptionsControl1_Load(object sender, EventArgs e)
        {
            mapOptionsControl1.Principal = this;
        }
    }
}
