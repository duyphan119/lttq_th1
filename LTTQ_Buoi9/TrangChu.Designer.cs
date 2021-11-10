
namespace LTTQ_Buoi9
{
    partial class TrangChu
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
            this.đơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.thốngKêToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đơnHàngToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đơnHàngToolStripMenuItem
            // 
            this.đơnHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpĐơnHàngToolStripMenuItem,
            this.thốngKêToolStripMenuItem1,
            this.thoátToolStripMenuItem});
            this.đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            this.đơnHàngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.đơnHàngToolStripMenuItem.Text = "Đơn hàng";
            // 
            // nhậpĐơnHàngToolStripMenuItem
            // 
            this.nhậpĐơnHàngToolStripMenuItem.Name = "nhậpĐơnHàngToolStripMenuItem";
            this.nhậpĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhậpĐơnHàngToolStripMenuItem.Text = "Nhập đơn hàng";
            this.nhậpĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpĐơnHàngToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíSảnPhẩmToolStripMenuItem,
            this.xuấtBáoToolStripMenuItem});
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            // 
            // quảnLíSảnPhẩmToolStripMenuItem
            // 
            this.quảnLíSảnPhẩmToolStripMenuItem.Name = "quảnLíSảnPhẩmToolStripMenuItem";
            this.quảnLíSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.quảnLíSảnPhẩmToolStripMenuItem.Text = "Quản lí sản phẩm";
            this.quảnLíSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLíSảnPhẩmToolStripMenuItem_Click);
            // 
            // xuấtBáoToolStripMenuItem
            // 
            this.xuấtBáoToolStripMenuItem.Name = "xuấtBáoToolStripMenuItem";
            this.xuấtBáoToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.xuấtBáoToolStripMenuItem.Text = "Xuất báo giá sản phẩm";
            this.xuấtBáoToolStripMenuItem.Click += new System.EventHandler(this.xuấtBáoToolStripMenuItem_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Location = new System.Drawing.Point(0, 31);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(800, 530);
            this.pnlControl.TabIndex = 1;
            this.pnlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControl_Paint);
            // 
            // thốngKêToolStripMenuItem1
            // 
            this.thốngKêToolStripMenuItem1.Name = "thốngKêToolStripMenuItem1";
            this.thốngKêToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.thốngKêToolStripMenuItem1.Text = "Thống kê";
            this.thốngKêToolStripMenuItem1.Click += new System.EventHandler(this.thốngKêToolStripMenuItem1_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyDonHang";
            this.Load += new System.EventHandler(this.TrangChu_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtBáoToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem1;
    }
}