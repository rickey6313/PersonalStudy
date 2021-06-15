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
    public partial class MainForm : Form
    {
        private Form1 _loginForm;
        private UserManagerForm _userManagerForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _loginForm = (Form1)Owner;
            if(_loginForm != null)
                _loginForm.Visible = false;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm?.Dispose();
        }

        private void 사용자등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _userManagerForm = new UserManagerForm();
            _userManagerForm.Owner = this;
            if (_userManagerForm.ShowDialog(this) == DialogResult.OK)
                _userManagerForm.Dispose();
        }

        private void 권한관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 직급관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RankManager rankManager = new RankManager();
            //rankManager.Owner = this;
            if(rankManager.ShowDialog(this) == DialogResult.OK)
            {
                rankManager.Dispose();
            }
        }

        private void 제품등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
