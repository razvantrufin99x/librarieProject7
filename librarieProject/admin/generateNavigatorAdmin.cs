using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace librarieProject.admin
{
    public partial class generateNavigatorAdmin : Form
    {
        public generateNavigatorAdmin()
        {
            InitializeComponent();
        }
        public navigationClass.theNavigationClass nc;
        private void generateNavigatorAdmin_Load(object sender, EventArgs e)
        {
            nc = new navigationClass.theNavigationClass(this, "librarieDBF.sdf", "admin", "RUNALL");
        }
    }
}
