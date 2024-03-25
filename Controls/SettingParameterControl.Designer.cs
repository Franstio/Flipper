namespace FVMI_INSPECTION.Controls
{
    partial class SettingParameterControl
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
            groupBox5 = new GroupBox();
            button14 = new Button();
            camPoint = new NumericUpDown();
            camExecBoxTop = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            button3 = new Button();
            camExecBoxBottom = new TextBox();
            label7 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            button5 = new Button();
            button4 = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            button1 = new Button();
            delPos = new NumericUpDown();
            button2 = new Button();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            timeLabel = new Label();
            runningModel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            uploadFileDialog = new OpenFileDialog();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)camPoint).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)delPos).BeginInit();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox5.Controls.Add(button14);
            groupBox5.Controls.Add(camPoint);
            groupBox5.Location = new Point(674, 23);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(283, 79);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Camera Program";
            // 
            // button14
            // 
            button14.Location = new Point(11, 48);
            button14.Name = "button14";
            button14.Size = new Size(209, 23);
            button14.TabIndex = 1;
            button14.Text = "Set";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // camPoint
            // 
            camPoint.Location = new Point(11, 20);
            camPoint.Margin = new Padding(3, 2, 3, 2);
            camPoint.Name = "camPoint";
            camPoint.Size = new Size(209, 23);
            camPoint.TabIndex = 0;
            // 
            // camExecBoxTop
            // 
            camExecBoxTop.Location = new Point(114, 42);
            camExecBoxTop.Margin = new Padding(3, 2, 3, 2);
            camExecBoxTop.Name = "camExecBoxTop";
            camExecBoxTop.Size = new Size(110, 23);
            camExecBoxTop.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 45);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 2;
            label5.Text = "Camera Execution";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(26, 152);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(973, 602);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = "Setting Parameter";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(camExecBoxBottom);
            groupBox4.Controls.Add(label7);
            groupBox4.Location = new Point(14, 122);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(324, 93);
            groupBox4.TabIndex = 37;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bottom Position";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(230, 22);
            button3.Name = "button3";
            button3.Size = new Size(88, 53);
            button3.TabIndex = 5;
            button3.Text = "Set";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // camExecBoxBottom
            // 
            camExecBoxBottom.Location = new Point(114, 38);
            camExecBoxBottom.Margin = new Padding(3, 2, 3, 2);
            camExecBoxBottom.Name = "camExecBoxBottom";
            camExecBoxBottom.Size = new Size(110, 23);
            camExecBoxBottom.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 41);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 2;
            label7.Text = "Camera Execution";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button5, 0, 2);
            tableLayoutPanel2.Controls.Add(button4, 0, 2);
            tableLayoutPanel2.Controls.Add(pictureBox2, 1, 1);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel2.Location = new Point(11, 221);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Size = new Size(946, 367);
            tableLayoutPanel2.TabIndex = 35;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button5.Location = new Point(3, 332);
            button5.Name = "button5";
            button5.Size = new Size(467, 32);
            button5.TabIndex = 40;
            button5.Tag = "Top";
            button5.Text = "Upload";
            button5.UseVisualStyleBackColor = true;
            button5.Click += uploadEvent;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.Location = new Point(476, 332);
            button4.Name = "button4";
            button4.Size = new Size(467, 32);
            button4.TabIndex = 39;
            button4.Tag = "Bottom";
            button4.Text = "Upload";
            button4.UseVisualStyleBackColor = true;
            button4.Click += uploadEvent;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(476, 39);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(467, 287);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 38;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ImageAlign = ContentAlignment.TopRight;
            label2.Location = new Point(476, 0);
            label2.Name = "label2";
            label2.Size = new Size(467, 36);
            label2.TabIndex = 36;
            label2.Text = "Bottom";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ImageAlign = ContentAlignment.TopRight;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(467, 36);
            label1.TabIndex = 5;
            label1.Text = "Top";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(467, 287);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(camExecBoxTop);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(14, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(324, 93);
            groupBox3.TabIndex = 36;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top Position";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(230, 26);
            button1.Name = "button1";
            button1.Size = new Size(88, 53);
            button1.TabIndex = 5;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // delPos
            // 
            delPos.Dock = DockStyle.Fill;
            delPos.Font = new Font("Segoe UI", 10.8F);
            delPos.Location = new Point(241, 2);
            delPos.Margin = new Padding(3, 2, 3, 2);
            delPos.Name = "delPos";
            delPos.Size = new Size(232, 27);
            delPos.TabIndex = 33;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(479, 2);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(232, 28);
            button2.TabIndex = 30;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(26, 96);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(720, 52);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(delPos, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 18);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(714, 32);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ImageAlign = ContentAlignment.TopRight;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(232, 32);
            label3.TabIndex = 4;
            label3.Text = "Position:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(884, 20);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(36, 30);
            timeLabel.TabIndex = 25;
            timeLabel.Text = "Date:\r\nTime:";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // runningModel
            // 
            runningModel.AutoSize = true;
            runningModel.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic);
            runningModel.Location = new Point(339, 20);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(97, 32);
            runningModel.TabIndex = 24;
            runningModel.Text = "Model: ";
            runningModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // uploadFileDialog
            // 
            uploadFileDialog.FileName = "openFileDialog1";
            // 
            // SettingParameterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(timeLabel);
            Controls.Add(runningModel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SettingParameterControl";
            Size = new Size(1004, 776);
            Load += SettingParameterControl_Load;
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)camPoint).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)delPos).EndInit();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox5;
        private Button button14;
        private NumericUpDown camPoint;
        private TextBox camExecBoxTop;
        private Label label5;
        private GroupBox groupBox2;
        private NumericUpDown delPos;
        private Button button2;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label timeLabel;
        private Label runningModel;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button button3;
        private TextBox camExecBoxBottom;
        private Label label7;
        private Button button1;
        private Button button5;
        private Button button4;
        private OpenFileDialog uploadFileDialog;
    }
}
