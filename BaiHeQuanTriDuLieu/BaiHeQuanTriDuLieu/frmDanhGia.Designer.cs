namespace BaiHeQuanTriDuLieu
{
    partial class frmDanhGia
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
            this.lblMaDanhGia = new System.Windows.Forms.Label();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.lblNgayThang = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.dtpNgayThang = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReSet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.cmbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoaiDanhGia = new System.Windows.Forms.Label();
            this.cmbLoaiDanhGia = new System.Windows.Forms.ComboBox();
            this.txtMaDanhGia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaDanhGia
            // 
            this.lblMaDanhGia.AutoSize = true;
            this.lblMaDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDanhGia.Location = new System.Drawing.Point(68, 33);
            this.lblMaDanhGia.Name = "lblMaDanhGia";
            this.lblMaDanhGia.Size = new System.Drawing.Size(107, 18);
            this.lblMaDanhGia.TabIndex = 0;
            this.lblMaDanhGia.Text = "Mã Đánh Giá : ";
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhanVien.Location = new System.Drawing.Point(68, 77);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(108, 18);
            this.lblMaNhanVien.TabIndex = 1;
            this.lblMaNhanVien.Text = "Mã Nhân Viên :";
            // 
            // lblNgayThang
            // 
            this.lblNgayThang.AutoSize = true;
            this.lblNgayThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThang.Location = new System.Drawing.Point(68, 122);
            this.lblNgayThang.Name = "lblNgayThang";
            this.lblNgayThang.Size = new System.Drawing.Size(95, 18);
            this.lblNgayThang.TabIndex = 3;
            this.lblNgayThang.Text = "Ngày Tháng :";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.Location = new System.Drawing.Point(426, 32);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(67, 18);
            this.lblSoTien.TabIndex = 4;
            this.lblSoTien.Text = "Số Tiền :";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLyDo.Location = new System.Drawing.Point(426, 77);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(55, 18);
            this.lblLyDo.TabIndex = 5;
            this.lblLyDo.Text = "Lý Do :";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(556, 74);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(163, 20);
            this.txtLyDo.TabIndex = 8;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(556, 30);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(163, 20);
            this.txtSoTien.TabIndex = 9;
            // 
            // dtpNgayThang
            // 
            this.dtpNgayThang.CustomFormat = "";
            this.dtpNgayThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThang.Location = new System.Drawing.Point(182, 120);
            this.dtpNgayThang.Name = "dtpNgayThang";
            this.dtpNgayThang.Size = new System.Drawing.Size(172, 20);
            this.dtpNgayThang.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(71, 169);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(215, 169);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(362, 169);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReSet
            // 
            this.btnReSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSet.Location = new System.Drawing.Point(648, 169);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(75, 32);
            this.btnReSet.TabIndex = 14;
            this.btnReSet.Text = "Reset";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(510, 169);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 32);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(56, 217);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(682, 221);
            this.dgvMain.TabIndex = 16;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            this.dgvMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEnter);
            // 
            // cmbMaNhanVien
            // 
            this.cmbMaNhanVien.FormattingEnabled = true;
            this.cmbMaNhanVien.Location = new System.Drawing.Point(182, 74);
            this.cmbMaNhanVien.Name = "cmbMaNhanVien";
            this.cmbMaNhanVien.Size = new System.Drawing.Size(172, 21);
            this.cmbMaNhanVien.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "label1";
            // 
            // lblLoaiDanhGia
            // 
            this.lblLoaiDanhGia.AutoSize = true;
            this.lblLoaiDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiDanhGia.Location = new System.Drawing.Point(426, 122);
            this.lblLoaiDanhGia.Name = "lblLoaiDanhGia";
            this.lblLoaiDanhGia.Size = new System.Drawing.Size(110, 18);
            this.lblLoaiDanhGia.TabIndex = 20;
            this.lblLoaiDanhGia.Text = "Loại Đánh Giá :";
            // 
            // cmbLoaiDanhGia
            // 
            this.cmbLoaiDanhGia.FormattingEnabled = true;
            this.cmbLoaiDanhGia.Items.AddRange(new object[] {
            "Thưởng",
            "Phạt"});
            this.cmbLoaiDanhGia.Location = new System.Drawing.Point(556, 119);
            this.cmbLoaiDanhGia.Name = "cmbLoaiDanhGia";
            this.cmbLoaiDanhGia.Size = new System.Drawing.Size(163, 21);
            this.cmbLoaiDanhGia.TabIndex = 21;
            // 
            // txtMaDanhGia
            // 
            this.txtMaDanhGia.Location = new System.Drawing.Point(182, 30);
            this.txtMaDanhGia.Name = "txtMaDanhGia";
            this.txtMaDanhGia.Size = new System.Drawing.Size(172, 20);
            this.txtMaDanhGia.TabIndex = 22;
            // 
            // frmDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMaDanhGia);
            this.Controls.Add(this.cmbLoaiDanhGia);
            this.Controls.Add(this.lblLoaiDanhGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMaNhanVien);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtpNgayThang);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.lblNgayThang);
            this.Controls.Add(this.lblMaNhanVien);
            this.Controls.Add(this.lblMaDanhGia);
            this.Name = "frmDanhGia";
            this.Text = "frmDanhGiaNhanVien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaDanhGia;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.Label lblNgayThang;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.DateTimePicker dtpNgayThang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cmbMaNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoaiDanhGia;
        private System.Windows.Forms.ComboBox cmbLoaiDanhGia;
        private System.Windows.Forms.TextBox txtMaDanhGia;
    }
}