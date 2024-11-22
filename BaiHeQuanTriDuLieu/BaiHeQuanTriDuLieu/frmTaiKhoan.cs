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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("select * from TaiKhoan", null);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("select * from TaiKhoan", null);
            txttk.ResetText();
            txtmk.ResetText();
            string sql = "select nv.MaNV  from NhanVien nv left join TaiKhoan tk " +
                "on nv.MaNV = tk.MaNV Where tk.MaNV is null ";
            cbMaNV.DataSource = TruyXuatCSDL.LayDanhSach(sql, null);
            dgvMain.ClearSelection();
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                txMaTK.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                txttk.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();
                txtmk.Text = dgvMain.CurrentRow.Cells[2].Value.ToString();
                cbMaNV.Text = dgvMain.CurrentRow.Cells[3].Value.ToString();


            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvMain.SelectedRows.Count > 0)
                {
                    string sql = "update TaiKhoan set TenDangNhap = @TenDangNhap," +
                        "MatKhau = @MatKhau  where MaTaiKhoan = @MaTaiKhoan";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TenDangNhap",txttk.Text),
                        new SqlParameter("@MatKhau",txtmk.Text),
                        new SqlParameter("@MaTaiKhoan",txMaTK.Text)
                    };
                    TruyXuatCSDL.themSuaXoa(sql, parameters);
                    dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from TaiKhoan", null);
                    MessageBox.Show("Đã Sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sửa thất bại: {ex.Message}", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool kiemTraTrungLap(int maNV)
        {
            string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE MaNV = @MaNV ";
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
                if (string.IsNullOrWhiteSpace(txttk.Text) || string.IsNullOrWhiteSpace(txtmk.Text) ||
                    cbMaNV.SelectedItem == null || cbMaNV.SelectedItem.ToString() == "All")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (kiemTraTrungLap(Convert.ToInt32(cbMaNV.SelectedItem.ToString())))
                {
                    MessageBox.Show("Đã có bản ghi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "insert into TaiKhoan values (@TenDangNhap,@MatKhau,@MaNV)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", txttk.Text),
                    new SqlParameter("@MatKhau", txtmk.Text),
                    new SqlParameter("@MaNV", cbMaNV.SelectedItem.ToString())
                };
                TruyXuatCSDL.themSuaXoa(sql, parameters);
                dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from TaiKhoan", null);
                dgvMain.CurrentCell = dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[0];
                MessageBox.Show("Đã thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm thất bại: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvMain.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = "delete TaiKhoan where MaTaiKhoan = @MaTaiKhoan";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaTaiKhoan",txMaTK.Text)
                        };
                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from TaiKhoan", null);
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
