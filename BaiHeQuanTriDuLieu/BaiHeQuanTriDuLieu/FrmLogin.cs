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
using BaiHeQuanTriDuLieu;
using BaiHeQuanTriDuLieu.Data;


namespace BaiHeQuanTriDuLieu
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            //lblError.Text = " ";
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string taiKhoan = txtTenTKhoan.Text;
                string matKhau = txtMatKhau.Text;

                // Câu truy vấn để lấy MaNV, MaChucVu và LoaiTaiKhoan
                string sql = "select NhanVien.MaNV, ChucVu.MaChucVu  " +
                             "from TaiKhoan " +
                             "inner join NhanVien on TaiKhoan.MaNV = NhanVien.MaNV " +
                             "inner join ChucVu on NhanVien.MaChucVu = ChucVu.MaChucVu " +
                             "where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau";


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", taiKhoan),
                    new SqlParameter("@MatKhau", matKhau)
                };

                // Sử dụng phương thức LayBang để lấy DataTable
                DataTable dt = TruyXuatCSDL.LayBang(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtTenTKhoan.Focus();
                }
                else
                {
                    // Lấy thông tin từ DataTable
                    string maNV = dt.Rows[0]["MaNV"].ToString();
                    string loaiTaiKhoan = dt.Rows[0]["MaChucVu"].ToString();

                    // Kiểm tra nếu là admin (loaiTaiKhoan là 2, 4, hoặc 5)
                    if (loaiTaiKhoan == "2" || loaiTaiKhoan == "4" || loaiTaiKhoan == "5")
                    {
                        MessageBox.Show("Chào mừng Admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Chào mừng user", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Truyền maChucVu và maNV vào frmMain
                    frmMain frmMain = new frmMain(loaiTaiKhoan, maNV);
                    this.Hide();
                    frmMain.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // lblError.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }

        }

    }
}
