﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeatBalance
{
    public partial class frm_Report : Form
    {
        public frm_Report()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void frm_Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}


