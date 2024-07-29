﻿using FVMI_INSPECTION.Interfaces;
using FVMI_INSPECTION.Models;
using FVMI_INSPECTION.Presenter;
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
    public partial class NgPopupShowForm : Form, NgPopUpMVP.IView
    {
        private NgPopUpMVP.IPresenter presenter;
        public RecordModel Model { get; set; }
        public NgPopupShowForm(RecordModel model)
        {
            InitializeComponent();
            Model = model;
        }

        public Image ActualImage { get => actualPictureBox.Image; 
            set 
            {
                actualPictureBox.Image = value;
            } 
        }
        public Image ParameterImage { get => parameterPictureBox.Image;
            set
            {
                parameterPictureBox.Image = value;
            }
        }
        public string Area { get => areaLabel.Text ; 
            set 
            {
                areaLabel.Invoke(delegate { areaLabel.Text = value; });
            }
        }

        private async void NgPopupShowForm_Load(object sender, EventArgs e)
        {
            presenter = await NgPopUpPresenter.Build(this, Model);
            
        }
        private async void UpdateStatus(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;
            InputTextModalForm frm = new InputTextModalForm("Reason");
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
            {
                Close();
                return;
            }

            Model = await presenter.UpdateResult(btn.Tag!.ToString() == "PASS", frm.Result);
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

    }
}
