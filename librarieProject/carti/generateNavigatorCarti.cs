using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;


namespace librarieProject.carti
{
    public partial class generateNavigatorCarti : Form
    {
        public generateNavigatorCarti()
        {
            InitializeComponent();
        }
        public navigationClass.theNavigationClass nc;

        private void generateNavigatorCarti_Load(object sender, EventArgs e)
        {
            nc = new navigationClass.theNavigationClass(this, "librarieDBF.sdf", "carti", "RUNALL");
            

        }

       
    }
}
