
namespace LTTQ_Buoi9
{
    partial class ucTrangChu
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
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDeliveryDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDeliveryDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbViewAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(630, 492);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 22);
            this.txtPrice.TabIndex = 12;
            this.txtPrice.Text = "0";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tổng cộng:";
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(168, 480);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(148, 36);
            this.btnAddInvoice.TabIndex = 10;
            this.btnAddInvoice.Text = "Thêm đơn hàng";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(14, 480);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(148, 36);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "In /Xem";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvSearch
            // 
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(14, 123);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.RowHeadersWidth = 51;
            this.dgvSearch.RowTemplate.Height = 24;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(773, 351);
            this.dgvSearch.TabIndex = 8;
            this.dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDeliveryDateTo);
            this.groupBox1.Controls.Add(this.dtpDeliveryDateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckbViewAll);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 103);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đơn hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "~";
            // 
            // dtpDeliveryDateTo
            // 
            this.dtpDeliveryDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDateTo.Location = new System.Drawing.Point(331, 66);
            this.dtpDeliveryDateTo.Name = "dtpDeliveryDateTo";
            this.dtpDeliveryDateTo.Size = new System.Drawing.Size(118, 22);
            this.dtpDeliveryDateTo.TabIndex = 3;
            this.dtpDeliveryDateTo.ValueChanged += new System.EventHandler(this.dtpDeliveryDateTo_ValueChanged);
            // 
            // dtpDeliveryDateFrom
            // 
            this.dtpDeliveryDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDateFrom.Location = new System.Drawing.Point(174, 66);
            this.dtpDeliveryDateFrom.Name = "dtpDeliveryDateFrom";
            this.dtpDeliveryDateFrom.Size = new System.Drawing.Size(118, 22);
            this.dtpDeliveryDateFrom.TabIndex = 2;
            this.dtpDeliveryDateFrom.ValueChanged += new System.EventHandler(this.dtpDeliveryDateFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thời gian giao hàng";
            // 
            // ckbViewAll
            // 
            this.ckbViewAll.AutoSize = true;
            this.ckbViewAll.Location = new System.Drawing.Point(19, 30);
            this.ckbViewAll.Name = "ckbViewAll";
            this.ckbViewAll.Size = new System.Drawing.Size(174, 21);
            this.ckbViewAll.TabIndex = 0;
            this.ckbViewAll.Text = "Xem tất cả trong tháng";
            this.ckbViewAll.UseVisualStyleBackColor = true;
            this.ckbViewAll.CheckedChanged += new System.EventHandler(this.ckbViewAll_CheckedChanged);
            // 
            // ucTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucTrangChu";
            this.Size = new System.Drawing.Size(800, 530);
            this.Load += new System.EventHandler(this.ucTrangChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDateTo;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbViewAll;
    }
}
