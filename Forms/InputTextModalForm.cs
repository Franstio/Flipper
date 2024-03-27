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
    public partial class InputTextModalForm : Form
    {
        private string title { get; set; }
        public string Result { get; private set; }
        public InputTextModalForm(string _title)
        {
            InitializeComponent();
            Text = $"Form Input: {_title}";
            title = _title ;
            titleLabel.Text = $"{title}:";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textInputBox.Text)|| string.IsNullOrWhiteSpace(textInputBox.Text))
            {
                MessageBox.Show("Data Can't be Empty", "Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Result = textInputBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
