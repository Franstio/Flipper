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
            panel6 = new Panel();
            tableLayoutPanel12 = new TableLayoutPanel();
            groupBox11 = new GroupBox();
            panel3 = new Panel();
            textBox1 = new TextBox();
            groupBox4 = new GroupBox();
            panel10 = new Panel();
            scanLabel = new Label();
            groupBox5 = new GroupBox();
            panel11 = new Panel();
            processTimeLabel = new Label();
            groupBox3 = new GroupBox();
            inspectionListGridTopUVView = new DataGridView();
            AREA = new DataGridViewTextBoxColumn();
            JUDGEMENT = new DataGridViewTextBoxColumn();
            label6 = new Label();
            statusLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            finalJudgeLabel = new Label();
            processTimer = new System.Windows.Forms.Timer(components);
            timeLabel = new Label();
            groupBox6 = new GroupBox();
            panel1 = new Panel();
            label4 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox10 = new GroupBox();
            inspectionListGridBottomWhiteView = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            inspectionListGridTopWhiteView = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            groupBox9 = new GroupBox();
            inspectionListGridBottomUVView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            groupBox7 = new GroupBox();
            campointLabel = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            panel7 = new Panel();
            topUVDecision = new Label();
            topUV = new FVMIPictureBox();
            panel9 = new Panel();
            topWhiteDecision = new Label();
            topWhite = new FVMIPictureBox();
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
            panel4 = new Panel();
            bottomWhiteDecision = new Label();
            bottomWhite = new FVMIPictureBox();
            label11 = new Label();
            label10 = new Label();
            panel5 = new Panel();
            bottomUVDecision = new Label();
            bottomUV = new FVMIPictureBox();
            panel8 = new Panel();
            tableLayoutPanel11 = new TableLayoutPanel();
            panel2 = new Panel();
            button2 = new Button();
            tableLayoutPanel13 = new TableLayoutPanel();
            panel15 = new Panel();
            panel14 = new Panel();
            label3 = new Label();
            panel13 = new Panel();
            label2 = new Label();
            panel12 = new Panel();
            resetCheckTimer = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            groupBox11.SuspendLayout();
            panel3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel10.SuspendLayout();
            groupBox5.SuspendLayout();
            panel11.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridTopUVView).BeginInit();
            groupBox6.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridBottomWhiteView).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridTopWhiteView).BeginInit();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridBottomUVView).BeginInit();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)topUV).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)topWhite).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            groupBox8.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottomWhite).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottomUV).BeginInit();
            panel8.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            panel15.SuspendLayout();
            panel14.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            SuspendLayout();
            // 
            // runningModel
            // 
            runningModel.BackColor = Color.FromArgb(28, 154, 220);
            runningModel.Dock = DockStyle.Fill;
            runningModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            runningModel.Location = new Point(3, 23);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(214, 38);
            runningModel.TabIndex = 0;
            runningModel.Text = "-";
            runningModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(28, 154, 220);
            groupBox1.Controls.Add(panel6);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.Location = new Point(811, 250);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(220, 224);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Serial No.";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(28, 154, 220);
            panel6.Controls.Add(tableLayoutPanel12);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 22);
            panel6.Name = "panel6";
            panel6.Size = new Size(214, 200);
            panel6.TabIndex = 5;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 1;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Controls.Add(groupBox11, 0, 0);
            tableLayoutPanel12.Controls.Add(groupBox4, 0, 1);
            tableLayoutPanel12.Controls.Add(groupBox5, 0, 2);
            tableLayoutPanel12.Dock = DockStyle.Fill;
            tableLayoutPanel12.Location = new Point(0, 0);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 3;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel12.Size = new Size(214, 200);
            tableLayoutPanel12.TabIndex = 0;
            // 
            // groupBox11
            // 
            groupBox11.BackColor = Color.FromArgb(28, 154, 220);
            groupBox11.Controls.Add(panel3);
            groupBox11.Dock = DockStyle.Fill;
            groupBox11.Location = new Point(3, 3);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(208, 60);
            groupBox11.TabIndex = 0;
            groupBox11.TabStop = false;
            groupBox11.Text = "Scan Code";
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(202, 34);
            panel3.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 25);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(28, 154, 220);
            groupBox4.Controls.Add(panel10);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 69);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(208, 60);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "RUNNING S/N:";
            // 
            // panel10
            // 
            panel10.Controls.Add(scanLabel);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 23);
            panel10.Name = "panel10";
            panel10.Size = new Size(202, 34);
            panel10.TabIndex = 0;
            // 
            // scanLabel
            // 
            scanLabel.BackColor = Color.Yellow;
            scanLabel.Dock = DockStyle.Fill;
            scanLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            scanLabel.ForeColor = SystemColors.ControlText;
            scanLabel.Location = new Point(0, 0);
            scanLabel.Name = "scanLabel";
            scanLabel.Size = new Size(202, 34);
            scanLabel.TabIndex = 3;
            scanLabel.Text = "-";
            scanLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.FromArgb(28, 154, 220);
            groupBox5.Controls.Add(panel11);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(3, 135);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(208, 62);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Process Time";
            // 
            // panel11
            // 
            panel11.Controls.Add(processTimeLabel);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(3, 23);
            panel11.Name = "panel11";
            panel11.Size = new Size(202, 36);
            panel11.TabIndex = 0;
            // 
            // processTimeLabel
            // 
            processTimeLabel.BackColor = SystemColors.Menu;
            processTimeLabel.Dock = DockStyle.Fill;
            processTimeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            processTimeLabel.Location = new Point(0, 0);
            processTimeLabel.Name = "processTimeLabel";
            processTimeLabel.Size = new Size(202, 36);
            processTimeLabel.TabIndex = 13;
            processTimeLabel.Text = "00:00:00";
            processTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(inspectionListGridTopUVView);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(8, 410);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(302, 195);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top UV:";
            // 
            // inspectionListGridTopUVView
            // 
            inspectionListGridTopUVView.AllowUserToAddRows = false;
            inspectionListGridTopUVView.AllowUserToDeleteRows = false;
            inspectionListGridTopUVView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridTopUVView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            inspectionListGridTopUVView.BackgroundColor = SystemColors.Control;
            inspectionListGridTopUVView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridTopUVView.Columns.AddRange(new DataGridViewColumn[] { AREA, JUDGEMENT });
            inspectionListGridTopUVView.Dock = DockStyle.Fill;
            inspectionListGridTopUVView.Location = new Point(3, 24);
            inspectionListGridTopUVView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridTopUVView.Name = "inspectionListGridTopUVView";
            inspectionListGridTopUVView.ReadOnly = true;
            inspectionListGridTopUVView.RowHeadersWidth = 51;
            inspectionListGridTopUVView.RowTemplate.Height = 29;
            inspectionListGridTopUVView.Size = new Size(296, 169);
            inspectionListGridTopUVView.TabIndex = 0;
            inspectionListGridTopUVView.Tag = "TopUV";
            inspectionListGridTopUVView.CellDoubleClick += ShowNgPopup;
            // 
            // AREA
            // 
            AREA.HeaderText = "AREA";
            AREA.Name = "AREA";
            AREA.ReadOnly = true;
            // 
            // JUDGEMENT
            // 
            JUDGEMENT.HeaderText = "RESULT";
            JUDGEMENT.Name = "JUDGEMENT";
            JUDGEMENT.ReadOnly = true;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(208, 206, 206);
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            label6.Location = new Point(3, 3);
            label6.Name = "label6";
            label6.Size = new Size(135, 34);
            label6.TabIndex = 8;
            label6.Text = "No Log Available";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.FromArgb(208, 206, 206);
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            statusLabel.Location = new Point(3, 3);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(135, 35);
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
            finalJudgeLabel.Location = new Point(937, 7);
            finalJudgeLabel.Name = "finalJudgeLabel";
            finalJudgeLabel.Size = new Size(0, 86);
            finalJudgeLabel.TabIndex = 12;
            // 
            // processTimer
            // 
            processTimer.Interval = 1000;
            processTimer.Tick += processTimer_Tick;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.Font = new Font("Segoe UI", 10F);
            timeLabel.Location = new Point(811, 629);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(220, 19);
            timeLabel.TabIndex = 14;
            timeLabel.Text = "Date: Time:";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox6.BackColor = SystemColors.Control;
            groupBox6.Controls.Add(runningModel);
            groupBox6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox6.Location = new Point(811, 97);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(220, 64);
            groupBox6.TabIndex = 15;
            groupBox6.TabStop = false;
            groupBox6.Text = "Model";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 85);
            panel1.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(494, 82);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 28;
            label4.Text = "label4";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(921, 85);
            label1.TabIndex = 2;
            label1.Text = "AUTO INSPECTION MACHINE";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox10, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 3);
            tableLayoutPanel1.Controls.Add(groupBox9, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(318, 815);
            tableLayoutPanel1.TabIndex = 25;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(inspectionListGridBottomWhiteView);
            groupBox10.Dock = DockStyle.Fill;
            groupBox10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox10.Location = new Point(8, 8);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(3, 2, 3, 2);
            groupBox10.Size = new Size(302, 195);
            groupBox10.TabIndex = 9;
            groupBox10.TabStop = false;
            groupBox10.Text = "Bottom White:";
            // 
            // inspectionListGridBottomWhiteView
            // 
            inspectionListGridBottomWhiteView.AllowUserToAddRows = false;
            inspectionListGridBottomWhiteView.AllowUserToDeleteRows = false;
            inspectionListGridBottomWhiteView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridBottomWhiteView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            inspectionListGridBottomWhiteView.BackgroundColor = SystemColors.Control;
            inspectionListGridBottomWhiteView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridBottomWhiteView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            inspectionListGridBottomWhiteView.Dock = DockStyle.Fill;
            inspectionListGridBottomWhiteView.Location = new Point(3, 24);
            inspectionListGridBottomWhiteView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridBottomWhiteView.Name = "inspectionListGridBottomWhiteView";
            inspectionListGridBottomWhiteView.ReadOnly = true;
            inspectionListGridBottomWhiteView.RowHeadersWidth = 51;
            inspectionListGridBottomWhiteView.RowTemplate.Height = 29;
            inspectionListGridBottomWhiteView.Size = new Size(296, 169);
            inspectionListGridBottomWhiteView.TabIndex = 0;
            inspectionListGridBottomWhiteView.Tag = "BottomWhite";
            inspectionListGridBottomWhiteView.CellDoubleClick += ShowNgPopup;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "AREA";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "RESULT";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(inspectionListGridTopWhiteView);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox2.Location = new Point(8, 611);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(302, 196);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Top White:";
            // 
            // inspectionListGridTopWhiteView
            // 
            inspectionListGridTopWhiteView.AllowUserToAddRows = false;
            inspectionListGridTopWhiteView.AllowUserToDeleteRows = false;
            inspectionListGridTopWhiteView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridTopWhiteView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            inspectionListGridTopWhiteView.BackgroundColor = SystemColors.Control;
            inspectionListGridTopWhiteView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridTopWhiteView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            inspectionListGridTopWhiteView.Dock = DockStyle.Fill;
            inspectionListGridTopWhiteView.Location = new Point(3, 24);
            inspectionListGridTopWhiteView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridTopWhiteView.Name = "inspectionListGridTopWhiteView";
            inspectionListGridTopWhiteView.ReadOnly = true;
            inspectionListGridTopWhiteView.RowHeadersWidth = 51;
            inspectionListGridTopWhiteView.RowTemplate.Height = 29;
            inspectionListGridTopWhiteView.Size = new Size(296, 170);
            inspectionListGridTopWhiteView.TabIndex = 0;
            inspectionListGridTopWhiteView.Tag = "TopWhite";
            inspectionListGridTopWhiteView.CellDoubleClick += ShowNgPopup;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "AREA";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "RESULT";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(inspectionListGridBottomUVView);
            groupBox9.Dock = DockStyle.Fill;
            groupBox9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox9.Location = new Point(8, 209);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(3, 2, 3, 2);
            groupBox9.Size = new Size(302, 195);
            groupBox9.TabIndex = 5;
            groupBox9.TabStop = false;
            groupBox9.Text = "Bottom UV:";
            // 
            // inspectionListGridBottomUVView
            // 
            inspectionListGridBottomUVView.AllowUserToAddRows = false;
            inspectionListGridBottomUVView.AllowUserToDeleteRows = false;
            inspectionListGridBottomUVView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridBottomUVView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            inspectionListGridBottomUVView.BackgroundColor = SystemColors.Control;
            inspectionListGridBottomUVView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridBottomUVView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            inspectionListGridBottomUVView.Dock = DockStyle.Fill;
            inspectionListGridBottomUVView.Location = new Point(3, 24);
            inspectionListGridBottomUVView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridBottomUVView.Name = "inspectionListGridBottomUVView";
            inspectionListGridBottomUVView.ReadOnly = true;
            inspectionListGridBottomUVView.RowHeadersWidth = 51;
            inspectionListGridBottomUVView.RowTemplate.Height = 29;
            inspectionListGridBottomUVView.Size = new Size(296, 169);
            inspectionListGridBottomUVView.TabIndex = 0;
            inspectionListGridBottomUVView.Tag = "BottomUV";
            inspectionListGridBottomUVView.CellDoubleClick += ShowNgPopup;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "AREA";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "RESULT";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Gray;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(811, 697);
            button1.Name = "button1";
            button1.Size = new Size(220, 38);
            button1.TabIndex = 6;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox7.BackColor = SystemColors.Control;
            groupBox7.Controls.Add(campointLabel);
            groupBox7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox7.Location = new Point(811, 167);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(220, 66);
            groupBox7.TabIndex = 16;
            groupBox7.TabStop = false;
            groupBox7.Text = "Camera";
            // 
            // campointLabel
            // 
            campointLabel.BackColor = Color.FromArgb(28, 154, 220);
            campointLabel.Dock = DockStyle.Fill;
            campointLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
            campointLabel.Location = new Point(3, 23);
            campointLabel.Name = "campointLabel";
            campointLabel.Size = new Size(214, 40);
            campointLabel.TabIndex = 0;
            campointLabel.Text = "-";
            campointLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = Resources.dharma;
            pictureBox2.Location = new Point(1291, 6);
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
            pictureBox3.Location = new Point(1148, 7);
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
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 1, 1);
            tableLayoutPanel2.Controls.Add(panel7, 0, 0);
            tableLayoutPanel2.Controls.Add(panel9, 1, 0);
            tableLayoutPanel2.Location = new Point(0, 28);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 82.89963F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.1003723F));
            tableLayoutPanel2.Size = new Size(776, 343);
            tableLayoutPanel2.TabIndex = 20;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 286);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(382, 55);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(391, 286);
            tableLayoutPanel6.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(382, 55);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // panel7
            // 
            panel7.Controls.Add(topUVDecision);
            panel7.Controls.Add(topUV);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(382, 278);
            panel7.TabIndex = 8;
            // 
            // topUVDecision
            // 
            topUVDecision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            topUVDecision.BackColor = Color.Transparent;
            topUVDecision.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            topUVDecision.Location = new Point(233, 3);
            topUVDecision.Margin = new Padding(0);
            topUVDecision.Name = "topUVDecision";
            topUVDecision.RightToLeft = RightToLeft.Yes;
            topUVDecision.Size = new Size(136, 30);
            topUVDecision.TabIndex = 5;
            topUVDecision.Text = "-";
            topUVDecision.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topUV
            // 
            topUV.BackgroundColor = Color.White;
            topUV.BorderStyle = BorderStyle.FixedSingle;
            topUV.Dock = DockStyle.Fill;
            topUV.isActive = false;
            topUV.isHovering = false;
            topUV.Location = new Point(0, 0);
            topUV.Margin = new Padding(3, 2, 3, 2);
            topUV.MovPos = new Point(0, 0);
            topUV.Name = "topUV";
            topUV.Size = new Size(382, 278);
            topUV.SizeMode = PictureBoxSizeMode.StretchImage;
            topUV.StartPos = new Point(0, 0);
            topUV.TabIndex = 4;
            topUV.TabStop = false;
            topUV.ZoomIncrement = 0.01F;
            topUV.ZoomValue = 0F;
            // 
            // panel9
            // 
            panel9.Controls.Add(topWhiteDecision);
            panel9.Controls.Add(topWhite);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(391, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(382, 278);
            panel9.TabIndex = 9;
            // 
            // topWhiteDecision
            // 
            topWhiteDecision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            topWhiteDecision.BackColor = Color.Transparent;
            topWhiteDecision.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            topWhiteDecision.Location = new Point(233, 3);
            topWhiteDecision.Margin = new Padding(0);
            topWhiteDecision.Name = "topWhiteDecision";
            topWhiteDecision.RightToLeft = RightToLeft.Yes;
            topWhiteDecision.Size = new Size(136, 30);
            topWhiteDecision.TabIndex = 6;
            topWhiteDecision.Text = "-";
            topWhiteDecision.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topWhite
            // 
            topWhite.BackgroundColor = Color.White;
            topWhite.BorderStyle = BorderStyle.FixedSingle;
            topWhite.Dock = DockStyle.Fill;
            topWhite.isActive = false;
            topWhite.isHovering = false;
            topWhite.Location = new Point(0, 0);
            topWhite.Margin = new Padding(3, 2, 3, 2);
            topWhite.MovPos = new Point(0, 0);
            topWhite.Name = "topWhite";
            topWhite.Size = new Size(382, 278);
            topWhite.SizeMode = PictureBoxSizeMode.StretchImage;
            topWhite.StartPos = new Point(0, 0);
            topWhite.TabIndex = 5;
            topWhite.TabStop = false;
            topWhite.ZoomIncrement = 0.01F;
            topWhite.ZoomValue = 0F;
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
            tableLayoutPanel7.Size = new Size(776, 26);
            tableLayoutPanel7.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(391, 0);
            label7.Name = "label7";
            label7.Size = new Size(382, 26);
            label7.TabIndex = 1;
            label7.Text = "Top White";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(382, 26);
            label5.TabIndex = 0;
            label5.Text = "Top UV";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox8.Controls.Add(tableLayoutPanel8);
            groupBox8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox8.Location = new Point(811, 479);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(220, 48);
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
            tableLayoutPanel8.Size = new Size(214, 22);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // failCountLabel
            // 
            failCountLabel.AutoSize = true;
            failCountLabel.BackColor = SystemColors.Control;
            failCountLabel.Dock = DockStyle.Fill;
            failCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            failCountLabel.Location = new Point(74, 0);
            failCountLabel.Name = "failCountLabel";
            failCountLabel.Size = new Size(65, 22);
            failCountLabel.TabIndex = 5;
            failCountLabel.Text = "Fail: 0";
            failCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.BackColor = SystemColors.Control;
            quantityLabel.Dock = DockStyle.Fill;
            quantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            quantityLabel.Location = new Point(3, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(65, 22);
            quantityLabel.TabIndex = 4;
            quantityLabel.Text = "Count: 0";
            quantityLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yieldLabel
            // 
            yieldLabel.AutoSize = true;
            yieldLabel.BackColor = SystemColors.Control;
            yieldLabel.Dock = DockStyle.Fill;
            yieldLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            yieldLabel.Location = new Point(145, 0);
            yieldLabel.Name = "yieldLabel";
            yieldLabel.Size = new Size(66, 22);
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
            tableLayoutPanel10.Controls.Add(panel4, 0, 1);
            tableLayoutPanel10.Controls.Add(label11, 0, 0);
            tableLayoutPanel10.Controls.Add(label10, 1, 0);
            tableLayoutPanel10.Controls.Add(panel5, 1, 1);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.Size = new Size(776, 370);
            tableLayoutPanel10.TabIndex = 23;
            // 
            // panel4
            // 
            panel4.Controls.Add(bottomWhiteDecision);
            panel4.Controls.Add(bottomWhite);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 40);
            panel4.Name = "panel4";
            panel4.Size = new Size(382, 327);
            panel4.TabIndex = 28;
            // 
            // bottomWhiteDecision
            // 
            bottomWhiteDecision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bottomWhiteDecision.BackColor = Color.Transparent;
            bottomWhiteDecision.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bottomWhiteDecision.Location = new Point(233, 4);
            bottomWhiteDecision.Margin = new Padding(0);
            bottomWhiteDecision.Name = "bottomWhiteDecision";
            bottomWhiteDecision.RightToLeft = RightToLeft.Yes;
            bottomWhiteDecision.Size = new Size(136, 30);
            bottomWhiteDecision.TabIndex = 3;
            bottomWhiteDecision.Text = "-";
            bottomWhiteDecision.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottomWhite
            // 
            bottomWhite.BackgroundColor = Color.White;
            bottomWhite.BorderStyle = BorderStyle.FixedSingle;
            bottomWhite.Dock = DockStyle.Fill;
            bottomWhite.isActive = false;
            bottomWhite.isHovering = false;
            bottomWhite.Location = new Point(0, 0);
            bottomWhite.MovPos = new Point(0, 0);
            bottomWhite.Name = "bottomWhite";
            bottomWhite.Size = new Size(382, 327);
            bottomWhite.SizeMode = PictureBoxSizeMode.StretchImage;
            bottomWhite.StartPos = new Point(0, 0);
            bottomWhite.TabIndex = 2;
            bottomWhite.TabStop = false;
            bottomWhite.ZoomIncrement = 0.01F;
            bottomWhite.ZoomValue = 0F;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(382, 37);
            label11.TabIndex = 1;
            label11.Text = "Bottom White";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(391, 0);
            label10.Name = "label10";
            label10.Size = new Size(382, 37);
            label10.TabIndex = 0;
            label10.Text = "Bottom UV";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.Controls.Add(bottomUVDecision);
            panel5.Controls.Add(bottomUV);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(391, 40);
            panel5.Name = "panel5";
            panel5.Size = new Size(382, 327);
            panel5.TabIndex = 29;
            // 
            // bottomUVDecision
            // 
            bottomUVDecision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bottomUVDecision.BackColor = Color.Transparent;
            bottomUVDecision.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bottomUVDecision.Location = new Point(233, 4);
            bottomUVDecision.Margin = new Padding(0);
            bottomUVDecision.Name = "bottomUVDecision";
            bottomUVDecision.RightToLeft = RightToLeft.Yes;
            bottomUVDecision.Size = new Size(136, 30);
            bottomUVDecision.TabIndex = 4;
            bottomUVDecision.Text = "-";
            bottomUVDecision.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottomUV
            // 
            bottomUV.BackgroundColor = Color.White;
            bottomUV.BorderStyle = BorderStyle.FixedSingle;
            bottomUV.Dock = DockStyle.Fill;
            bottomUV.isActive = false;
            bottomUV.isHovering = false;
            bottomUV.Location = new Point(0, 0);
            bottomUV.MovPos = new Point(0, 0);
            bottomUV.Name = "bottomUV";
            bottomUV.Size = new Size(382, 327);
            bottomUV.SizeMode = PictureBoxSizeMode.StretchImage;
            bottomUV.StartPos = new Point(0, 0);
            bottomUV.TabIndex = 3;
            bottomUV.TabStop = false;
            bottomUV.ZoomIncrement = 0.01F;
            bottomUV.ZoomValue = 0F;
            // 
            // panel8
            // 
            panel8.Controls.Add(tableLayoutPanel7);
            panel8.Controls.Add(tableLayoutPanel2);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 379);
            panel8.Name = "panel8";
            panel8.Size = new Size(776, 371);
            panel8.TabIndex = 24;
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
            tableLayoutPanel11.Size = new Size(782, 753);
            tableLayoutPanel11.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Location = new Point(1037, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(335, 745);
            panel2.TabIndex = 27;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.Yellow;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(811, 651);
            button2.Name = "button2";
            button2.Size = new Size(220, 34);
            button2.TabIndex = 28;
            button2.Text = "Generate Log";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel13.Controls.Add(panel15, 1, 0);
            tableLayoutPanel13.Controls.Add(panel14, 0, 1);
            tableLayoutPanel13.Controls.Add(panel13, 0, 0);
            tableLayoutPanel13.Controls.Add(panel12, 1, 1);
            tableLayoutPanel13.Location = new Point(811, 533);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 2;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel13.Size = new Size(220, 93);
            tableLayoutPanel13.TabIndex = 29;
            // 
            // panel15
            // 
            panel15.Controls.Add(label6);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(76, 3);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(3);
            panel15.Size = new Size(141, 40);
            panel15.TabIndex = 3;
            // 
            // panel14
            // 
            panel14.Controls.Add(label3);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(3, 49);
            panel14.Name = "panel14";
            panel14.Padding = new Padding(3);
            panel14.Size = new Size(67, 41);
            panel14.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(61, 35);
            label3.TabIndex = 1;
            label3.Text = "Log File";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            panel13.Controls.Add(label2);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(3, 3);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(3);
            panel13.Size = new Size(67, 40);
            panel13.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(61, 34);
            label2.TabIndex = 0;
            label2.Text = "Status";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            panel12.Controls.Add(statusLabel);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(76, 49);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(3);
            panel12.Size = new Size(141, 41);
            panel12.TabIndex = 0;
            // 
            // resetCheckTimer
            // 
            resetCheckTimer.Interval = 2000;
            resetCheckTimer.Tick += resetCheckTimer_Tick;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel13);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel11);
            Controls.Add(groupBox8);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(timeLabel);
            Controls.Add(finalJudgeLabel);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DashboardControl";
            Size = new Size(1375, 863);
            Load += DashboardControl_Load;
            Leave += DashboardControl_Leave;
            groupBox1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel12.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox4.ResumeLayout(false);
            panel10.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            panel11.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridTopUVView).EndInit();
            groupBox6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridBottomWhiteView).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridTopWhiteView).EndInit();
            groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridBottomUVView).EndInit();
            groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)topUV).EndInit();
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)topWhite).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            groupBox8.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bottomWhite).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bottomUV).EndInit();
            panel8.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel12.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label runningModel;
        private GroupBox groupBox1;
        private Label scanLabel;
        private TextBox textBox1;
        private GroupBox groupBox3;
        private DataGridView inspectionListGridTopUVView;
        private Label label6;
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
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private FVMIPictureBox topUV;
        private FVMIPictureBox topWhite;
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
        private FVMIPictureBox bottomUV;
        private Label label11;
        private FVMIPictureBox bottomWhite;
        private Panel panel8;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox9;
        private DataGridView inspectionListGridBottomUVView;
        private TableLayoutPanel tableLayoutPanel11;
        private Button button1;
        private Panel panel2;
        private Label label4;
        private Panel panel4;
        private Label bottomWhiteDecision;
        private Panel panel5;
        private Label bottomUVDecision;
        private Panel panel7;
        private Label topUVDecision;
        private Panel panel9;
        private Label topWhiteDecision;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel12;
        private GroupBox groupBox11;
        private GroupBox groupBox10;
        private DataGridView inspectionListGridBottomWhiteView;
        private GroupBox groupBox2;
        private DataGridView inspectionListGridTopWhiteView;
        private Button button2;
        private Panel panel3;
        private GroupBox groupBox4;
        private Panel panel10;
        private GroupBox groupBox5;
        private Panel panel11;
        private TableLayoutPanel tableLayoutPanel13;
        private Panel panel15;
        private Panel panel14;
        private Label label3;
        private Panel panel13;
        private Label label2;
        private Panel panel12;
        private DataGridViewTextBoxColumn AREA;
        private DataGridViewTextBoxColumn JUDGEMENT;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Timer resetCheckTimer;
    }
}
