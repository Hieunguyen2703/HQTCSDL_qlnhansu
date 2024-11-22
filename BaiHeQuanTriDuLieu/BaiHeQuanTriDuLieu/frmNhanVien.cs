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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            txtidnhanvien.Enabled = false;
            txtsoLanDG.Enabled = false;
        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

            dgvMain.DataSource = TruyXuatCSDL.LayBang("select * from NhanVien", null);

        }
        public bool KiemTraTrungLap(int maNV)
        {
            string sql = "SELECT COUNT(1) FROM NhanVien WHERE MaNV = @MaNV ";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaNV", maNV),
            };

            object result = truyXuatCSDL.lay1DuLieu(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txthoten.Text) ||
                            string.IsNullOrWhiteSpace(txtgioitinh.Text) ||
                            string.IsNullOrWhiteSpace(txtquequan.Text) ||
                            string.IsNullOrWhiteSpace(txtEmail.Text) ||
                            string.IsNullOrWhiteSpace(txtsodienthoai.Text) ||
                            cbmachuvu.SelectedItem == "All" || cbMaPhongBan.SelectedItem == "All"
                            )
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (KiemTraTrungLap(Convert.ToInt32(txtidnhanvien.Text)))
                {
                    MessageBox.Show("Đã có bản ghi này", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "EXEC AddNhanVien @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @MaChucVu, @MaPhongBan";
                SqlParameter[] parameters = new SqlParameter[] {
                     new SqlParameter("@HoTen", txthoten.Text),
                    new SqlParameter("@NgaySinh", dtpngaysinh.Value),
                    new SqlParameter("@GioiTinh", txtgioitinh.Text),
                    new SqlParameter("@DiaChi", txtquequan.Text),
                    new SqlParameter("@SoDienThoai", txtsodienthoai.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@MaChucVu", cbmachuvu.SelectedValue),
                    new SqlParameter("@MaPhongBan", cbMaPhongBan.SelectedValue)

            };
                TruyXuatCSDL.themSuaXoa(sql, parameters);
                dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from NhanVien", null);
                dgvMain.CurrentCell = dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[0];
                MessageBox.Show("Đã thêm", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm thất bại: {ex.Message}", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                txtidnhanvien.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                txthoten.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();
                dtpngaysinh.Text = dgvMain.CurrentRow.Cells[2].Value.ToString();
                txtgioitinh.Text = dgvMain.CurrentRow.Cells[3].Value.ToString();
                txtquequan.Text = dgvMain.CurrentRow.Cells[4].Value.ToString();
                txtsodienthoai.Text = dgvMain.CurrentRow.Cells[5].Value.ToString();
                txtEmail.Text = dgvMain.CurrentRow.Cells[6].Value.ToString();
                cbMaPhongBan.Text = dgvMain.CurrentRow.Cells[7].Value.ToString();
                cbmachuvu.Text = dgvMain.CurrentRow.Cells[8].Value.ToString();
                txtsoLanDG.Text = dgvMain.CurrentRow.Cells[9].Value.ToString();
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


        private void btnreset_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("select * from NhanVien", null);
            txtidnhanvien.ResetText();
            txthoten.ResetText();
            txtgioitinh.ResetText();
            txtEmail.ResetText();
            txtquequan.ResetText();
            txtsodienthoai.ResetText();
            txtsoLanDG.ResetText();
            cbmachuvu.DataSource = TruyXuatCSDL.LayDanhSach("select MaChucVu from ChucVu ", null);
            cbMaPhongBan.DataSource = TruyXuatCSDL.LayDanhSach("select MaPhongBan from PhongBan", null);
            dgvMain.ClearSelection();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.CurrentRow != null)
                {
                    string idNhanVien = txtidnhanvien.Text;

                    if (string.IsNullOrWhiteSpace(idNhanVien))
                    {
                        MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Câu lệnh SQL để cập nhật thông tin nhân viên
                    string sql = "UPDATE NhanVien SET HoTen = @HoTen, NgaySinh = @NgaySinh," +
                        " GioiTinh = @GioiTinh, DiaChi = @DiaChi," +
                        " SoDienThoai = @SoDienThoai, Email = @Email, MaPhongBan = @MaPhongBan," +
                        " MaChucVu = @MaChucVu WHERE MaNV = @MaNV";

                    // Tạo các tham số
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaNV", idNhanVien),
                        new SqlParameter("@HoTen", txthoten.Text),
                        new SqlParameter("@NgaySinh", dtpngaysinh.Value),
                        new SqlParameter("@GioiTinh", txtgioitinh.Text),
                        new SqlParameter("@DiaChi", txtquequan.Text),
                        new SqlParameter("@SoDienThoai", txtsodienthoai.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@MaPhongBan", cbMaPhongBan.Text),
                        new SqlParameter("@MaChucVu", cbmachuvu.Text)
                    };

                    TruyXuatCSDL.themSuaXoa(sql, parameters);

                    dgvMain.DataSource = TruyXuatCSDL.LayBang("SELECT * FROM NhanVien", null);
                    MessageBox.Show("Đã sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sửa thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtidnhanvien.Text;

                if (dgvMain.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = "delete NhanVien where MaNV = @MaNV";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaNV",maNhanVien)
                        };
                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from NhanVien", null);
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa thất bại: {ex.Message}", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
