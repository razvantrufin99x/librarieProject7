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
    public partial class adaugareCarte : Form
    {
        public adaugareCarte()
        {
            InitializeComponent();
        }
        SqlCeConnection co = new SqlCeConnection();
        private void adaugareCarte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conect 2
            co.ConnectionString = "Data Source=librarieDBF.sdf;";


            //open
            co.Open();

            //declare variable 

            string txttitlu = textBox1.Text;//
            string txtdescriere = textBox2.Text;// 
            string txtdata = textBox3.Text;// 
            string txtidcarte = textBox4.Text;// 
            string txtpret = textBox5.Text;// 
            string txtidautor = textBox6.Text;// 
            string txtiddom = textBox7.Text;// 


            //add new data

            string insertString = "Insert INTO carti(titlu,descriere,data,idcarte,pret,idautor,iddom) values ('" + txttitlu + "' , '" + txtdescriere + "' , '" + txtdata + "' , '" + txtidcarte + "' , '" + txtpret + "' , '" + txtidautor + "' , '" + txtiddom + "')";
            SqlCeCommand insert = new SqlCeCommand(insertString, co);
            insert.ExecuteNonQuery();

            //close
            co.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            txttitlu = "";
            txtdescriere = "";
            txtdata = "";
            txtidcarte = "";
            txtpret = "";
            txtidcarte = "";
            txtiddom = "";

            MessageBox.Show("Carte nou adaugata!");
        }
    }
}
