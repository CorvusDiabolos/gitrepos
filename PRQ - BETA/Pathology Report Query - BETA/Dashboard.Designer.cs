namespace Pathology_Report_Query___BETA
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.stopWatchText = new System.Windows.Forms.Label();
            this.rowCount = new System.Windows.Forms.Label();
            this.loadingBar = new System.Windows.Forms.PictureBox();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.excelGlowButton = new GlowingButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchStopButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.slideButton = new System.Windows.Forms.Button();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.phiModeButton = new System.Windows.Forms.Button();
            this.phiModeLabel = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.andKeywordBox = new System.Windows.Forms.TextBox();
            this.orKeywordBox = new System.Windows.Forms.TextBox();
            this.notKeywordBox = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.addendaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prefixComboBox = new Pathology_Report_Query___BETA.CustomComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DateToButton = new System.Windows.Forms.Button();
            this.dateFromButton = new System.Windows.Forms.Button();
            this.endDateTextBox = new System.Windows.Forms.TextBox();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.slideTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.endDatePicker = new System.Windows.Forms.MonthCalendar();
            this.startDatePicker = new System.Windows.Forms.MonthCalendar();
            this.resultsGrid = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.searchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.searchNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBar)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.slidePanel.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Indigo;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.stopWatchText);
            this.panelHeader.Controls.Add(this.rowCount);
            this.panelHeader.Controls.Add(this.loadingBar);
            this.panelHeader.Controls.Add(this.keywordTextBox);
            this.panelHeader.Controls.Add(this.headerLabel);
            this.panelHeader.Controls.Add(this.MinimizeButton);
            this.panelHeader.Controls.Add(this.MaximizeButton);
            this.panelHeader.Controls.Add(this.CloseButton);
            this.panelHeader.Controls.Add(this.panel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(933, 36);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDoubleClick);
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // stopWatchText
            // 
            this.stopWatchText.AutoSize = true;
            this.stopWatchText.BackColor = System.Drawing.Color.Transparent;
            this.stopWatchText.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopWatchText.ForeColor = System.Drawing.Color.White;
            this.stopWatchText.Location = new System.Drawing.Point(506, 6);
            this.stopWatchText.Name = "stopWatchText";
            this.stopWatchText.Size = new System.Drawing.Size(182, 51);
            this.stopWatchText.TabIndex = 14;
            this.stopWatchText.Text = "00:00:00";
            this.stopWatchText.Visible = false;
            // 
            // rowCount
            // 
            this.rowCount.AutoSize = true;
            this.rowCount.BackColor = System.Drawing.Color.Transparent;
            this.rowCount.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCount.ForeColor = System.Drawing.Color.White;
            this.rowCount.Location = new System.Drawing.Point(345, 6);
            this.rowCount.Name = "rowCount";
            this.rowCount.Size = new System.Drawing.Size(331, 51);
            this.rowCount.TabIndex = 10;
            this.rowCount.Text = "Rows: 9,999,999";
            this.rowCount.Visible = false;
            // 
            // loadingBar
            // 
            this.loadingBar.BackColor = System.Drawing.Color.Transparent;
            this.loadingBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadingBar.Image = global::Pathology_Report_Query___BETA.Properties.Resources.ajax_loader_bert;
            this.loadingBar.Location = new System.Drawing.Point(360, 11);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(128, 15);
            this.loadingBar.TabIndex = 13;
            this.loadingBar.TabStop = false;
            this.loadingBar.Visible = false;
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.keywordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.keywordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keywordTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keywordTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.keywordTextBox.Location = new System.Drawing.Point(115, 7);
            this.keywordTextBox.MaxLength = 126;
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(219, 47);
            this.keywordTextBox.TabIndex = 8;
            this.keywordTextBox.Text = "diagnosis keyword here";
            this.keywordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.keywordTextBox.Enter += new System.EventHandler(this.keywordTextBox_Enter);
            this.keywordTextBox.Leave += new System.EventHandler(this.keywordTextBox_Leave);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headerLabel.Location = new System.Drawing.Point(45, 6);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(105, 49);
            this.headerLabel.TabIndex = 7;
            this.headerLabel.Text = "PRQ";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Indigo;
            this.MinimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinimizeButton.BackgroundImage")));
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Location = new System.Drawing.Point(843, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(30, 36);
            this.MinimizeButton.TabIndex = 4;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.BackColor = System.Drawing.Color.Indigo;
            this.MaximizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaximizeButton.BackgroundImage")));
            this.MaximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MaximizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Location = new System.Drawing.Point(873, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(30, 36);
            this.MaximizeButton.TabIndex = 3;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Indigo;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(903, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 36);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 36);
            this.panel1.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Indigo;
            this.leftPanel.Controls.Add(this.excelGlowButton);
            this.leftPanel.Controls.Add(this.panel5);
            this.leftPanel.Controls.Add(this.refreshButton);
            this.leftPanel.Controls.Add(this.panel4);
            this.leftPanel.Controls.Add(this.searchStopButton);
            this.leftPanel.Controls.Add(this.panel3);
            this.leftPanel.Controls.Add(this.slideButton);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 36);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.leftPanel.Size = new System.Drawing.Size(45, 488);
            this.leftPanel.TabIndex = 4;
            // 
            // excelGlowButton
            // 
            this.excelGlowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.excelGlowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("excelGlowButton.BackgroundImage")));
            this.excelGlowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.excelGlowButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.excelGlowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelGlowButton.ForeColor = System.Drawing.Color.White;
            this.excelGlowButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(99)))), ((int)(((byte)(50)))));
            this.excelGlowButton.Location = new System.Drawing.Point(0, 155);
            this.excelGlowButton.MouseDownBackColor = System.Drawing.Color.Green;
            this.excelGlowButton.Name = "excelGlowButton";
            this.excelGlowButton.Size = new System.Drawing.Size(45, 28);
            this.excelGlowButton.TabIndex = 16;
            this.excelGlowButton.UseVisualStyleBackColor = false;
            this.excelGlowButton.Visible = false;
            this.excelGlowButton.Click += new System.EventHandler(this.excelGlowButton_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 133);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(45, 22);
            this.panel5.TabIndex = 14;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Indigo;
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(0, 105);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(45, 28);
            this.refreshButton.TabIndex = 13;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(45, 22);
            this.panel4.TabIndex = 12;
            // 
            // searchStopButton
            // 
            this.searchStopButton.BackColor = System.Drawing.Color.Indigo;
            this.searchStopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchStopButton.BackgroundImage")));
            this.searchStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchStopButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchStopButton.FlatAppearance.BorderSize = 0;
            this.searchStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchStopButton.Location = new System.Drawing.Point(0, 55);
            this.searchStopButton.Name = "searchStopButton";
            this.searchStopButton.Size = new System.Drawing.Size(45, 28);
            this.searchStopButton.TabIndex = 11;
            this.searchStopButton.UseVisualStyleBackColor = false;
            this.searchStopButton.Click += new System.EventHandler(this.searchStopButton_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(45, 22);
            this.panel3.TabIndex = 1;
            // 
            // slideButton
            // 
            this.slideButton.BackColor = System.Drawing.Color.Indigo;
            this.slideButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slideButton.BackgroundImage")));
            this.slideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.slideButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.slideButton.FlatAppearance.BorderSize = 0;
            this.slideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slideButton.Location = new System.Drawing.Point(0, 5);
            this.slideButton.Name = "slideButton";
            this.slideButton.Size = new System.Drawing.Size(45, 28);
            this.slideButton.TabIndex = 0;
            this.slideButton.UseVisualStyleBackColor = false;
            this.slideButton.Click += new System.EventHandler(this.slideButton_Click);
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.Color.Indigo;
            this.slidePanel.Controls.Add(this.panel12);
            this.slidePanel.Controls.Add(this.panel11);
            this.slidePanel.Controls.Add(this.panel8);
            this.slidePanel.Controls.Add(this.panel10);
            this.slidePanel.Controls.Add(this.panel9);
            this.slidePanel.Controls.Add(this.panel7);
            this.slidePanel.Controls.Add(this.panel6);
            this.slidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidePanel.Location = new System.Drawing.Point(45, 36);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(186, 488);
            this.slidePanel.TabIndex = 5;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.phiModeButton);
            this.panel12.Controls.Add(this.phiModeLabel);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 389);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(186, 99);
            this.panel12.TabIndex = 25;
            // 
            // phiModeButton
            // 
            this.phiModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phiModeButton.BackColor = System.Drawing.Color.Indigo;
            this.phiModeButton.BackgroundImage = global::Pathology_Report_Query___BETA.Properties.Resources.icons8_switch_on_32;
            this.phiModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.phiModeButton.FlatAppearance.BorderSize = 0;
            this.phiModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.phiModeButton.Location = new System.Drawing.Point(132, 49);
            this.phiModeButton.Name = "phiModeButton";
            this.phiModeButton.Size = new System.Drawing.Size(35, 40);
            this.phiModeButton.TabIndex = 27;
            this.phiModeButton.UseVisualStyleBackColor = false;
            this.phiModeButton.Click += new System.EventHandler(this.phiModeButton_Click);
            // 
            // phiModeLabel
            // 
            this.phiModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.phiModeLabel.AutoSize = true;
            this.phiModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.phiModeLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phiModeLabel.ForeColor = System.Drawing.Color.White;
            this.phiModeLabel.Location = new System.Drawing.Point(49, 15);
            this.phiModeLabel.Name = "phiModeLabel";
            this.phiModeLabel.Size = new System.Drawing.Size(261, 45);
            this.phiModeLabel.TabIndex = 26;
            this.phiModeLabel.Text = "phi mode on";
            this.phiModeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 388);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(186, 1);
            this.panel11.TabIndex = 24;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.andKeywordBox);
            this.panel8.Controls.Add(this.orKeywordBox);
            this.panel8.Controls.Add(this.notKeywordBox);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 181);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(186, 207);
            this.panel8.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(103, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 45);
            this.label6.TabIndex = 19;
            this.label6.Text = "dx \'not\'";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(116, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 45);
            this.label5.TabIndex = 18;
            this.label5.Text = "dx \'or\'";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(96, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 45);
            this.label4.TabIndex = 17;
            this.label4.Text = "dx \'and\'";
            // 
            // andKeywordBox
            // 
            this.andKeywordBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.andKeywordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.andKeywordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.andKeywordBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.andKeywordBox.ForeColor = System.Drawing.Color.White;
            this.andKeywordBox.Location = new System.Drawing.Point(18, 31);
            this.andKeywordBox.MaxLength = 126;
            this.andKeywordBox.Name = "andKeywordBox";
            this.andKeywordBox.Size = new System.Drawing.Size(157, 47);
            this.andKeywordBox.TabIndex = 16;
            this.andKeywordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // orKeywordBox
            // 
            this.orKeywordBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.orKeywordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.orKeywordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orKeywordBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orKeywordBox.ForeColor = System.Drawing.Color.White;
            this.orKeywordBox.Location = new System.Drawing.Point(18, 89);
            this.orKeywordBox.MaxLength = 126;
            this.orKeywordBox.Name = "orKeywordBox";
            this.orKeywordBox.Size = new System.Drawing.Size(157, 47);
            this.orKeywordBox.TabIndex = 15;
            this.orKeywordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // notKeywordBox
            // 
            this.notKeywordBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.notKeywordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.notKeywordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notKeywordBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notKeywordBox.ForeColor = System.Drawing.Color.White;
            this.notKeywordBox.Location = new System.Drawing.Point(18, 147);
            this.notKeywordBox.MaxLength = 126;
            this.notKeywordBox.Name = "notKeywordBox";
            this.notKeywordBox.Size = new System.Drawing.Size(157, 47);
            this.notKeywordBox.TabIndex = 14;
            this.notKeywordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 180);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(186, 1);
            this.panel10.TabIndex = 18;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.addendaButton);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.prefixComboBox);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 100);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(186, 80);
            this.panel9.TabIndex = 16;
            // 
            // addendaButton
            // 
            this.addendaButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addendaButton.BackColor = System.Drawing.Color.Indigo;
            this.addendaButton.BackgroundImage = global::Pathology_Report_Query___BETA.Properties.Resources.icons8_unchecked_checkbox_32;
            this.addendaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addendaButton.FlatAppearance.BorderSize = 0;
            this.addendaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addendaButton.Location = new System.Drawing.Point(151, 46);
            this.addendaButton.Name = "addendaButton";
            this.addendaButton.Size = new System.Drawing.Size(28, 28);
            this.addendaButton.TabIndex = 21;
            this.addendaButton.UseVisualStyleBackColor = false;
            this.addendaButton.Click += new System.EventHandler(this.addendaButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 45);
            this.label2.TabIndex = 20;
            this.label2.Text = "prefix";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 45);
            this.label1.TabIndex = 19;
            this.label1.Text = "+ addenda";
            // 
            // prefixComboBox
            // 
            this.prefixComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.prefixComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.prefixComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.prefixComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.prefixComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prefixComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prefixComboBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefixComboBox.ForeColor = System.Drawing.Color.White;
            this.prefixComboBox.FormattingEnabled = true;
            this.prefixComboBox.Items.AddRange(new object[] {
            "AU",
            "BM",
            "BT",
            "CB",
            "CG",
            "CN",
            "CT",
            "FA",
            "GA",
            "GG",
            "GR",
            "GT",
            "HP",
            "MO",
            "NG",
            "NP",
            "OC",
            "PF",
            "RO",
            "RX",
            "SP",
            "SR",
            "TH",
            "TR",
            "TX",
            "UF"});
            this.prefixComboBox.Location = new System.Drawing.Point(82, 10);
            this.prefixComboBox.Name = "prefixComboBox";
            this.prefixComboBox.Size = new System.Drawing.Size(92, 53);
            this.prefixComboBox.Sorted = true;
            this.prefixComboBox.TabIndex = 16;
            this.prefixComboBox.SelectedIndexChanged += new System.EventHandler(this.prefixComboBox_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 99);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(186, 1);
            this.panel7.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.DateToButton);
            this.panel6.Controls.Add(this.dateFromButton);
            this.panel6.Controls.Add(this.endDateTextBox);
            this.panel6.Controls.Add(this.startDateTextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(186, 99);
            this.panel6.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(63, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 45);
            this.label3.TabIndex = 18;
            this.label3.Text = "date range";
            // 
            // DateToButton
            // 
            this.DateToButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateToButton.BackColor = System.Drawing.Color.Indigo;
            this.DateToButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DateToButton.BackgroundImage")));
            this.DateToButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DateToButton.FlatAppearance.BorderSize = 0;
            this.DateToButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateToButton.Location = new System.Drawing.Point(10, 64);
            this.DateToButton.Name = "DateToButton";
            this.DateToButton.Size = new System.Drawing.Size(34, 28);
            this.DateToButton.TabIndex = 17;
            this.DateToButton.UseVisualStyleBackColor = false;
            this.DateToButton.Click += new System.EventHandler(this.DateToButton_Click);
            // 
            // dateFromButton
            // 
            this.dateFromButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFromButton.BackColor = System.Drawing.Color.Indigo;
            this.dateFromButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dateFromButton.BackgroundImage")));
            this.dateFromButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dateFromButton.FlatAppearance.BorderSize = 0;
            this.dateFromButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateFromButton.Location = new System.Drawing.Point(10, 29);
            this.dateFromButton.Name = "dateFromButton";
            this.dateFromButton.Size = new System.Drawing.Size(34, 28);
            this.dateFromButton.TabIndex = 16;
            this.dateFromButton.UseVisualStyleBackColor = false;
            this.dateFromButton.Click += new System.EventHandler(this.dateFromButton_Click);
            // 
            // endDateTextBox
            // 
            this.endDateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.endDateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.endDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endDateTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.endDateTextBox.Location = new System.Drawing.Point(50, 65);
            this.endDateTextBox.MaxLength = 10;
            this.endDateTextBox.Name = "endDateTextBox";
            this.endDateTextBox.Size = new System.Drawing.Size(125, 47);
            this.endDateTextBox.TabIndex = 10;
            this.endDateTextBox.Text = "mm/dd/yyyy";
            this.endDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.endDateTextBox.Enter += new System.EventHandler(this.endDateTextBox_Enter);
            this.endDateTextBox.Leave += new System.EventHandler(this.endDateTextBox_Leave);
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startDateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.startDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startDateTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.startDateTextBox.Location = new System.Drawing.Point(50, 31);
            this.startDateTextBox.MaxLength = 10;
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.Size = new System.Drawing.Size(125, 47);
            this.startDateTextBox.TabIndex = 14;
            this.startDateTextBox.Text = "mm/dd/yyyy";
            this.startDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startDateTextBox.Enter += new System.EventHandler(this.startDateTextBox_Enter);
            this.startDateTextBox.Leave += new System.EventHandler(this.startDateTextBox_Leave);
            // 
            // slideTimer
            // 
            this.slideTimer.Tick += new System.EventHandler(this.slideTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.endDatePicker);
            this.panel2.Controls.Add(this.startDatePicker);
            this.panel2.Controls.Add(this.resultsGrid);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(231, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(702, 488);
            this.panel2.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.endDatePicker.ForeColor = System.Drawing.Color.White;
            this.endDatePicker.Location = new System.Drawing.Point(1, 64);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.TabIndex = 7;
            this.endDatePicker.TitleBackColor = System.Drawing.Color.SlateBlue;
            this.endDatePicker.TitleForeColor = System.Drawing.Color.White;
            this.endDatePicker.Visible = false;
            this.endDatePicker.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.endDatePicker_DateSelected);
            // 
            // startDatePicker
            // 
            this.startDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.startDatePicker.ForeColor = System.Drawing.Color.White;
            this.startDatePicker.Location = new System.Drawing.Point(0, 29);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.TabIndex = 6;
            this.startDatePicker.TitleBackColor = System.Drawing.Color.SlateBlue;
            this.startDatePicker.TitleForeColor = System.Drawing.Color.White;
            this.startDatePicker.Visible = false;
            this.startDatePicker.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.startDatePicker_DateSelected);
            // 
            // resultsGrid
            // 
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.resultsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.resultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGrid.EnableHeadersVisualStyles = false;
            this.resultsGrid.GridColor = System.Drawing.Color.DimGray;
            this.resultsGrid.Location = new System.Drawing.Point(10, 10);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.resultsGrid.RowHeadersVisible = false;
            this.resultsGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.resultsGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.resultsGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateBlue;
            this.resultsGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.resultsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsGrid.Size = new System.Drawing.Size(682, 468);
            this.resultsGrid.TabIndex = 9;
            this.resultsGrid.Visible = false;
            this.resultsGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.resultsGrid_UserDeletedRow);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(317, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 419);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // searchTimer
            // 
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // searchBackgroundWorker
            // 
            this.searchBackgroundWorker.WorkerReportsProgress = true;
            this.searchBackgroundWorker.WorkerSupportsCancellation = true;
            this.searchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchBackgroundWorker_DoWork);
            this.searchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchBackgroundWorker_RunWorkerCompleted);
            // 
            // searchNotifyIcon
            // 
            this.searchNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.searchNotifyIcon.BalloonTipTitle = "PRQ";
            this.searchNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("searchNotifyIcon.Icon")));
            this.searchNotifyIcon.Text = "Pathology Case Retrieval";
            this.searchNotifyIcon.Visible = true;
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(936, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.slidePanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(944, 250);
            this.Name = "Dashboard";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Dashboard_Shown);
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBar)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.slidePanel.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button slideButton;
        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.Timer slideTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button searchStopButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.TextBox endDateTextBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.Button dateFromButton;
        private System.Windows.Forms.Button DateToButton;
        private System.Windows.Forms.MonthCalendar startDatePicker;
        private System.Windows.Forms.MonthCalendar endDatePicker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GlowingButton excelGlowButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox loadingBar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button addendaButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomComboBox prefixComboBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox andKeywordBox;
        private System.Windows.Forms.TextBox orKeywordBox;
        private System.Windows.Forms.TextBox notKeywordBox;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer searchTimer;
        private System.ComponentModel.BackgroundWorker searchBackgroundWorker;
        private System.Windows.Forms.DataGridView resultsGrid;
        private System.Windows.Forms.Label rowCount;
        private System.Windows.Forms.Label stopWatchText;
        private System.Windows.Forms.NotifyIcon searchNotifyIcon;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button phiModeButton;
        private System.Windows.Forms.Label phiModeLabel;
    }
}

