using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Frames;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;

namespace PdfViewerDemo {
    public partial class MainForm : RibbonForm {
        readonly PopupMenu popupSkins = new PopupMenu();
        readonly BarCheckItem checkItemAllowFormSkins;
        readonly string mainFormText;

        public MainForm() {
            WindowsFormsSettings.UseDXDialogs = DefaultBoolean.True;
            InitializeComponent();
            UpdateGlass();
            pdfViewer.DocumentCreator = "PDF Viewer Demo";
            pdfViewer.DocumentProducer = "Developer Express Inc., " + AssemblyInfo.Version;
            pdfViewer.CreateRibbon();
            foreach (RibbonPage page in ribbonControl.Pages)
                if (page.Text == "PDF Viewer") {
                    popupSkins.BeginUpdate();
                    popupSkins.Ribbon = ribbonControl;
                    checkItemAllowFormSkins = new BarCheckItem(ribbonControl.Manager);
                    checkItemAllowFormSkins.Caption = "Allow Form Skins";
                    checkItemAllowFormSkins.ItemClick += new ItemClickEventHandler(OnAllowFormSkinsItemClick);
                    popupSkins.AddItem(checkItemAllowFormSkins);
                    SkinHelper.InitSkinPopupMenu(popupSkins);
                    popupSkins.ItemLinks[1].BeginGroup = true;
                    popupSkins.EndUpdate();
                    popupSkins.Popup += new EventHandler(OnPmSkinsPopup);
                    RibbonPageGroup skinsPage = new RibbonPageGroup(ribbonGallerySkins.Caption);
                    SkinHelper.InitSkinGallery(ribbonGallerySkins, true);
                    skinsPage.CaptionButtonClick += new RibbonPageGroupEventHandler(OnSkinsPageCaptionButtonClick);
                    skinsPage.ItemLinks.Add(ribbonGallerySkins);
                    skinsPage.ItemLinks.Add(skinDropDownButtonItem1);
                    skinsPage.ItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
                    RibbonPageGroup devExpressPage = new RibbonPageGroup("DevExpress");
                    devExpressPage.ShowCaptionButton = false;
                    AddBarItem(devExpressPage, "Getting Started", "GetStarted", OnGettingStartedItemClicked);
                    AddBarItem(devExpressPage, "Get Free Support", "GetSupport", OnGetFreeSupportItemClicked);
                    AddBarItem(devExpressPage, "Buy Now", "BuyNow", OnBuyNowItemClicked);
                    AddBarItem(devExpressPage, "About", "Info", OnAboutItemClicked);
                    page.Groups.AddRange(new RibbonPageGroup[] { skinsPage, devExpressPage });
                    break;
                }
            mainFormText = Text;
            pdfViewer.DocumentChanged += new PdfDocumentChangedEventHandler(OnPdfViewerDocumentChanged);
            pdfViewer.UriOpening += OnPdfViewerUriOpening;
            pdfViewer.LoadDocument(DemoHelpers.GetDocumentStream());
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (pdfViewer.IsDocumentChanged)
                e.Cancel = !pdfViewer.ShowDocumentClosingWarning();
        }
        void AddBarItem(RibbonPageGroup page, string caption, string imageName, ItemClickEventHandler handler) {
            BarButtonItem item = new BarButtonItem(ribbonControl.Manager, caption);
            if (WindowsFormsSettings.GetAllowDefaultSvgImages()) 
                item.ImageOptions.DefaultSvgImage = DemoHelpers.GetSvgImageFromResources(imageName);
            else {
                item.ImageOptions.Image = DemoHelpers.GetSmallImageFromResources(imageName);
                item.ImageOptions.LargeImage = DemoHelpers.GetLargeImageFromResources(imageName);
            }
            item.ItemClick += handler;
            page.ItemLinks.Add(item);
        }
        void UpdateGlass() {
            AllowFormGlass = SkinManager.AllowFormSkins ? DefaultBoolean.False : DefaultBoolean.True;
        }
        void OnPdfViewerUriOpening(object sender, PdfUriOpeningEventArgs e) {
            Uri uri = e.Uri;
            e.Handled = uri.IsAbsoluteUri && String.Compare(uri.AbsoluteUri, AssemblyInfo.DXLinkGetStarted, true) == 0;
        }
        void OnPdfViewerDocumentChanged(object sender, PdfDocumentChangedEventArgs e) {
            string fileName = Path.GetFileName(e.DocumentFilePath);
            if (String.IsNullOrEmpty(fileName)) 
                Text = mainFormText;
            else
                Text = fileName + " - " + mainFormText;
        }
        void OnRibbonControlPaint(object sender, PaintEventArgs e) {
            RibbonViewInfo ribbonViewInfo = ribbonControl.ViewInfo;
            if (ribbonViewInfo != null) {
                RibbonPanelViewInfo panelViewInfo = ribbonViewInfo.Panel;
                if (panelViewInfo != null) {
                    RibbonPageGroupViewInfoCollection groups = panelViewInfo.Groups;
                    if (groups != null) {
                        Rectangle bounds = panelViewInfo.Bounds;
                        Image image = ApplicationCaption8_1.GetImageLogoEx(LookAndFeel);
                        int imageHeight = image.Height;
                        int yOffset = bounds.Height - imageHeight;
                        if (yOffset >= 0) {
                            int minX;
                            if (groups.Count > 0)
                                minX = groups[groups.Count - 1].Bounds.Right;
                            else
                                minX = bounds.X;
                            int imageWidth = image.Width + 15;
                            int xOffset = bounds.Width - imageWidth;
                            if (xOffset >= minX) {
                                bounds.X = xOffset;
                                bounds.Y += yOffset / 2;
                                bounds.Width = imageWidth;
                                bounds.Height = imageHeight;
                                e.Graphics.DrawImage(image, bounds.Location);
                            }
                        }
                    }
                }
            }
        }
        void OnPmSkinsPopup(object sender, EventArgs e) {
            checkItemAllowFormSkins.Checked = SkinManager.AllowFormSkins;
            string activeSkinName = UserLookAndFeel.Default.ActiveSkinName;
            checkItemAllowFormSkins.Enabled = !activeSkinName.Contains("Office 2013") && !activeSkinName.Contains("Office 2016");
        }
        void OnAllowFormSkinsItemClick(object sender, ItemClickEventArgs e) {
            if (SkinManager.AllowFormSkins) 
                SkinManager.DisableFormSkins();
            else
                SkinManager.EnableFormSkins();
            UpdateGlass();
        }
        void OnSkinsPageCaptionButtonClick(object sender, RibbonPageGroupEventArgs e) {
            popupSkins.ShowPopup(MousePosition);
        }
        void OnGettingStartedItemClicked(object sender, ItemClickEventArgs e) {
            DemoHelpers.StartProcess(AssemblyInfo.DXLinkGetStarted);
        }
        void OnGetFreeSupportItemClicked(object sender, ItemClickEventArgs e) {
            DemoHelpers.StartProcess(AssemblyInfo.DXLinkGetSupport);
        }
        void OnBuyNowItemClicked(object sender, ItemClickEventArgs e) {
            DemoHelpers.StartProcess(AssemblyInfo.DXLinkBuyNow);
        }
        void OnAboutItemClicked(object sender, ItemClickEventArgs e) {
            PdfViewer.About();
        }
    }
}
