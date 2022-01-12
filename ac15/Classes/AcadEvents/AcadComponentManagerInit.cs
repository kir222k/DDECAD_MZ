using System;
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
using DDECAD.MZ.GUI.Model;


using Autodesk.AutoCAD.EditorInput;

using System.Windows.Media.Imaging;

using System.Reflection;
using TIExCAD.Generic;
using System.IO;


namespace DDECAD.MZ
{
    static class AcadComponentManagerInit
    {

        /// <summary>
        /// Подключение обоработчика к событию создания ленты, для автоподключения нашей вкладки
        /// </summary>
        internal static void AcadComponentManagerInit_ConnectHandlerRibbon()
        {
            Autodesk.Windows.ComponentManager.ItemInitialized +=
                new EventHandler<RibbonItemEventArgs>(AcadComponentManager_ItemInitialized);
            LogEasy.WriteLog("AcadComponentManagerInit.AcadComponentManagerInit_ConnectHandlerRibbon: " +
                "подписываем создание вкладки на ленте к событию ItemInitialized", Pathes.PathLog);

        }

        /// <summary>
        /// Подключение обоработчика к событию загрузки меню, для автоподключения нашего меню.
        /// Но есть один нюанс: ApplicationMenu - это меню ПРИЛОЖЕНИЯ - см. где "cохранить как" )
        /// </summary>
        internal static void AcadComponentManagerInit_ConnectHandlerMenu()
        {

            ComponentManager.ApplicationMenu.Opening +=
                new EventHandler<EventArgs>(ApplicationMenu_Opening);
            LogEasy.WriteLog("AcadComponentManagerInit.AcadComponentManagerInit_ConnectHandlerMenu: " +
                "подписываем создание меню  к событию ApplicationMenu.Opening", Pathes.PathLog);

        }

        /// <summary>
        /// Автосоздание вкладки ленты.
        /// </summary>
        internal static void AcadComponentManager_ItemInitialized(object sender, Autodesk.Windows.RibbonItemEventArgs e)
        {
            if (Autodesk.Windows.ComponentManager.Ribbon != null) // Если лента вообще доступна.
            {

                        RibbonTabBuildDDEMZ RibTab = new RibbonTabBuildDDEMZ();
                LogEasy.WriteLog("AcadComponentManagerInit.AcadComponentManager_ItemInitialized: " +
                    "экз. RibbonTabBuildDDEMZ создан", Pathes.PathLog);

                RibTab.RibbonTabBuild();
                LogEasy.WriteLog("AcadComponentManagerInit.AcadComponentManager_ItemInitialized: " +
                    "RibbonTabBuild выполнено", Pathes.PathLog);
            }
            else
            {
                LogEasy.WriteLog("AcadComponentManagerInit.AcadComponentManager_ItemInitialized: " +
                    "Ribbon = NULL! возможно, кад запущен с ранее уст. класс. раб. пространством", Pathes.PathLog);
            }


            // Отключить обработчик загрузки ленты, т.к. он вызвается
            // только 1 раз при инициализации DLL.
            ComponentManager.ItemInitialized -=
                new EventHandler<RibbonItemEventArgs>(AcadComponentManager_ItemInitialized);
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal static void ApplicationMenu_Opening(object sender, EventArgs e)
        {
            // Remove the event when it is fired
            ComponentManager.ApplicationMenu.Opening -=
              new EventHandler<EventArgs>(ApplicationMenu_Opening);
            // Add our Application Menu
            AddApplicationMenu();
        }

        internal static void AddApplicationMenu()
        {
            ApplicationMenu menu = ComponentManager.ApplicationMenu;
           
            if (menu != null && menu.MenuContent != null)
            {
                // Create our Application Menu Item
                ApplicationMenuItem mi = new ApplicationMenuItem
                {
                    Text = "DDECAD-MZ",
                    Description = "MZ",
                    //mi.LargeImage = "image_large.png";
                    ShowImage = false
                };
                // Attach the handler to fire out command
                //mi.CommandHandler = new AutoCADCommandHandler(bpCmd);
                // Add it to the menu content
                menu.MenuContent.Items.Add(mi);
            }
        }


    }

}
