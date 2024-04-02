using FVMI_INSPECTION.Properties;

namespace FVMI_INSPECTION.Controls
{
    partial class DashboardControl
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
            components = new System.ComponentModel.Container();
            runningModel = new Label();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            panel6 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            scanLabel = new Label();
            groupBox2 = new GroupBox();
            panel7 = new Panel();
            labeld = new Label();
            panel5 = new Panel();
            bottomDecisionLabel = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            topDecisionLabel = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            inspectionListGridView = new DataGridView();
            AREA = new DataGridViewTextBoxColumn();
            JUDGEMENT = new DataGridViewTextBoxColumn();
            groupBox4 = new GroupBox();
            label6 = new Label();
            groupBox5 = new GroupBox();
            statusLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            finalJudgeLabel = new Label();
            processTimeLabel = new Label();
            processTimer = new System.Windows.Forms.Timer(components);
            timeLabel = new Label();
            groupBox6 = new GroupBox();
            panel1 = new Panel();
            label1 = new Label();
            groupBox7 = new GroupBox();
            campointLabel = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            actualTop = new PictureBox();
            actualBottom = new PictureBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label7 = new Label();
            label5 = new Label();
            groupBox8 = new GroupBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            failCountLabel = new Label();
            quantityLabel = new Label();
            yieldLabel = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            label8 = new Label();
            label9 = new Label();
            tableLayoutPanel10 = new TableLayoutPanel();
            parameterBottom = new PictureBox();
            label11 = new Label();
            label10 = new Label();
            parameterTop = new PictureBox();
            panel8 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            groupBox9 = new GroupBox();
            bottomInspectionGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            tableLayoutPanel11 = new TableLayoutPanel();
            groupBox1.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridView).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            panel1.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)actualTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)actualBottom).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            groupBox8.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)parameterBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)parameterTop).BeginInit();
            panel8.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottomInspectionGridView).BeginInit();
            tableLayoutPanel11.SuspendLayout();
            SuspendLayout();
            // 
            // runningModel
            // 
            runningModel.BackColor = Color.MediumTurquoise;
            runningModel.Dock = DockStyle.Fill;
            runningModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            runningModel.Location = new Point(3, 23);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(222, 38);
            runningModel.TabIndex = 0;
            runningModel.Text = "-";
            runningModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(panel6);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.Location = new Point(667, 250);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(228, 137);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Serial No.";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBox1.Location = new Point(6, 46);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 25);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // panel6
            // 
            panel6.BackColor = Color.MediumTurquoise;
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(panel3);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 22);
            panel6.Name = "panel6";
            panel6.Size = new Size(222, 113);
            panel6.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.MediumTurquoise;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(74, 4);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 1;
            label2.Text = "Scan Code";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.MediumTurquoise;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(53, 66);
            label3.Name = "label3";
            label3.Size = new Size(108, 19);
            label3.TabIndex = 2;
            label3.Text = "RUNNING S/N:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(scanLabel);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 87);
            panel3.Name = "panel3";
            panel3.Size = new Size(222, 26);
            panel3.TabIndex = 4;
            // 
            // scanLabel
            // 
            scanLabel.BackColor = Color.Transparent;
            scanLabel.Dock = DockStyle.Fill;
            scanLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            scanLabel.ForeColor = SystemColors.Highlight;
            scanLabel.Location = new Point(0, 0);
            scanLabel.Name = "scanLabel";
            scanLabel.Size = new Size(222, 26);
            scanLabel.TabIndex = 3;
            scanLabel.Text = "-";
            scanLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(panel7);
            groupBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox2.Location = new Point(667, 392);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(228, 125);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inspection";
            // 
            // panel7
            // 
            panel7.BackColor = Color.MediumTurquoise;
            panel7.Controls.Add(labeld);
            panel7.Controls.Add(panel5);
            panel7.Controls.Add(panel4);
            panel7.Controls.Add(label4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 22);
            panel7.Name = "panel7";
            panel7.Size = new Size(222, 101);
            panel7.TabIndex = 20;
            // 
            // labeld
            // 
            labeld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labeld.AutoSize = true;
            labeld.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labeld.Location = new Point(53, 47);
            labeld.Name = "labeld";
            labeld.Size = new Size(123, 19);
            labeld.TabIndex = 6;
            labeld.Text = "Bottom Decision:";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(bottomDecisionLabel);
            panel5.Controls.Add(panel2);
            panel5.Location = new Point(3, 76);
            panel5.Name = "panel5";
            panel5.Size = new Size(219, 25);
            panel5.TabIndex = 9;
            // 
            // bottomDecisionLabel
            // 
            bottomDecisionLabel.BackColor = Color.MediumTurquoise;
            bottomDecisionLabel.Dock = DockStyle.Fill;
            bottomDecisionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bottomDecisionLabel.ForeColor = Color.Lime;
            bottomDecisionLabel.Location = new Point(0, 0);
            bottomDecisionLabel.Name = "bottomDecisionLabel";
            bottomDecisionLabel.Size = new Size(219, 25);
            bottomDecisionLabel.TabIndex = 7;
            bottomDecisionLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 31);
            panel2.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(topDecisionLabel);
            panel4.Location = new Point(3, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 17);
            panel4.TabIndex = 8;
            // 
            // topDecisionLabel
            // 
            topDecisionLabel.BackColor = Color.MediumTurquoise;
            topDecisionLabel.Dock = DockStyle.Fill;
            topDecisionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            topDecisionLabel.Location = new Point(0, 0);
            topDecisionLabel.Name = "topDecisionLabel";
            topDecisionLabel.Size = new Size(220, 17);
            topDecisionLabel.TabIndex = 5;
            topDecisionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(62, 6);
            label4.Name = "label4";
            label4.Size = new Size(98, 19);
            label4.TabIndex = 4;
            label4.Text = "Top Decision:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(inspectionListGridView);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(8, 8);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(307, 227);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top Inspection List:";
            // 
            // inspectionListGridView
            // 
            inspectionListGridView.AllowUserToAddRows = false;
            inspectionListGridView.AllowUserToDeleteRows = false;
            inspectionListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            inspectionListGridView.BackgroundColor = SystemColors.Control;
            inspectionListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridView.Columns.AddRange(new DataGridViewColumn[] { AREA, JUDGEMENT });
            inspectionListGridView.Dock = DockStyle.Fill;
            inspectionListGridView.Location = new Point(3, 24);
            inspectionListGridView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridView.Name = "inspectionListGridView";
            inspectionListGridView.ReadOnly = true;
            inspectionListGridView.RowHeadersWidth = 51;
            inspectionListGridView.RowTemplate.Height = 29;
            inspectionListGridView.Size = new Size(301, 201);
            inspectionListGridView.TabIndex = 0;
            inspectionListGridView.Tag = "TOP";
            inspectionListGridView.CellDoubleClick += ShowNgPopup;
            // 
            // AREA
            // 
            AREA.HeaderText = "AREA";
            AREA.Name = "AREA";
            AREA.ReadOnly = true;
            // 
            // JUDGEMENT
            // 
            JUDGEMENT.HeaderText = "JUDGEMENT";
            JUDGEMENT.Name = "JUDGEMENT";
            JUDGEMENT.ReadOnly = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox4.Controls.Add(label6);
            groupBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox4.Location = new Point(905, 638);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(304, 50);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Log File:";
            // 
            // label6
            // 
            label6.BackColor = Color.LightGreen;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            label6.Location = new Point(3, 24);
            label6.Name = "label6";
            label6.Size = new Size(298, 24);
            label6.TabIndex = 8;
            label6.Text = "No Log Available";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox5.Controls.Add(statusLabel);
            groupBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox5.Location = new Point(668, 670);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(227, 55);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Status:";
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.LightGreen;
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            statusLabel.Location = new Point(3, 24);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(221, 29);
            statusLabel.TabIndex = 8;
            statusLabel.Text = "log1123445.txt";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // finalJudgeLabel
            // 
            finalJudgeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            finalJudgeLabel.AutoSize = true;
            finalJudgeLabel.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            finalJudgeLabel.Location = new Point(793, 7);
            finalJudgeLabel.Name = "finalJudgeLabel";
            finalJudgeLabel.Size = new Size(0, 86);
            finalJudgeLabel.TabIndex = 12;
            // 
            // processTimeLabel
            // 
            processTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            processTimeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            processTimeLabel.Location = new Point(670, 644);
            processTimeLabel.Name = "processTimeLabel";
            processTimeLabel.Size = new Size(228, 31);
            processTimeLabel.TabIndex = 13;
            processTimeLabel.Text = "Process Time: 00:00:00";
            processTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // processTimer
            // 
            processTimer.Interval = 1000;
            processTimer.Tick += processTimer_Tick;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 10F);
            timeLabel.Location = new Point(905, 691);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(41, 38);
            timeLabel.TabIndex = 14;
            timeLabel.Text = "Date:\r\nTime:";
            timeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox6.BackColor = SystemColors.Control;
            groupBox6.Controls.Add(runningModel);
            groupBox6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox6.Location = new Point(667, 97);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(228, 64);
            groupBox6.TabIndex = 15;
            groupBox6.TabStop = false;
            groupBox6.Text = "Model";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(777, 85);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(777, 85);
            label1.TabIndex = 2;
            label1.Text = "FVMI INSPECTION MACHINE";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox7.BackColor = SystemColors.Control;
            groupBox7.Controls.Add(campointLabel);
            groupBox7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox7.Location = new Point(667, 167);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(229, 66);
            groupBox7.TabIndex = 16;
            groupBox7.TabStop = false;
            groupBox7.Text = "Camera";
            // 
            // campointLabel
            // 
            campointLabel.BackColor = Color.MediumTurquoise;
            campointLabel.Dock = DockStyle.Fill;
            campointLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
            campointLabel.Location = new Point(3, 23);
            campointLabel.Name = "campointLabel";
            campointLabel.Size = new Size(223, 40);
            campointLabel.TabIndex = 0;
            campointLabel.Text = "-";
            campointLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = Resources.dharma;
            pictureBox2.Location = new Point(1147, 6);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 85);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.Image = Resources.flex;
            pictureBox3.Location = new Point(1004, 7);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(137, 85);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(actualTop, 0, 0);
            tableLayoutPanel2.Controls.Add(actualBottom, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 1, 1);
            tableLayoutPanel2.Location = new Point(0, 28);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 82.89963F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.1003723F));
            tableLayoutPanel2.Size = new Size(632, 275);
            tableLayoutPanel2.TabIndex = 20;
            // 
            // actualTop
            // 
            actualTop.BorderStyle = BorderStyle.FixedSingle;
            actualTop.Dock = DockStyle.Fill;
            actualTop.Location = new Point(3, 2);
            actualTop.Margin = new Padding(3, 2, 3, 2);
            actualTop.Name = "actualTop";
            actualTop.Size = new Size(310, 223);
            actualTop.SizeMode = PictureBoxSizeMode.StretchImage;
            actualTop.TabIndex = 4;
            actualTop.TabStop = false;
            // 
            // actualBottom
            // 
            actualBottom.BorderStyle = BorderStyle.FixedSingle;
            actualBottom.Dock = DockStyle.Fill;
            actualBottom.Location = new Point(319, 2);
            actualBottom.Margin = new Padding(3, 2, 3, 2);
            actualBottom.Name = "actualBottom";
            actualBottom.Size = new Size(310, 223);
            actualBottom.SizeMode = PictureBoxSizeMode.StretchImage;
            actualBottom.TabIndex = 5;
            actualBottom.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 229);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(310, 44);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(319, 229);
            tableLayoutPanel6.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(310, 44);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(200, 100);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(label7, 1, 0);
            tableLayoutPanel7.Controls.Add(label5, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Top;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(632, 26);
            tableLayoutPanel7.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(319, 0);
            label7.Name = "label7";
            label7.Size = new Size(310, 26);
            label7.TabIndex = 1;
            label7.Text = "Actual Bottom";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(310, 26);
            label5.TabIndex = 0;
            label5.Text = "Actual Top";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox8.Controls.Add(tableLayoutPanel8);
            groupBox8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox8.Location = new Point(668, 522);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(222, 77);
            groupBox8.TabIndex = 22;
            groupBox8.TabStop = false;
            groupBox8.Text = "Counter";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.Controls.Add(failCountLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(quantityLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(yieldLabel, 2, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 23);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(216, 51);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // failCountLabel
            // 
            failCountLabel.AutoSize = true;
            failCountLabel.BackColor = SystemColors.Control;
            failCountLabel.Dock = DockStyle.Fill;
            failCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            failCountLabel.Location = new Point(74, 0);
            failCountLabel.Name = "failCountLabel";
            failCountLabel.Size = new Size(65, 51);
            failCountLabel.TabIndex = 5;
            failCountLabel.Text = "Fail: 0";
            failCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.BackColor = SystemColors.Control;
            quantityLabel.Dock = DockStyle.Fill;
            quantityLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            quantityLabel.Location = new Point(3, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(65, 51);
            quantityLabel.TabIndex = 4;
            quantityLabel.Text = "Count: 0";
            quantityLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yieldLabel
            // 
            yieldLabel.AutoSize = true;
            yieldLabel.BackColor = SystemColors.Control;
            yieldLabel.Dock = DockStyle.Fill;
            yieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            yieldLabel.Location = new Point(145, 0);
            yieldLabel.Name = "yieldLabel";
            yieldLabel.Size = new Size(68, 51);
            yieldLabel.TabIndex = 2;
            yieldLabel.Text = "Yield: 0%";
            yieldLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(label8, 1, 0);
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.Size = new Size(200, 100);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(103, 0);
            label8.Name = "label8";
            label8.Size = new Size(94, 100);
            label8.TabIndex = 1;
            label8.Text = "NG Bottom";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(94, 100);
            label9.TabIndex = 0;
            label9.Text = "NG Top";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Controls.Add(parameterBottom, 1, 1);
            tableLayoutPanel10.Controls.Add(label11, 1, 0);
            tableLayoutPanel10.Controls.Add(label10, 0, 0);
            tableLayoutPanel10.Controls.Add(parameterTop, 0, 1);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.Size = new Size(632, 303);
            tableLayoutPanel10.TabIndex = 23;
            // 
            // parameterBottom
            // 
            parameterBottom.BorderStyle = BorderStyle.FixedSingle;
            parameterBottom.Dock = DockStyle.Fill;
            parameterBottom.Location = new Point(319, 33);
            parameterBottom.Name = "parameterBottom";
            parameterBottom.Size = new Size(310, 267);
            parameterBottom.SizeMode = PictureBoxSizeMode.StretchImage;
            parameterBottom.TabIndex = 3;
            parameterBottom.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.Location = new Point(319, 0);
            label11.Name = "label11";
            label11.Size = new Size(310, 30);
            label11.TabIndex = 1;
            label11.Text = "Bottom";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(310, 30);
            label10.TabIndex = 0;
            label10.Text = "Top";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // parameterTop
            // 
            parameterTop.BorderStyle = BorderStyle.FixedSingle;
            parameterTop.Dock = DockStyle.Fill;
            parameterTop.Location = new Point(3, 33);
            parameterTop.Name = "parameterTop";
            parameterTop.Size = new Size(310, 267);
            parameterTop.SizeMode = PictureBoxSizeMode.StretchImage;
            parameterTop.TabIndex = 2;
            parameterTop.TabStop = false;
            // 
            // panel8
            // 
            panel8.Controls.Add(tableLayoutPanel7);
            panel8.Controls.Add(tableLayoutPanel2);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 312);
            panel8.Name = "panel8";
            panel8.Size = new Size(632, 303);
            panel8.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(button1, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox9, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Location = new Point(902, 104);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(323, 529);
            tableLayoutPanel1.TabIndex = 25;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(8, 474);
            button1.Name = "button1";
            button1.Size = new Size(307, 47);
            button1.TabIndex = 6;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(bottomInspectionGridView);
            groupBox9.Dock = DockStyle.Fill;
            groupBox9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox9.Location = new Point(8, 241);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(3, 2, 3, 2);
            groupBox9.Size = new Size(307, 227);
            groupBox9.TabIndex = 5;
            groupBox9.TabStop = false;
            groupBox9.Text = "Bottom Inspection List:";
            // 
            // bottomInspectionGridView
            // 
            bottomInspectionGridView.AllowUserToAddRows = false;
            bottomInspectionGridView.AllowUserToDeleteRows = false;
            bottomInspectionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bottomInspectionGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            bottomInspectionGridView.BackgroundColor = SystemColors.Control;
            bottomInspectionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bottomInspectionGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            bottomInspectionGridView.Dock = DockStyle.Fill;
            bottomInspectionGridView.Location = new Point(3, 24);
            bottomInspectionGridView.Margin = new Padding(3, 2, 3, 2);
            bottomInspectionGridView.Name = "bottomInspectionGridView";
            bottomInspectionGridView.ReadOnly = true;
            bottomInspectionGridView.RowHeadersWidth = 51;
            bottomInspectionGridView.RowTemplate.Height = 29;
            bottomInspectionGridView.Size = new Size(301, 201);
            bottomInspectionGridView.TabIndex = 0;
            bottomInspectionGridView.Tag = "BOTTOM";
            bottomInspectionGridView.CellDoubleClick += ShowNgPopup;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "AREA";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "JUDGEMENT";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Controls.Add(tableLayoutPanel10, 0, 0);
            tableLayoutPanel11.Controls.Add(panel8, 0, 1);
            tableLayoutPanel11.Location = new Point(23, 107);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 2;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new Size(638, 618);
            tableLayoutPanel11.TabIndex = 26;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel11);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(groupBox8);
            Controls.Add(processTimeLabel);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(timeLabel);
            Controls.Add(finalJudgeLabel);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DashboardControl";
            Size = new Size(1231, 728);
            Load += DashboardControl_Load;
            Leave += DashboardControl_Leave;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridView).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)actualTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)actualBottom).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            groupBox8.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)parameterBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)parameterTop).EndInit();
            panel8.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bottomInspectionGridView).EndInit();
            tableLayoutPanel11.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label runningModel;
        private GroupBox groupBox1;
        private Label scanLabel;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private Label bottomDecisionLabel;
        private Label labeld;
        private Label label4;
        private GroupBox groupBox3;
        private DataGridView inspectionListGridView;
        private GroupBox groupBox4;
        private Label label6;
        private GroupBox groupBox5;
        private Label statusLabel;
        private System.Windows.Forms.Timer timer1;
        private Label finalJudgeLabel;
        private Label processTimeLabel;
        private System.Windows.Forms.Timer processTimer;
        private Label timeLabel;
        private GroupBox groupBox6;
        private Panel panel1;
        private Label label1;
        private GroupBox groupBox7;
        private Label campointLabel;
        private Panel panel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private Label topDecisionLabel;
        private Panel panel6;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox actualTop;
        private PictureBox actualBottom;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label7;
        private Label label5;
        private GroupBox groupBox8;
        private Label quantityLabel;
        private TableLayoutPanel tableLayoutPanel8;
        private Label failCountLabel;
        private Label yieldLabel;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label8;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel10;
        private Label label10;
        private PictureBox parameterBottom;
        private Label label11;
        private PictureBox parameterTop;
        private DataGridViewTextBoxColumn AREA;
        private DataGridViewTextBoxColumn JUDGEMENT;
        private Panel panel8;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox9;
        private DataGridView bottomInspectionGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private TableLayoutPanel tableLayoutPanel11;
        private Button button1;
    }
}
