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
    public partial class ListReasonsForm : Form
    {
        private ReasonRepository reasonRepository = new ReasonRepository();
        private IEnumerable<ReasonModel> Reasons = new List<ReasonModel>();
        public ListReasonsForm()
        {
            InitializeComponent();
        }

        private async void ListReasonsForm_Load(object sender, EventArgs e)
        {
            await LoadReasonsView();
        }
        private async Task LoadReasonsView()
        {
            Reasons = await reasonRepository.GetReason();
            if (reasonGridView.Columns.Count < 1)
            {
                reasonGridView.Columns.Add("No", "No");
                reasonGridView.Columns.Add("Reason", "Reason");
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn()
                {
                    Name = "Action",
                    Text = "Delete",
                    UseColumnTextForButtonValue=true
                };
                reasonGridView.Columns.Add(buttonColumn);
            }
            reasonGridView.Rows.Clear();
            int no = 1;
            foreach (var reason in Reasons)
            {
                reasonGridView.Rows.Add();
                DataGridViewRow row = reasonGridView.Rows[no-1];
                row.Cells[0].Value = no;
                row.Cells[1].Value = reason.Reason;
                row.Tag = reason.Id.ToString();
                no++;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await reasonRepository.InsertReason(reasonBox.Text);
            reasonBox.Clear();
            await LoadReasonsView();
        }

        private async void reasonGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var res = MessageBox.Show("Are you sure want to delete this?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(reasonGridView.Rows[e.RowIndex].Tag);
                    await reasonRepository.DeleteReason(id);
                }
                await LoadReasonsView();
            }
        }
    }
}
