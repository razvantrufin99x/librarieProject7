using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace librarieProject.autori
{
    public partial class adaugareAutor : Form
    {
        public adaugareAutor()
        {
            InitializeComponent();
        }
        SqlCeConnection co = new SqlCeConnection();
        private void button1_Click(object sender, EventArgs e)
        {
            //conect 2
            co.ConnectionString = "Data Source=librarieDBF.sdf;";


            //open
            co.Open();

            //declare variable 

            string txtidautor = textBox1.Text;//
            string txtnumeautor = textBox2.Text;// 


            //add new data

            string insertString = "Insert INTO autori(idautor,numeautor) values ('" + txtidautor + "' , '" + txtnumeautor+"')";
            SqlCeCommand insert = new SqlCeCommand(insertString, co);
            insert.ExecuteNonQuery();

            //close
            co.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            txtidautor = "";
            txtnumeautor = "";
            MessageBox.Show("Autor nou adaugat!");
        }
    }
}
