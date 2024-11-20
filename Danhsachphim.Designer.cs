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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTheLoai = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbTheLoaiPhim = new System.Windows.Forms.ComboBox();
            this.lstDanhSachPhim = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDatghe = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picPhim = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblThongTinFilm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlTheLoai.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhim)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 45);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(177, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách phim chiếu ngày hôm nay:";
            // 
            // pnlTheLoai
            // 
            this.pnlTheLoai.Controls.Add(this.txtSearch);
            this.pnlTheLoai.Controls.Add(this.cmbTheLoaiPhim);
            this.pnlTheLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTheLoai.Location = new System.Drawing.Point(0, 45);
            this.pnlTheLoai.Name = "pnlTheLoai";
            this.pnlTheLoai.Size = new System.Drawing.Size(235, 480);
            this.pnlTheLoai.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(232, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Tìm Phim";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbTheLoaiPhim
            // 
            this.cmbTheLoaiPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTheLoaiPhim.FormattingEnabled = true;
            this.cmbTheLoaiPhim.Location = new System.Drawing.Point(0, 40);
            this.cmbTheLoaiPhim.Name = "cmbTheLoaiPhim";
            this.cmbTheLoaiPhim.Size = new System.Drawing.Size(232, 24);
            this.cmbTheLoaiPhim.TabIndex = 2;
            this.cmbTheLoaiPhim.Text = "Chọn thể loại phim ";
            this.cmbTheLoaiPhim.SelectedIndexChanged += new System.EventHandler(this.cmbTheLoaiPhim_SelectedIndexChanged);
            // 
            // lstDanhSachPhim
            // 
            this.lstDanhSachPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDanhSachPhim.FormattingEnabled = true;
            this.lstDanhSachPhim.ItemHeight = 16;
            this.lstDanhSachPhim.Location = new System.Drawing.Point(0, 0);
            this.lstDanhSachPhim.Name = "lstDanhSachPhim";
            this.lstDanhSachPhim.Size = new System.Drawing.Size(307, 481);
            this.lstDanhSachPhim.TabIndex = 2;
            this.lstDanhSachPhim.SelectedIndexChanged += new System.EventHandler(this.lstDanhSachPhim_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDatghe);
            this.panel2.Controls.Add(this.lstDanhSachPhim);
            this.panel2.Location = new System.Drawing.Point(241, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 481);
            this.panel2.TabIndex = 3;
            // 
            // btnDatghe
            // 
            this.btnDatghe.Location = new System.Drawing.Point(0, 419);
            this.btnDatghe.Name = "btnDatghe";
            this.btnDatghe.Size = new System.Drawing.Size(307, 61);
            this.btnDatghe.TabIndex = 3;
            this.btnDatghe.Text = "Đặt ghế";
            this.btnDatghe.UseVisualStyleBackColor = true;
            this.btnDatghe.Click += new System.EventHandler(this.btnDatghe_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picPhim);
            this.panel3.Location = new System.Drawing.Point(554, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 376);
            this.panel3.TabIndex = 4;
            // 
            // picPhim
            // 
            this.picPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPhim.Location = new System.Drawing.Point(0, 0);
            this.picPhim.Name = "picPhim";
            this.picPhim.Size = new System.Drawing.Size(356, 376);
            this.picPhim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhim.TabIndex = 0;
            this.picPhim.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblThongTinFilm);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(555, 425);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 100);
            this.panel4.TabIndex = 5;
            // 
            // lblThongTinFilm
            // 
            this.lblThongTinFilm.AutoSize = true;
            this.lblThongTinFilm.Location = new System.Drawing.Point(3, 27);
            this.lblThongTinFilm.Name = "lblThongTinFilm";
            this.lblThongTinFilm.Size = new System.Drawing.Size(53, 16);
            this.lblThongTinFilm.TabIndex = 1;
            this.lblThongTinFilm.Text = "Tại đây";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin phim";
            // 
            // frmDanhsachphim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 525);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTheLoai);
            this.Controls.Add(this.panel1);
            this.Name = "frmDanhsachphim";
            this.Text = "Danh sách phim";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTheLoai.ResumeLayout(false);
            this.pnlTheLoai.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPhim)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTheLoai;
        private System.Windows.Forms.ComboBox cmbTheLoaiPhim;
        private System.Windows.Forms.ListBox lstDanhSachPhim;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDatghe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picPhim;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblThongTinFilm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}