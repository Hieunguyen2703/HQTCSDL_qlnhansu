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
    public partial class frmDanhGia : Form
    {
        public frmDanhGia()
        {
            InitializeComponent();
            txtMaDanhGia.Enabled = false;
        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public bool KiemTraTrungLap(int maNV, DateTime ngayThang)
        {
            string sql = "SELECT COUNT(1) FROM DanhGiaNhanVien WHERE MaNV = @MaNV AND NgayThang = @NgayThang";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaNV", maNV),
            new SqlParameter("@NgayThang", ngayThang)
            };

            object result = truyXuatCSDL.lay1DuLieu(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMaNhanVien.Text == "All" ||
                    string.IsNullOrWhiteSpace(txtSoTien.Text) ||
                    string.IsNullOrWhiteSpace(txtLyDo.Text) ||
                    string.IsNullOrWhiteSpace(cmbLoaiDanhGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtSoTien.Text, out decimal soTien))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (KiemTraTrungLap(Convert.ToInt32(cmbMaNhanVien.Text), dtpNgayThang.Value))
                {
                    MessageBox.Show("Đã có bản ghi này ", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "  EXEC sp_ThemDanhGiaNhanVien @MaNV , @NgayThang , @SoTien,@LoaiDanhGia , @LyDo ;";


                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@MaNV", cmbMaNhanVien.Text),
                        new SqlParameter("@NgayThang", dtpNgayThang.Value),
                        new SqlParameter("@SoTien", soTien),
                        new SqlParameter("@LyDo", txtLyDo.Text),
                        new SqlParameter("@LoaiDanhGia", cmbLoaiDanhGia.Text)
                };

                TruyXuatCSDL.themSuaXoa(sql, parameters);

                dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietDanhGiaNhanVien", null);

                dgvMain.CurrentCell = dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[0];
                MessageBox.Show("Đã thêm đánh giá nhân viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm thất bại: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(cmbMaNhanVien.Text) ||
                        string.IsNullOrWhiteSpace(txtSoTien.Text) ||
                        string.IsNullOrWhiteSpace(txtLyDo.Text) ||
                        cmbMaNhanVien.Text == "All")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sql = "UPDATE DanhGiaNhanVien SET MaNV = @MaNV, NgayThang = @NgayThang, " +
                                 "SoTien = @SoTien, LyDo = @LyDo, LoaiDanhGia = @LoaiDanhGia WHERE MaDanhGia = @MaDanhGia";

                    // Tạo mảng tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                            new SqlParameter("@MaDanhGia", txtMaDanhGia.Text),
                            new SqlParameter("@MaNV", cmbMaNhanVien.Text),
                            new SqlParameter("@NgayThang", dtpNgayThang.Value), 
                            new SqlParameter("@SoTien", txtSoTien.Text),
                            new SqlParameter("@LyDo", txtLyDo.Text),
                            new SqlParameter("@LoaiDanhGia", cmbLoaiDanhGia.Text)
                    };

                    TruyXuatCSDL.themSuaXoa(sql, parameters);

                    dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietDanhGiaNhanVien", null);

                    MessageBox.Show("Đã sửa thông tin đánh giá nhân viên", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sửa thất bại: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đánh giá này không?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM DanhGiaNhanVien WHERE MaDanhGia = @MaDanhGia";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaDanhGia", txtMaDanhGia.Text) 
                        };

                        TruyXuatCSDL.themSuaXoa(sql, parameters);

                        dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietDanhGiaNhanVien", null);

                        MessageBox.Show("Đã xóa đánh giá nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đánh giá để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietDanhGiaNhanVien", null);

            txtMaDanhGia.ResetText();
            cmbMaNhanVien.ResetText();
            dtpNgayThang.Value = DateTime.Now;
            txtSoTien.ResetText();
            txtLyDo.ResetText();
            cmbMaNhanVien.DataSource = TruyXuatCSDL.LayDanhSach("select MaNV from NhanVien", null);
            cmbMaNhanVien.Focus();
            dgvMain.ClearSelection();
           
            
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                txtMaDanhGia.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                cmbMaNhanVien.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();

                if (DateTime.TryParse(dgvMain.CurrentRow.Cells[5].Value.ToString(), out DateTime ngayThang))
                {
                    dtpNgayThang.Value = ngayThang;
                }
                else
                {
                    dtpNgayThang.Value = DateTime.Now;
                }
                cmbLoaiDanhGia.Text = dgvMain.CurrentRow.Cells[6].Value.ToString();

                txtSoTien.Text = dgvMain.CurrentRow.Cells[7].Value.ToString();
                txtLyDo.Text = dgvMain.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void frmDanhGia_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM vw_ChiTietDanhGiaNhanVien", null);

        }
    }
}
