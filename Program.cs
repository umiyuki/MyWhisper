using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace WinWisper
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
            // Set the UI culture based on the system language
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InstalledUICulture;
            if (CultureInfo.InstalledUICulture.Name.StartsWith("ja"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }*/

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            Application.Run(new MyWhisper());
        }
    }
}
