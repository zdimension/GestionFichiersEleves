using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    public static class Helper
    {
        // http://stackoverflow.com/a/1600990/2196124
        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        public static void SetFont(Control ctl, Font fnt)
        {
            ctl.Font = fnt;
            foreach (Control c in ctl.Controls)
            {
                SetFont(c, fnt);
            }
        }

        public static Font GetSystemDefaultFont()
        {
            /*var v = Environment.OSVersion;
            if(v.Platform == PlatformID.Win32NT)
            {
                if(v.Version.Major >= 6) return new Font("Segoe UI", 9F);
            }*/
            if(IsFontInstalled("Segoe UI")) return new Font("Segoe UI", 9F);
            return new Font("Tahoma", 8F);
        }

        public static bool IsFontInstalled(string name)
        {
            using (var font = new Font(name, 9F))
            {
                return string.Compare(name, font.Name, StringComparison.InvariantCultureIgnoreCase) == 0;
            }
        }

        public static string WrapPixel(this string str, int maxWidth, Font fnt)
        {
            var temp = "";
            return string.Concat(str.TakeWhile(c => TextRenderer.MeasureText(temp += c, fnt).Width <= maxWidth));
        }

        public static List<List<string>> AddEmptyLine(this List<List<string>> l, int n)
        {
            var a = l;
            a.Add(Enumerable.Repeat("", n).ToList());
            return a;
        } 

        public static string DetecterLigne(string code)
        {
            // Pour détecter le format de ligne
            // Sur Windows: \r\n
            // Sur Linux: \n
            // Sur Mac: \r
            if (code.Contains("\r\n"))
                return "\r\n";
            if (!code.Contains("\n"))
                return "\r";

            return "\n";
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        public static void Clear(this DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();
        }

        public static void ShowExceptionMessage(Exception ex)
        {
            var message =
                    "Une erreur est survenue : " + ex.Message + "\n";

            if (ex.Message.Contains("en cours d'utilisation"))
            {
                message +=
                    "\nCela signifie qu'un fichier précédemment créé par GestionFichiersEleves" +
                    " est ouvert dans un autre programme tel que Microsoft Excel, et que ce " +
                    "dernier doit être fermé pour autoriser la modification du fichier.\n";
            }
            else if (ex.Message.Contains("L'accès") && ex.Message.Contains("est refusé"))
            {
                message +=
                    "\nCela signifie que GestionFichiersEleves ne peut pas actuellement accéder" +
                    " à ce fichier car il n'a pas les privilèges nécessaires. Vérifiez que le " +
                    "fichier n'est pas en mode \"lecture seule\" et qu'il se trouve dans un " +
                    "emplacement auquel vous avez le droit d'accéder.\n";
            }

            message +=
                "\nPile des appels :\n" + ex.StackTrace + "\n\n" +
                "En cas de problèmes récurrents, n'hésitez pas à vous adresser au développeur du " +
                "logiciel (moi) à l'adresse e-mail suivante : zippedfire@free.fr";

            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static IEnumerable<string> ToSize(this List<string> l, int size)
        {
            for (var i = 0; i < size; i++)
            {
                yield return i < l.Count ? l[i] : "";
            }
        }  
    }
}
