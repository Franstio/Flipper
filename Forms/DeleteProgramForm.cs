using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FVMI_INSPECTION.Forms
{
    public partial class DeleteProgramForm : Form
    {
        private ModelRepository Repostiory = new ModelRepository();
        private List<MasterModel> MasterModels = new List<MasterModel>();
        public DeleteProgramForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to delete this program?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            await Repostiory.DeletePosition(((MasterModel)comboBox1.SelectedItem!).Model);
            MessageBox.Show("Delete Success");
            Close();
        }

        private async void DeleteProgramForm_Load(object sender, EventArgs e)
        {

            MasterModels = await Repostiory.GetModel();
            comboBox1.Items.AddRange(MasterModels.DistinctBy(x => x.Model).ToArray());
            comboBox1.ValueMember = "Model";
            comboBox1.SelectedIndex = 0;

        }
    }
}
