using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Layout;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Demos.Forms;

namespace DevExpress.XtraRichEdit.Demos {
    public partial class FirstLookModule : Form {
        bool _isZoomChanging = false;
        int _pageCount = 1;
        int _currentPage = 1;
        bool _includeTextBoxes = false;

        public FirstLookModule() {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            InitializeComponent();

            RibbonControl ribbonControl = richEditControl.CreateRibbon();
            this.Controls.Add(ribbonControl);
            AppendCustomRibbonItems(ribbonControl);
        }

        public RichEditControl RichEdit { get { return richEditControl; } }
        int PageCount {
            get { return _pageCount; }
            set {
                if (_pageCount == value)
                    return;
                _pageCount = value;
                OnPagesInfoChanged();
            }
        }
        int CurrentPage {
            get { return _currentPage; }
            set {
                if (_currentPage == value)
                    return;
                _currentPage = value;
                OnPagesInfoChanged();
            }
        }
        bool IncludeTextBoxes {
            get { return _includeTextBoxes; }
            set {
                if (_includeTextBoxes == value)
                    return;
                _includeTextBoxes = value;
                OnIncludeTextBoxesChanged();
            }
        }

        #region AppendCustomRibbonItems
        private XtraBars.BarStaticItem pagesBarItem;
        private DevExpress.XtraBars.BarEditItem zoomBarEditItem;
        private DevExpress.XtraBars.BarButtonItem documentStatisticsBarButtonItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;

