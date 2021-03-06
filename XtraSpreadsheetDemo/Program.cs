﻿using System;
using System.Windows.Forms;

namespace DevExpress.XtraSpreadsheet.Demos {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful", "Forest");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstLookModule());
        }
    }
}
