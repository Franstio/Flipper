namespace FVMI_INSPECTION
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Models.ViewData.CountViewModel countViewModel1 = new Models.ViewData.CountViewModel();
            menuStrip1 = new MenuStrip();
            optionToolStripMenuItem = new ToolStripMenuItem();
            changeModelToolStripMenuItem = new ToolStripMenuItem();
            settingParameterToolStripMenuItem = new ToolStripMenuItem();
            newModelParameterToolStripMenuItem = new ToolStripMenuItem();
            modifyParameterToolStripMenuItem = new ToolStripMenuItem();
            copyProgramToolStripMenuItem = new ToolStripMenuItem();
            deleteProgramToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            dashboardControl1 = new Controls.DashboardControl();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeModelToolStripMenuItem, settingParameterToolStripMenuItem, configurationToolStripMenuItem, exitToolStripMenuItem });
            optionToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline);
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(57, 20);
            optionToolStripMenuItem.Text = "Option";
            // 
            // changeModelToolStripMenuItem
            // 
            changeModelToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            changeModelToolStripMenuItem.Name = "changeModelToolStripMenuItem";
            changeModelToolStripMenuItem.Size = new Size(180, 22);
            changeModelToolStripMenuItem.Text = "Change Model";
            changeModelToolStripMenuItem.Click += changeModelToolStripMenuItem_Click;
            // 
            // settingParameterToolStripMenuItem
            // 
            settingParameterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newModelParameterToolStripMenuItem, modifyParameterToolStripMenuItem, copyProgramToolStripMenuItem, deleteProgramToolStripMenuItem });
            settingParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            settingParameterToolStripMenuItem.Name = "settingParameterToolStripMenuItem";
            settingParameterToolStripMenuItem.Size = new Size(180, 22);
            settingParameterToolStripMenuItem.Text = "Setting Parameter";
            // 
            // newModelParameterToolStripMenuItem
            // 
            newModelParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            newModelParameterToolStripMenuItem.Name = "newModelParameterToolStripMenuItem";
            newModelParameterToolStripMenuItem.Size = new Size(192, 22);
            newModelParameterToolStripMenuItem.Text = "New Model Parameter";
            newModelParameterToolStripMenuItem.Click += newModelParameterToolStripMenuItem_Click;
            // 
            // modifyParameterToolStripMenuItem
            // 
            modifyParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            modifyParameterToolStripMenuItem.Name = "modifyParameterToolStripMenuItem";
            modifyParameterToolStripMenuItem.Size = new Size(192, 22);
            modifyParameterToolStripMenuItem.Text = "Modify Parameter";
            modifyParameterToolStripMenuItem.Click += modifyParameterToolStripMenuItem_Click;
            // 
            // copyProgramToolStripMenuItem
            // 
            copyProgramToolStripMenuItem.Name = "copyProgramToolStripMenuItem";
            copyProgramToolStripMenuItem.Size = new Size(192, 22);
            copyProgramToolStripMenuItem.Text = "Copy Program";
            copyProgramToolStripMenuItem.Click += copyProgramToolStripMenuItem_Click;
            // 
            // deleteProgramToolStripMenuItem
            // 
            deleteProgramToolStripMenuItem.Name = "deleteProgramToolStripMenuItem";
            deleteProgramToolStripMenuItem.Size = new Size(192, 22);
            deleteProgramToolStripMenuItem.Text = "Delete Program";
            deleteProgramToolStripMenuItem.Click += deleteProgramToolStripMenuItem_Click;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(180, 22);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // panel1
            // 
            panel1.Controls.Add(dashboardControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 426);
            panel1.TabIndex = 2;
            // 
            // dashboardControl1
            // 
            dashboardControl1.topWhiteImage = null;
            dashboardControl1.BottomUVDecision = "";
            dashboardControl1.bottomWhiteImage = null;
            countViewModel1.Count = 0;
            countViewModel1.Fail = 0;
            countViewModel1.Pass = 0;
            countViewModel1.Yield = new decimal(new int[] { 0, 0, 0, 0 });
            dashboardControl1.countViewModel = countViewModel1;
            dashboardControl1.Dock = DockStyle.Fill;
            dashboardControl1.FinalJudge = "";
            dashboardControl1.Location = new Point(0, 0);
            dashboardControl1.Margin = new Padding(3, 2, 3, 2);
            dashboardControl1.Name = "dashboardControl1";
            dashboardControl1.SerialNumber = "";
            dashboardControl1.Size = new Size(800, 426);
            dashboardControl1.StatusRun = "log1123445.txt";
            dashboardControl1.TabIndex = 0;
            dashboardControl1.topUVImage = null;
            dashboardControl1.TopUVDecision = "";
            dashboardControl1.bottomUVImage = null;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "MainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem changeModelToolStripMenuItem;
        private ToolStripMenuItem settingParameterToolStripMenuItem;
        private ToolStripMenuItem newModelParameterToolStripMenuItem;
        private ToolStripMenuItem modifyParameterToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel panel1;
        private Controls.DashboardControl dashboardControl1;
        private ToolStripMenuItem copyProgramToolStripMenuItem;
        private ToolStripMenuItem deleteProgramToolStripMenuItem;
    }
}
