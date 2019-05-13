namespace DevExpress.XtraRichEdit.Demos {
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
            this.components = new System.ComponentModel.Container();
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentStatisticsTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richEditControl
            // 
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.Location = new System.Drawing.Point(0, 0);
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.Behavior.MaxZoomFactor = 5F;
            this.richEditControl.Options.Behavior.MinZoomFactor = 0.1F;
            this.richEditControl.Options.Comments.Visibility = DevExpress.XtraRichEdit.RichEditCommentVisibility.Hidden;
            this.richEditControl.Size = new System.Drawing.Size(845, 600);
            this.richEditControl.TabIndex = 0;
            this.richEditControl.SelectionChanged += new System.EventHandler(this.richEditControl_SelectionChanged);
            this.richEditControl.DocumentClosing += new System.ComponentModel.CancelEventHandler(this.richEditControl_DocumentClosing);
            this.richEditControl.ContentChanged += new System.EventHandler(this.richEditControl_ContentChanged);
            this.richEditControl.ZoomChanged += new System.EventHandler(this.richEditControl_ZoomChanged);
            this.richEditControl.InvalidFormatException += new DevExpress.XtraRichEdit.RichEditInvalidFormatExceptionEventHandler(this.richEditControl_InvalidFormatException);
            this.richEditControl.VisiblePagesChanged += new System.EventHandler(this.richEditControl_VisiblePagesChanged);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 369);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Size = new System.Drawing.Size(845, 20);
            // 
            // documentStatisticsTimer
            // 
            this.documentStatisticsTimer.Tick += new System.EventHandler(this.documentStatisticsTimer_Tick);
            // 
            // FirstLookModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Name = "FirstLookModule";
            this.Size = new System.Drawing.Size(845, 600);
            this.Load += new System.EventHandler(this.FirstLookModule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichEditControl richEditControl;
        private XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private System.Windows.Forms.Timer documentStatisticsTimer;
    }
}
