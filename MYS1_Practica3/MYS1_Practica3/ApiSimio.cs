using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SimioAPI;
using SimioAPI.Extensions;

using SimioAPI.Graphics;
using Simio;
using Simio.SimioEnums;
namespace MYS1_Practica3
{
    class ApiSimio
    {
        private ISimioProject proyectoApi;
        private string rutabase;
        private string rutafinal;
        private string[] warnings;
        private IModel model;
        private IIntelligentObjects intelligentObjects;
        int contadorP = 1;
        LinkedList<int> listaPs = new LinkedList<int>();

        public ApiSimio(String rbase,String rfinal)
        {
            rutabase = rbase;
            rutafinal = rfinal;
            proyectoApi = SimioProjectFactory.LoadProject(rutabase,out warnings);
            model = proyectoApi.Models[1];
            intelligentObjects = model.Facility.IntelligentObjects;
        }

        public void createSource(int x, int y)
        {
            this.createObject("Source", x, y);
        }

        public void createServer(int x, int y)
        {
            this.createObject("Server", x, y);
        }

        public void createSink(int x, int y)
        {
            this.createObject("Sink", x, y);
        }

        public void crearTransferNode(int x, int y)
        {
            this.createObject("TransferNode",x,y);
        }

        public void createObject(String type, int x, int y)
        {
            intelligentObjects.CreateObject(type, new FacilityLocation(x, 0, y));
        }

        public void createPath(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("Path", nodo1, nodo2);
        }

        public void createLink(String type, INodeObject nodo1, INodeObject nodo2)
        {
            intelligentObjects.CreateLink(type, nodo1, nodo2, null);
        }

        public void createTimePath(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("TimePath", nodo1, nodo2);
        }

        public void createConveyor(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("Conveyor", nodo1, nodo2);
        }

        public void updateProperty(String name, String property, String value)
        {
            model.Facility.IntelligentObjects[name].Properties[property].Value = value;
        }

        public void CrearCarnets()
        {
            String carnet1 = "201612097";
            String carnet2 = "201612276";
            CrearModelo(carnet1,10,10);
            CrearModelo(carnet2, 10, 40);
            SimioProjectFactory.SaveProject(proyectoApi, rutafinal, out warnings);
        }

