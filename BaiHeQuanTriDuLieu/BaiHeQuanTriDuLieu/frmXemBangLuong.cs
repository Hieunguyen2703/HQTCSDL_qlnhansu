using BaiHeQuanTriDuLieu.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiHeQuanTriDuLieu
{
    public partial class frmXemBangLuong : Form
    {
        private string loaiTaiKhoan;
        private string maNV;
        public frmXemBangLuong(string loaiTaiKhoan, string maNV)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.maNV = maNV;
            txtMaNV.Enabled = false;
        }


        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();
        public void loadForm()
        {
            string sql = "SELECT * FROM vw_ChiTietBangLuong " +
                         "WHERE MaNV = @MaNV " +
                         "AND (YEAR(NgayThang) < YEAR(GETDATE()) " +
                         "OR (YEAR(NgayThang) = YEAR(GETDATE()) AND MONTH(NgayThang) < MONTH(GETDATE())))" +
                         "ORDER BY NgayThang ASC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV",maNV)
            };
            dgvMain.DataSource = TruyXuatCSDL.LayBang(sql, parameters);

        }
        private void frmXemBangLuong_Load(object sender, EventArgs e)
        {

            loadForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int month = dtpNgayThang.Value.Month;
                int year = dtpNgayThang.Value.Year;

                string sql = "SELECT * FROM vw_ChiTietBangLuong WHERE MaNV = @MaNV AND MONTH(NgayThang) = @Month AND YEAR(NgayThang) = @Year";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@Month", month),
                    new SqlParameter("@Year", year)
                };
                dgvMain.DataSource = TruyXuatCSDL.LayBang(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message); // Hiển thị thông báo lỗi
            }
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            loadForm();
            dtpNgayThang.Value = DateTime.Now;
            dgvMain.ClearSelection();
        }
    }
}
