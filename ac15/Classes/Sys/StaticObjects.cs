using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Reflection;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using AdW = Autodesk.Windows;
using acadApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DDECAD.MZ
{
    /// <summary>
    /// Содержит статические поля и возращающие мнтоды.
    /// Разработан для хранения необходимых статических данных в теле сборки.
    /// </summary>
    internal static class StaticObjAcadRev
    {
        internal static readonly string Acad2015 = "20.0";
        internal static readonly string Acad2016 = "20.1";
        internal static readonly string Acad2017 = "21.0";
        internal static readonly string Acad2018 = "22.0";
        internal static readonly string Acad2019 = "23.0";
        internal static readonly string Acad2020 = "23.1";
        internal static readonly string Acad2021 = "24.0";
        internal static readonly string Acad2022 = "24.1";

        internal static List<string> GetListAcadReleaseVersions()
        {
            List<string> listVersion = new List<string>
            {
                Acad2015,
                Acad2016,
                Acad2017,
                Acad2018,
                Acad2019,
                Acad2020,
                Acad2021,
                Acad2022
            };

            return listVersion;
        }

    }

    internal static class Pathes
    {
        // internal static readonly string PathApp = Assembly.GetExecutingAssembly().Location;
        // DirectoryInfo dirDLL = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
        internal static readonly string PathSmallIcon = Path.GetFullPath(GetPathApp() + "\\image_standart.bmp");
        internal static readonly string PathLargeIcon = Path.GetFullPath(GetPathApp() + "\\image_large.bmp");

        internal static string GetPathApp ()
        {
            DirectoryInfo dirDLL = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            var pathDir = dirDLL.Parent.FullName;
            return pathDir;
        }

        internal static readonly string PathLog = GetPathApp() + "\\ddecadmz.log";

        // Возращает строку пути в виде c:\\\\..
        internal static string GetPathAppForLisp()
        {
            //DirectoryInfo dirDLL = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo dirDLL = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            var pathDir = dirDLL.Parent.FullName;

            pathDir = pathDir.Replace("\\", "\\\\");

            return pathDir;
        }

        internal static readonly string MzVlxFileFullPath = Pathes.GetPathAppForLisp() + "\\\\MZ.VLX";

       


    }
    /*
                     SmallIcon= "u:\\dev\\DDECAD-MZ\\distr\\img\\image_standart.png", LargeIcon= "u:\\dev\\DDECAD-MZ\\distr\\img\\image_large.png"});

    */

    internal static class CommandToExecute
    {
        //internal static readonly string LoadMzVlxFile= "(load \"" + Pathes.MzVlxFileFullPath + "\")";
        internal static readonly string LoadMzVlxFile = "(load \"" + Pathes.MzVlxFileFullPath + "\")";

        internal static readonly string CmdCheckLicense = "(enex-mz-check-lic-user)";

        // (enex-mz-dcl-insert-mp)
        internal static readonly string CmdSetStick = "(enex-mz-dcl-insert-mp)";

        // (enex-mz-start nil)
        internal static readonly string CmdBuildZone= "(enex-mz-start nil)";

        // enex-mz-base-redraw
        internal static readonly string CmdReBuildZone = "(enex-mz-base-redraw)";


        // "( (load \"" + "c:\\\\Users\\\\kir\\\\AppData\\\\Roaming\\\\DDECAD-MZ\\\\sys\\\\MZ.VLX" + "\")(enex-mz-check-lic-user)) "

        // Console.WriteLine("(load \"" + "c:\\\\Users\\\\kir\\\\AppData\\\\Roaming\\\\DDECAD-MZ\\\\sys\\\\MZ.VLX" + "\")")
    }
}
