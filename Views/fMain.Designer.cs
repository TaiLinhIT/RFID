namespace UHF_RFID_READER.Views
{
    partial class fMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_Dtgv1 = new System.Windows.Forms.Panel();
            this.SplDisplay = new System.Windows.Forms.SplitContainer();
            this.dtgvDisplayRecordDetails = new System.Windows.Forms.DataGridView();
            this.SplDisplayInfo = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOnlineTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDatabaseUsage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvDisplayCounts = new System.Windows.Forms.DataGridView();
            this.pnl_Dtgv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplDisplay)).BeginInit();
            this.SplDisplay.Panel1.SuspendLayout();
            this.SplDisplay.Panel2.SuspendLayout();
            this.SplDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDisplayRecordDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplDisplayInfo)).BeginInit();
            this.SplDisplayInfo.Panel1.SuspendLayout();
            this.SplDisplayInfo.Panel2.SuspendLayout();
            this.SplDisplayInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDisplayCounts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Dtgv1
            // 
            this.pnl_Dtgv1.Controls.Add(this.SplDisplay);
            this.pnl_Dtgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Dtgv1.Location = new System.Drawing.Point(0, 0);
            this.pnl_Dtgv1.Name = "pnl_Dtgv1";
            this.pnl_Dtgv1.Size = new System.Drawing.Size(1407, 696);
            this.pnl_Dtgv1.TabIndex = 0;
            // 
            // SplDisplay
            // 
            this.SplDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplDisplay.Location = new System.Drawing.Point(0, 0);
            this.SplDisplay.Name = "SplDisplay";
            // 
            // SplDisplay.Panel1
            // 
            this.SplDisplay.Panel1.Controls.Add(this.dtgvDisplayRecordDetails);
            // 
            // SplDisplay.Panel2
            // 
            this.SplDisplay.Panel2.Controls.Add(this.SplDisplayInfo);
            this.SplDisplay.Size = new System.Drawing.Size(1407, 696);
            this.SplDisplay.SplitterDistance = 1163;
            this.SplDisplay.TabIndex = 1;
            // 
            // dtgvDisplayRecordDetails
            // 
            this.dtgvDisplayRecordDetails.AllowUserToAddRows = false;
            this.dtgvDisplayRecordDetails.AllowUserToDeleteRows = false;
            this.dtgvDisplayRecordDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgvDisplayRecordDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgvDisplayRecordDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDisplayRecordDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDisplayRecordDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDisplayRecordDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvDisplayRecordDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDisplayRecordDetails.Location = new System.Drawing.Point(0, 0);
            this.dtgvDisplayRecordDetails.MultiSelect = false;
            this.dtgvDisplayRecordDetails.Name = "dtgvDisplayRecordDetails";
            this.dtgvDisplayRecordDetails.ReadOnly = true;
            this.dtgvDisplayRecordDetails.RowHeadersWidth = 11;
            this.dtgvDisplayRecordDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDisplayRecordDetails.Size = new System.Drawing.Size(1163, 696);
            this.dtgvDisplayRecordDetails.TabIndex = 0;
            // 
            // SplDisplayInfo
            // 
            this.SplDisplayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplDisplayInfo.Location = new System.Drawing.Point(0, 0);
            this.SplDisplayInfo.Name = "SplDisplayInfo";
            this.SplDisplayInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplDisplayInfo.Panel1
            // 
            this.SplDisplayInfo.Panel1.Controls.Add(this.panel2);
            this.SplDisplayInfo.Panel1.Controls.Add(this.panel1);
            // 
            // SplDisplayInfo.Panel2
            // 
            this.SplDisplayInfo.Panel2.Controls.Add(this.dtgvDisplayCounts);
            this.SplDisplayInfo.Size = new System.Drawing.Size(240, 696);
            this.SplDisplayInfo.SplitterDistance = 80;
            this.SplDisplayInfo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblOnlineTime);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 29);
            this.panel2.TabIndex = 4;
            // 
            // lblOnlineTime
            // 
            this.lblOnlineTime.AutoSize = true;
            this.lblOnlineTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOnlineTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblOnlineTime.Location = new System.Drawing.Point(180, 0);
            this.lblOnlineTime.Name = "lblOnlineTime";
            this.lblOnlineTime.Size = new System.Drawing.Size(20, 18);
            this.lblOnlineTime.TabIndex = 1;
            this.lblOnlineTime.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Online Time: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblDatabaseUsage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 29);
            this.panel1.TabIndex = 2;
            // 
            // lblDatabaseUsage
            // 
            this.lblDatabaseUsage.AutoSize = true;
            this.lblDatabaseUsage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDatabaseUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseUsage.Location = new System.Drawing.Point(172, 0);
            this.lblDatabaseUsage.Name = "lblDatabaseUsage";
            this.lblDatabaseUsage.Size = new System.Drawing.Size(28, 18);
            this.lblDatabaseUsage.TabIndex = 3;
            this.lblDatabaseUsage.Text = "....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usaged Database:";
            // 
            // dtgvDisplayCounts
            // 
            this.dtgvDisplayCounts.AllowUserToAddRows = false;
            this.dtgvDisplayCounts.AllowUserToDeleteRows = false;
            this.dtgvDisplayCounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgvDisplayCounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgvDisplayCounts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDisplayCounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvDisplayCounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDisplayCounts.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvDisplayCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDisplayCounts.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtgvDisplayCounts.Location = new System.Drawing.Point(0, 0);
            this.dtgvDisplayCounts.MultiSelect = false;
            this.dtgvDisplayCounts.Name = "dtgvDisplayCounts";
            this.dtgvDisplayCounts.ReadOnly = true;
            this.dtgvDisplayCounts.RowHeadersWidth = 10;
            this.dtgvDisplayCounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDisplayCounts.Size = new System.Drawing.Size(240, 612);
            this.dtgvDisplayCounts.TabIndex = 1;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 696);
            this.Controls.Add(this.pnl_Dtgv1);
            this.Name = "fMain";
            this.Text = "fMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.pnl_Dtgv1.ResumeLayout(false);
            this.SplDisplay.Panel1.ResumeLayout(false);
            this.SplDisplay.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplDisplay)).EndInit();
            this.SplDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDisplayRecordDetails)).EndInit();
            this.SplDisplayInfo.Panel1.ResumeLayout(false);
            this.SplDisplayInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplDisplayInfo)).EndInit();
            this.SplDisplayInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDisplayCounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Dtgv1;
        private System.Windows.Forms.DataGridView dtgvDisplayRecordDetails;
        private System.Windows.Forms.SplitContainer SplDisplay;
        private System.Windows.Forms.SplitContainer SplDisplayInfo;
        private System.Windows.Forms.Label lblOnlineTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatabaseUsage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvDisplayCounts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}