using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimioAPI;
using SimioAPI.Extensions;
using SimioAPI.Graphics;
using Simio;
using Simio.SimioEnums;

namespace MYS1_Practica3
{
    public partial class Form1 : Form
    {
        private ISimioProject APIProject;
        private string rutabase = "Practica3.spfx";
        private string rutafinal = "ModeloFinal.spfx";
        private string []warnings;
        private IModel modelo;
        private IIntelligentObjects InteligentObject;

        public Form1()
        {
            APIProject = SimioProjectFactory.LoadProject(rutabase, out warnings);
            modelo = APIProject.Models[1];
            InteligentObject = modelo.Facility.IntelligentObjects;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InteligentObject.CreateObject("Source", new FacilityLocation(0, 0, 10));
            InteligentObject.CreateObject("Source", new FacilityLocation(0, 0, 15));

            modelo.Facility.IntelligentObjects["Source1"].Properties["InterarrivalTime"].Value = "Random.Exponential(5)";

            SimioProjectFactory.SaveProject(APIProject, rutafinal, out warnings);
        }
    }
}
