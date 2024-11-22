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
    public partial class frmChamCong : Form
    {
        
        private string loaiTaiKhoan;
        private string maNV;
        public frmChamCong(string loaiTaiKhoan, string maNV)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.maNV = maNV;
            if (loaiTaiKhoan == "2" || loaiTaiKhoan == "4" || loaiTaiKhoan == "5")
            {
                LoadChamCong();
                
            }
            else 
            {
                btnxoa.Visible = false;
                btnTimKiem.Visible = false;
                dtpThangNam.Visible = false;
                lbThangNam.Visible = false ;
                cbMaNV.Enabled = false;
            }

        }
        TruyXuatCSDL truyXuatCSDL = new TruyXuatCSDL();

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            string sqlCB = "select distinct nv.maNV from NhanVien nv join ChamCong cc on nv.MaNV = cc.Manv ";
            cbMaNV.DataSource = TruyXuatCSDL.LayDanhSach(sqlCB, null);

        }
        public void LoadChamCong()
        {
            string sql = "SELECT c.MaChamCong,c.MaNV, n.HoTen, c.NgayThang, c.GioVao, c.GioRa FROM ChamCong c JOIN NhanVien n ON c.MaNV = n.MaNV";
            dgvMain.DataSource = TruyXuatCSDL.LayBang(sql, null);

        }
        
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;

                string checkSql = "SELECT * FROM ChamCong WHERE MaNV = @MaNV AND NgayThang = @NgayThang";
                SqlParameter[] checkParameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@NgayThang", dtpNgayThang.Value.Date)
                };

                DataTable checkDt = TruyXuatCSDL.LayBang(checkSql, checkParameters);

                if (checkDt.Rows.Count == 0)
                {
                    // Nếu chưa chấm công vào, chấm công vào
                    sql = "INSERT INTO ChamCong (MaNV, NgayThang, GioVao) VALUES (@MaNV, @NgayThang, CONVERT(TIME,GETDATE()))";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaNV", maNV),
                        new SqlParameter("@NgayThang", dtpNgayThang.Value.Date),
                    };

                    TruyXuatCSDL.themSuaXoa(sql, parameters);
                    MessageBox.Show("Chấm công vào thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu đã chấm công vào rồi thì không cho phép chấm công vào lần nữa
                    DataRow row = checkDt.Rows[0];
                    if (row["GioRa"] != DBNull.Value)
                    {
                        MessageBox.Show("Bạn đã chấm công ngày hôm nay rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        sql = "UPDATE ChamCong SET GioRa = CONVERT(TIME,GETDATE()) WHERE MaNV = @MaNV AND NgayThang = @NgayThang AND GioRa IS NULL";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaNV", maNV),
                            new SqlParameter("@NgayThang", dtpNgayThang.Value.Date)
                        };

                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        MessageBox.Show("Chấm công ra thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                string sqlHien = "select * from ChamCong where MaNV = @MaNV";
                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@MaNV",maNV)
                };

                dgvMain.DataSource = TruyXuatCSDL.LayBang(sqlHien, parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(cbMaNV.SelectedItem == "All")
                {
                    MessageBox.Show("Vui lòng điền mã nhân viên","Thông báo ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                string sql = "SELECT c.MaChamCong, c.MaNV, n.HoTen, c.NgayThang, c.GioVao, c.GioRa " +
                 "FROM ChamCong c JOIN NhanVien n ON c.MaNV = n.MaNV " +
                 "WHERE c.MaNV = @MaNV AND MONTH(c.NgayThang) = @Month AND YEAR(c.NgayThang) = @Year";

                // Extract the month and year from the selected date
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", cbMaNV.Text),
                    new SqlParameter("@Month", dtpThangNam.Value.Month),
                    new SqlParameter("@Year", dtpThangNam.Value.Year)
                };

                DataTable dt = TruyXuatCSDL.LayBang(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    dgvMain.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chấm công cho ngày này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (dgvMain.SelectedRows.Count > 0)
                {
                    DialogResult confirmDelete = MessageBox.Show("Bạn có chắc muốn xóa bản ghi chấm công này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmDelete == DialogResult.Yes)
                    {
                        int maCC = Convert.ToInt32(dgvMain.SelectedRows[0].Cells["MaChamCong"].Value);
                        string sql = "DELETE FROM ChamCong WHERE MaChamCong = @MaChamCong";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaChamCong", maCC)
                        };

                        TruyXuatCSDL.themSuaXoa(sql, parameters);
                        MessageBox.Show("Xóa chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChamCong();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
