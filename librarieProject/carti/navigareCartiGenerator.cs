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
    public partial class navigareCartiGenerator : Form
    {
        public navigareCartiGenerator()
        {
            InitializeComponent();
        }

        public string databaseName = "";
        public string table = "";

        public List<string> databasesNames = new List<string>();
        public List<string> tablesNames = new List<string>();
        public List<string> fieldsNames = new List<string>();
        public List<record> recordsNames = new List<record>();

        //keep labels and textboxes
        public List<Label> labels = new List<Label>();
        public List<TextBox> textboxes = new List<TextBox>();


        //count labels and textboxes generated
        public int countLabels = 0;
        public int countTextBoxes = 0;

        //starting points for labels
        public int leftLabelStartPoint = 13;
        public int topLabelStartPoint = 105;

        //starting points for textboxes
        public int leftTextBoxStartPoint = 241;
        public int topTextBoxStartPoint = 105;


        public void addNewLabel(string s)
        {
            labels.Add(new Label());
            countLabels++;
            Controls.Add(labels[countLabels - 1]);
            labels[countLabels - 1].Visible = true;
            labels[countLabels - 1].Left = leftLabelStartPoint;
            labels[countLabels - 1].Top = topLabelStartPoint + countLabels * 35;
            labels[countLabels - 1].Text = s;


        }


        public void addNewTextBox(string s)
        {
            textboxes.Add(new TextBox());
            countTextBoxes++;
            Controls.Add(textboxes[countTextBoxes - 1]);
            textboxes[countTextBoxes - 1].Visible = true;
            textboxes[countTextBoxes - 1].Left = leftTextBoxStartPoint;
            textboxes[countTextBoxes - 1].Top = topTextBoxStartPoint + countTextBoxes * 35;
            textboxes[countTextBoxes - 1].Text = s;


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
            cmd3 = new SqlCeCommand("SELECT * FROM " + currentTableName, co);
            reader3 = cmd3.ExecuteReader();
            tmpList = new List<string>();

            while (reader3.Read())
            {
                tmpList = new List<string>(); //this is the new row who make it work just fine 
                for (int i = 0; i < totalColumnInTheCurrentTable; i++)
                {
                    tmpList.Add(reader3.GetValue(i).ToString());

                }
                Table2Record(ref tmpList);

            }
        }





        public void printCurrentRecord()
        {

           

        }

        public void printAllTheRecordFromInregistrariTable()
        {
            for (int i = 0; i < inregistrariTabela.Count; i++)
            {
                for (int j = 0; j < totalColumnInTheCurrentTable; j++)
                {
                    txtListAllRecords.Text += inregistrariTabela[i].row[j].ToString() + " : ";
                }
            }

        }
        public void updateCurrentRecordNumberTextBox()
        {
            txtCurrentRecordNumber.Text = currentRecordNumber.ToString();
        }


        private void navigareCartiGenerator_Load(object sender, EventArgs e)
        {
            /*
             * textBox2.Visible = false;
            currentDBName = this.textBox1.Text;
            currentTableName = "carti";

            // points 1 to 3
            //conect 2
            co.ConnectionString = "Data Source=" + currentDBName + ";";


            //open
            co.Open();




            //execute reader2
            cmd2 = new SqlCeCommand("SELECT * FROM " + currentTableName, co);
            reader2 = cmd2.ExecuteReader();


            reader2.Read();
             * */
        }

        public void selectToSelectedServer()
        {

        }
        public void connectToSelectedDatabase()
        {

        }

        public int GetNumberOfRecords2()
        {
            int count = -1;
            try
            {
                //co.Open();
                SqlCeCommand countall = new SqlCeCommand("select count(*) from " + currentTableName, co);
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
            for (int i = 0; i < currentNumberOfRecordsInTable; i++)
            {
                labels[i].Text = fieldsNames[i].ToString();
                textboxes[i].Text = inregistrariTabela[currentRecordNumber].row[i].ToString();
            }

        }
        string currentDBName;

        string currentTableName;

        int totalColumnInTheCurrentTable = 0;

        public void rec()
        {
            textBox1.Text += " \r\n" + GetNumberOfRecords2().ToString();
            currentNumberOfRecordsInTable = GetNumberOfRecords2();
            txtNumberOfTotalRecords.Text = currentNumberOfRecordsInTable.ToString();

            currentRecordNumber = 0;
            updateCurrentRecordNumberTextBox();


            lblDBName.Text += currentDBName;
            lblTabelName.Text += currentTableName;


            findAllTheRecordsInTable();
            printAllTheRecordFromInregistrariTable();
        }

        public void addRecordsLabelsAndTextBoxesOnForm(string l, string t)
        {
            addNewLabel(l);
            addNewTextBox(t);
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




        private void button5_Click(object sender, EventArgs e)
        {
            findAllTheRecordsInTable();
            printAllTheRecordFromInregistrariTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //get current db name
            currentDBName = textBox1.Text;


            //connect to current db
            // points 1 to 3
            //conect 2
            co.ConnectionString = "Data Source=" + currentDBName + ";";


            //open
            co.Open();
        }




        private void button7_Click(object sender, EventArgs e)
        {



            //get db schema

            //GET ALL COLUMNS NAMES FROM DATABASE
            //SELECT * FROM INFORMATION_SCHEMA.COLUMNS

            //GET ALL INDEXES OF DATABASE
            //SELECT * FROM INFORMATION_SCHEMA.INDEXES

            //GET ALL INDEXES AND COLUMNS OF THE DB
            //SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMNS_USAGE

            //get all datatypes of the db
            //SELECT * FROM INFORMATION_SCHEMA.PROVIDER_TYPES

            //GET AL TABLES FROM DB
            //SELECT * FROM INFORMATION_SCHEMA.TABLES

            //GET ALL CONSTRAINTS FRO MDB
            //SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS

            //GET ALL FOREIGN KEYS OF THE DB
            //SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS



            //list all tables names

            //SELECT * FROM INFORMATION_SCHEMA.TABLES where table_name LIKE '%INV%' 
            //sys.tables


            SqlCeCommand FINDALLTABLES = new SqlCeCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", co);


            SqlCeDataReader reader4;
            reader4 = FINDALLTABLES.ExecuteReader();





            while (reader4.Read())
            {
                comboBox1.Items.Add(reader4["TABLE_NAME"].ToString());
            }


            //find all field names


            //list all records






        }


        private void button8_Click(object sender, EventArgs e)
        {
            SqlCeCommand FINDALLTABLESCOLUMNS = new SqlCeCommand("SELECT * FROM INFORMATION_SCHEMA.COLUMNS", co);


            SqlCeDataReader reader5;
            reader5 = FINDALLTABLESCOLUMNS.ExecuteReader();





            while (reader5.Read())
            {
                if (reader5["TABLE_NAME"].ToString() == currentTableName)
                {
                    this.listBox1.Items.Add(reader5["COLUMN_NAME"].ToString());
                    totalColumnInTheCurrentTable++;
                    fieldsNames.Add(reader5["COLUMN_NAME"].ToString());
                }
            }
        }




        private void button9_Click(object sender, EventArgs e)
        {
            rec();
            SqlCeCommand cmd6;
            SqlCeDataReader reader6;
            Text = this.currentTableName + " ";
            Text += "SELECT * FROM " + currentTableName;

            cmd6 = new SqlCeCommand("SELECT * FROM " + currentTableName, co);


            reader6 = cmd6.ExecuteReader();



            while (reader6.Read())
            {
                for (int i = 0; i < totalColumnInTheCurrentTable; i++)
                {
                    try
                    {
                        textBox2.Text += reader6.GetValue(i).ToString() + "     ";

                    }
                    catch { }
                }
                textBox2.Text += "\r\n";
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            textBox2.Visible = false;
            for (int i = 0; i < totalColumnInTheCurrentTable; i++)
            {
                addRecordsLabelsAndTextBoxesOnForm(fieldsNames[i].ToString(), inregistrariTabela[currentRecordNumber].row[i].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTableName = comboBox1.Text;
            lblcurrentTableName.Text = currentTableName;
        }

        private void lblTabelName_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
