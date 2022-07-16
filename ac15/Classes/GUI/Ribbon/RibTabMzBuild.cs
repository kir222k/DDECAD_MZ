using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Reflection;
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

[assembly: CommandClass(typeof(DDECAD.MZ.RibbonTabButtonHandlers))]


namespace DDECAD.MZ
{
    /// <summary>
    /// Создание и настройка новой вкладки ленты.
    /// </summary>
    internal class RibbonTabBuildDDEMZ
    {
        /// <summary>
        /// Контрол палитры.
        /// </summary>
        //private readonly ViewBaseControl ViewBase;
        /// <summary>
        /// Конструктор без аргументов.
        /// </summary>
        internal RibbonTabBuildDDEMZ() { }
        /// <summary>
        /// Конструктор с параметром-палитрой.
        /// </summary>
        /// <param name="viewBasePaletteSet"></param>
        //internal RibbonTabBuildDDEMZ(ViewBaseControl viewBasePaletteSet) { ViewBase = viewBasePaletteSet; }

        /// <summary>
        /// Создание вкладки ленты DDECAD-MZ.
        /// </summary>
        internal void RibbonTabBuild()
        {
            /** Описание возм. для кнопки
            *    Текст кнопки. 
            *    Показать текст. 
            *    Размер кнопки. 
            *    Ориентация кнопки. 
            *    Показать картинку. 
            *    Имя файла большой картинки. 
            *    Имя файла малой картинки. 
            *    Экземпляр делегата
            */

            /// Объект для работы с лентой.
            CreateRibTabSpeed CrTabSpeed = new CreateRibTabSpeed();
            LogEasy.WriteLog("RibbonTabBuildDDEMZ.RibbonTabBuild: " +
                "Instance CreateRibTabSpeed is created", Pathes.PathLog);

            #region ПАНЕЛЬ 1
            //DelegateRibButtonHandler DelBtn1 = new DelegateRibButtonHandler(MzSticksFormShow);

            /// Список из кнопок.
            List<RibButtonMyFull> listBtn = new List<RibButtonMyFull>
            {
                #region Кнопка1

                // 1
                //new RibButtonMyFull()
                //{
                //    //Текст кнопки.
                //    ribButtonText = "Открыть палитру",
                //    //Показать текст.
                //    showText = true,
                //    //Размер кнопки.
                //    ribButtonSize = RibbonItemSize.Standard,
                //    //Ориентация кнопки.
                //    ribButtonOrientation = Orientation.Vertical,
                //    //Показать картинку.
                //    showImage = false,
                //    //Имя файла большой картинки.
                //    ribButtonLargeImageName = "image_large.png",
                //    //Имя файла малой картинки. 
                //    ribButtonImageName = "image_standart.png",
                //    //Экземпляр делегата
                //    delegateRibBtnEv = MzStickFormShowRun // GetStaticInfo.SendMessToAcad_test1
                //},
                #endregion
                
                #region Кнопка2-Проверить_лиц
                // 2
                // ^C^C^P(load (strcat (getenv "userprofile")  (chr 92) "AppData" (chr 92) "Roaming" (chr 92) "DDECAD-MZ" (chr 92) "sys" (chr 92) "MZ.vlx"));(enex-mz-check-lic-user)
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Проверить\nлицензию",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Standard,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_large.png"),
                    //Имя файла малой картинки. 
                    ribButtonImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_standart.png"),
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzCheckLicense // GetStaticInfo.SendMessToAcad_test1
                 },
                #endregion

                #region Кнопка3-Удалить
                // 3 
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Удалить\nDDECAD-MZ",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Standard,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_large.png"),
                    //Имя файла малой картинки. 
                    ribButtonImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_standart.png"),
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzExcludeFromRegApp // GetStaticInfo.SendMessToAcad_test1
                },
                #endregion

            };
            LogEasy.WriteLog("RibbonTabBuildDDEMZ.RibbonTabBuild: " +
                 "Buttons list 1 is created", Pathes.PathLog);

            CrTabSpeed.CreateOrModifityRibbonTab("DDECAD-MZ", "ddecadmz", "Настройки", listBtn);
            LogEasy.WriteLog("RibbonTabBuildDDEMZ.RibbonTabBuild: " +
                "CreateOrModifityRibbonTab is done", Pathes.PathLog);

            #endregion

            #region ПАНЕЛЬ 2
            List<RibButtonMyFull> listBtnTools = new List<RibButtonMyFull>
            {
                #region Кнопка1-Установить_МП
                // 1 кнопка
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Установить\nМП",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_large.png"),
                    //Имя файла малой картинки. 
                    ribButtonImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_standart.png"),
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzSetStick // GetStaticInfo.SendMessToAcad_test1
                },
                #endregion

                #region Кнопка2-Построить_зону
                // 2 кнопка
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Построить\nзону",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_large.png"),
                    //Имя файла малой картинки. 
                    ribButtonImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_standart.png"),
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzBuildZone // GetStaticInfo.SendMessToAcad_test1
                },
                #endregion

                #region Кнопка3-Перестроить_зону
                // 3 кнопка
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Перестроить\nзону",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_large.png"),
                    //Имя файла малой картинки. 
                    ribButtonImageName = Path.GetFullPath(Pathes.GetPathApp() +  "\\image_standart.png"),
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzReBuildZone // GetStaticInfo.SendMessToAcad_test1
                }
                #endregion
            };

            CrTabSpeed.CreateOrModifityRibbonTab("DDECAD-MZ", "ddecadmz", "Инструменты", listBtnTools);
            #endregion

        }

