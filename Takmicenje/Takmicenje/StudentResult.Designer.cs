﻿namespace Takmicenje
{
    partial class StudentResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cR = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cR
            // 
            this.cR.ActiveViewIndex = -1;
            this.cR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cR.Cursor = System.Windows.Forms.Cursors.Default;
            this.cR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cR.Location = new System.Drawing.Point(0, 0);
            this.cR.Name = "cR";
            this.cR.Size = new System.Drawing.Size(800, 450);
            this.cR.TabIndex = 0;
            // 
            // StudentResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cR);
            this.Name = "StudentResult";
            this.Text = "StudentResult";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cR;
    }
}