using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.DatabaseServices;
//using KR.CAD.NET.DDECAD.MZ;
using acad = Autodesk.AutoCAD;
//using System.Windows;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using DDECAD.MZ.Classes.GUI.Windows;
using Autodesk.Windows;
using TIExCAD.Generic;

namespace DDECAD.MZ.GUI.Model
{

    public class AddStick
    {
        [CommandMethod("ddeaddstickshow")]
        public  void ShowAddStick()
        {
            ViewAddStickDialog.AddStickDialog();
        }
    }

    internal static class ViewAddStickDialog
    {
        internal static void AddStickDialog()
        {
            TaskDialog AcWincTaskDialog = new TaskDialog();

            //AcWincTaskDialog.
            
            AcWincTaskDialog.Show();

            /*
             * Autodesk.Windows.TaskDialog
            var AcWincMzAddStick = new MzAddStick();

            System.Windows.Window AcWind = new DialogWindow();
            AcWind.Content = AcWincMzAddStick;

            AcWind.ShowDialog();
            */
        }
    }
}
