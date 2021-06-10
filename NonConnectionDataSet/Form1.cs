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

namespace NonConnectionDataSet
{
    public partial class Form1 : Form
    {
        DataSet dataSet;
        DataRelation relation;
        SqlConnection conn;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder cmdBuilder;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataSet = new DataSet("Info");

            //dataSet.Tables.Add(new DataTable("table1"));
            //dataSet.Tables.Add(new DataTable("table2"));

            //DataColumn col = new DataColumn("id", typeof(string));
            //col.MaxLength = 10;
            //col.Unique = true;            
            //dataSet.Tables[0].Columns.Add(col);
            //dataSet.Tables[0].PrimaryKey = new DataColumn[] { col };

            //col = new DataColumn("pwd", typeof(string));
            //col.MaxLength = 8;
            //dataSet.Tables[0].Columns.Add(col);

            //col = new DataColumn("name", typeof(string));
            //col.MaxLength = 15;
            //dataSet.Tables[0].Columns.Add(col);

            //DataRow row;
            //row = dataSet.Tables[0].NewRow();
            //row["id"] = "1234";
            //row["pwd"] = "1234";
            //row["name"] = "대한";
            //dataSet.Tables[0].Rows.Add(row);

            //row = dataSet.Tables[0].NewRow();
            //row["id"] = "5678";
            //row["pwd"] = "5678";
            //row["name"] = "민국";
            //dataSet.Tables[0].Rows.Add(row);

            
            //col = new DataColumn("id", typeof(string));
            //col.MaxLength = 10;
            //dataSet.Tables[1].Columns.Add(col);
            //ForeignKeyConstraint fk = new ForeignKeyConstraint("FK", dataSet.Tables[0].Columns["id"], col);
            //dataSet.Tables[1].Constraints.Add(fk);

            //col = new DataColumn("fruit_name", typeof(string));
            //col.MaxLength = 20;
            //dataSet.Tables[1].Columns.Add(col);

            //row = dataSet.Tables[1].NewRow();
            //row["id"] = "1234";
            //row["fruit_name"] = "수박";
            //dataSet.Tables[1].Rows.Add(row);

            //row = dataSet.Tables[1].NewRow();
            //row["id"] = "5678";
            //row["fruit_name"] = "딸기";
            //dataSet.Tables[1].Rows.Add(row);

            //row = dataSet.Tables[1].NewRow();
            //row["id"] = "1234";
            //row["fruit_name"] = "사과";
            //dataSet.Tables[1].Rows.Add(row);

            //// 객체를 통한 관계 설정
            //relation = new DataRelation("Tb1andTb2_FK", dataSet.Tables[0].Columns["id"], dataSet.Tables[1].Columns["id"]);
            //dataSet.Relations.Add(relation);
            //dataGridView1.DataSource = dataSet.Tables[0];

            conn = new SqlConnection();
            conn.ConnectionString = "server=.\\MSSQLEXPRESS;database=school;uid=sa;pwd=1234";
            dataAdapter = new SqlDataAdapter("select * from UserInfo", conn);
            dataSet = new DataSet();
            cmdBuilder = new SqlCommandBuilder(dataAdapter);


            dataAdapter.Fill(dataSet, "UserInfo");
            dataGridView1.DataSource = dataSet.Tables[0];
            //SqlCommandInit();

        }


        

        // 이름보기
        private void button2_Click(object sender, EventArgs e)
        {
            //string id =  (string)dataGridView2.CurrentRow.Cells["id"].Value;
            //DataRow[] findPerson = dataSet.Tables[1].Select($"id = '{id}'");
            //DataRow item = findPerson[0].GetParentRow("Tb1andTb2_FK");
            
            //StringBuilder sb = new StringBuilder();            
            //sb.AppendLine(item["name"].ToString());

            //MessageBox.Show(sb.ToString());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strSelect = "Select * from UserInfo";
            dataAdapter.SelectCommand = new SqlCommand(strSelect, conn);
            //dataAdapter.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name");
            //dataAdapter.SelectCommand.Parameters["@name"].Value = textBox1.Text;
            
            //dataSet.Clear();
            //if (dataAdapter.Fill(dataSet, "UserInfo") == 0)
            //    MessageBox.Show("찾는 데이터가 없습니다");
            //else
            //    dataGridView3.DataSource = dataSet.Tables["UserInfo"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //dataAdapter.InsertCommand = new SqlCommand("insert into UserInfo values(@id, @pwd, @name, @grade)", conn);
            //dataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
            //dataAdapter.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 50, "pwd");
            //dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
            //dataAdapter.InsertCommand.Parameters.Add("@grade", SqlDbType.Int, 50, "grade");
            //dataAdapter.InsertCommand.Parameters["@id"].Value = textBox4.Text;
            //dataAdapter.InsertCommand.Parameters["@pwd"].Value = textBox5.Text;
            //dataAdapter.InsertCommand.Parameters["@name"].Value = textBox3.Text;
            //dataAdapter.InsertCommand.Parameters["@grade"].Value = 1;

            //dataAdapter.InsertCommand.ExecuteNonQuery();

            //dataSet.Clear();
            //dataAdapter.Fill(dataSet, "UserInfo");
            //dataGridView4.DataSource = dataSet.Tables["UserInfo"];
            //conn.Close();
            //dataAdapter.InsertCommand.Dispose();

            // Update 이용
            dataAdapter.InsertCommand = new SqlCommand("insert into UserInfo values(@id, @pwd, @name, @grade)", conn);
            dataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
            dataAdapter.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 50, "pwd");
            dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
            dataAdapter.InsertCommand.Parameters.Add("@grade", SqlDbType.Int, 50, "grade");

