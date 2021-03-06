using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Windows;
using AcWin = Autodesk.AutoCAD.Windows;
using System.Drawing;
using System.Windows;
using SysWin = System.Windows;
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
using DDECAD.MZ;
using TIExCAD.Generic;

namespace DDECAD.MZ.GUI.Model
{
    internal class ViewBaseControl 
    {

        internal CustomPaletteSetAcad PalSet;
        //internal SizePaletteSet SizePal;


        /// <summary>
        /// Создание палитры и подписка на события
        /// </summary>
        /// <remarks>Выполняется из Init.cs </remarks>
        internal  void ViewBaseCreate()
        {
            if (PalSet == null)
            { 
                var BaseWindow = new MzBaseWindow();
                // Подпишем наш метод на событие в форме MzBaseWindow
                MzAddStickEventHandler MzAddStickDel = new MzAddStickEventHandler(AddStickRealisation);
                BaseWindow.MzAddStickEvent += MzAddStickDel;

                // Создадим палитру и вставим в нее MzBaseWindow
                //SizePaletteSet SizePal =new SizePaletteSet();
                PalSet = new CustomPaletteSetAcad(
                    "DDE", new Guid("A7807F9F-E5EA-449B-840C-AE57491DFE56"), WidthPaletteSet.WidthBig, HeigthPaletteSet.HeightBig, BaseWindow, "Control");
                PalSet.PaletteSetCreate();
            }
            else
            {
                PalSet.PaletteSetCreate();
            }



        }

        internal static void AddStickRealisation()
        {
            MzAddStickControl StickControl = new MzAddStickControl();
            DialogWindow DialWin = new DialogWindow();

            DialWin.DialWinGrid.Children.Add(StickControl);
            DialWin.ShowDialog();
        }



    }
}
