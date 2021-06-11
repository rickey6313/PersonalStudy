using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP_Portfolio.User;

namespace ERP_Portfolio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 회원가입 버튼
        private void RegistBtn_Click(object sender, EventArgs e)
        {
            RegistForm registForm = new RegistForm();
            registForm.Owner = this;
            if(registForm.ShowDialog(this) == DialogResult.OK)
            {
                Visible = true;
                registForm.Dispose();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string id = idTextBox.Text;
            string pwd = pwdTextBox.Text;

            DataTable userInfo = SqlManager.Instance.GetDataTable("UserInfo");
            string filter = $"userId = '{id}' and userPwd = '{pwd}'";
            DataRow[] row = userInfo.Select(filter);

            if (row.Length > 0)
            {
                Form2 mainForm = new Form2();
                mainForm.Owner = this;
                mainForm.Show(this);
            }
            else
            {
                MessageBox.Show("아이디 또는 패스워드가 틀렸습니다", "로그인 실패");
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
