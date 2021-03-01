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

using TIExCAD.Generic;

namespace DDECAD.MZ
{
    internal static class ViewBaseControl 
    {
        internal static void ViewBaseCreate()
        {
           // IntPtr intPtr =  Marshal.StringToHGlobalAnsi("SreingPr");
            var AcWind = new acad.Windows.PaletteSet("Base");
            AcWind.DockEnabled = (DockSides)((int)DockSides.Left + (int)DockSides.Right);

            var AcWincMzAddStick = new MzAddStick();
            // вставка экз. контрола в палитру
            ElementHost host = new ElementHost(); //  какой-то объект
                                                  // настройка какого-то объекта
            host.AutoSize = true;
            host.Dock = DockStyle.Fill;
            // вставка в какой-то объект нашего контрола 
            host.Child = AcWincMzAddStick;
            // добавление какого-то объекта с нашим контролом в палитру
            AcWind.Add("Добавить МП", host);
            // объект размера
            Size sz = new Size
            {
                Width = 310,
                Height = 500
            };
            // передача размеров палитре
            AcWind.SetSize(sz);

            // задаем  фокус на палитру
            AcWind.KeepFocus = true;
            // показываем палитру
            AcWind.Visible = true;


            // Подпишем наш метод на событие в форме MzAddStick
            MzAddStickDelegate MzAddStickDel = new MzAddStickDelegate(AddStickRealisation);
            AcWincMzAddStick.EventAddStick += MzAddStickDel;
        }

        internal static void AddStickRealisation()
        {
            AcadSendMess AcSM = new AcadSendMess();
            AcSM.SendStringDebugStars(new List<string>
                    {
                        "AddStickRealisation",
                        "MzAddStick",

                    });

        }

    }
}
