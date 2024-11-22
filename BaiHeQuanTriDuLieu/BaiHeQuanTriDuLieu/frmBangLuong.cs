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
    public partial class frmBangLuong : Form
    {
        private string loaiTaiKhoan;
        private string maNV;
        public frmBangLuong(string loaiTaiKhoan,string maNV)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.maNV = maNV;
            txtMaBangLuong.Enabled = false;

            
        }
        TruyXuatCSDL truyXuatCSDL=new TruyXuatCSDL();
        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM vw_ChiTietBangLuong ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV",maNV)
            };
            
            dgvMain.DataSource= TruyXuatCSDL.LayBang(sql, parameters);

        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietBangLuong", null);
           txtMaBangLuong.ResetText();
            txtHeSoLuong.ResetText();
            txtLuongCoBan.ResetText();
            txtPhuCap.ResetText();
            dtpNgayThang.Value = DateTime.Now;
            cbMaNV.DataSource = TruyXuatCSDL.LayDanhSach("select MaNV from NhanVien", null);
            dgvMain.ClearSelection();
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaBangLuong.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                cbMaNV.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();

                
                dtpNgayThang.Value = Convert.ToDateTime(dgvMain.CurrentRow.Cells[5].Value);

                txtLuongCoBan.Text = dgvMain.CurrentRow.Cells[6].Value.ToString();

                txtHeSoLuong.Text = dgvMain.CurrentRow.Cells[7].Value.ToString();

                txtPhuCap.Text = dgvMain.CurrentRow.Cells[8].Value.ToString();
            }
        }
        public bool KiemTraTrungLap(int maNV, DateTime ngayThang)
        {
            string sql = "SELECT COUNT(1) FROM BangLuong WHERE MaNV = @MaNV AND NgayThang = @NgayThang";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaNV", maNV),
            new SqlParameter("@NgayThang", ngayThang)
            };

            object result = truyXuatCSDL.lay1DuLieu(sql, parameters);
            return Convert.ToInt32(result) >0 ;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtHeSoLuong.Text) ||
                    string.IsNullOrWhiteSpace(txtLuongCoBan.Text) ||
                    string.IsNullOrWhiteSpace(txtPhuCap.Text)||
                    cbMaNV.Text == "All")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtLuongCoBan.Text, out decimal luongCoBan) ||
                    !decimal.TryParse(txtHeSoLuong.Text, out decimal heSoLuong) ||
                    !decimal.TryParse(txtPhuCap.Text, out decimal phuCap))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(KiemTraTrungLap(Convert.ToInt32(cbMaNV.Text), dtpNgayThang.Value)){
                    MessageBox.Show("Đã có bản ghi lương cho nhân viên này trong tháng này.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "EXEC sp_ThemBangLuong @MaNV, @NgayThang, @LuongCoBan, @HeSoLuong, @PhuCap";
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@MaNV", cbMaNV.Text),
                        new SqlParameter("@NgayThang", dtpNgayThang.Value),
                        new SqlParameter("@LuongCoBan", luongCoBan),
                        new SqlParameter("@HeSoLuong", heSoLuong),
                        new SqlParameter("@PhuCap", phuCap),
                };
                TruyXuatCSDL.themSuaXoa(sql, parameters);
                dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietBangLuong", null);
                MessageBox.Show("Đã thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvMain.SelectedRows.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(txtHeSoLuong.Text) ||
                    string.IsNullOrWhiteSpace(txtLuongCoBan.Text) ||
                    string.IsNullOrWhiteSpace(txtPhuCap.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sql = "UPDATE BangLuong SET MaNV = @MaNV, NgayThang = @NgayThang, " +
                                 "LuongCoBan = @LuongCoBan, HeSoLuong = @HeSoLuong, PhuCap = @PhuCap " +
                                 "WHERE MaBangLuong = @MaBangLuong";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaBangLuong", txtMaBangLuong.Text),
                    new SqlParameter("@MaNV", cbMaNV.Text),
                    new SqlParameter("@NgayThang", dtpNgayThang.Value),
                    new SqlParameter("@LuongCoBan", Convert.ToDecimal(txtLuongCoBan.Text)),
                    new SqlParameter("@HeSoLuong", Convert.ToDecimal(txtHeSoLuong.Text)),
                    new SqlParameter("@PhuCap", Convert.ToDecimal(txtPhuCap.Text))
                    };

                    TruyXuatCSDL.themSuaXoa(sql, parameters);
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReSet_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để sửa","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM BangLuong WHERE MaBangLuong = @MaBangLuong";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaBangLuong", txtMaBangLuong.Text)
                        };

                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReSet_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMaNV.SelectedItem == "All")
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "SELECT * FROM vw_ChiTietBangLuong WHERE MaNV = @MaNV OR NgayThang = @NgayThang";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", cbMaNV.SelectedItem.ToString()), 
                    new SqlParameter("@NgayThang", dtpNgayThang.Value.Date) 
                };

                // Thực hiện truy vấn và hiển thị kết quả
                dgvMain.DataSource = TruyXuatCSDL.LayBang(sql, parameters);

                if (dgvMain.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
