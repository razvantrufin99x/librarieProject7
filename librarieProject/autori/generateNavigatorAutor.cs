﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace librarieProject.autori
{
    public partial class generateNavigatorAutor : Form
    {
        public generateNavigatorAutor()
        {
            InitializeComponent();
        }
        public navigationClass.theNavigationClass nc;
        private void generateNavigatorAutor_Load(object sender, EventArgs e)
        {
            nc = new navigationClass.theNavigationClass(this, "librarieDBF.sdf", "autori", "RUNALL");
        }
    }
}
