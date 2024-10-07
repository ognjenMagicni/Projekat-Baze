namespace Takmicenje
{
    partial class InputOutputForm
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
            this.iOGrid = new System.Windows.Forms.DataGridView();
            this.nameSurname = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iOGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iOGrid
            // 
            this.iOGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iOGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.iOGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iOGrid.Location = new System.Drawing.Point(28, 97);
            this.iOGrid.Name = "iOGrid";
            this.iOGrid.RowHeadersWidth = 51;
            this.iOGrid.RowTemplate.Height = 24;
            this.iOGrid.Size = new System.Drawing.Size(771, 377);
            this.iOGrid.TabIndex = 0;
            // 
            // nameSurname
            // 
            this.nameSurname.AutoSize = true;
            this.nameSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameSurname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nameSurname.Location = new System.Drawing.Point(100, 19);
            this.nameSurname.Name = "nameSurname";
            this.nameSurname.Size = new System.Drawing.Size(58, 22);
            this.nameSurname.TabIndex = 1;
            this.nameSurname.Text = "label1";
            // 
            // roomName
            // 
            this.roomName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roomName.AutoSize = true;
            this.roomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomName.Location = new System.Drawing.Point(680, 19);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(58, 22);
            this.roomName.TabIndex = 2;
            this.roomName.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.roomName);
            this.panel1.Controls.Add(this.nameSurname);
            this.panel1.Location = new System.Drawing.Point(28, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 66);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(612, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Room:";
            // 
            // InputOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(833, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iOGrid);
            this.Name = "InputOutputForm";
            this.Text = "InputOutputForm";
            ((System.ComponentModel.ISupportInitialize)(this.iOGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView iOGrid;
        private System.Windows.Forms.Label nameSurname;
        private System.Windows.Forms.Label roomName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}