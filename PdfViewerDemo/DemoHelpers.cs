using DevExpress.Utils;
using DevExpress.Utils.Svg;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace PdfViewerDemo {
    public static class DemoHelpers {
        static T GetImageFromResources<T>(string imageName, Func<string, T> create) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            T result = create(imageName);
            if (result == null)
                result = create("Images." + imageName);
            return result;
        }
        static Image GetRasterImageFromResources(string imageName, string suffix) {
            return GetImageFromResources<Image>(imageName + suffix, name => ResourceImageHelper.CreateImageFromResources(name, Assembly.GetExecutingAssembly()));
        }
        public static Image GetSmallImageFromResources(string imageName) {
            return GetRasterImageFromResources(imageName, "_16x16.png");
        }
        public static Image GetLargeImageFromResources(string imageName) {
            return GetRasterImageFromResources(imageName, "_32x32.png");
        }
        public static SvgImage GetSvgImageFromResources(string imageName) {
            return GetImageFromResources<SvgImage>(imageName + ".svg", name => SvgImage.FromResources(name, Assembly.GetExecutingAssembly()));
        }
        public static Stream GetDocumentStream() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Demo.pdf");
            if (stream == null)
                return assembly.GetManifestResourceStream("Data.Demo.pdf");
            return stream;
        }
        public static void StartProcess(string name) {
            try {
                Process process = new Process();
                ProcessStartInfo startInfo = process.StartInfo;
                startInfo.FileName = name + "?gldata=" + AssemblyInfo.VersionShort + "_DevExpress.XtraPdfViewer.Demos.Main|Winforms&platform=Winforms";
                startInfo.Arguments = String.Empty;
                startInfo.Verb = "Open";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch {
            }
        }
    }         
}
