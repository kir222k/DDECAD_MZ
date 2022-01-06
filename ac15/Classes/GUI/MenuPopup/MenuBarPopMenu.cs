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
using DDECAD.MZ.GUI.Model; // DDECAD.MZ.GUI.Model
using DDECAD.MZ.Classes.GUI.Windows;

namespace DDECAD.MZ
{
    internal static class MenuBarPopMenu


    {
        // создать меню 
        // запустить после создания ленты.

        internal static void MenuBarPopMenuCreate()
        {
            //throw new NotImplementedException();
            //MzLoadVLXnextCmd(CommandToExecute
            
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.MzLoadAllVlxMacros + " ", true, false, false);

            TieMenubar menubar = new TieMenubar();
            var listMI = new List<MenuPopItem>
            {
                new MenuPopItem { Name = "Проверить лицензию", Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdCheckLicense + " " },
                new MenuPopItem { Name = "Удалить DDECAD-MZ", Macros = "DDECAD-MZ-UNREG" + " " },


                new MenuPopItem { Name = "Установить МП", Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdSetStick + " " },
                new MenuPopItem { Name = "Построить зону", Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdBuildZone + " " },
                new MenuPopItem { Name = "Перестроить зону", Macros = CommandToExecute.MzLoadVLXMacros + CommandToExecute.CmdReBuildZone + " " }
            };
            menubar.MenubarCreatePopupMenu("DDECAD-MZ", listMI);

        }

    }

    public class MzExecCmd
    {
        [CommandMethod("DDECAD-MZ-UNREG")]
        public void MzExecExcludeFromRegApp ()
        {
            RibbonTabButtonHandlers.MzExcludeFromRegApp();
        }
    }

}
