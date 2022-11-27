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
    public partial class adaugareAdmin : Form
    {
        public adaugareAdmin()
        {
            InitializeComponent();
        }
        SqlCeConnection co = new SqlCeConnection();
        private void adaugareAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conect 2
            co.ConnectionString = "Data Source=librarieDBF.sdf;";


            //open
            co.Open();

            //declare variable 

            string txtadminnume = textBox1.Text;//
            string txtadminparola = textBox2.Text;// 


            //add new data

            string insertString = "Insert INTO admin(adminnume, adminparola,ultimulcomentariumoderat) values ('"+txtadminnume+"' , '"+txtadminparola+"' , '"+"XXXXXXXXXXXX"+"')";
            SqlCeCommand insert = new SqlCeCommand(insertString, co);
            insert.ExecuteNonQuery();

            //close
            co.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            txtadminnume = "";
            txtadminparola="";
            MessageBox.Show("Administrator nou adaugat!");

        }
    }
}
