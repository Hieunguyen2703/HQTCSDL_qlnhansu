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
    public partial class frmHoSoNhanVien : Form
    {
        private string maNV;
        public frmHoSoNhanVien(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            txtidnhanvien.Enabled = false; txthoten.Enabled = false;
            txtgioitinh.Enabled = false; txtEmail.Enabled = false;
            txtNgaySinh.Enabled = false; txtquequan.Enabled = false;
            txtMaChucVu.Enabled = false; txtMaPhongBan.Enabled = false;
            txtsoLanDG.Enabled = false; txtsodienthoai.Enabled = false;
        }

        private void frmHoSoNhanVien_Load(object sender, EventArgs e)
        {
            string sql = "Select * from NhanVien where MaNV = @MaNV";
            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@MaNV",maNV)
            };
            DataTable dt = TruyXuatCSDL.LayBang(sql, sqlParameter);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];


                txtidnhanvien.Text = row["MaNV"].ToString();
                txthoten.Text = row["HoTen"].ToString();
                if (row["NgaySinh"] != DBNull.Value)
                {
                    DateTime ngaySinh = Convert.ToDateTime(row["NgaySinh"]);
                    txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgaySinh.Text = string.Empty;
                }
                txtgioitinh.Text = row["GioiTinh"].ToString();
                txtquequan.Text = row["DiaChi"].ToString();
                txtsodienthoai.Text = row["SoDienThoai"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtMaPhongBan.Text = row["MaPhongBan"].ToString();
                txtMaChucVu.Text = row["MaChucVu"].ToString();
                txtsoLanDG.Text = row["SoLanDanhGia"].ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
