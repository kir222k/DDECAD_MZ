using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

//using ac15.Generic;
// Acad
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using AdW = Autodesk.Windows;
using acadApp = Autodesk.AutoCAD.ApplicationServices.Application;
//using AcDoc = acadApp.DocumentManager.MdiActiveDocument;

using TIExCAD;
using TIExCAD.Generic;
using DDECAD.MZ.GUI.Model; 
using DDECAD.MZ.Classes.GUI.Windows;

#if DEBUG

[assembly: CommandClass(typeof(DDECAD.MZ.ToolbarTest))]
#endif

//[assembly: CommandClass(typeof(DDECAD.MZ.ToolbarCmdSend))]


namespace DDECAD.MZ
{
    internal static class ToolBar
    {
        internal static void ToolBarCreate()
        {
            var TBar = new TieToolbar();
            var ListTBarButtons = new List<ToolbarButtItem>();

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 0,
                Name = "Проверить лицензию",
                HelpString = "Проверка/получение лицензии",
                Macros = "MzTbarCmdCheckLic" + " ",
                SmallIcon = Pathes.PathSmallIconAbout,
                LargeIcon = Pathes.PathLargeIconAbout
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 1,
                Name = "Удалить DDECAD - MZ",
                HelpString = "Удалить DDECAD-MZ",
                Macros = "DDECADMZUNREG" + " ",
                SmallIcon = Pathes.PathSmallIconDelProgram,
                LargeIcon = Pathes.PathLargeIconDelProgram
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 2,
                Name = "Установить МП",
                HelpString = "Установить МП",
                Macros = "MzTbarCmdSetStick" + " ",
                SmallIcon = Pathes.PathSmallIconAddStick,
                LargeIcon = Pathes.PathLargeIconAddStick
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 3,
                Name = "Построить зону",
                HelpString = "Построить зону",
                Macros = "MzTbarCmdBuildZone" + " ",
                SmallIcon = Pathes.PathSmallIconZoneDraw,
                LargeIcon = Pathes.PathLargeIconZoneDraw
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 4,
                Name = "Перестроить зону",
                HelpString = "Перестроить зону",
                Macros = "MzTbarCmdReBuildZone" + " ",
                SmallIcon = Pathes.PathSmallIconZoneReDraw,
                LargeIcon = Pathes.PathLargeIconZoneReDraw
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 5,
                Name = "Маркировать зону",
                HelpString = "Маркировать зону",
                Macros = "MzTbarCmdLeader" + " ",
                SmallIcon = Pathes.PathSmallIconLeader,
                LargeIcon = Pathes.PathLargeIconLeader
            });

            TBar.ToolbarCreate("DDECAD-MZ", ListTBarButtons);
            // u:\dev\DDECAD-MZ\distr\img\image_standart.png
        }
    }


    //public static class ToolbarCmdSend
    //{
    //    [CommandMethod("MzTbarCmdCheckLic")]
    //    public static void TbarCmdCheckLic()
    //    {
    //        RibbonTabButtonHandlers.MzCheckLicense();
            
    //    }
    //}




#if DEBUG
    public static class ToolbarTest
    {
        [CommandMethod("tiexToolbarTestCreate")]
        public static void ToolbarTestCreate()
        {
            ToolBar.ToolBarCreate();
        }

        [CommandMethod("tiexToolbarTestDelete")]
        public static void ToolbarTestDelete()
        {
            var TBar = new TieToolbar();
            TBar.ToolbarRemove("DDECAD-MZ");
        }
    }
#endif

}


