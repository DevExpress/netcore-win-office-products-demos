namespace DevExpress.XtraSpreadsheet.Demos {
    partial class FirstLookModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstLookModule));
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.edZoom = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.lblSelection = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 170);
            this.spreadsheetControl1.MenuManager = this.ribbonControl1;
            this.spreadsheetControl1.TabIndex = 0;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            this.spreadsheetControl1.Options.Behavior.MaxZoomFactor = 4F;
            this.spreadsheetControl1.Options.Behavior.MinZoomFactor = 0.1F;
            this.spreadsheetControl1.Options.Behavior.UseSkinColors = false;
            this.spreadsheetControl1.Options.Culture = new System.Globalization.CultureInfo("en-US");
            this.spreadsheetControl1.Options.View.Charts.Antialiasing = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled;
            this.spreadsheetControl1.Size = new System.Drawing.Size(784, 264);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.edZoom,
            this.lblSelection});
            this.ribbonControl1.MaxItemId = 337;
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemZoomTrackBar1});
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.edZoom);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblSelection);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 405);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(784, 27);
            // 
            // edZoom
            // 
            this.edZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.edZoom.Caption = "100%";
            this.edZoom.Edit = this.repositoryItemZoomTrackBar1;
            this.edZoom.EditValue = 100;
            this.edZoom.EditWidth = 150;
            this.edZoom.Id = 335;
            this.edZoom.Name = "edZoom";
            // 
            // repositoryItemZoomTrackBar1
            // 
            this.repositoryItemZoomTrackBar1.AllowUseMiddleValue = true;
            this.repositoryItemZoomTrackBar1.LargeChange = 50;
            this.repositoryItemZoomTrackBar1.Maximum = 400;
            this.repositoryItemZoomTrackBar1.Middle = 100;
            this.repositoryItemZoomTrackBar1.Minimum = 10;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            this.repositoryItemZoomTrackBar1.SmallChange = 10;
            this.repositoryItemZoomTrackBar1.SnapToMiddle = 5;
            // 
            // lblSelection
            // 
            this.lblSelection.Caption = "Avg: Sum: Count:";
            this.lblSelection.Id = 336;
            this.lblSelection.Name = "lblSelection";
            // 
            // FirstLookModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Size = new System.Drawing.Size(784, 600);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar1);
            this.Name = "FirstLookModule";
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.spreadsheetControl1);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar1, 0);
            this.Controls.SetChildIndex(this.spreadsheetControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private XtraBars.Ribbon.RibbonControl ribbonControl1;
        private XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private XtraBars.BarEditItem edZoom;
        private XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private XtraBars.BarStaticItem lblSelection;
    }
}
