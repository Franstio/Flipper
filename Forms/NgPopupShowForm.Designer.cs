
using FVMI_INSPECTION.Controls;

namespace FVMI_INSPECTION.Forms
{
    partial class NgPopupShowForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            button2 = new Button();
            actualPictureBox = new FVMIPictureBox();
            areaLabel = new Label();
            parameterPictureBox = new FVMIPictureBox();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)actualPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)parameterPictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button2, 1, 2);
            tableLayoutPanel1.Controls.Add(actualPictureBox, 1, 1);
            tableLayoutPanel1.Controls.Add(areaLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(parameterPictureBox, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(918, 648);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkRed;
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(462, 553);
            button2.Name = "button2";
            button2.Size = new Size(453, 92);
            button2.TabIndex = 4;
            button2.Tag = "NG";
            button2.Text = "NG";
            button2.UseVisualStyleBackColor = false;
            button2.Click += UpdateStatus;
            // 
            // actualPictureBox
            // 
            actualPictureBox.Dock = DockStyle.Fill;
            actualPictureBox.Location = new Point(462, 100);
            actualPictureBox.Name = "actualPictureBox";
            actualPictureBox.Size = new Size(453, 447);
            actualPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            actualPictureBox.TabIndex = 2;
            actualPictureBox.TabStop = false;
            // 
            // areaLabel
            // 
            tableLayoutPanel1.SetColumnSpan(areaLabel, 2);
            areaLabel.Dock = DockStyle.Fill;
            areaLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            areaLabel.Location = new Point(3, 0);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new Size(912, 97);
            areaLabel.TabIndex = 0;
            areaLabel.Text = "Area: [Area Name]";
            areaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // parameterPictureBox
            // 
            parameterPictureBox.Dock = DockStyle.Fill;
            parameterPictureBox.Location = new Point(3, 100);
            parameterPictureBox.Name = "parameterPictureBox";
            parameterPictureBox.Size = new Size(453, 447);
            parameterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            parameterPictureBox.TabIndex = 1;
            parameterPictureBox.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(3, 553);
            button1.Name = "button1";
            button1.Size = new Size(453, 92);
            button1.TabIndex = 3;
            button1.Tag = "PASS";
            button1.Text = "PASS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += UpdateStatus;
            // 
            // NgPopupShowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 648);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NgPopupShowForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Ng Detail";
            Load += NgPopupShowForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)actualPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)parameterPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label areaLabel;
        private Button button2;
        private FVMIPictureBox actualPictureBox;
        private FVMIPictureBox parameterPictureBox;
        private Button button1;
    }
}