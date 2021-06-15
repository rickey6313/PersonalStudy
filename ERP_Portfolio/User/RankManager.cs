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
    public partial class RankManager : Form
    {
        private string _tableName = "RankInfo";

        public RankManager()
        {
            InitializeComponent();
        }

        private void RankManager_Load(object sender, EventArgs e)
        {
            LoadRankInfo();
        }

        private void LoadRankInfo()
        {
            SelectRankInfo(-1);
        }

        private void insertRankBtn_Click(object sender, EventArgs e)
        {
            if (rankIdTextbox.Text == "" || rankNameTextbox.Text == "")
                return;

            int id = int.Parse(rankIdTextbox.Text);
            
            int success = SqlManager.Instance.ExecuteInsertRankInfo(id, rankNameTextbox.Text);
            if (success == -1)
                MessageBox.Show("번호 또는 이름이 중복 됩니다.", "직급 추가");
            else
            {
                LoadRankInfo();
                MessageBox.Show("등록되었습니다.", "직급 추가");
            }

        }

        private void deleteRankBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = (int)rankDataGridView.SelectedRows[0].Cells["rankId"].Value;
            SqlManager.Instance.RemoveCommand(_tableName, "rankId", selectedIndex);
            LoadRankInfo();
        }

        private void selectRankBtn_Click(object sender, EventArgs e)
        {
            int id = -1;

            if (rankIdTextbox.Text == "")
                id = -1;
            else
                id = int.Parse(rankIdTextbox.Text);

            SelectRankInfo(id);
        }

        private void SelectRankInfo(int id)
        {
            string name = rankNameTextbox.Text;
            DataTable table = SqlManager.Instance.ExecuteSelectRankInfo(id, name);
            rankDataGridView.DataSource = table;
            rankDataGridView.Columns["rankId"].Visible = false;
        }
    }
}
