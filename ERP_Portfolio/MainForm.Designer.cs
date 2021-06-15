
namespace ERP_Portfolio
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.인사관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.권한관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.직급관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.생산ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.구매ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제품ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제품등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.인사관리ToolStripMenuItem,
            this.생산ToolStripMenuItem,
            this.구매ToolStripMenuItem,
            this.제품ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 인사관리ToolStripMenuItem
            // 
            this.인사관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자등록ToolStripMenuItem,
            this.권한관리ToolStripMenuItem,
            this.직급관리ToolStripMenuItem});
            this.인사관리ToolStripMenuItem.Name = "인사관리ToolStripMenuItem";
            this.인사관리ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.인사관리ToolStripMenuItem.Text = "인사";
            // 
            // 사용자등록ToolStripMenuItem
            // 
            this.사용자등록ToolStripMenuItem.Name = "사용자등록ToolStripMenuItem";
            this.사용자등록ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.사용자등록ToolStripMenuItem.Text = "사용자 관리";
            this.사용자등록ToolStripMenuItem.Click += new System.EventHandler(this.사용자등록ToolStripMenuItem_Click);
            // 
            // 권한관리ToolStripMenuItem
            // 
            this.권한관리ToolStripMenuItem.Name = "권한관리ToolStripMenuItem";
            this.권한관리ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.권한관리ToolStripMenuItem.Text = "권한 관리";
            this.권한관리ToolStripMenuItem.Click += new System.EventHandler(this.권한관리ToolStripMenuItem_Click);
            // 
            // 직급관리ToolStripMenuItem
            // 
            this.직급관리ToolStripMenuItem.Name = "직급관리ToolStripMenuItem";
            this.직급관리ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.직급관리ToolStripMenuItem.Text = "직급 관리";
            this.직급관리ToolStripMenuItem.Click += new System.EventHandler(this.직급관리ToolStripMenuItem_Click);
            // 
            // 생산ToolStripMenuItem
            // 
            this.생산ToolStripMenuItem.Name = "생산ToolStripMenuItem";
            this.생산ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.생산ToolStripMenuItem.Text = "생산";
            // 
            // 구매ToolStripMenuItem
            // 
            this.구매ToolStripMenuItem.Name = "구매ToolStripMenuItem";
            this.구매ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.구매ToolStripMenuItem.Text = "구매";
            // 
            // 제품ToolStripMenuItem
            // 
            this.제품ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.제품등록ToolStripMenuItem});
            this.제품ToolStripMenuItem.Name = "제품ToolStripMenuItem";
            this.제품ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.제품ToolStripMenuItem.Text = "제품";
            // 
            // 제품등록ToolStripMenuItem
            // 
            this.제품등록ToolStripMenuItem.Name = "제품등록ToolStripMenuItem";
            this.제품등록ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.제품등록ToolStripMenuItem.Text = "제품 관리";
            this.제품등록ToolStripMenuItem.Click += new System.EventHandler(this.제품등록ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 인사관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 생산ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 권한관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 직급관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 구매ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제품ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제품등록ToolStripMenuItem;
    }
}