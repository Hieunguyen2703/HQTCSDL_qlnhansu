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
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
            txtmaphongban.Enabled = false;

        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("select * from PhongBan", null);
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                txtmaphongban.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                txttenphongban.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();
                txtdiachi.Text = dgvMain.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dgvMain.CurrentRow.Cells[3].Value.ToString();
            }
        }
        public bool KiemTraTrungLap(int maPhongBan)
        {
            string sql = "SELECT COUNT(1) FROM PhongBan WHERE MaPhongBan = @MaPhongBan ";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaPhongBan", maPhongBan),
            };

            object result = truyXuatCSDL.lay1DuLieu(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txttenphongban.Text) ||
                            string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                            string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (KiemTraTrungLap(Convert.ToInt32(txtmaphongban.Text)))
                {
                    MessageBox.Show("Đã có bản ghi này", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "insert into PhongBan values (@TenPhongBan,@DiaChi,@SoDienThoai)";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TenPhongBan",txttenphongban.Text),
                new SqlParameter("@DiaChi",txtdiachi.Text),
                new SqlParameter("@SoDienThoai",txtSDT.Text)
            };
                TruyXuatCSDL.themSuaXoa(sql, parameters);
                dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from PhongBan", null);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from PhongBan", null);
            txtmaphongban.ResetText();
            txttenphongban.ResetText();
            txtdiachi.ResetText();
            txtSDT.ResetText();
            txttenphongban.Focus();
            dgvMain.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count > 0)
                {
                    string sql = "update PhongBan set TenPhongBan = @TenPhongBan," +
                        "DiaChi = @DiaChi , SoDienThoai = @SoDienThoai where MaPhongBan = @MaPhongBan";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaPhongBan",txtmaphongban.Text),
                        new SqlParameter("@TenPhongBan",txttenphongban.Text),
                        new SqlParameter("@DiaChi",txtdiachi.Text),
                        new SqlParameter ("@SoDienThoai",txtSDT.Text)
                    };
                    TruyXuatCSDL.themSuaXoa(sql, parameters);
                    dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from PhongBan", null);
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
                        string sql = "delete PhongBan where MaPhongBan = @MaPhongBan";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaPhongBan",txtmaphongban.Text)
                        };
                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from PhongBan", null);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("bạn có chắc muốn thoát không", "thông báo");
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
