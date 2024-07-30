﻿namespace FVMI_INSPECTION.Controls
{
    partial class ConfigForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            statusLabel = new Label();
            button15 = new Button();
            label4 = new Label();
            portBox = new TextBox();
            label3 = new Label();
            ipBox = new TextBox();
            groupBox2 = new GroupBox();
            ngCameraDelay = new NumericUpDown();
            label6 = new Label();
            cameraTriggerDelay = new NumericUpDown();
            label5 = new Label();
            button1 = new Button();
            dashboardDelay = new NumericUpDown();
            settingParamDelay = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            button17 = new Button();
            label22 = new Label();
            backupReportLogPath = new TextBox();
            button16 = new Button();
            WhitePrefixBox = new TextBox();
            label21 = new Label();
            button14 = new Button();
            UVPrefixBox = new TextBox();
            label20 = new Label();
            button13 = new Button();
            uvCSVBox = new TextBox();
            label19 = new Label();
            button12 = new Button();
            label18 = new Label();
            whiteCSVBox = new TextBox();
            button11 = new Button();
            label17 = new Label();
            whiteImgBox = new TextBox();
            button10 = new Button();
            uvImgBox = new TextBox();
            label16 = new Label();
            button9 = new Button();
            label15 = new Label();
            csvPathBox = new TextBox();
            button8 = new Button();
            label12 = new Label();
            reportLogPath = new TextBox();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            label11 = new Label();
            debugLogPath = new TextBox();
            label10 = new Label();
            ftpCameraDir = new TextBox();
            label9 = new Label();
            markedImgSaveDir = new TextBox();
            label8 = new Label();
            ngImgSaveDir = new TextBox();
            label7 = new Label();
            triggerImgSaveDir = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox4 = new GroupBox();
            button2 = new Button();
            newPasswordBox = new TextBox();
            label14 = new Label();
            label13 = new Label();
            currentPasswordBox = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ngCameraDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraTriggerDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dashboardDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingParamDelay).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(button15);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(portBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(ipBox);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(384, 116);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(230, 27);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(42, 15);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Status:";
            // 
            // button15
            // 
            button15.Location = new Point(47, 82);
            button15.Name = "button15";
            button15.Size = new Size(75, 23);
            button15.TabIndex = 4;
            button15.Text = "Save";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 56);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 3;
            label4.Text = "Port:";
            // 
            // portBox
            // 
            portBox.Location = new Point(47, 53);
            portBox.Name = "portBox";
            portBox.Size = new Size(177, 23);
            portBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 27);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 1;
            label3.Text = "IP:";
            // 
            // ipBox
            // 
            ipBox.Location = new Point(47, 24);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(177, 23);
            ipBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(ngCameraDelay);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cameraTriggerDelay);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(dashboardDelay);
            groupBox2.Controls.Add(settingParamDelay);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(3, 122);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(378, 453);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delay Setting";
            // 
            // ngCameraDelay
            // 
            ngCameraDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ngCameraDelay.Location = new Point(182, 122);
            ngCameraDelay.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            ngCameraDelay.Name = "ngCameraDelay";
            ngCameraDelay.Size = new Size(190, 23);
            ngCameraDelay.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 124);
            label6.Name = "label6";
            label6.Size = new Size(170, 15);
            label6.TabIndex = 9;
            label6.Text = "Dashboard Camera Delay (Ng):";
            label6.Click += label6_Click;
            // 
            // cameraTriggerDelay
            // 
            cameraTriggerDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cameraTriggerDelay.Location = new Point(182, 95);
            cameraTriggerDelay.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            cameraTriggerDelay.Name = "cameraTriggerDelay";
            cameraTriggerDelay.Size = new Size(190, 23);
            cameraTriggerDelay.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 97);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 7;
            label5.Text = "Camera Trigger:";
            // 
            // button1
            // 
            button1.Location = new Point(182, 151);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dashboardDelay
            // 
            dashboardDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dashboardDelay.Location = new Point(182, 66);
            dashboardDelay.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            dashboardDelay.Name = "dashboardDelay";
            dashboardDelay.Size = new Size(190, 23);
            dashboardDelay.TabIndex = 3;
            // 
            // settingParamDelay
            // 
            settingParamDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            settingParamDelay.Location = new Point(182, 37);
            settingParamDelay.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            settingParamDelay.Name = "settingParamDelay";
            settingParamDelay.Size = new Size(190, 23);
            settingParamDelay.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 68);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Dashboard Process:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 39);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "Setting Parameter:";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(button17);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(backupReportLogPath);
            groupBox3.Controls.Add(button16);
            groupBox3.Controls.Add(WhitePrefixBox);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(button14);
            groupBox3.Controls.Add(UVPrefixBox);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(button13);
            groupBox3.Controls.Add(uvCSVBox);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(button12);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(whiteCSVBox);
            groupBox3.Controls.Add(button11);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(whiteImgBox);
            groupBox3.Controls.Add(button10);
            groupBox3.Controls.Add(uvImgBox);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(button9);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(csvPathBox);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(reportLogPath);
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(button5);
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(debugLogPath);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(ftpCameraDir);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(markedImgSaveDir);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(ngImgSaveDir);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(triggerImgSaveDir);
            groupBox3.Location = new Point(390, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(445, 447);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Directory Setting";
            // 
            // button17
            // 
            button17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button17.Location = new Point(365, 197);
            button17.Name = "button17";
            button17.Size = new Size(75, 23);
            button17.TabIndex = 42;
            button17.Tag = "BackupLogPath";
            button17.Text = "Change";
            button17.UseVisualStyleBackColor = true;
            button17.Click += openDialogFolder;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(6, 201);
            label22.Name = "label22";
            label22.Size = new Size(137, 15);
            label22.TabIndex = 41;
            label22.Text = "Backup Report Log Path:";
            // 
            // backupReportLogPath
            // 
            backupReportLogPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            backupReportLogPath.Location = new Point(144, 198);
            backupReportLogPath.Name = "backupReportLogPath";
            backupReportLogPath.ReadOnly = true;
            backupReportLogPath.Size = new Size(216, 23);
            backupReportLogPath.TabIndex = 40;
            backupReportLogPath.Tag = "BackupLogPath";
            // 
            // button16
            // 
            button16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button16.Location = new Point(364, 403);
            button16.Name = "button16";
            button16.Size = new Size(75, 23);
            button16.TabIndex = 39;
            button16.Tag = "CSVPath";
            button16.Text = "Change";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // WhitePrefixBox
            // 
            WhitePrefixBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WhitePrefixBox.Location = new Point(143, 403);
            WhitePrefixBox.Name = "WhitePrefixBox";
            WhitePrefixBox.Size = new Size(216, 23);
            WhitePrefixBox.TabIndex = 38;
            WhitePrefixBox.Tag = "CsvPath";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 412);
            label21.Name = "label21";
            label21.Size = new Size(71, 15);
            label21.TabIndex = 37;
            label21.Text = "White Prefix";
            // 
            // button14
            // 
            button14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button14.Location = new Point(364, 374);
            button14.Name = "button14";
            button14.Size = new Size(75, 23);
            button14.TabIndex = 36;
            button14.Tag = "CSVPath";
            button14.Text = "Change";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // UVPrefixBox
            // 
            UVPrefixBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UVPrefixBox.Location = new Point(143, 374);
            UVPrefixBox.Name = "UVPrefixBox";
            UVPrefixBox.Size = new Size(216, 23);
            UVPrefixBox.TabIndex = 35;
            UVPrefixBox.Tag = "CsvPath";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 383);
            label20.Name = "label20";
            label20.Size = new Size(58, 15);
            label20.TabIndex = 34;
            label20.Text = "UV Prefix:";
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button13.Location = new Point(365, 345);
            button13.Name = "button13";
            button13.Size = new Size(75, 23);
            button13.TabIndex = 33;
            button13.Tag = "UVCSVPath";
            button13.Text = "Change";
            button13.UseVisualStyleBackColor = true;
            button13.Click += openDialogFolder;
            // 
            // uvCSVBox
            // 
            uvCSVBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uvCSVBox.Location = new Point(144, 345);
            uvCSVBox.Name = "uvCSVBox";
            uvCSVBox.ReadOnly = true;
            uvCSVBox.Size = new Size(216, 23);
            uvCSVBox.TabIndex = 32;
            uvCSVBox.Tag = "CsvPath";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(7, 354);
            label19.Name = "label19";
            label19.Size = new Size(67, 15);
            label19.TabIndex = 31;
            label19.Text = "UV CSV Dir:";
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button12.Location = new Point(365, 286);
            button12.Name = "button12";
            button12.Size = new Size(75, 23);
            button12.TabIndex = 30;
            button12.Tag = "WhiteCSVPath";
            button12.Text = "Change";
            button12.UseVisualStyleBackColor = true;
            button12.Click += openDialogFolder;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(7, 290);
            label18.Name = "label18";
            label18.Size = new Size(83, 15);
            label18.TabIndex = 29;
            label18.Text = "White CSV Dir:";
            // 
            // whiteCSVBox
            // 
            whiteCSVBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            whiteCSVBox.Location = new Point(144, 287);
            whiteCSVBox.Name = "whiteCSVBox";
            whiteCSVBox.ReadOnly = true;
            whiteCSVBox.Size = new Size(216, 23);
            whiteCSVBox.TabIndex = 28;
            whiteCSVBox.Tag = "CsvPath";
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button11.Location = new Point(365, 257);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 27;
            button11.Tag = "WhiteImgPath";
            button11.Text = "Change";
            button11.UseVisualStyleBackColor = true;
            button11.Click += openDialogFolder;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, 261);
            label17.Name = "label17";
            label17.Size = new Size(95, 15);
            label17.TabIndex = 26;
            label17.Text = "White Image Dir:";
            // 
            // whiteImgBox
            // 
            whiteImgBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            whiteImgBox.Location = new Point(144, 258);
            whiteImgBox.Name = "whiteImgBox";
            whiteImgBox.ReadOnly = true;
            whiteImgBox.Size = new Size(216, 23);
            whiteImgBox.TabIndex = 25;
            whiteImgBox.Tag = "CsvPath";
            whiteImgBox.TextChanged += textBox2_TextChanged;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.Location = new Point(365, 316);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 24;
            button10.Tag = "UVImgPath";
            button10.Text = "Change";
            button10.UseVisualStyleBackColor = true;
            button10.Click += openDialogFolder;
            // 
            // uvImgBox
            // 
            uvImgBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uvImgBox.Location = new Point(144, 316);
            uvImgBox.Name = "uvImgBox";
            uvImgBox.ReadOnly = true;
            uvImgBox.Size = new Size(216, 23);
            uvImgBox.TabIndex = 23;
            uvImgBox.Tag = "CsvPath";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 325);
            label16.Name = "label16";
            label16.Size = new Size(79, 15);
            label16.TabIndex = 22;
            label16.Text = "UV Image Dir:";
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.Location = new Point(365, 227);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 21;
            button9.Tag = "CSVPath";
            button9.Text = "Change";
            button9.UseVisualStyleBackColor = true;
            button9.Click += openDialogFolder;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 231);
            label15.Name = "label15";
            label15.Size = new Size(93, 15);
            label15.TabIndex = 20;
            label15.Text = "CSV Result Path:";
            // 
            // csvPathBox
            // 
            csvPathBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            csvPathBox.Location = new Point(144, 228);
            csvPathBox.Name = "csvPathBox";
            csvPathBox.ReadOnly = true;
            csvPathBox.Size = new Size(216, 23);
            csvPathBox.TabIndex = 19;
            csvPathBox.Tag = "CsvPath";
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.Location = new Point(364, 168);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 18;
            button8.Tag = "LogPath";
            button8.Text = "Change";
            button8.UseVisualStyleBackColor = true;
            button8.Click += openDialogFolder;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 172);
            label12.Name = "label12";
            label12.Size = new Size(95, 15);
            label12.TabIndex = 17;
            label12.Text = "Report Log Path:";
            // 
            // reportLogPath
            // 
            reportLogPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            reportLogPath.Location = new Point(143, 169);
            reportLogPath.Name = "reportLogPath";
            reportLogPath.ReadOnly = true;
            reportLogPath.Size = new Size(216, 23);
            reportLogPath.TabIndex = 16;
            reportLogPath.Tag = "LogPath";
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(364, 139);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 15;
            button7.Tag = "DebugLogPath";
            button7.Text = "Change";
            button7.UseVisualStyleBackColor = true;
            button7.Click += openDialogFolder;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(364, 111);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 14;
            button6.Tag = "ImageDirName";
            button6.Text = "Change";
            button6.UseVisualStyleBackColor = true;
            button6.Click += openDialogFolder;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(364, 82);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 13;
            button5.Tag = "MarkSaveDir";
            button5.Text = "Change";
            button5.UseVisualStyleBackColor = true;
            button5.Click += openDialogFolder;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(364, 53);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 12;
            button4.Tag = "NgImageDirName";
            button4.Text = "Change";
            button4.UseVisualStyleBackColor = true;
            button4.Click += openDialogFolder;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(364, 23);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Tag = "SaveImageDirName";
            button3.Text = "Change";
            button3.UseVisualStyleBackColor = true;
            button3.Click += openDialogFolder;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 143);
            label11.Name = "label11";
            label11.Size = new Size(95, 15);
            label11.TabIndex = 9;
            label11.Text = "Debug Log Path:";
            // 
            // debugLogPath
            // 
            debugLogPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            debugLogPath.Location = new Point(143, 140);
            debugLogPath.Name = "debugLogPath";
            debugLogPath.ReadOnly = true;
            debugLogPath.Size = new Size(216, 23);
            debugLogPath.TabIndex = 8;
            debugLogPath.Tag = "DebugLogPath";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 114);
            label10.Name = "label10";
            label10.Size = new Size(91, 15);
            label10.TabIndex = 7;
            label10.Text = "FTP Camera Dir:";
            // 
            // ftpCameraDir
            // 
            ftpCameraDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ftpCameraDir.Location = new Point(143, 111);
            ftpCameraDir.Name = "ftpCameraDir";
            ftpCameraDir.ReadOnly = true;
            ftpCameraDir.Size = new Size(216, 23);
            ftpCameraDir.TabIndex = 6;
            ftpCameraDir.Tag = "ImageDirName";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 85);
            label9.Name = "label9";
            label9.Size = new Size(131, 15);
            label9.TabIndex = 5;
            label9.Text = "Marked Image Save Dir:";
            // 
            // markedImgSaveDir
            // 
            markedImgSaveDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            markedImgSaveDir.Location = new Point(143, 82);
            markedImgSaveDir.Name = "markedImgSaveDir";
            markedImgSaveDir.ReadOnly = true;
            markedImgSaveDir.Size = new Size(216, 23);
            markedImgSaveDir.TabIndex = 4;
            markedImgSaveDir.Tag = "MarkSaveDir";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 56);
            label8.Name = "label8";
            label8.Size = new Size(107, 15);
            label8.TabIndex = 3;
            label8.Text = "Ng Image Save Dir:";
            // 
            // ngImgSaveDir
            // 
            ngImgSaveDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ngImgSaveDir.Location = new Point(143, 53);
            ngImgSaveDir.Name = "ngImgSaveDir";
            ngImgSaveDir.ReadOnly = true;
            ngImgSaveDir.Size = new Size(216, 23);
            ngImgSaveDir.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 27);
            label7.Name = "label7";
            label7.Size = new Size(127, 15);
            label7.TabIndex = 1;
            label7.Text = "Trigger Image Save Dir:";
            // 
            // triggerImgSaveDir
            // 
            triggerImgSaveDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            triggerImgSaveDir.Location = new Point(143, 24);
            triggerImgSaveDir.Name = "triggerImgSaveDir";
            triggerImgSaveDir.ReadOnly = true;
            triggerImgSaveDir.Size = new Size(216, 23);
            triggerImgSaveDir.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(newPasswordBox);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(currentPasswordBox);
            groupBox4.Location = new Point(390, 458);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(439, 117);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Setting Parameter Password";
            // 
            // button2
            // 
            button2.Location = new Point(115, 77);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // newPasswordBox
            // 
            newPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newPasswordBox.Location = new Point(115, 49);
            newPasswordBox.Name = "newPasswordBox";
            newPasswordBox.Size = new Size(0, 23);
            newPasswordBox.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(22, 52);
            label14.Name = "label14";
            label14.Size = new Size(87, 15);
            label14.TabIndex = 2;
            label14.Text = "New Password:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 25);
            label13.Name = "label13";
            label13.Size = new Size(103, 15);
            label13.TabIndex = 1;
            label13.Text = "Current Password:";
            // 
            // currentPasswordBox
            // 
            currentPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            currentPasswordBox.Location = new Point(115, 22);
            currentPasswordBox.Name = "currentPasswordBox";
            currentPasswordBox.Size = new Size(0, 23);
            currentPasswordBox.TabIndex = 0;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ConfigForm";
            Size = new Size(838, 578);
            Load += ConfigForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ngCameraDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)cameraTriggerDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)dashboardDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingParamDelay).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button15;
        private Label label4;
        private TextBox portBox;
        private Label label3;
        private TextBox ipBox;
        private Label statusLabel;
        private GroupBox groupBox2;
        private Button button1;
        private NumericUpDown dashboardDelay;
        private NumericUpDown settingParamDelay;
        private Label label2;
        private Label label1;
        private NumericUpDown cameraTriggerDelay;
        private Label label5;
        private NumericUpDown ngCameraDelay;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox triggerImgSaveDir;
        private Label label7;
        private Label label8;
        private TextBox ngImgSaveDir;
        private Label label9;
        private TextBox markedImgSaveDir;
        private Label label10;
        private TextBox ftpCameraDir;
        private Label label11;
        private TextBox debugLogPath;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button8;
        private Label label12;
        private TextBox reportLogPath;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox4;
        private Button button2;
        private TextBox newPasswordBox;
        private Label label14;
        private Label label13;
        private TextBox currentPasswordBox;
        private Button button9;
        private Label label15;
        private TextBox csvPathBox;
        private Button button10;
        private TextBox uvImgBox;
        private Label label16;
        private Button button11;
        private Label label17;
        private TextBox whiteImgBox;
        private Button button12;
        private Label label18;
        private TextBox whiteCSVBox;
        private Button button13;
        private TextBox uvCSVBox;
        private Label label19;
        private Button button16;
        private TextBox WhitePrefixBox;
        private Label label21;
        private Button button14;
        private TextBox UVPrefixBox;
        private Label label20;
        private Button button17;
        private Label label22;
        private TextBox backupReportLogPath;
    }
}