#if DEBUG
        /// <summary>
        /// Показывает палитру.
        /// </summary>
        //internal void MzStickFormShowRun()
        //{
        //    if (ViewBase != null)
        //        RibbonTabButtonHandlers.MzSticksFormShow(ViewBase);
        //    else
        //    {
        //        AcadSendMess AcSM = new AcadSendMess();
        //        AcSM.SendStringDebugStars(new List<string> { "Требуется перезапустить AutoCAD" });

        //    }
        //}
#endif
    }


    /// <summary>
    /// Обработчики кнопок ленты.
    /// </summary>
    public static class RibbonTabButtonHandlers
    {
#if DEBUG
        /// <summary>
        /// Палитра.
        /// </summary>
        /// <param name="viewBasePaletteSet"></param>
        internal static void MzSticksFormShow(ViewBaseControl viewBasePaletteSet)
        {
            // Создать и показать палитру
            viewBasePaletteSet.ViewBaseCreate();
        }

        internal static void MzZonesFormShow()
        {
            AcadSendMess AcSM = new AcadSendMess();
            AcSM.SendStringDebugStars(new List<string> { "Обработчик", "MzZonesFormShow" });
        }
#endif

        /// <summary>
        /// Вызов LSP "проеверка лицензии".
        /// </summary>
        [CommandMethod("MzTbarCmdCheckLic")]
        public static void MzCheckLicense()
        {
            MzLoadVLXnextCmd(CommandToExecute.CmdCheckLicense);
        }

        /// <summary>
        /// Отменить регистр. dll и автозагрузку  dll.
        /// </summary>
        [CommandMethod("DDECADMZUNREG")]
        public static void MzExcludeFromRegApp()
        {
            TIExCAD.Generic.RegGeneric RegGen = new RegGeneric();
            if (!RegGen.GetUnRegisterCustomApp(DDECAD.MZ.Constantes.ConstNameCustomApp))
            {
                AcadSendMess AcSM = new AcadSendMess();
                AcSM.SendStringDebugStars(new List<string> { "Регистрация", $"{ DDECAD.MZ.Constantes.ConstNameCustomApp}", "отменена" });
            }
        }

        /// <summary>
        /// Вызов LSP "Установить МП".
        /// </summary>
        [CommandMethod("MzTbarCmdSetStick")]
        public static void MzSetStick()
        {
            //foreach (var item in new List<string>() { CommandToExecute.MzLoadVLX + " ", CommandToExecute.CmdSetStick + " " })
            //{
            //    acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(item, true, false, false);
            //}
            MzLoadVLXnextCmd(CommandToExecute.CmdSetStick);

        }

        /// <summary>
        /// Вызов LSP "Построить зону".
        /// </summary>
        [CommandMethod("MzTbarCmdBuildZone")]
        public static void MzBuildZone()
        {
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.MzLoadVLX + " ", true, false, false);
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.CmdBuildZone + " ", true, false, false);
            MzLoadVLXnextCmd(CommandToExecute.LoadMzVlxFile);
            MzLoadVLXnextCmd(CommandToExecute.CmdBuildZone);
        }

        /// <summary>
        /// Вызов LSP "Перестроить зону".
        /// </summary>
        [CommandMethod("MzTbarCmdReBuildZone")]
        public static void MzReBuildZone()
        {
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.MzLoadVLX + " ", true, false, false);
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.CmdReBuildZone + " ", true, false, false);
            MzLoadVLXnextCmd(CommandToExecute.LoadMzVlxFile);
            MzLoadVLXnextCmd(CommandToExecute.CmdReBuildZone);
        }

        /// <summary>
        /// Вызов LSP "Маркировать зону".
        /// </summary>
        [CommandMethod("MzTbarCmdLeader")]
        public static void MzLeader()
        {
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.MzLoadVLX + " ", true, false, false);
            //acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.CmdReBuildZone + " ", true, false, false);
            MzLoadVLXnextCmd(CommandToExecute.LoadMzVlxFile);
            MzLoadVLXnextCmd(CommandToExecute.CmdLeader);
        }


        /// <summary>
        /// Загружает VLX файл и выполняет команду в параметрах.
        /// </summary>
        /// <param name="cmd"> команда LISP в скобочках.</param>
        internal static void MzLoadVLXnextCmd(string cmd)
        {
            acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(CommandToExecute.LoadMzVlxFile + " ", true, false, false);
            acadApp.DocumentManager.MdiActiveDocument.SendStringToExecute(cmd + " ", true, false, false);
        }
    }



}

