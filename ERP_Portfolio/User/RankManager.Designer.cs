
namespace ERP_Portfolio.User
{
    partial class RankManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rankDataGridView = new System.Windows.Forms.DataGridView();
            this.insertRankBtn = new System.Windows.Forms.Button();
            this.rankIdLabel = new System.Windows.Forms.Label();
            this.rankIdTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rankNameTextbox = new System.Windows.Forms.TextBox();
            this.deleteRankBtn = new System.Windows.Forms.Button();
            this.selectRankBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rankDataGridView
            // 
            this.rankDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rankDataGridView.Location = new System.Drawing.Point(24, 187);
            this.rankDataGridView.Name = "rankDataGridView";
            this.rankDataGridView.RowTemplate.Height = 23;
            this.rankDataGridView.Size = new System.Drawing.Size(254, 251);
            this.rankDataGridView.TabIndex = 0;
            // 
            // insertRankBtn
            // 
            this.insertRankBtn.Location = new System.Drawing.Point(203, 40);
            this.insertRankBtn.Name = "insertRankBtn";
            this.insertRankBtn.Size = new System.Drawing.Size(75, 37);
            this.insertRankBtn.TabIndex = 1;
            this.insertRankBtn.Text = "직급 추가";
            this.insertRankBtn.UseVisualStyleBackColor = true;
            this.insertRankBtn.Click += new System.EventHandler(this.insertRankBtn_Click);
            // 
            // rankIdLabel
            // 
            this.rankIdLabel.AutoSize = true;
            this.rankIdLabel.Location = new System.Drawing.Point(22, 53);
            this.rankIdLabel.Name = "rankIdLabel";
            this.rankIdLabel.Size = new System.Drawing.Size(57, 12);
            this.rankIdLabel.TabIndex = 2;
            this.rankIdLabel.Text = "직급 번호";
            // 
            // rankIdTextbox
            // 
            this.rankIdTextbox.Location = new System.Drawing.Point(24, 78);
            this.rankIdTextbox.Name = "rankIdTextbox";
            this.rankIdTextbox.Size = new System.Drawing.Size(100, 21);
            this.rankIdTextbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "직급 이름";
            // 
            // rankNameTextbox
            // 
            this.rankNameTextbox.Location = new System.Drawing.Point(24, 135);
            this.rankNameTextbox.Name = "rankNameTextbox";
            this.rankNameTextbox.Size = new System.Drawing.Size(100, 21);
            this.rankNameTextbox.TabIndex = 3;
            // 
            // deleteRankBtn
            // 
            this.deleteRankBtn.Location = new System.Drawing.Point(203, 88);
            this.deleteRankBtn.Name = "deleteRankBtn";
            this.deleteRankBtn.Size = new System.Drawing.Size(75, 37);
            this.deleteRankBtn.TabIndex = 1;
            this.deleteRankBtn.Text = "직급 삭제";
            this.deleteRankBtn.UseVisualStyleBackColor = true;
            this.deleteRankBtn.Click += new System.EventHandler(this.deleteRankBtn_Click);
            // 
            // selectRankBtn
            // 
            this.selectRankBtn.Location = new System.Drawing.Point(203, 135);
            this.selectRankBtn.Name = "selectRankBtn";
            this.selectRankBtn.Size = new System.Drawing.Size(75, 37);
            this.selectRankBtn.TabIndex = 1;
            this.selectRankBtn.Text = "직급 조회";
            this.selectRankBtn.UseVisualStyleBackColor = true;
            this.selectRankBtn.Click += new System.EventHandler(this.selectRankBtn_Click);
            // 
            // RankManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 476);
            this.Controls.Add(this.rankNameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rankIdTextbox);
            this.Controls.Add(this.rankIdLabel);
            this.Controls.Add(this.selectRankBtn);
            this.Controls.Add(this.deleteRankBtn);
            this.Controls.Add(this.insertRankBtn);
            this.Controls.Add(this.rankDataGridView);
            this.Name = "RankManager";
            this.Text = "RankManager";
            this.Load += new System.EventHandler(this.RankManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rankDataGridView;
        private System.Windows.Forms.Button insertRankBtn;
        private System.Windows.Forms.Label rankIdLabel;
        private System.Windows.Forms.TextBox rankIdTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rankNameTextbox;
        private System.Windows.Forms.Button deleteRankBtn;
        private System.Windows.Forms.Button selectRankBtn;
    }
}