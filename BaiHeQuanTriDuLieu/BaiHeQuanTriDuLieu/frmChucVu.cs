using BaiHeQuanTriDuLieu.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiHeQuanTriDuLieu
{
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
            txtmachucvu.Enabled = false;
        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from ChucVu", null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from ChucVu", null);
            txtmachucvu.ResetText();
            txttenchucvu.ResetText();
            dgvMain.ClearSelection ();
            
        }
        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvMain.CurrentRow != null)
            {
                txtmachucvu.Text = dgvMain.CurrentRow.Cells[0].Value.ToString();
                txttenchucvu.Text = dgvMain.CurrentRow.Cells[1].Value.ToString();
            }
        }
        public bool IsChucVuExist(string tenChucVu)
        {
            try
            {
                string checkSql = "SELECT COUNT(1) FROM ChucVu WHERE TenChucVu = @TenChucVu";
                SqlParameter[] checkParameters = new SqlParameter[] {
                    new SqlParameter("@TenChucVu", tenChucVu)
        };

                // Lấy số lượng kết quả trả về
                object count = truyXuatCSDL.lay1DuLieu(checkSql, checkParameters);

                // Nếu count > 0 có nghĩa là chức vụ đã tồn tại
                return Convert.ToUInt32(count) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra tồn tại chức vụ: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txttenchucvu.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "insert into ChucVu values (@TenChucVu)";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@TenChucVu",txttenchucvu.Text)
                };
                if (IsChucVuExist(txttenchucvu.Text))
                {
                    MessageBox.Show("Chức vụ này đã tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TruyXuatCSDL.themSuaXoa(sql, parameters);
                dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from ChucVu", null);
                MessageBox.Show("Đã thêm", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm thất bại: {ex.Message}", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvMain.SelectedRows.Count >0)
                {
                    string sql = "update ChucVu set TenChucVu = @TenChucVu where MaChucVu = @MaChucVu";
                    SqlParameter[] parameters = new SqlParameter[] 
                    {
                        new SqlParameter("@TenChucVu",txttenchucvu.Text),
                        new SqlParameter("@MaChucVu",txtmachucvu.Text)
                    };
                    TruyXuatCSDL.themSuaXoa(sql, parameters);
                    dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from ChucVu", null);
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
                if (dgvMain.SelectedRows.Count>0)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đánh giá này không?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        string sql = "delete ChucVu where MaChucVu = @MaChucVu";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaChucVu",txtmachucvu.Text)
                        };
                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        dgvMain.DataSource = TruyXuatCSDL.LayBang("Select * from ChucVu", null);
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
