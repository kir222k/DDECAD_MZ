﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Acad
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using AdW = Autodesk.Windows;
using acadApp = Autodesk.AutoCAD.ApplicationServices.Application;

using TIExCAD;
using TIExCAD.Generic;

using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Reflection;


namespace DDECAD.MZ
{
    /// <summary>
    /// Работа с событием изменения сист переменных.
    /// </summary>
    static partial class AcadSystemVarChanged
    {
        /// <summary>
        /// Подключение обоработчика к событию изменения системных переменных, 
        /// в т.ч., для переподключения нашей вкладки при смене раб. пр-ва.
        /// </summary>
        internal static void AcadSystemVariableChanged_ConnectHandler()
        {
            acadApp.SystemVariableChanged +=
                new SystemVariableChangedEventHandler(AcadSysVarChangedEventHandler);
        }


        /// <summary>
        /// Обработчик события изменения системных переменных.
        /// </summary>
        internal static void AcadSysVarChangedEventHandler(object sender, Autodesk.AutoCAD.ApplicationServices.SystemVariableChangedEventArgs e)
        {
            // e.Name  - проверим имя переменной
            switch (e.Name)
            {
                case "WSCURRENT": // название текущего раб. простраства.
                    AcadSysVarChangedEvHr_WSCURRENT();
                    break;
                //case 2:
                //    ;
                //    break;
                default:
#if DEBUG
                    AcadSendMess AcSM = new AcadSendMess();
                    AcSM.SendStringDebugStars(new List<string> {
                        "Изменения переменной",
                        $"{e.Name}",
                        "не отслеживается"});
#endif
                    break;
            }
        }

        internal static void AcadSysVarChangedEvHr_WSCURRENT()
        {
            /// @TODO Нужно разобраться, что это.
            string cmdNames =
            (string)Autodesk.AutoCAD.ApplicationServices.Application.
                GetSystemVariable(
                    "CMDNAMES");

            /// @TODO Нужно разобраться, что это: 
            /// if the QUICKCUI or CUI command is active, returns
            if (cmdNames.ToUpper().IndexOf("QUICKCUI") >= 0 ||
                cmdNames.ToUpper().IndexOf("CUI") >= 0)
                return;

            // Создать и загрузить вкладку
            if (Autodesk.Windows.ComponentManager.Ribbon != null) // если лента инициализирована.
            {
                var RibTab = new RibbonTabBuildDDEMZ();
                RibTab.RibbonTabBuild();
            }

            // Создать и загрузить меню
            MenuBarPopMenu.MenuBarPopMenuCreate();

            LogEasy.WriteLog("Metod: " + "AcadSysVarChangedEvHr_WSCURRENT  " +  "WSCURRENT = "  + 
                Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("WSCURRENT").ToString(), 
                Pathes.PathLog);

        }  

    }


}
