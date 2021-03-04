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

namespace DDECAD.MZ.GUI.Model
{
    internal static class ViewBaseControl 
    {
        internal static void ViewBaseCreate()
        {
            var BaseWindow = new MzBaseWindow();
            
            // вставка экз. контрола в палитру
            ElementHost host = new ElementHost(); //  какой-то объект
            //// настройка какого-то объекта
            host.AutoSize = true;
            host.Dock = DockStyle.Fill;
            //// вставка в какой-то объект нашего контрола 
            host.Child = BaseWindow;

            var AcWind = new acad.Windows.PaletteSet("DDECAD-MZ")
            {
                DockEnabled = (DockSides)((int)DockSides.Left + (int)DockSides.Right),
                Text = "Text",
                RolledUp = true,
                //WindowState = Window.State.Minimized
                Style=PaletteSetStyles.NoTitleBar |
                    PaletteSetStyles.ShowCloseButton |
                    PaletteSetStyles.ShowPropertiesMenu |
                    PaletteSetStyles.ShowAutoHideButton //|
                    //PaletteSetStyles.PauseAutoRollupForChildModalDialog |
                    //PaletteSetStyles.NameEditable |
                   // PaletteSetStyles.SingleColDock |
                    //PaletteSetStyles.SingleRowDock |
                    //PaletteSetStyles.Snappable 
                    

            };

            // объект размера
            Size sz = new Size { Width = 310, Height = 500 };
            // передача размеров палитре
            AcWind.SetSize(sz);

            // добавление какого-то объекта с нашим контролом в палитру
            AcWind.Add("Добавить МП", host);
            

            // задаем  фокус на палитру
            AcWind.KeepFocus = true;
            // показываем палитру
            AcWind.Visible = true;

            // Подпишем наш метод на событие в форме M
            MzAddStickDelegate MzAddStickDel = new MzAddStickDelegate(AddStickRealisation);
            BaseWindow.EventAddStick += MzAddStickDel;
        }

        internal static void AddStickRealisation()
        {
            AcadSendMess AcSM = new AcadSendMess();
            AcSM.SendStringDebugStars(new List<string>
                    {
                        "AddStickRealisation",
                        "M",
                        "New Text"

                    });

        }



    }
}
