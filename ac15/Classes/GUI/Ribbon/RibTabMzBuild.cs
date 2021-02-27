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

using TIExCAD;
using TIExCAD.Generic;

namespace DDECAD.MZ

{
    internal class RibbonTabBuildDDEMZ
    {
        /// <summary>
        /// Создание вкладки ленты DDECAD-MZ.
        /// </summary>
        internal void RibbonTabBuild()
        {
            /**
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

            #region ПАНЕЛЬ 1
            //DelegateRibButtonHandler DelBtn1 = new DelegateRibButtonHandler(MzSticksFormShow);

            List<RibButtonMyFull> listBtn = new List<RibButtonMyFull>
            {
                // 1
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Молниеприемники",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = "image_large.png",
                    //Имя файла малой картинки. 
                    ribButtonImageName = "image_standart.png",
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzSticksFormShow// GetStaticInfo.SendMessToAcad_test1
                },
                // 2
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Зоны защиты",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = "image_large.png",
                    //Имя файла малой картинки. 
                    ribButtonImageName = "image_standart.png",
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzZonesFormShow // GetStaticInfo.SendMessToAcad_test1
                 },
                // 3 кнопка
                new RibButtonMyFull()
                {
                    //Текст кнопки.
                    ribButtonText = "Исключить из автозагрузки",
                    //Показать текст.
                    showText = true,
                    //Размер кнопки.
                    ribButtonSize = RibbonItemSize.Large,
                    //Ориентация кнопки.
                    ribButtonOrientation = Orientation.Vertical,
                    //Показать картинку.
                    showImage = true,
                    //Имя файла большой картинки.
                    ribButtonLargeImageName = "image_large.png",
                    //Имя файла малой картинки. 
                    ribButtonImageName = "image_standart.png",
                    //Экземпляр делегата
                    delegateRibBtnEv = RibbonTabButtonHandlers.MzExcludeFromRegApp // GetStaticInfo.SendMessToAcad_test1
                }
            };
            CrTabSpeed.CreateOrModifityRibbonTab("DDECAD-MZ", "ddecadmz", "Молниезащита", listBtn);
            #endregion
        }
    }
}


/// <summary>
/// Обработчики кнопок ленты.
/// </summary>
internal static class RibbonTabButtonHandlers
{
    internal static void MzSticksFormShow()
    {
        AcadSendMess AcSM = new AcadSendMess();
        AcSM.SendStringDebugStars(new List<string> { "Обработчик", "MzSticksFormShow" });
    }

    internal static void MzZonesFormShow()
    {
        AcadSendMess AcSM = new AcadSendMess();
        AcSM.SendStringDebugStars(new List<string> { "Обработчик", "MzZonesFormShow" });
    }

    internal static void MzExcludeFromRegApp()
    {
        TIExCAD.Generic.RegGeneric RegGen = new RegGeneric();
        if (!RegGen.GetUnRegisterCustomApp(DDECAD.MZ.Constantes.ConstNameCustomApp))
        {
            AcadSendMess AcSM = new AcadSendMess();
            AcSM.SendStringDebugStars(new List<string> { "Регистрация", $"{ DDECAD.MZ.Constantes.ConstNameCustomApp}", "отменена" });
        }
    }


}



