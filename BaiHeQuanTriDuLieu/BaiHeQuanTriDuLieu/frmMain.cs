using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiHeQuanTriDuLieu
{
    public partial class frmMain : Form
    {
        private string loaiTaiKhoan;
        private string maNV;
        public frmMain(string loaiTaiKhoan, string maNV)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.maNV = maNV;
            if (loaiTaiKhoan == "2" || loaiTaiKhoan == "4" || loaiTaiKhoan == "5")
            {
                
            }
            else
            {
                mnuQLHeThong.Enabled = false;
                mnuQLHoSo.Enabled = false;

            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == DialogResult.OK)
            {
                this.Close();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanVien = new frmNhanVien();
            nhanVien.MdiParent = this;
            nhanVien.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTaiKhoan taiKhoan = new frmTaiKhoan();
            taiKhoan.MdiParent = this;
            taiKhoan.Show();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmChamCong chamCong = new frmChamCong(loaiTaiKhoan, maNV);
            chamCong.MdiParent = this;
            chamCong.Show();
        }

        private void đánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhGia danhGia = new frmDanhGia();
            danhGia.MdiParent = this;
            danhGia.Show();
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemBangLuong bangLuong = new frmXemBangLuong(loaiTaiKhoan, maNV);
            bangLuong.MdiParent = this;
            bangLuong.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu chucVu = new frmChucVu();
            chucVu.MdiParent = this;
            chucVu.Show();
        }

        private void phòngBanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPhongBan phongBan = new frmPhongBan();
            phongBan.MdiParent = this;
            phongBan.Show();
        }

        private void bảngLươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBangLuong bangLuong = new frmBangLuong(loaiTaiKhoan, maNV);
            bangLuong.MdiParent = this;
            bangLuong.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHoSoNhanVien hoSoNhanVien = new frmHoSoNhanVien(maNV);
            hoSoNhanVien.MdiParent = this;
            hoSoNhanVien.Show();
        }

        private void đánhGiáToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDanhGia danhGia = new frmDanhGia();
            danhGia.MdiParent = this;
            danhGia.Show();
        }

        
    }
}
