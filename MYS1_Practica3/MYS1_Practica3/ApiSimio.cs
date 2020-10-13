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
        private string rutabase = "[MYS1]ModeloBaseCarnets_P18.spfx";
        private string rutafinal = "[MYS1]ModeloFinalCarnets_P18.spfx";
        private string[] warnings;
        private IModel model;
        private IIntelligentObjects intelligentObjects;
        int contadorP = 1;
        LinkedList<int> listaPs = new LinkedList<int>();

        public ApiSimio()
        {
            proyectoApi = SimioProjectFactory.LoadProject(rutabase,out warnings);
            model = proyectoApi.Models[1];
            intelligentObjects = model.Facility.IntelligentObjects;
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
    }
}
