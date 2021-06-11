using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP_Portfolio;

namespace ERP_Portfolio.User
{
    
    public partial class RegistForm : Form
    {
        private Form1 _loginForm;
        public RegistForm()
        {
            InitializeComponent();
        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            _loginForm = (Form1)Owner;

            partComboBox.Items.Clear();

            SetPartInfo();
            SetAuthorityInfo();
            SetRankInfo();

        }

        private void SetPartInfo()
        {
            string tableName = "PartInfo";
            SqlManager.Instance.SelectTable(tableName);
            DataTable items = SqlManager.Instance.GetDataTable(tableName);
            foreach (DataRow row in items.Rows)
                partComboBox.Items.Add(row["partName"].ToString());
        }
        private void SetAuthorityInfo()
        {
            string tableName = "AuthorityInfo";
            SqlManager.Instance.SelectTable(tableName);
            DataTable items = SqlManager.Instance.GetDataTable(tableName);
            foreach (DataRow row in items.Rows)
                authorityComboBox.Items.Add(row["authorityName"].ToString());
        }
        private void SetRankInfo()
        {
            string tableName = "RankInfo";
            SqlManager.Instance.SelectTable(tableName);
            DataTable items = SqlManager.Instance.GetDataTable(tableName);
            foreach (DataRow row in items.Rows)
                rankComboBox.Items.Add(row["rankName"].ToString());
        }


        private void RegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // 회원가입 버튼
        private void EnterUserBtn_Click(object sender, EventArgs e)
        {
            string userId = userIdTextbox.Text;
            string userPwd = userPwdTextbox.Text;
            string userName = userNameTextbox.Text;
            int partIndex = partComboBox.SelectedIndex == -1? 1 : partComboBox.SelectedIndex+1;
            int authorityIndex = authorityComboBox.SelectedIndex == -1 ? 1 : authorityComboBox.SelectedIndex + 1;
            int rankIndex = rankComboBox.SelectedIndex == -1 ? 1 : rankComboBox.SelectedIndex + 1;
            string email = emailTextbox.Text;
            string phone1 = phoneTextbox1.Text;
            string phone2 = phoneTextbox2.Text;
            string address1 = addressTextbox1.Text;
            string address2 = addressTextbox2.Text;

            if (userId == "" || userPwd == "" || userName == "")
            {
                MessageBox.Show("아이디, 비밀번호, 이름은 필수입력 사항입니다", "회원가입 실패");
                return;
            }

            string tableName = "UserInfo";
            SqlManager.Instance.SetBuilder(tableName);
            int value = SqlManager.Instance.InsertCommand(tableName, userId, userPwd, userName, partIndex, authorityIndex, rankIndex, email, phone1, phone2, address1, address2);
            if(value == 1)
            {
                if(MessageBox.Show("회원가입 성공", "회원가입") == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("회원가입 실패", "회원가입");
            }
        }
    }
}
