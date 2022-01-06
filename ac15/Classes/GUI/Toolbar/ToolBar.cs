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

namespace DDECAD.MZ
{
    internal static class ToolBar
    {
        internal static void ToolBarCreate()
        {
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.MzLoadAllVlxMacros + " ", true, false, false);

            var TBar = new TieToolbar();

            var ListTBarButtons = new List<ToolbarButtItem>();

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 0,
                Name = "Проверить лицензию",
                HelpString = "Проверка/получение лицензии",
                Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdCheckLicense + " ",
                SmallIcon = Pathes.PathSmallIcon,
                LargeIcon = Pathes.PathLargeIcon
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 1,
                Name = "Удалить DDECAD - MZ",
                HelpString = "Удалить DDECAD-MZ",
                Macros = "DDECAD-MZ-UNREG" + " ",
                SmallIcon = Pathes.PathSmallIcon,
                LargeIcon = Pathes.PathLargeIcon
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 2,
                Name = "Установить МП",
                HelpString = "Установить МП",
                Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdSetStick + " ",
                SmallIcon = Pathes.PathSmallIcon,
                LargeIcon = Pathes.PathLargeIcon
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 3,
                Name = "Построить зону",
                HelpString = "Построить зону",
                Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdBuildZone + " ",
                SmallIcon = Pathes.PathSmallIcon,
                LargeIcon = Pathes.PathLargeIcon
            });

            ListTBarButtons.Add(new ToolbarButtItem
            {
                Index = 4,
                Name = "Перестроить зону",
                HelpString = "Перестроить зону",
                Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdReBuildZone + " ",
                SmallIcon = Pathes.PathSmallIcon,
                LargeIcon = Pathes.PathLargeIcon
            });


            TBar.ToolbarCreate("DDECAD-MZ", ListTBarButtons);



            // u:\dev\DDECAD-MZ\distr\img\image_standart.png
        }
    }
}
/*
                new MenuPopItem { Name = "Проверить лицензию", Macros = CommandToExecute.CmdCheckLicense + " " },
                new MenuPopItem { Name = "Удалить DDECAD-MZ", Macros = "DDECAD-MZ-UNREG" + " " },


                new MenuPopItem { Name = "Установить МП", Macros = CommandToExecute.CmdSetStick + " " },
                new MenuPopItem { Name = "Построить зону", Macros = CommandToExecute.CmdBuildZone + " " },
                new MenuPopItem { Name = "Перестроить зону", Macros = CommandToExecute.CmdReBuildZone + " " }

*/