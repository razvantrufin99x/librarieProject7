using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace librarieProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public bool canICloseApplication = true;


        private void Form1_Load(object sender, EventArgs e)
        {
            admin.index idx = new admin.index();
            idx.MdiParent = this;
            idx.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            librarieProject.Help.AboutBox1 ab1 = new Help.AboutBox1();
            ab1.MdiParent = this;
            ab1.Show();
        }

        private void splashScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            librarieProject.Help.SplashScreen sp1 = new Help.SplashScreen();
            sp1.MdiParent = this;
            sp1.Show();
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            librarieProject.Help.ajutor aj1 = new Help.ajutor();
            aj1.MdiParent = this;
            aj1.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (canICloseApplication == true)
            {

                Application.Exit();

            }
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adaugareAdmin addadmin = new adaugareAdmin();
            addadmin.MdiParent = this;
            addadmin.Show();
        }

        private void adaugareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            autori.adaugareAutor addautor = new autori.adaugareAutor();
            addautor.MdiParent = this;
            addautor.Show();
        }

        private void adaugareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            carti.adaugareCarte caddc = new carti.adaugareCarte();
            caddc.MdiParent = this;
            caddc.Show();
        }

        private void navigareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carti.navigareCarti cnc = new carti.navigareCarti();
            cnc.MdiParent = this;
            cnc.Show();
        }

        private void navigareCartiGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carti.navigareCartiGenerator cncg = new carti.navigareCartiGenerator();
            cncg.MdiParent = this;
            cncg.Show();
        }

        private void generatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carti.generateNavigatorCarti gnc = new carti.generateNavigatorCarti();
            gnc.MdiParent = this;
            gnc.Show();
        }

        private void generateNavigatorAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin.generateNavigatorAdmin gna = new admin.generateNavigatorAdmin();
            gna.MdiParent = this;
            gna.Show();
        }

        private void generateNavigatorAutoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autori.generateNavigatorAutor gnau = new autori.generateNavigatorAutor();
            gnau.MdiParent = this;
            gnau.Show();
        }
    }
}
