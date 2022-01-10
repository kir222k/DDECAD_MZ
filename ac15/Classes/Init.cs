//  Файл инициализации библиотеки
// https://overcoder.net/q/236774/%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%B8%D1%82%D1%8C-resourcedictionary-%D0%B2-%D0%B1%D0%B8%D0%B1%D0%BB%D0%B8%D0%BE%D1%82%D0%B5%D0%BA%D1%83-%D0%BA%D0%BB%D0%B0%D1%81%D1%81%D0%BE%D0%B2
// ПОЛЯ
// СВОЙЙСТВА
// КОНСТРУКТОРЫ
// МЕТОДЫ

using System.Collections.Generic;
using Autodesk.AutoCAD.Runtime;
using DDECAD.MZ.GUI.Model;
using System.Reflection;
using TIExCAD.Generic;


// This line is not mandatory, but improves loading performances, чтобы это не значило(!)
//[assembly: ExtensionApplication(typeof(ac15.InitSelf))]

namespace DDECAD.MZ
{
    /// <summary>
    /// Запускаемый класс - точка входа.
    /// При загрузке данной dll в AutoCAD выполняется код в методе IExtensionApplication.Initialize()
    /// </summary>
//#if !ddac21
    public class InitSelf : IExtensionApplication
    {
        //#else
        //    public class InitSelf // : IExtensionApplication
        //    {
        //#endif


        /// <summary>
        /// Инициализация.
        /// для запуска своих методов при загрузке dll в acad
        /// через команду _netload дописать здесь свой код 
        /// </summary>
        //#if !ddac21
        void IExtensionApplication.Initialize()
        //#else
        //[CommandMethod("ddeinit")]
        //public void InitApp()
        ////void IExtensionApplication.Initialize()
        //#endif

        {
            //InitThis InThis = new InitThis();

            //// Вывод данных о приложении в ком строку AutoCAD
            //InThis.InitOne();
            //// Подключение обработчиков основных событий.
            //InThis.BasicEventHadlerlersConnect();
            //// Загрузка интерфейса
            //InThis.LoadUserInterface();

            //InitThis InThis = new InitThis();

            // Вывод данных о приложении в ком строку AutoCAD
            InitThis.InitOne();
            // Подключение обработчиков основных событий.
            InitThis.BasicEventHadlerlersConnect();
            // Загрузка интерфейса
            InitThis.LoadUserInterface();

            

        }

        //#if true

        //#endif

        //#if !ddac21
        /// <summary>
        /// Метод, выполняемый при выгрузке плагина
        /// в нашем случае, при выгрузке экземляра acad.exe
        /// </summary>
        void IExtensionApplication.Terminate()
        {
        }
        //#endif
    }


#if DEBUG
    public class TestAcadSend
    {
        [CommandMethod("ddetest")]
        public void TestSendRun()
        {
            // Сообщение в ком строку AutoCAD
            AcadSendMess AcSM = new AcadSendMess();
            AcSM.SendStringDebugStars(new List<string>
                    {
                        "DDECAD-MZ - TestSendRun",
                        "С# 8.0, VS2022, API .NET AutoCAD",

                    });
        }
    }
#endif

    /// <summary>
    /// Дествия при загрузки сборки.
    /// </summary>
    /// <remarks>Подключение обработчиков основных событий, 
    /// Загрузка интерфейса пользователя,
    /// чтение ini-файлов, выполнение затем каких-то настроек и др.</remarks>
    internal static class InitThis
    {

        //ViewBaseControl ViewBasePaletteSet;

        internal static void InitOne()
        {
#if DEBUG
            AcadSendMess AcSM = new AcadSendMess();
            // Сообщение в ком строку AutoCAD
            AcSM.SendStringDebugStars("DDECAD-MZ");

            // Assembly.GetExecutingAssembly().Location
            // CommandToExecute.MzInstallDir
            AcSM.SendStringDebugStars($"MzInstallDir = {CommandToExecute.LoadMzVlxFile}");
            //AcSM.SendStringDebugStars($"MzInstallDirMacros = {CommandToExecute.MzInstallDirMacros}");
            //AcSM.SendStringDebugStars($"MzLoadVLXMacros = {CommandToExecute.MzLoadVLXMacros}");
            AcSM.SendStringDebugStars($"PathApp = {Pathes.GetPathApp()}");
#endif

#if !DEBUG
            // Регистрация сборок в автозагрузке AutoCAD.
            RegtoolsCMDF RegCMD = new RegtoolsCMDF(Constantes.ConstNameCustomApp);

            // Проверка регистрации сборки в автозагрузке AutoCAD.
            RegGeneric RegGen = new RegGeneric();

            // Вызывается регистрация сборки: 
            if (RegGen.GetRegisterCustomApp(Constantes.ConstNameCustomApp,
                Assembly.GetExecutingAssembly().Location)) // true
                                                           // если регистрация прошла успешно, то уведомляем
            {
                //AcSM.SendStringDebugStars("Приложение зарегистрировано. " +
                //    "\nПри следуюющем запуске AutoCAD будет загружно автоматически!");
                // выведем список зарег приложений, кот в автозагрузке AutoCAD.
                RegCMD.GetRegistryKeyAppsCMD();

            }
            // Иначе ничего не делаем, т.к. наше приложение уже есть в автозагрузке AutoCAD.
#endif
        }

        /// <summary>
        /// Подключение обработчиков основных событий.
        /// </summary>
        internal static void BasicEventHadlerlersConnect()
        {
            // Подключим автосоздание вкладки ленты.
            AcadComponentManagerInit.AcadComponentManagerInit_ConnectHandlerRibbon();

            // Подключим автосоздание меню приложения
            //AcadComponentManagerInit.AcadComponentManagerInit_ConnectHandlerMenu();

            // Подключим автосоздание панелей инструментов 

            // ИЗМЕНЕНИЯ СИСТЕМНЫХ ПЕРЕМЕННЫХ
            // Подключим пересоздание вкладки ленты.
            // В случае вкладки ленты, отслеживается переменная WSCURRENT.
            AcadSystemVarChanged.AcadSystemVariableChanged_ConnectHandler();
        }

        internal static void LoadUserInterface()
        {

            // если файла usercadr.ini нет в папке /sys, то загрузка в соотв. с настройками cadr.ini (кот. исп. при инсталяции)
            // usercadr.ini создается при первой запуске окна настроек, или при "сбросить" в окне настроек (заново создается)

            // Вкладка ленты. Только в режиме отладки. В релизе - см. автосоздание вкладки
#if DEBUG
            RibbonTabBuildDDEMZ RibTab = new RibbonTabBuildDDEMZ();
            RibTab.RibbonTabBuild();
#endif
            // Меню
            MenuBarPopMenu.MenuBarPopMenuCreate();

            // Панель инструментов
            ToolBar.ToolBarCreate();

             

            // ПАЛИТРА.
            // _ = new ViewBaseControl();



        }

    }

}
