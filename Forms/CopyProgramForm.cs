using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Repositories;

namespace FVMI_INSPECTION.Forms
{
    public partial class CopyProgramForm : Form
    {
        ModelRepository db = new ModelRepository();
        private List<MasterModel> masterModels = new List<MasterModel>();
        public CopyProgramForm()
        {
            InitializeComponent();
            db = new ();
        }

        private async void CopyProgramForm_Load(object sender, EventArgs e)
        {
            masterModels = await db.GetModel();
            comboBox1.Items.AddRange(masterModels.DistinctBy(x=>x.Model).ToArray());
            comboBox1.ValueMember = "Model";
            comboBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await db.FullCopyPosition(((MasterModel)comboBox1.SelectedItem!).Model, newModelNameBox.Text);
            MessageBox.Show("Copy Complete");
            this.Close();
        }
    }
}