        public void CrearModelo(String carnet, int x, int y)
        {
            for (int i=0;i<carnet.Length;i++)
            {
                switch (carnet.ElementAt(i))
                {
                    case '0':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 3), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 3), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 13;
                        break;
                    case '1':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x, y+10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 3;
                        break;
                    case '2':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P"+contadorP);
                        contadorP++;
                        this.crearTransferNode(x+10, y);
                        updateName("TransferNode3", "P"+contadorP);
                        contadorP++;
                        createPath(getNodo("P"+(contadorP-2), 1), getNodo("P"+(contadorP-1), 0));
                        this.crearTransferNode(x + 10, y+5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 13;
                        break;
                    case '3':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 13;
                        break;
                    case '6':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 3), 0));
                        x = x + 13;
                        break;
                    case '7':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 3), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 13;
                        break;
                    case '9':
                        this.crearTransferNode(x, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x + 10, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 5);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 1), 0));
                        this.crearTransferNode(x, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        this.crearTransferNode(x + 10, y + 10);
                        updateName("TransferNode3", "P" + contadorP);
                        contadorP++;
                        createPath(getNodo("P" + (contadorP - 2), 1), getNodo("P" + (contadorP - 1), 0));
                        createPath(getNodo("P" + (contadorP - 4), 1), getNodo("P" + (contadorP - 1), 0));
                        x = x + 13;
                        break;
                    default:
                        break;
                }
            }
        }
        
        public void updateName(String oldName, String newName)
        {
            model.Facility.IntelligentObjects[oldName].ObjectName = newName;
        }

        public INodeObject getNodo(String name, int nodo)
        {
            return (model.Facility.IntelligentObjects[name]) as INodeObject;
        }

        public void GenerarMapa()
        {
            GenerarRegiones();
            Generar_Puntos_Cardinales();
            Generar_Aeropuertos();
            Generar_SalidaAeropuerto();
            Generar_Movimientos();
            Unir_Entrada_Aeropuertos();
            Generar_Turistas_Nacionales();
            Generar_Salida_Hacia_Aeropuertos();
            Generar_Quedarse_En_Misma_Region();
            SimioProjectFactory.SaveProject(proyectoApi, rutafinal, out warnings);
        }

        public void GenerarRegiones()
        {
            //------------------GENERAMOS REGION METROPOLITANA-----------------
            this.createServer(0,0);
            updateName("Server2","Metropolitana");
            updateProperty("Metropolitana", "InitialCapacity", "200");
            updateProperty("Metropolitana", "ProcessingTime", "Random.Exponential(4)");
            updateProperty("Output@Metropolitana", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION NORTE-----------------
            this.createServer(5,-20);
            updateName("Server2", "Norte");
            updateProperty("Norte", "InitialCapacity", "50");
            updateProperty("Norte", "ProcessingTime", "Random.Exponential(5)");
            updateProperty("Output@Norte", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION NOR-ORIENTE-----------------
            this.createServer(30, -10);
            updateName("Server2", "Nor_Oriente");
            updateProperty("Nor_Oriente", "InitialCapacity", "40");
            updateProperty("Nor_Oriente", "ProcessingTime", "Random.Exponential(3)");
            updateProperty("Output@Nor_Oriente", "OutboundLinkRule", "By Link Weight");


            //------------------GENERAMOS REGION SUR-ORIENTE-----------------
            this.createServer(15,20);
            updateName("Server2", "Sur_Oriente");
            updateProperty("Sur_Oriente", "InitialCapacity", "30");
            updateProperty("Sur_Oriente", "ProcessingTime", "Random.Exponential(4)");
            updateProperty("Output@Sur_Oriente", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION CENTRAL-----------------
            this.createServer(-15,20);
            updateName("Server2", "Central");
            updateProperty("Central", "InitialCapacity", "100");
            updateProperty("Central", "ProcessingTime", "Random.Exponential(5)");
            updateProperty("Output@Central", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION SUR-OCCIDENTE-----------------
            this.createServer(-40,10);
            updateName("Server2", "Sur_Occidente");
            updateProperty("Sur_Occidente", "InitialCapacity", "120");
            updateProperty("Sur_Occidente", "ProcessingTime", "Random.Exponential(3)");
            updateProperty("Output@Sur_Occidente", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION NOR-OCCIDENTE-----------------
            this.createServer(-40,-20);
            updateName("Server2", "Nor_Occidente");
            updateProperty("Nor_Occidente", "InitialCapacity", "30");
            updateProperty("Nor_Occidente", "ProcessingTime", "Random.Exponential(6)");
            updateProperty("Output@Nor_Occidente", "OutboundLinkRule", "By Link Weight");

            //------------------GENERAMOS REGION PETEN-----------------
            this.createServer(10,-50);
            updateName("Server2", "Peten");
            updateProperty("Peten", "InitialCapacity", "150");
            updateProperty("Peten", "ProcessingTime", "Random.Exponential(4)");
            updateProperty("Output@Peten", "OutboundLinkRule", "By Link Weight");
        }

        public void Generar_Puntos_Cardinales()
        {
            this.crearTransferNode(0, -100);
            updateName("TransferNode2", "N");

            this.crearTransferNode(0, 70);
            updateName("TransferNode2", "S");

            this.crearTransferNode(-90, 0);
            updateName("TransferNode2", "O");

            this.crearTransferNode(90, 0);
            updateName("TransferNode2", "E");
        }

        public void Generar_Aeropuertos()
        {
            this.createSource(10, 0);
            updateName("Source2", "Aurora");
            updateProperty("Aurora", "EntityType", "Persona1");
            updateProperty("Aurora", "InterarrivalTime", "Random.Exponential(35)");
            updateProperty("Aurora", "EntitiesPerArrival", "70");

            this.createSource(10, -60);
            updateName("Source2", "Mundo_Maya");
            updateProperty("Mundo_Maya", "EntityType", "Persona1");
            updateProperty("Mundo_Maya", "InterarrivalTime", "Random.Exponential(50)");
            updateProperty("Mundo_Maya", "EntitiesPerArrival", "40");

            this.createSource(-40, 20);
            updateName("Source2", "Quetzaltenango");
            updateProperty("Quetzaltenango", "EntityType", "Persona1");
            updateProperty("Quetzaltenango", "InterarrivalTime", "Random.Exponential(70)");
            updateProperty("Quetzaltenango", "EntitiesPerArrival", "30");
        }

        public void Generar_SalidaAeropuerto()
        {
            this.createSink(10, 5);
            updateName("Sink2", "Aurora_Out");

            this.createSink(15, -60);
            updateName("Sink2", "Mundo_Maya_Out");

            this.createSink(-45, 20);
            updateName("Sink2", "Quetzaltenango_Out");
        }

        public void Generar_Movimientos()
        {
            //faltaria de metropolitano a metropolitano

            //---------metropolitana a central
            createPath(getNodo("Output@Metropolitana", 1), getNodo("Input@Central", 0));
            updateName("Path2", "met_cent");
            updateProperty("met_cent", "DrawnToScale", "False");
            updateProperty("met_cent", "LogicalLength", "63000");
            updateProperty("met_cent", "AllowPassing", "False");
            updateProperty("met_cent", "SelectionWeight", "0.3");
            //metropolitana a sur-oriente
            createPath(getNodo("Output@Metropolitana", 1), getNodo("Input@Sur_Oriente", 0));
            updateName("Path2", "met_s_or");
            updateProperty("met_s_or", "DrawnToScale", "False");
            updateProperty("met_s_or", "LogicalLength", "124000");
            updateProperty("met_s_or", "AllowPassing", "False");
            updateProperty("met_s_or", "SelectionWeight", "0.15");
            //metropolitana a nor-oriente
            createPath(getNodo("Output@Metropolitana", 1), getNodo("Input@Nor_Oriente", 0));
            updateName("Path2", "met_n_or");
            updateProperty("met_n_or", "DrawnToScale", "False");
            updateProperty("met_n_or", "LogicalLength", "241000");
            updateProperty("met_n_or", "AllowPassing", "False");
            updateProperty("met_n_or", "SelectionWeight", "0.2");

            //faltaria de norte a norte

            //---------norte a peten
            createPath(getNodo("Output@Norte", 1), getNodo("Input@Peten", 0));
            updateName("Path2", "nort_peten");
            updateProperty("nort_peten", "DrawnToScale", "False");
            updateProperty("nort_peten", "LogicalLength", "147000");
            updateProperty("nort_peten", "AllowPassing", "False");
            updateProperty("nort_peten", "SelectionWeight", "0.4");
            //norte a nor-oriente
            createPath(getNodo("Output@Norte", 1), getNodo("Input@Nor_Oriente", 0));
            updateName("Path2", "nort_n_or");
            updateProperty("nort_n_or", "DrawnToScale", "False");
            updateProperty("nort_n_or", "LogicalLength", "138000");
            updateProperty("nort_n_or", "AllowPassing", "False");
            updateProperty("nort_n_or", "SelectionWeight", "0.1");
            //norte a nor-occidente
            createPath(getNodo("Output@Norte", 1), getNodo("Input@Nor_Occidente", 0));
            updateName("Path2", "nort_n_occ");
            updateProperty("nort_n_occ", "DrawnToScale", "False");
            updateProperty("nort_n_occ", "LogicalLength", "145000");
            updateProperty("nort_n_occ", "AllowPassing", "False");
            updateProperty("nort_n_occ", "SelectionWeight", "0.1");

            //faltaria de nor_or a nor_or

            //---------nor_or a met
            createPath(getNodo("Output@Nor_Oriente", 1), getNodo("Input@Metropolitana", 0));
            updateName("Path2", "nor_or_met");
            updateProperty("nor_or_met", "DrawnToScale", "False");
            updateProperty("nor_or_met", "LogicalLength", "241000");
            updateProperty("nor_or_met", "AllowPassing", "False");
            updateProperty("nor_or_met", "SelectionWeight", "0.3");
            //nor_or a Norte
            createPath(getNodo("Output@Nor_Oriente", 1), getNodo("Input@Norte", 0));
            updateName("Path2", "nor_or_n");
            updateProperty("nor_or_met", "DrawnToScale", "False");
            updateProperty("nor_or_met", "LogicalLength", "138000");
            updateProperty("nor_or_met", "AllowPassing", "False");
            updateProperty("nor_or_met", "SelectionWeight", "0.15");
            //nor_or a Norte
            createPath(getNodo("Output@Nor_Oriente", 1), getNodo("Input@Sur_Oriente", 0));
            updateName("Path2", "nor_or_s_or");
            updateProperty("nor_or_s_or", "DrawnToScale", "False");
            updateProperty("nor_or_s_or", "LogicalLength", "231000");
            updateProperty("nor_or_s_or", "AllowPassing", "False");
            updateProperty("nor_or_s_or", "SelectionWeight", "0.05");
            //nor_or a Norte
            createPath(getNodo("Output@Nor_Oriente", 1), getNodo("Input@Peten", 0));
            updateName("Path2", "nor_or_peten");
            updateProperty("nor_or_peten", "DrawnToScale", "False");
            updateProperty("nor_or_peten", "LogicalLength", "282000");
            updateProperty("nor_or_peten", "AllowPassing", "False");
            updateProperty("nor_or_peten", "SelectionWeight", "0.3");

            //faltaria de sur_or a sur_or

            //---------sur_or a nor_or
            createPath(getNodo("Output@Sur_Oriente", 1), getNodo("Input@Nor_Oriente", 0));
            updateName("Path2", "sur_or_nor_or");
            updateProperty("sur_or_nor_or", "DrawnToScale", "False");
            updateProperty("sur_or_nor_or", "LogicalLength", "231000");
            updateProperty("sur_or_nor_or", "AllowPassing", "False");
            updateProperty("sur_or_nor_or", "SelectionWeight", "0.2");

            //---------sur_or a met
            createPath(getNodo("Output@Sur_Oriente", 1), getNodo("Input@Metropolitana", 0));
            updateName("Path2", "sur_or_met");
            updateProperty("sur_or_met", "DrawnToScale", "False");
            updateProperty("sur_or_met", "LogicalLength", "124000");
            updateProperty("sur_or_met", "AllowPassing", "False");
            updateProperty("sur_or_met", "SelectionWeight", "0.25");

            //---------sur_or a met
            createPath(getNodo("Output@Sur_Oriente", 1), getNodo("Input@Central", 0));
            updateName("Path2", "sur_or_cent");
            updateProperty("sur_or_cent", "DrawnToScale", "False");
            updateProperty("sur_or_cent", "LogicalLength", "154000");
            updateProperty("sur_or_cent", "AllowPassing", "False");
            updateProperty("sur_or_cent", "SelectionWeight", "0.15");

            //faltaria de central a central

            //---------cent a met
            createPath(getNodo("Output@Central", 1), getNodo("Input@Metropolitana", 0));
            updateName("Path2", "cen_met");
            updateProperty("cen_met", "DrawnToScale", "False");
            updateProperty("cen_met", "LogicalLength", "63000");
            updateProperty("cen_met", "AllowPassing", "False");
            updateProperty("cen_met", "SelectionWeight", "0.35");

            //---------cent a sur_or
            createPath(getNodo("Output@Central", 1), getNodo("Input@Sur_Oriente", 0));
            updateName("Path2", "cen_sur_or");
            updateProperty("cen_sur_or", "DrawnToScale", "False");
            updateProperty("cen_sur_or", "LogicalLength", "154000");
            updateProperty("cen_sur_or", "AllowPassing", "False");
            updateProperty("cen_sur_or", "SelectionWeight", "0.05");
            //---------cent a sur_or
            createPath(getNodo("Output@Central", 1), getNodo("Input@Sur_Occidente", 0));
            updateName("Path2", "cen_sur_occ");
            updateProperty("cen_sur_occ", "DrawnToScale", "False");
            updateProperty("cen_sur_occ", "LogicalLength", "155000");
            updateProperty("cen_sur_occ", "AllowPassing", "False");
            updateProperty("cen_sur_occ", "SelectionWeight", "0.15");
            //---------cent a sur_or
            createPath(getNodo("Output@Central", 1), getNodo("Input@Nor_Occidente", 0));
            updateName("Path2", "cen_nor_occ");
            updateProperty("cen_nor_occ", "DrawnToScale", "False");
            updateProperty("cen_nor_occ", "LogicalLength", "269000");
            updateProperty("cen_nor_occ", "AllowPassing", "False");
            updateProperty("cen_nor_occ", "SelectionWeight", "0.1");

            //faltaria de sur_occ a sur_occ

            //---------sur_occ a nor_occ
            createPath(getNodo("Output@Sur_Occidente", 1), getNodo("Input@Nor_Occidente", 0));
            updateName("Path2", "sur_occ_nor_occ");
            updateProperty("sur_occ_nor_occ", "DrawnToScale", "False");
            updateProperty("sur_occ_nor_occ", "LogicalLength", "87000");
            updateProperty("sur_occ_nor_occ", "AllowPassing", "False");
            updateProperty("sur_occ_nor_occ", "SelectionWeight", "0.3");
            //---------sur_occ a central
            createPath(getNodo("Output@Sur_Occidente", 1), getNodo("Input@Central", 0));
            updateName("Path2", "sur_occ_cen");
            updateProperty("sur_occ_cen", "DrawnToScale", "False");
            updateProperty("sur_occ_cen", "LogicalLength", "155000");
            updateProperty("sur_occ_cen", "AllowPassing", "False");
            updateProperty("sur_occ_cen", "SelectionWeight", "0.35");

            //faltaria de Nor_occ a Nor_occ

            //---------sur_occ a nor_occ
            createPath(getNodo("Output@Nor_Occidente", 1), getNodo("Input@Sur_Occidente", 0));
            updateName("Path2", "nor_occ_sur_occ");
            updateProperty("nor_occ_sur_occ", "DrawnToScale", "False");
            updateProperty("nor_occ_sur_occ", "LogicalLength", "87000");
            updateProperty("nor_occ_sur_occ", "AllowPassing", "False");
            updateProperty("nor_occ_sur_occ", "SelectionWeight", "0.3");
            //---------sur_occ a central
            createPath(getNodo("Output@Nor_Occidente", 1), getNodo("Input@Central", 0));
            updateName("Path2", "nor_occ_cen");
            updateProperty("nor_occ_cen", "DrawnToScale", "False");
            updateProperty("nor_occ_cen", "LogicalLength", "269000");
            updateProperty("nor_occ_cen", "AllowPassing", "False");
            updateProperty("nor_occ_cen", "SelectionWeight", "0.1");
            //---------sur_occ a norte
            createPath(getNodo("Output@Nor_Occidente", 1), getNodo("Input@Norte", 0));
            updateName("Path2", "nor_occ_nor");
            updateProperty("nor_occ_nor", "DrawnToScale", "False");
            updateProperty("nor_occ_nor", "LogicalLength", "145000");
            updateProperty("nor_occ_nor", "AllowPassing", "False");
            updateProperty("nor_occ_nor", "SelectionWeight", "0.2");

            //faltaria de peten a peten

            //---------sur_occ a nor_occ
            createPath(getNodo("Output@Peten", 1), getNodo("Input@Norte", 0));
            updateName("Path2", "peten_nor");
            updateProperty("peten_nor", "DrawnToScale", "False");
            updateProperty("peten_nor", "LogicalLength", "147000");
            updateProperty("peten_nor", "AllowPassing", "False");
            updateProperty("peten_nor", "SelectionWeight", "0.25");
            //---------sur_occ a nor_occ
            createPath(getNodo("Output@Peten", 1), getNodo("Input@Nor_Oriente", 0));
            updateName("Path2", "peten_nor_or");
            updateProperty("peten_nor_or", "DrawnToScale", "False");
            updateProperty("peten_nor_or", "LogicalLength", "282000");
            updateProperty("peten_nor_or", "AllowPassing", "False");
            updateProperty("peten_nor_or", "SelectionWeight", "0.25");
        }

        public void Unir_Entrada_Aeropuertos()
        {
            //Aurora a metropolitana
            createPath(getNodo("Output@Aurora", 1), getNodo("Input@Metropolitana", 0));
            updateName("Path2", "aur_met");
            //Aurora a metropolitana
            createPath(getNodo("Output@Quetzaltenango", 1), getNodo("Input@Sur_Occidente", 0));
            updateName("Path2", "quet_sur_occ");
            //Aurora a metropolitana
            createPath(getNodo("Output@Mundo_Maya", 1), getNodo("Input@Peten", 0));
            updateName("Path2", "mm_pet");
        }

        public void Generar_Turistas_Nacionales()
        {
            //------------------GENERAMOS EN REGION METROPOLITANA-----------------
            this.createSource(-5, -5);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(2)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateProperty("Output@Source2", "OutboundLinkRule", "By Link Weight");
            updateName("Source2", "Metro_Nac");

            //------------------GENERAMOS EN REGION NORTE-----------------
            this.createSource(0, -15);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(8)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateName("Source2", "N_Nac");

            //------------------GENERAMOS EN REGION NOR-ORIENTE-----------------
            this.createSource(25, -5);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(6)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateProperty("Output@Source2", "OutboundLinkRule", "By Link Weight");
            updateName("Source2", "Nor_Nac");


            //------------------GENERAMOS EN REGION SUR-ORIENTE-----------------
            this.createSource(10, 15);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(10)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateName("Source2", "Sur_Nac");

            //------------------GENERAMOS EN REGION CENTRAL-----------------
            this.createSource(-20, 15);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(3)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateName("Source2", "Cen_Nac");

            //------------------GENERAMOS EN REGION SUR-OCCIDENTE-----------------
            this.createSource(-45, 15);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(4)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateProperty("Output@Source2", "OutboundLinkRule", "By Link Weight");
            updateName("Source2", "Sur_O_Nac");

            //------------------GENERAMOS EN REGION NOR-OCCIDENTE-----------------
            this.createSource(-45, -25);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(12)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateName("Source2", "Nor_O_Nac");

            //------------------GENERAMOS EN REGION PETEN-----------------
            this.createSource(5, -55);
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "EntityType", "Persona1");
            updateProperty("Source2", "InterarrivalTime", "Random.Poisson(4)");
            updateProperty("Source2", "EntitiesPerArrival", "1");
            updateProperty("Output@Source2", "OutboundLinkRule", "By Link Weight");
            updateName("Source2", "P_Nac");
        }

        public void Generar_Salida_Hacia_Aeropuertos()
        {
            createPath(getNodo("Output@Metro_Nac", 1), getNodo("Input@Aurora_Out", 0));
            updateProperty("Path2", "AllowPassing", "False");
            updateProperty("Path2", "SelectionWeight", "0.5");
            updateName("Path2", "menac_aur_out");

            createPath(getNodo("Output@P_Nac", 1), getNodo("Input@Mundo_Maya_Out", 0));
            updateProperty("Path2", "AllowPassing", "False");
            updateProperty("Path2", "SelectionWeight", "0.3");
            updateName("Path2", "pnac_mm_out");

            createPath(getNodo("Output@Sur_O_Nac", 1), getNodo("Input@Quetzaltenango_Out", 0));
            updateProperty("Path2", "AllowPassing", "False");
            updateProperty("Path2", "SelectionWeight", "0.4");
            updateName("Path2", "suronac_qout");
        }

        public void Generar_Quedarse_En_Misma_Region()
        {
            createPath(getNodo("Output@Metropolitana", 1), getNodo("Output@Metro_Nac", 0));
            updateName("Path2", "met_mnac");
            updateProperty("met_mnac", "DrawnToScale", "False");
            updateProperty("met_mnac", "LogicalLength", "0");
            updateProperty("met_mnac", "AllowPassing", "False");
            updateProperty("met_mnac", "SelectionWeight", "0.35");

            createPath(getNodo("Output@Metro_Nac", 1), getNodo("Input@Metropolitana", 0));
            updateName("Path2", "mnac_met");
            updateProperty("mnac_met", "DrawnToScale", "False");
            updateProperty("mnac_met", "LogicalLength", "0");
            updateProperty("mnac_met", "AllowPassing", "False");
            updateProperty("mnac_met", "SelectionWeight", "0.5");

            createPath(getNodo("Output@Norte", 1), getNodo("Output@N_Nac", 0));
            updateName("Path2", "nort_nnac");
            updateProperty("nort_nnac", "DrawnToScale", "False");
            updateProperty("nort_nnac", "LogicalLength", "0");
            updateProperty("nort_nnac", "AllowPassing", "False");
            updateProperty("nort_nnac", "SelectionWeight", "0.4");

            createPath(getNodo("Output@N_Nac", 1), getNodo("Input@Norte", 0));
            updateName("Path2", "nnac_n");

            createPath(getNodo("Output@Nor_Oriente", 1), getNodo("Output@Nor_Nac", 0));
            updateName("Path2", "nor_nornac");
            updateProperty("nor_nornac", "DrawnToScale", "False");
            updateProperty("nor_nornac", "LogicalLength", "0");
            updateProperty("nor_nornac", "AllowPassing", "False");
            updateProperty("nor_nornac", "SelectionWeight", "0.2");

            createPath(getNodo("Output@Nor_Nac", 1), getNodo("Input@Nor_Oriente", 0));
            updateName("Path2", "nornac_nor");

            createPath(getNodo("Output@Sur_Oriente", 1), getNodo("Output@Sur_Nac", 0));
            updateName("Path2", "suro_suronac");
            updateProperty("suro_suronac", "DrawnToScale", "False");
            updateProperty("suro_suronac", "LogicalLength", "0");
            updateProperty("suro_suronac", "AllowPassing", "False");
            updateProperty("suro_suronac", "SelectionWeight", "0.4");

            createPath(getNodo("Output@Sur_Nac", 1), getNodo("Input@Sur_Oriente", 0));
            updateName("Path2", "suronacc_suro");

            createPath(getNodo("Output@Central", 1), getNodo("Output@Cen_Nac", 0));
            updateName("Path2", "cen_cennac");
            updateProperty("cen_cennac", "DrawnToScale", "False");
            updateProperty("cen_cennac", "LogicalLength", "0");
            updateProperty("cen_cennac", "AllowPassing", "False");
            updateProperty("cen_cennac", "SelectionWeight", "0.35");

            createPath(getNodo("Output@Cen_Nac", 1), getNodo("Input@Central", 0));
            updateName("Path2", "cennac_cen");

            createPath(getNodo("Output@Sur_Occidente", 1), getNodo("Output@Sur_O_Nac", 0));
            updateName("Path2", "surocc_suroccnac");
            updateProperty("surocc_suroccnac", "DrawnToScale", "False");
            updateProperty("surocc_suroccnac", "LogicalLength", "0");
            updateProperty("surocc_suroccnac", "AllowPassing", "False");
            updateProperty("surocc_suroccnac", "SelectionWeight", "0.35");

            createPath(getNodo("Output@Sur_O_Nac", 1), getNodo("Input@Sur_Occidente", 0));
            updateName("Path2", "suroccnac_surocc");
            updateProperty("suroccnac_surocc", "DrawnToScale", "False");
            updateProperty("suroccnac_surocc", "LogicalLength", "0");
            updateProperty("suroccnac_surocc", "AllowPassing", "False");
            updateProperty("suroccnac_surocc", "SelectionWeight", "0.6");

            createPath(getNodo("Output@Nor_Occidente", 1), getNodo("Output@Nor_O_Nac", 0));
            updateName("Path2", "norocc_noroccnac");
            updateProperty("norocc_noroccnac", "DrawnToScale", "False");
            updateProperty("norocc_noroccnac", "LogicalLength", "0");
            updateProperty("norocc_noroccnac", "AllowPassing", "False");
            updateProperty("norocc_noroccnac", "SelectionWeight", "0.4");

            createPath(getNodo("Output@Nor_O_Nac", 1), getNodo("Input@Nor_Occidente", 0));
            updateName("Path2", "noroccnac_norocc");

            createPath(getNodo("Output@Peten", 1), getNodo("Output@P_Nac", 0));
            updateName("Path2", "p_pnac");
            updateProperty("p_pnac", "DrawnToScale", "False");
            updateProperty("p_pnac", "LogicalLength", "0");
            updateProperty("p_pnac", "AllowPassing", "False");
            updateProperty("p_pnac", "SelectionWeight", "0.5");

            createPath(getNodo("Output@P_Nac", 1), getNodo("Input@Peten", 0));
            updateName("Path2", "pnac_p");
            updateProperty("pnac_p", "DrawnToScale", "False");
            updateProperty("pnac_p", "LogicalLength", "0");
            updateProperty("pnac_p", "AllowPassing", "False");
            updateProperty("pnac_p", "SelectionWeight", "0.7");
        }
    }
}
