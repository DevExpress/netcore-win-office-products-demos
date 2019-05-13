﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace DevExpress.XtraSpreadsheet.Demos {
    public partial class FirstLookModule : Form {
        bool changing = false;

        public FirstLookModule() {
            InitializeComponent();
            spreadsheetControl1.Options.Culture = new CultureInfo("en-US");
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InvestmentPortfolio.xltx");
            spreadsheetControl1.LoadDocument(path);
            spreadsheetControl1.InvalidFormatException += spreadsheetControl1_InvalidFormatException;
            spreadsheetControl1.DocumentClosing += spreadsheetControl1_DocumentClosing;
            spreadsheetControl1.ActiveSheetChanged += spreadsheetControl1_ZoomChanged;
            spreadsheetControl1.ZoomChanged += spreadsheetControl1_ZoomChanged;
            spreadsheetControl1.SelectionChanged += spreadsheetControl1_SelectionChanged;
            edZoom.EditValueChanged += edZoom_EditValueChanged;

            spreadsheetControl1.CreateRibbon();
        }

        #region Properties
        //protected internal override RibbonPage SelectedRibbonPage { get { return homeRibbonPage1; } }
        #endregion

        void spreadsheetControl1_InvalidFormatException(object sender, SpreadsheetInvalidFormatExceptionEventArgs e) {
            XtraMessageBox.Show(string.Format("Cannot open the file '{0}' because the file format or file extension is not valid.\n" + 
                "Verify that file has not been corrupted and that the file extension matches the format of the file.", e.SourceUri), 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void spreadsheetControl1_DocumentClosing(object sender, CancelEventArgs e) {
            if (spreadsheetControl1.Modified) {
                string currentFileName = spreadsheetControl1.Options.Save.CurrentFileName;
                string message = !string.IsNullOrEmpty(currentFileName) ?
                    string.Format("Do you want to save the changes you made for '{0}'?", currentFileName) :
                    "Do you want to save the changes?";
                DialogResult result = XtraMessageBox.Show(message, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) {
                    e.Cancel = !spreadsheetControl1.SaveDocument();
                }
                else
                    e.Cancel = result == DialogResult.Cancel;
            }
        }

        void spreadsheetControl1_ZoomChanged(object sender, EventArgs e) {
            if (changing)
                return;
            changing = true;
            try {
                int zoomValue = spreadsheetControl1.ActiveViewZoom;
                edZoom.EditValue = zoomValue;
                edZoom.Caption = string.Format("{0}%", zoomValue);
            }
            finally {
                changing = false;
            }
        }

        void edZoom_EditValueChanged(object sender, EventArgs e) {
            if (changing)
                return;
            changing = true;
            try {
                int zoomValue = Convert.ToInt32(edZoom.EditValue);
                spreadsheetControl1.ActiveViewZoom = zoomValue;
                edZoom.Caption = string.Format("{0}%", zoomValue);
            }
            finally {
                changing = false;
            }
        }

        void spreadsheetControl1_SelectionChanged(object sender, EventArgs e) {
            int count = 0;
            double sum = 0.0;
            int numericCount = 0;
            Worksheet sheet = spreadsheetControl1.ActiveWorksheet;
            Spreadsheet.Range selectedCells = sheet.Selection.Intersect(sheet.GetDataRange());
            if (selectedCells != null) {
                foreach (Cell cell in selectedCells.ExistingCells) {
                    count++;
                    if (cell.Value.IsNumeric) {
                        numericCount++;
                        sum += cell.Value.NumericValue;
                    }
                }
            }
            if (count <= 1)
                lblSelection.Caption = string.Empty;
            else if (numericCount == 0)
                lblSelection.Caption = string.Format("Count: {0}", count);
            else {
                double average = sum / numericCount;
                lblSelection.Caption = string.Format(spreadsheetControl1.Options.Culture, 
                    "Average: {0:#0.######}  Count: {1}  Sum: {2}", average, count, sum);
            }
        }
    }
}
