namespace Takmicenje
{
    partial class AdministratorWindow
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
            this.name = new System.Windows.Forms.Label();
            this.surname = new System.Windows.Forms.Label();
            this.roomDataGrid = new System.Windows.Forms.DataGridView();
            this.roomLabel = new System.Windows.Forms.Label();
            this.addRoomBtn = new System.Windows.Forms.Button();
            this.deleteRoomBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.taskGridView = new System.Windows.Forms.DataGridView();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.roomDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Location = new System.Drawing.Point(17, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(63, 20);
            this.name.TabIndex = 0;
            this.name.Text = "Name: ";
            // 
            // surname
            // 
            this.surname.AutoSize = true;
            this.surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.surname.Location = new System.Drawing.Point(162, 12);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(86, 20);
            this.surname.TabIndex = 1;
            this.surname.Text = "Surname: ";
            // 
            // roomDataGrid
            // 
            this.roomDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.roomDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomDataGrid.Location = new System.Drawing.Point(27, 126);
            this.roomDataGrid.Name = "roomDataGrid";
            this.roomDataGrid.RowHeadersWidth = 51;
            this.roomDataGrid.RowTemplate.Height = 24;
            this.roomDataGrid.Size = new System.Drawing.Size(609, 260);
            this.roomDataGrid.TabIndex = 2;
            this.roomDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomDataGrid_CellClick);
            this.roomDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomDataGrid_CellContentClick);
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomLabel.Location = new System.Drawing.Point(24, 99);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(62, 20);
            this.roomLabel.TabIndex = 3;
            this.roomLabel.Text = "Rooms";
            // 
            // addRoomBtn
            // 
            this.addRoomBtn.Location = new System.Drawing.Point(30, 18);
            this.addRoomBtn.Name = "addRoomBtn";
            this.addRoomBtn.Size = new System.Drawing.Size(110, 39);
            this.addRoomBtn.TabIndex = 4;
            this.addRoomBtn.Text = "Add room";
            this.addRoomBtn.UseVisualStyleBackColor = true;
            this.addRoomBtn.Click += new System.EventHandler(this.addRoomBtn_Click);
            // 
            // deleteRoomBtn
            // 
            this.deleteRoomBtn.Location = new System.Drawing.Point(266, 15);
            this.deleteRoomBtn.Name = "deleteRoomBtn";
            this.deleteRoomBtn.Size = new System.Drawing.Size(98, 39);
            this.deleteRoomBtn.TabIndex = 5;
            this.deleteRoomBtn.Text = "Delete room";
            this.deleteRoomBtn.UseVisualStyleBackColor = true;
            this.deleteRoomBtn.Click += new System.EventHandler(this.deleteRoomBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(465, 16);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(114, 39);
            this.openBtn.TabIndex = 6;
            this.openBtn.Text = "Open room";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // taskGridView
            // 
            this.taskGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.taskGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGridView.Location = new System.Drawing.Point(642, 126);
            this.taskGridView.Name = "taskGridView";
            this.taskGridView.RowHeadersWidth = 51;
            this.taskGridView.RowTemplate.Height = 24;
            this.taskGridView.Size = new System.Drawing.Size(547, 260);
            this.taskGridView.TabIndex = 7;
            this.taskGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskGrid_CellClick);
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(22, 16);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(97, 39);
            this.addTaskBtn.TabIndex = 8;
            this.addTaskBtn.Text = "Add task";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "Delete task";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Open task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.surname);
            this.panel1.Controls.Add(this.name);
            this.panel1.Location = new System.Drawing.Point(27, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 49);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(638, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tasks";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.openBtn);
            this.panel2.Controls.Add(this.addRoomBtn);
            this.panel2.Controls.Add(this.deleteRoomBtn);
            this.panel2.Location = new System.Drawing.Point(27, 392);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 73);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.addTaskBtn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(642, 392);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 73);
            this.panel3.TabIndex = 14;
            // 
            // AdministratorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1220, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.taskGridView);
            this.Controls.Add(this.roomLabel);
            this.Controls.Add(this.roomDataGrid);
            this.Name = "AdministratorWindow";
            this.Text = "AdministratorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.roomDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label surname;
        private System.Windows.Forms.DataGridView roomDataGrid;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.Button addRoomBtn;
        private System.Windows.Forms.Button deleteRoomBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.DataGridView taskGridView;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}