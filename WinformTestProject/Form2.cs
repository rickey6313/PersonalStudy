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

namespace WinformTestProject
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox4.Text = "해제";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString;
            connectionString = "server=.\\MSSQLEXPRESS;" + "database=" + textBox1.Text + ";" +
                "uid=" + textBox2.Text + ";" + "pwd=" + textBox3.Text + ";";

            if(conn != null)
            {
                conn.Dispose();
            }
            conn = new SqlConnection(connectionString);

            if (conn != null)
                textBox4.Text = "연결";
            else
            {
                textBox4.Text = "해제";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                MessageBox.Show("데이터베이스 열렸습니다.");
            }
            else
            {
                MessageBox.Show("데이터베이스 Open 에러");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Close();
            if (conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("데이터베이스 닫았습니다.");
            }
            else
            {
                MessageBox.Show("데이터베이스 Closed 에러");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Dispose();
            conn = null;
            textBox4.Text = "해제";
            MessageBox.Show("서버 연결 해제");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            string sqlStr = $"Select * from UserInfo";
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = sqlStr;
            sqlCommand.CommandType = CommandType.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int i = 0;
            while(reader.Read())
            {
                MessageBox.Show(reader[i].ToString());
                
            }
            //Console.WriteLine($"UserName : {reader["UserName"]} / Password : {reader["Password"]}");
            
            

        }
    }
}
