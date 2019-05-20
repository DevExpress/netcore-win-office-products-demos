using System;
using System.Windows.Forms;

namespace PdfViewerDemo {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
			DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful", "Fire Brick");
            DevExpress.XtraEditors.WindowsFormsSettings.AllowSkinEditorAttach = DevExpress.Utils.DefaultBoolean.True;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
