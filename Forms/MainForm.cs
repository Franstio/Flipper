using FVMI_INSPECTION.Controls;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.Forms;
using System.Windows.Forms;

namespace FVMI_INSPECTION
{
    public partial class MainForm : Form
    {
        private ModelRepository repo = new ModelRepository();
        public MainForm()
        {
            InitializeComponent();
            DashboardControl dc = new DashboardControl();
            panel1.Controls.Clear();
            dc.Dock = DockStyle.Fill;
            panel1.Controls.Add(dc);
        }

        private void newModelParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputModalForm form = new InputModalForm("Insert New Model Name");
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                SettingParameterControl frm = new SettingParameterControl(form.Result);
                frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(frm);
            }
        }

        private async void changeModelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var data = await repo.GetModel();
            SelectModalForm form = new SelectModalForm("Select Model", data.Select(x => x.Model).ToList());
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                DashboardControl frm = new DashboardControl(form.Result);
                frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(frm);
            }
        }

        private async void modifyParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = await repo.GetModel();
            SelectModalForm form = new SelectModalForm("Select Model", data.Select(x => x.Model).ToList());
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                SettingParameterControl frm = new SettingParameterControl(form.Result);
                frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(frm);
            }
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm frm = new ConfigForm();
            panel1.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
        }

        private void copyProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyProgramForm form = new CopyProgramForm();
            form.ShowDialog(this);
        }

        private void deleteProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProgramForm frm = new DeleteProgramForm();
            frm.ShowDialog(this);
        }
    }
}
