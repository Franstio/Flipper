namespace FVMI_INSPECTION.Forms
{
    partial class ListReasonsForm
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
            groupBox1 = new GroupBox();
            reasonGridView = new DataGridView();
            groupBox2 = new GroupBox();
            button1 = new Button();
            reasonBox = new RichTextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reasonGridView).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(reasonGridView);
            groupBox1.Location = new Point(12, 174);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(573, 264);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "List Reason";
            // 
            // reasonGridView
            // 
            reasonGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reasonGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reasonGridView.Dock = DockStyle.Fill;
            reasonGridView.Location = new Point(5, 21);
            reasonGridView.Name = "reasonGridView";
            reasonGridView.Size = new Size(563, 238);
            reasonGridView.TabIndex = 0;
            reasonGridView.CellContentClick += reasonGridView_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(reasonBox);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(568, 156);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "New Reason";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(6, 116);
            button1.Name = "button1";
            button1.Size = new Size(556, 34);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // reasonBox
            // 
            reasonBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reasonBox.Location = new Point(5, 43);
            reasonBox.Name = "reasonBox";
            reasonBox.Size = new Size(557, 67);
            reasonBox.TabIndex = 1;
            reasonBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 0;
            label1.Text = "Reason:";
            // 
            // ListReasonsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ListReasonsForm";
            Text = "Reason Form";
            Load += ListReasonsForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)reasonGridView).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView reasonGridView;
        private GroupBox groupBox2;
        private Button button1;
        private RichTextBox reasonBox;
        private Label label1;
    }
}