        void AppendCustomRibbonItems(RibbonControl ribbonControl1) {
            this.pagesBarItem = new DevExpress.XtraBars.BarStaticItem();
            this.zoomBarEditItem = new DevExpress.XtraBars.BarEditItem();
            this.documentStatisticsBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();


            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.pagesBarItem,
                this.zoomBarEditItem,
                this.documentStatisticsBarButtonItem,
            });

            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemZoomTrackBar1,
            });

            // 
            // pagesBarItem
            // 
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.pagesBarItem.Id = 246;
            this.pagesBarItem.Name = "pagesBarItem";
            toolTipItem1.Text = "Page number in document.";
            superToolTip1.Items.Add(toolTipItem1);
            this.pagesBarItem.SuperTip = superToolTip1;

            // 
            // zoomBarEditItem
            // 
            this.zoomBarEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.zoomBarEditItem.Caption = "100%";
            this.zoomBarEditItem.Edit = this.repositoryItemZoomTrackBar1;
            this.zoomBarEditItem.EditValue = 100;
            this.zoomBarEditItem.EditWidth = 150;
            this.zoomBarEditItem.Id = 245;
            this.zoomBarEditItem.Name = "zoomBarEditItem";
            this.zoomBarEditItem.EditValueChanged += new System.EventHandler(this.zoomBarEditItem_EditValueChanged);


            // 
            // repositoryItemZoomTrackBar1
            // 
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();

            this.repositoryItemZoomTrackBar1.AllowUseMiddleValue = true;
            this.repositoryItemZoomTrackBar1.LargeChange = 50;
            this.repositoryItemZoomTrackBar1.Maximum = 500;
            this.repositoryItemZoomTrackBar1.Middle = 100;
            this.repositoryItemZoomTrackBar1.Minimum = 10;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            this.repositoryItemZoomTrackBar1.SmallChange = 10;
            this.repositoryItemZoomTrackBar1.SnapToMiddle = 2;

            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();

            this.ribbonStatusBar1.ItemLinks.Add(this.pagesBarItem);
            this.ribbonStatusBar1.ItemLinks.Add(this.zoomBarEditItem);
            this.ribbonStatusBar1.ItemLinks.Add(this.documentStatisticsBarButtonItem);

            this.ribbonStatusBar1.Ribbon = ribbonControl1;

            // 
            // documentStatisticsBarButtonItem
            // 
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.documentStatisticsBarButtonItem.Id = 247;
            this.documentStatisticsBarButtonItem.Name = "documentStatisticsBarButtonItem";
            toolTipItem2.Text = "Number of words in document. Click to open the Document Statistics dialog box.";
            superToolTip2.Items.Add(toolTipItem2);
            this.documentStatisticsBarButtonItem.SuperTip = superToolTip2;
            this.documentStatisticsBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.documentStatistics_ItemClick);
        }
        #endregion

        void FirstLookModule_Load(object sender, EventArgs e) {
            RichEdit.DocumentLayout.DocumentFormatted += DocumentLayout_DocumentFormatted;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FirstLook.docx");
            richEditControl.LoadDocument(path);
        }
        void DocumentLayout_DocumentFormatted(object sender, EventArgs e) {
            BeginInvoke(new Action(() => {
                PageCount = RichEdit.DocumentLayout.GetPageCount();
            }));
        }
        void zoomBarEditItem_EditValueChanged(object sender, System.EventArgs e) {
            if (this._isZoomChanging)
                return;
            int value = Convert.ToInt32(zoomBarEditItem.EditValue);
            this._isZoomChanging = true;
            try {
                RichEdit.ActiveView.ZoomFactor = value / 100f;
                zoomBarEditItem.Caption = String.Format("{0}%", value);
            }
            finally {
                this._isZoomChanging = false;
            }
        }
        void richEditControl_ZoomChanged(object sender, EventArgs e) {
            if (this._isZoomChanging)
                return;
            int value = (int)Math.Round(RichEdit.ActiveView.ZoomFactor * 100);
            this._isZoomChanging = true;
            try {
                zoomBarEditItem.EditValue = value;
                zoomBarEditItem.Caption = String.Format("{0}%", value);
            }
            finally {
                this._isZoomChanging = false;
            }
        }
        void OnPagesInfoChanged() {
            pagesBarItem.Caption = String.Format("PAGE {0} OF {1}", CurrentPage, PageCount);
        }
        void OnIncludeTextBoxesChanged() {
            CalculateDocumentStatistics();
        }
        void richEditControl_VisiblePagesChanged(object sender, EventArgs e) {
            CurrentPage = RichEdit.ActiveView.GetVisiblePageLayoutInfos()[0].PageIndex + 1;
        }
        void richEditControl_SelectionChanged(object sender, EventArgs e) {
            RangedLayoutElement element = RichEdit.DocumentLayout.GetElement<RangedLayoutElement>(RichEdit.Document.CaretPosition);
            if (element != null)
                CurrentPage = RichEdit.DocumentLayout.GetPageIndex(element) + 1;
        }
        void documentStatistics_ItemClick(object sender, XtraBars.ItemClickEventArgs e) {
            using (DocumentStatisticsForm form = new DocumentStatisticsForm(RichEdit.Document, IncludeTextBoxes)) {
                form.ShowDialog();
                IncludeTextBoxes = form.IncludeTextboxes;
            }
        }
        void richEditControl_ContentChanged(object sender, EventArgs e) {
            documentStatisticsTimer.Start();
        }
        void documentStatisticsTimer_Tick(object sender, EventArgs e) {
            documentStatisticsTimer.Stop();
            BeginInvoke(new Action(CalculateDocumentStatistics));
        }
        void CalculateDocumentStatistics() {
            DocumentIterator iterator = new DocumentIterator(RichEdit.Document, true);
            StaticsticsVisitor visitor = new StaticsticsVisitor(IncludeTextBoxes);
            while (iterator.MoveNext())
                iterator.Current.Accept(visitor);
            documentStatisticsBarButtonItem.Caption = String.Format("{0} WORDS", visitor.WordCount);
        }
        void richEditControl_InvalidFormatException(object sender, RichEditInvalidFormatExceptionEventArgs e) {
            XtraMessageBox.Show(string.Format("Cannot open the file '{0}' because the file format or file extension is not valid.\n" +
                "Verify that file has not been corrupted and that the file extension matches the format of the file.", RichEdit.Options.DocumentSaveOptions.CurrentFileName),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void richEditControl_DocumentClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (RichEdit.Modified) {
                string currentFileName = RichEdit.Options.DocumentSaveOptions.CurrentFileName;
                string message = !string.IsNullOrEmpty(currentFileName) ?
                    string.Format("Do you want to save the changes you made for '{0}'?", currentFileName) : "Do you want to save the changes?";
                DialogResult result = XtraMessageBox.Show(message, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    RichEdit.SaveDocument();
                e.Cancel = result == DialogResult.Cancel;
            }
        }
    }
}
