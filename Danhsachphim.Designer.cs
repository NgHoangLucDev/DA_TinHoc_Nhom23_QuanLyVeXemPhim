namespace DoAnTinHoc
{
    partial class frmDanhsachphim
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTheLoai = new System.Windows.Forms.Panel();
            this.btnDatghe = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThongTinPhim = new System.Windows.Forms.DataGridView();
            this.NgayChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoRap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlTheLoai.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinPhim)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuayLai);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.Ivory;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(0, 0);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(77, 45);
            this.btnQuayLai.TabIndex = 0;
            this.btnQuayLai.Text = "<- BACK";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(188, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(423, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH PHIM CHIẾU TẠI RẠP HÔM NAY";
            // 
            // pnlTheLoai
            // 
            this.pnlTheLoai.Controls.Add(this.btnDatghe);
            this.pnlTheLoai.Controls.Add(this.txtSearch);
            this.pnlTheLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTheLoai.Location = new System.Drawing.Point(0, 45);
            this.pnlTheLoai.Name = "pnlTheLoai";
            this.pnlTheLoai.Size = new System.Drawing.Size(235, 480);
            this.pnlTheLoai.TabIndex = 1;
            // 
            // btnDatghe
            // 
            this.btnDatghe.Location = new System.Drawing.Point(0, 444);
            this.btnDatghe.Name = "btnDatghe";
            this.btnDatghe.Size = new System.Drawing.Size(246, 34);
            this.btnDatghe.TabIndex = 1;
            this.btnDatghe.Text = "Đặt Ghế";
            this.btnDatghe.UseVisualStyleBackColor = true;
            this.btnDatghe.Click += new System.EventHandler(this.btnDatghe_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(232, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm Phim";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvThongTinPhim);
            this.panel2.Location = new System.Drawing.Point(241, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 481);
            this.panel2.TabIndex = 3;
            // 
            // dgvThongTinPhim
            // 
            this.dgvThongTinPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTinPhim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayChieu,
            this.TenPhim,
            this.SoRap});
            this.dgvThongTinPhim.Location = new System.Drawing.Point(6, 5);
            this.dgvThongTinPhim.Name = "dgvThongTinPhim";
            this.dgvThongTinPhim.RowHeadersWidth = 51;
            this.dgvThongTinPhim.RowTemplate.Height = 24;
            this.dgvThongTinPhim.Size = new System.Drawing.Size(653, 474);
            this.dgvThongTinPhim.TabIndex = 0;
            // 
            // NgayChieu
            // 
            this.NgayChieu.DataPropertyName = "NgayChieu";
            this.NgayChieu.HeaderText = "Ngày Chiếu";
            this.NgayChieu.MinimumWidth = 6;
            this.NgayChieu.Name = "NgayChieu";
            this.NgayChieu.Width = 125;
            // 
            // TenPhim
            // 
            this.TenPhim.DataPropertyName = "TenPhim";
            this.TenPhim.HeaderText = "Tên Phim";
            this.TenPhim.MinimumWidth = 6;
            this.TenPhim.Name = "TenPhim";
            this.TenPhim.Width = 125;
            // 
            // SoRap
            // 
            this.SoRap.DataPropertyName = "SoRap";
            this.SoRap.HeaderText = "Số Rạp";
            this.SoRap.MinimumWidth = 6;
            this.SoRap.Name = "SoRap";
            this.SoRap.Width = 125;
            // 
            // frmDanhsachphim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTheLoai);
            this.Controls.Add(this.panel1);
            this.Name = "frmDanhsachphim";
            this.Text = "Danh sách phim";
            this.Load += new System.EventHandler(this.frmDanhsachphim_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTheLoai.ResumeLayout(false);
            this.pnlTheLoai.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinPhim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTheLoai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.DataGridView dgvThongTinPhim;
        private System.Windows.Forms.Button btnDatghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhim;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoRap;
    }
}