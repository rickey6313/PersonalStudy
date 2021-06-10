using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NonConnectionDatabase
{    
    public partial class Form1 : Form
    {
        DataTable table1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table1 = new DataTable("table1");
            DataColumn col1 = new DataColumn("Name", typeof(string));
            table1.Columns.Add(col1);
            table1.PrimaryKey = new DataColumn[] { col1 };

            col1 = new DataColumn("Age", typeof(int));
            table1.Columns.Add(col1);
            col1 = new DataColumn("Male", typeof(bool));
            table1.Columns.Add(col1);

            DataRow row = table1.NewRow();
            row["Name"] = "철수";
            row["Age"] = 19;
            row["Male"] = true;
            table1.Rows.Add(row);

            row = table1.NewRow();
            row["Name"] = "수지";
            row["Age"] = 18;
            row["Male"] = false;
            table1.Rows.Add(row);

            table1.AcceptChanges();
            dataGridView1.DataSource = table1;
            dataGridView1.MultiSelect = false;

            StringBuilder sb = new StringBuilder();

            foreach (DataRow PrintRow in table1.Rows)
            {
                string str;
                if(PrintRow["Male"].ToString() == "True")
                    str = "남자";
                else
                    str = "여자";
                
                sb.AppendLine($"이름 : {PrintRow["Name"]} / 나이 : {PrintRow["Age"]} / 성별 : {str}");                
            }
            textBox1.Text = sb.ToString();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            DataRow[] SelectRow = null;
            
            try
            {
                //textBox2.Text;
                SelectRow = table1.Select(textBox2.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            StringBuilder sb = new StringBuilder();
            if (SelectRow == null) return;

            foreach (DataRow PrintRow in SelectRow)
            {
                string str;
                if (PrintRow["Male"].ToString() == "True")
                    str = "남자";
                else
                    str = "여자";

                sb.AppendLine($"이름 : {PrintRow["Name"]} / 나이 : {PrintRow["Age"]} / 성별 : {str}");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool male = true;
            if (textBox3.Text == "" || textBox4.Text == "")
                return;

            if (radioButton1.Checked == true)
                male = true;
            else if(radioButton1.Checked == true)
                male = false;

            DataRow row = table1.NewRow();
            row["Name"] = textBox3.Text;            
            row["Age"] = int.Parse(textBox4.Text);
            row["Male"] = male;
            table1.Rows.Add(row);
            table1.AcceptChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            bool male = true;
            if (textBox3.Text == "" || textBox4.Text == "")
                return;

            if (radioButton1.Checked == true)
                male = true;
            else if (radioButton1.Checked == true)
                male = false;

            DataGridViewSelectedRowCollection selected = dataGridView1.SelectedRows;
            DataRow row = table1.Rows[selected[0].Index];

            row["Name"] = textBox3.Text;
            row["Age"] = int.Parse(textBox4.Text);
            row["Male"] = male;            
            table1.AcceptChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection selected = dataGridView1.SelectedRows;
            //int selectedRowIndex = selected[0].Index;
            //DataRow row = table1.Rows[selectedRowIndex];
            //row.Delete();
            //table1.AcceptChanges();

            //DataGridViewSelectedRowCollection selected = dataGridView1.SelectedRows;
            //dataGridView1.Rows.Remove(selected[0]);

            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
