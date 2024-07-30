using FVMI_INSPECTION.Controls;
using FVMI_INSPECTION.Repositories;
using FVMI_INSPECTION.Forms;
using System.Windows.Forms;
using FVMI_INSPECTION.Utilities;

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
            InputModalForm frm = new InputModalForm("Confirm Password", "Password",'*');
            var resDialog = frm.ShowDialog();
            if (resDialog == DialogResult.OK)
            {
                if (frm.textBox1.Text.Hmac512Hash() != Properties.Settings.Default.Password)
                {
                    MessageBox.Show("Incorrect Password");
                    return;
                }
            }
            else
                return;
            InputModalForm form = new InputModalForm("New Model","Insert New Model Name");
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                SettingParameterControl _frm = new SettingParameterControl(form.Result);
                _frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(_frm);
            }
        }

        private async void changeModelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var data = await repo.GetModel();
            SelectModalForm form = new SelectModalForm("Run Model","Select Model", data.Select(x => x.Model).ToList());
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                DashboardControl _frm = new DashboardControl(form.Result);
                _frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(_frm);
            }
        }

        private async void modifyParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputModalForm frm = new InputModalForm("Confirm Password", "Password", '*');
            var resDialog = frm.ShowDialog();
            if (resDialog == DialogResult.OK)
            {
                if (frm.textBox1.Text.Hmac512Hash() != Properties.Settings.Default.Password)
                {
                    MessageBox.Show("Incorrect Password");
                    return;
                }
            }
            else
                return;
            var data = await repo.GetModel();
            SelectModalForm form = new SelectModalForm("Modify Model", "Select Model", data.Select(x => x.Model).ToList());
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls.Clear();
                SettingParameterControl _frm = new SettingParameterControl(form.Result);
                _frm.Dock = DockStyle.Fill;
                panel1.Controls.Add(_frm);
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
