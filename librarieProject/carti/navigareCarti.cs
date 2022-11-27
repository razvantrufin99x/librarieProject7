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
    public partial class navigareCarti : Form
    {
        public navigareCarti()
        {
            InitializeComponent();
        }

        //this will keep a record
        public class record
        {
            public record() { }
            public record(int n, ref List<string> x) { }
            public record(ref List<string> strinRec)
            {
                this.row = strinRec;
            }
            public List<string> row = new List<string>();

        }

        public void Table2Record(ref List<string> x)
        {
            record tmprec = new record(ref x);

            inregistrariTabela.Add(tmprec);
            

        }
       
        public int currentRecordNumber = 0;
        public int lastRecordNumber = 0;
        public int currentNumberOfRecordsInTable = 0;

        //7 create for each field in table a textBox
        // we will use just 5 textBoxes for now
        public int numberOfFieldsInTable = 0;
        //this will keep the names of all the fields in tha table
        public List<string> namesOfFieldsInTable = new List<string>();

        //create a list with all records
        public List<record> inregistrariTabela = new List<record>();
        public List<string> tmpList;

        //connect 1
        SqlCeConnection co = new SqlCeConnection();

        //read datata and write from FunctiiDBF

        SqlCeCommand cmd2;
        SqlCeDataReader reader2;// = cmd2.ExecuteReader();

        public void findAllTheRecordsInTable()
        {
           

            SqlCeCommand cmd3;
            SqlCeDataReader reader3;
            cmd3 = new SqlCeCommand("SELECT * FROM carti", co);
            reader3 = cmd3.ExecuteReader();
            tmpList = new List<string>();
            
           while(reader3.Read())
           {
                tmpList = new List<string>(); //this is the new row who make it work just fine 
                tmpList.Add(reader3.GetValue(0).ToString());
                tmpList.Add(reader3.GetValue(1).ToString());
                tmpList.Add(reader3.GetValue(2).ToString());
                tmpList.Add(reader3.GetValue(3).ToString());
                tmpList.Add(reader3.GetValue(4).ToString());
                tmpList.Add(reader3.GetValue(5).ToString());
                tmpList.Add(reader3.GetValue(6).ToString());
                Table2Record(ref tmpList);
               
            }
        }



        private void navigareCarti_Load(object sender, EventArgs e)
        {
            // points 1 to 3
            //conect 2
            co.ConnectionString = "Data Source=librarieDBF.sdf;";


            //open
            co.Open();


           

            //execute reader2
            cmd2 = new SqlCeCommand("SELECT * FROM carti", co);
            reader2 = cmd2.ExecuteReader();


            reader2.Read();
            lblFieldName0.Text = "titlu $" + ":";
            txtField0.Text = reader2[0].ToString();
            lblFieldName1.Text = "descriere $" + ":";
            txtField1.Text = reader2[1].ToString();
            lblFieldName2.Text = "data date" + ":";
            txtField2.Text = reader2[2].ToString();
            lblFieldName3.Text = "idcarte N" + ":";
            txtField3.Text = reader2[3].ToString();
            lblFieldName4.Text = "pret N" + ":";
            txtField4.Text = reader2[4].ToString();
            lblFieldName5.Text = "idautor N" + ":";
            txtField5.Text = reader2[5].ToString();
            lblFieldName6.Text = "iddom N" + ":";
            txtField6.Text = reader2[6].ToString();

            //textBox1.Text += " \r\n" + GetNumberOfRecords2().ToString();
            currentNumberOfRecordsInTable = GetNumberOfRecords2();
            txtNumberOfTotalRecords.Text = currentNumberOfRecordsInTable.ToString();

            currentRecordNumber = 0;
            updateCurrentRecordNumberTextBox();


            lblDBName.Text += " librarie.sdf";
            lblTabelName.Text += " carti";


            findAllTheRecordsInTable();
            printAllTheRecordFromInregistrariTable();
        }

        public void printCurrentRecord()
        {

           
            lblFieldName0.Text = "titlu $" + ":";
            txtField0.Text = reader2[0].ToString();
            lblFieldName1.Text = "descriere $" + ":";
            txtField1.Text = reader2[1].ToString();
            lblFieldName2.Text = "data date" + ":";
            txtField2.Text = reader2[2].ToString();
            lblFieldName3.Text = "idcarte N" + ":";
            txtField3.Text = reader2[3].ToString();
            lblFieldName4.Text = "pret N" + ":";
            txtField4.Text = reader2[4].ToString();
            lblFieldName5.Text = "idautor N" + ":";
            txtField5.Text = reader2[5].ToString();
            lblFieldName6.Text = "iddom N" + ":";
            txtField6.Text = reader2[6].ToString();

        }

        public void printAllTheRecordFromInregistrariTable()
        {
            for (int i = 0; i < inregistrariTabela.Count; i++)
            {
                txtListAllRecords.Text += inregistrariTabela[i].row[0].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[1].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[2].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[3].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[4].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[5].ToString() + " : ";
                txtListAllRecords.Text += inregistrariTabela[i].row[6].ToString() + " \r\n ";
                
            }

        }
        public void updateCurrentRecordNumberTextBox()
        {
            txtCurrentRecordNumber.Text = currentRecordNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentRecordNumber = 0;

            //goto record 0
            //reader2.Read();
            updateCurrentRecordNumberTextBox();
            gotoRecord(currentRecordNumber);
            loadRecordIntoForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentRecordNumber > 0)
            {
                //goto record currentRecordNumer-1;
                //reader2.Read();
                printCurrentRecord();
                currentRecordNumber--;
                updateCurrentRecordNumberTextBox();
                gotoRecord(currentRecordNumber);
                loadRecordIntoForm();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentRecordNumber < currentNumberOfRecordsInTable - 1)
            {
                //goto record currentRecordNumer+1;
                //reader2.NextResult();
                //reader2.Read();
                printCurrentRecord();
                currentRecordNumber++;
                updateCurrentRecordNumberTextBox();
                gotoRecord(currentRecordNumber);
                loadRecordIntoForm();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentRecordNumber = currentNumberOfRecordsInTable - 1;
            //goto record last
            //reader2.Read();
            updateCurrentRecordNumberTextBox();
            gotoRecord(currentRecordNumber);
            loadRecordIntoForm();
        }

        public int GetNumberOfRecords2()
        {
            int count = -1;
            try
            {
                //co.Open();
                SqlCeCommand countall = new SqlCeCommand("select count(*) from carti", co);
                count = (int)countall.ExecuteScalar();
            }
            finally
            {
                //if (co!= null){co.Close();}
            }
            return count;
        }

        public void gotoRecord(int x)
        {
            currentRecordNumber = x;

        }
        public void loadRecordIntoForm()
        {
            //lblFieldName0.Text = "titlu $" + ":";
            txtField0.Text = inregistrariTabela[currentRecordNumber].row[0].ToString();
            //lblFieldName1.Text = "descriere $" + ":";
            txtField1.Text = inregistrariTabela[currentRecordNumber].row[1].ToString();
            //lblFieldName2.Text = "data date" + ":";
            txtField2.Text = inregistrariTabela[currentRecordNumber].row[2].ToString(); 
            //lblFieldName3.Text = "idcarte N" + ":";
            txtField3.Text = inregistrariTabela[currentRecordNumber].row[3].ToString(); 
            //lblFieldName4.Text = "pret N" + ":";
            txtField4.Text = inregistrariTabela[currentRecordNumber].row[4].ToString(); 
            //lblFieldName4.Text = "idautor N" + ":";
            txtField5.Text = inregistrariTabela[currentRecordNumber].row[5].ToString();
            //
            txtField6.Text = inregistrariTabela[currentRecordNumber].row[6].ToString(); 
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            findAllTheRecordsInTable();
            printAllTheRecordFromInregistrariTable();
        }


    }
}
