using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Autodesk.AutoCAD.ApplicationServices;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.DatabaseServices;
using acad = Autodesk.AutoCAD;
using TIExCAD.Generic;

namespace DDECAD.MZ.Classes.Sys
{
    public class WindowsCollection
    {
        [CommandMethod("DDEGETWINDOWCOLLECTION")]
        public void GetAcadAppWindowCollection()
        {
            AcadSendMess AcSM = new AcadSendMess();

            foreach (Document Adoc in AcadApp.DocumentManager)
            {

                
                AcSM.SendStringDebugStars(new List<string> {

                    Adoc.ToString(),
                    Adoc.Name,
                   // Adoc.Database.Filename,
                    Adoc.Database.Insbase.ToString(),
                    Adoc.Database.VersionGuid


                });
            }

          
        }

    }
}
