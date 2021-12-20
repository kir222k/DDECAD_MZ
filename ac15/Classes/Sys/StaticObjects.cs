using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    internal static class CommandToExecute
    {
        internal static readonly string MzInstallDir = "c:\\\\Users\\\\kir\\\\AppData\\\\Roaming\\\\DDECAD-MZ\\\\sys\\\\MZ.VLX";

        internal static readonly string MzLoadVLX= "(load \"" + MzInstallDir + "\")";

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