            //DataRow row = dataSet.Tables["UserInfo"].NewRow();
            //row["name"] = textBox3.Text;
            //row["id"] = textBox4.Text;
            //row["pwd"] = textBox5.Text;
            //row["grade"] = 1;
            //dataSet.Tables["UserInfo"].Rows.Add(row);
            //dataAdapter.Update(dataSet, "UserInfo");

            //dataSet.Clear();
            //dataAdapter.Fill(dataSet, "UserInfo");
            //dataGridView4.DataSource = dataSet.Tables["UserInfo"];
        }


        private void SqlCommandInit()
        {
            string strSelectSQl = "Select * from UserInfo";
            dataAdapter.SelectCommand = new SqlCommand(strSelectSQl, conn);

            string strInsertSQL = "insert into UserInfo values(@id, @pwd, @name, @grade)";
            dataAdapter.InsertCommand = new SqlCommand(strInsertSQL, conn);
            dataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
            dataAdapter.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 50, "pwd");
            dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
            dataAdapter.InsertCommand.Parameters.Add("@grade", SqlDbType.Int, 50, "grade");

            string strDeleteSQL = "Delete From UserInfo where id = @id";
            dataAdapter.DeleteCommand = new SqlCommand(strDeleteSQL, conn);
            dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");

            string strUpdateSQL = "Update UserInfo Set pwd = @pwd, name = @name, grade = @grade where id = @id";
            dataAdapter.UpdateCommand = new SqlCommand(strUpdateSQL, conn);
            dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
            dataAdapter.UpdateCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 50, "pwd");
            dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
            dataAdapter.UpdateCommand.Parameters.Add("@grade", SqlDbType.Int, 50, "grade");
        }

        // 입력
        private void button1_Click(object sender, EventArgs e)
        {
            //string id = (string)dataGridView1.CurrentRow.Cells["id"].Value;
            //DataRow[] findPerson = dataSet.Tables[0].Select($"id = '{id}'");
            //DataRow[] items = findPerson[0].GetChildRows("Tb1andTb2_FK");

            //if (items.Length > 0)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (DataRow row in items)
            //    {
            //        sb.AppendLine(row["fruit_name"].ToString());
            //    }
            //    MessageBox.Show(sb.ToString());
            //}

            DataRow row = dataSet.Tables["UserInfo"].NewRow();
            row["id"] = textBox1.Text;
            row["pwd"] = textBox2.Text;
            row["name"] = textBox3.Text;
            row["grade"] = int.Parse(textBox4.Text);
            dataSet.Tables["UserInfo"].Rows.Add(row);
            dataAdapter.Update(dataSet, "UserInfo");

            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");
            dataGridView1.DataSource = dataSet.Tables["UserInfo"];
        }

        // 수정
        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");

            string filter = $"id='{id}'";
            DataRow[] findRows = dataSet.Tables["UserInfo"].Select(filter);
            findRows[0]["name"] = textBox3.Text;
            findRows[0]["pwd"] = textBox2.Text;
            findRows[0]["grade"] = int.Parse(textBox4.Text);

            dataAdapter.Update(dataSet, "UserInfo");
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");
            dataGridView1.DataSource = dataSet.Tables["UserInfo"];
        }

        // 삭제
        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");

            string filter = $"id='{id}'";
            DataRow[] findRows = dataSet.Tables["UserInfo"].Select(filter);
            findRows[0].Delete();

            dataAdapter.Update(dataSet, "UserInfo");
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");
            dataGridView1.DataSource = dataSet.Tables["UserInfo"];
        }

        // 새로고침
        private void button6_Click(object sender, EventArgs e)
        {
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "UserInfo");
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
