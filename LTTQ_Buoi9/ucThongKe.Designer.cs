
namespace LTTQ_Buoi9
{
    partial class ucThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStatisticsMonth = new System.Windows.Forms.Button();
            this.btnStatistics3Month = new System.Windows.Forms.Button();
            this.btnStatisticsYear = new System.Windows.Forms.Button();
            this.btnStatisticsProductYear = new System.Windows.Forms.Button();
            this.btnStatisticsProduct3Month = new System.Windows.Forms.Button();
            this.btnStatisticsProductMonth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStatisticsMonth
            // 
            this.btnStatisticsMonth.Location = new System.Drawing.Point(41, 71);
            this.btnStatisticsMonth.Name = "btnStatisticsMonth";
            this.btnStatisticsMonth.Size = new System.Drawing.Size(215, 81);
            this.btnStatisticsMonth.TabIndex = 0;
            this.btnStatisticsMonth.Text = "Doanh Thu Theo Tháng";
            this.btnStatisticsMonth.UseVisualStyleBackColor = true;
            this.btnStatisticsMonth.Click += new System.EventHandler(this.btnStatisticsMonth_Click);
            // 
            // btnStatistics3Month
            // 
            this.btnStatistics3Month.Location = new System.Drawing.Point(278, 71);
            this.btnStatistics3Month.Name = "btnStatistics3Month";
            this.btnStatistics3Month.Size = new System.Drawing.Size(215, 81);
            this.btnStatistics3Month.TabIndex = 1;
            this.btnStatistics3Month.Text = "Doanh Thu Theo Quý";
            this.btnStatistics3Month.UseVisualStyleBackColor = true;
            this.btnStatistics3Month.Click += new System.EventHandler(this.btnStatistics3Month_Click);
            // 
            // btnStatisticsYear
            // 
            this.btnStatisticsYear.Location = new System.Drawing.Point(524, 71);
            this.btnStatisticsYear.Name = "btnStatisticsYear";
            this.btnStatisticsYear.Size = new System.Drawing.Size(215, 81);
            this.btnStatisticsYear.TabIndex = 2;
            this.btnStatisticsYear.Text = "Doanh Thu Theo Năm";
            this.btnStatisticsYear.UseVisualStyleBackColor = true;
            this.btnStatisticsYear.Click += new System.EventHandler(this.btnStatisticsYear_Click);
            // 
            // btnStatisticsProductYear
            // 
            this.btnStatisticsProductYear.Location = new System.Drawing.Point(524, 250);
            this.btnStatisticsProductYear.Name = "btnStatisticsProductYear";
            this.btnStatisticsProductYear.Size = new System.Drawing.Size(215, 81);
            this.btnStatisticsProductYear.TabIndex = 5;
            this.btnStatisticsProductYear.Text = "Doanh Thu Theo Năm";
            this.btnStatisticsProductYear.UseVisualStyleBackColor = true;
            this.btnStatisticsProductYear.Click += new System.EventHandler(this.btnStatisticsProductYear_Click);
            // 
            // btnStatisticsProduct3Month
            // 
            this.btnStatisticsProduct3Month.Location = new System.Drawing.Point(278, 250);
            this.btnStatisticsProduct3Month.Name = "btnStatisticsProduct3Month";
            this.btnStatisticsProduct3Month.Size = new System.Drawing.Size(215, 81);
            this.btnStatisticsProduct3Month.TabIndex = 4;
            this.btnStatisticsProduct3Month.Text = "Doanh Thu Theo Quý";
            this.btnStatisticsProduct3Month.UseVisualStyleBackColor = true;
            this.btnStatisticsProduct3Month.Click += new System.EventHandler(this.btnStatisticsProduct3Month_Click);
            // 
            // btnStatisticsProductMonth
            // 
            this.btnStatisticsProductMonth.Location = new System.Drawing.Point(41, 250);
            this.btnStatisticsProductMonth.Name = "btnStatisticsProductMonth";
            this.btnStatisticsProductMonth.Size = new System.Drawing.Size(215, 81);
            this.btnStatisticsProductMonth.TabIndex = 3;
            this.btnStatisticsProductMonth.Text = "Doanh Thu Theo Tháng";
            this.btnStatisticsProductMonth.UseVisualStyleBackColor = true;
            this.btnStatisticsProductMonth.Click += new System.EventHandler(this.btnStatisticsProductMonth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Doanh Thu Từng Loại Sản Phẩm";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(324, 24);
            this.numYear.Maximum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 22);
            this.numYear.TabIndex = 7;
            this.numYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tháng";
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(115, 24);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(120, 22);
            this.numMonth.TabIndex = 9;
            this.numMonth.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // ucThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStatisticsProductYear);
            this.Controls.Add(this.btnStatisticsProduct3Month);
            this.Controls.Add(this.btnStatisticsProductMonth);
            this.Controls.Add(this.btnStatisticsYear);
            this.Controls.Add(this.btnStatistics3Month);
            this.Controls.Add(this.btnStatisticsMonth);
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(800, 530);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStatisticsMonth;
        private System.Windows.Forms.Button btnStatistics3Month;
        private System.Windows.Forms.Button btnStatisticsYear;
        private System.Windows.Forms.Button btnStatisticsProductYear;
        private System.Windows.Forms.Button btnStatisticsProduct3Month;
        private System.Windows.Forms.Button btnStatisticsProductMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMonth;
    }
}
