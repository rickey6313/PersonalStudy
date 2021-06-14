using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Portfolio.User
{
    public partial class UserManagerForm : Form
    {
        MainForm mainForm;
        public UserManagerForm()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)Owner;

            LoadData();
        }

        private void LoadData()
        {
            SelectUserInfo();
            SetPartInfo();
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
        
        private void SetRankInfo()
        {
            string tableName = "RankInfo";
            SqlManager.Instance.SelectTable(tableName);
            DataTable items = SqlManager.Instance.GetDataTable(tableName);
            foreach (DataRow row in items.Rows)
                rankComboBox.Items.Add(row["rankName"].ToString());
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            RegistForm registForm = new RegistForm();
            registForm.Owner = this;
            if (registForm.ShowDialog(this) == DialogResult.OK)
            {
                Visible = true;
                registForm.Dispose();
                SelectUserInfo();
            }
        }

        private void SelectUserBtn_Click(object sender, EventArgs e)
        {
            string id = idTextBox.Text;
            string name = nameTextBox.Text;
            int part = partComboBox.SelectedIndex == -1 ? -1 : partComboBox.SelectedIndex + 1;
            int rank = rankComboBox.SelectedIndex == -1 ? -1 : rankComboBox.SelectedIndex + 1;            
            DataTable table = SqlManager.Instance.ExecSelectUserinfo(id, name, part, rank);
            userGridView.Columns["uniqueId"].Visible = false;
            userGridView.DataSource = table;
        }

        // 유저정보 조회
        private void SelectUserInfo()
        {
            string tableName = "UserInfo";
            string select =
                $"select " +
                "A.uniqueId, " +
                "A.userId as \"아이디\", A.userName as \"이름\", " +
                "P.partName as \"부서\", auth.authorityName as \"권한\", " +
                "RankInfo.rankName \"직급\", email as \"이메일\", " +
                "phoneNumber1 as \"전화번호1\", phoneNumber2 as \"전화번호2\", " +
                "address1 as \"주소1\", address2 as \"주소2\", " +
                "A.RegisterDate as \"등록일\" " + 
                $"from {tableName} A Inner join PartInfo P On A.part = P.partId " +
                "Inner join AuthorityInfo auth On A.authorityGrade = auth.authorityId " +
                "Inner join RankInfo On A.rankGrade = RankInfo.rankId";

            SqlManager.Instance.SelectTable(tableName, select);
            userGridView.DataSource = SqlManager.Instance.GetDataTable(tableName);
            userGridView.Columns[0].Visible = false;
        }

        private void RemoveUserBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = (int)userGridView.SelectedRows[0].Cells["uniqueId"].Value;
            SqlManager.Instance.RemoveCommand("UserInfo", "uniqueId", selectedIndex);
            SelectUserInfo();
            userGridView.DataSource = SqlManager.Instance.GetDataTable("UserInfo");
        }
    }
}
