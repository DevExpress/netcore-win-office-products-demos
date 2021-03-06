﻿namespace DevExpress.XtraRichEdit.Demos.Forms {
    partial class DocumentStatisticsForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblParagraphsCount = new DevExpress.XtraEditors.LabelControl();
            this.lblWithSpacesCharactersCount = new DevExpress.XtraEditors.LabelControl();
            this.lblNoSpacesCharactersCount = new DevExpress.XtraEditors.LabelControl();
            this.lblWordsCount = new DevExpress.XtraEditors.LabelControl();
            this.chkIncludeTextboxes = new DevExpress.XtraEditors.CheckEdit();
            this.lblParagraphs = new DevExpress.XtraEditors.LabelControl();
            this.lblWithSpacesCharacters = new DevExpress.XtraEditors.LabelControl();
            this.lblNoSpacesCharacters = new DevExpress.XtraEditors.LabelControl();
            this.lblWords = new DevExpress.XtraEditors.LabelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTextboxes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(164, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.OnCloseClick);
            // 
            // lblParagraphsCount
            // 
            this.lblParagraphsCount.Location = new System.Drawing.Point(217, 92);
            this.lblParagraphsCount.Name = "lblParagraphsCount";
            this.lblParagraphsCount.Size = new System.Drawing.Size(0, 13);
            this.lblParagraphsCount.TabIndex = 17;
            // 
            // lblWithSpacesCharactersCount
            // 
            this.lblWithSpacesCharactersCount.Location = new System.Drawing.Point(217, 72);
            this.lblWithSpacesCharactersCount.Name = "lblWithSpacesCharactersCount";
            this.lblWithSpacesCharactersCount.Size = new System.Drawing.Size(0, 13);
            this.lblWithSpacesCharactersCount.TabIndex = 16;
            // 
            // lblNoSpacesCharactersCount
            // 
            this.lblNoSpacesCharactersCount.Location = new System.Drawing.Point(217, 52);
            this.lblNoSpacesCharactersCount.Name = "lblNoSpacesCharactersCount";
            this.lblNoSpacesCharactersCount.Size = new System.Drawing.Size(0, 13);
            this.lblNoSpacesCharactersCount.TabIndex = 15;
            // 
            // lblWordsCount
            // 
            this.lblWordsCount.Location = new System.Drawing.Point(217, 32);
            this.lblWordsCount.Name = "lblWordsCount";
            this.lblWordsCount.Size = new System.Drawing.Size(0, 13);
            this.lblWordsCount.TabIndex = 14;
            // 
            // chkIncludeTextboxes
            // 
            this.chkIncludeTextboxes.Location = new System.Drawing.Point(24, 111);
            this.chkIncludeTextboxes.Name = "chkIncludeTextboxes";
            this.chkIncludeTextboxes.Properties.Caption = "Include textboxes";
            this.chkIncludeTextboxes.Size = new System.Drawing.Size(111, 19);
            this.chkIncludeTextboxes.TabIndex = 13;
            this.chkIncludeTextboxes.CheckedChanged += new System.EventHandler(this.OnIncludeTextboxesCheckedChanged);
            // 
            // lblParagraphs
            // 
            this.lblParagraphs.Location = new System.Drawing.Point(24, 92);
            this.lblParagraphs.Name = "lblParagraphs";
            this.lblParagraphs.Size = new System.Drawing.Size(55, 13);
            this.lblParagraphs.TabIndex = 12;
            this.lblParagraphs.Text = "Paragraphs";
            // 
            // lblWithSpacesCharacters
            // 
            this.lblWithSpacesCharacters.Location = new System.Drawing.Point(24, 72);
            this.lblWithSpacesCharacters.Name = "lblWithSpacesCharacters";
            this.lblWithSpacesCharacters.Size = new System.Drawing.Size(120, 13);
            this.lblWithSpacesCharacters.TabIndex = 11;
            this.lblWithSpacesCharacters.Text = "Characters (with spaces)";
            // 
            // lblNoSpacesCharacters
            // 
            this.lblNoSpacesCharacters.Location = new System.Drawing.Point(24, 52);
            this.lblNoSpacesCharacters.Name = "lblNoSpacesCharacters";
            this.lblNoSpacesCharacters.Size = new System.Drawing.Size(112, 13);
            this.lblNoSpacesCharacters.TabIndex = 10;
            this.lblNoSpacesCharacters.Text = "Characters (no spaces)";
            // 
            // lblWords
            // 
            this.lblWords.Location = new System.Drawing.Point(24, 32);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(31, 13);
            this.lblWords.TabIndex = 9;
            this.lblWords.Text = "Words";
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.LineVisible = true;
            this.lblCaption.Location = new System.Drawing.Point(12, 12);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(227, 13);
            this.lblCaption.TabIndex = 18;
            this.lblCaption.Text = "Statistics";
            // 
            // DocumentStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 176);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblParagraphsCount);
            this.Controls.Add(this.lblWithSpacesCharactersCount);
            this.Controls.Add(this.lblNoSpacesCharactersCount);
            this.Controls.Add(this.lblWordsCount);
            this.Controls.Add(this.chkIncludeTextboxes);
            this.Controls.Add(this.lblParagraphs);
            this.Controls.Add(this.lblWithSpacesCharacters);
            this.Controls.Add(this.lblNoSpacesCharacters);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentStatisticsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTextboxes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XtraEditors.SimpleButton btnClose;
        private XtraEditors.LabelControl lblParagraphsCount;
        private XtraEditors.LabelControl lblWithSpacesCharactersCount;
        private XtraEditors.LabelControl lblNoSpacesCharactersCount;
        private XtraEditors.LabelControl lblWordsCount;
        private XtraEditors.CheckEdit chkIncludeTextboxes;
        private XtraEditors.LabelControl lblParagraphs;
        private XtraEditors.LabelControl lblWithSpacesCharacters;
        private XtraEditors.LabelControl lblNoSpacesCharacters;
        private XtraEditors.LabelControl lblWords;
        private XtraEditors.LabelControl lblCaption;
    }
}