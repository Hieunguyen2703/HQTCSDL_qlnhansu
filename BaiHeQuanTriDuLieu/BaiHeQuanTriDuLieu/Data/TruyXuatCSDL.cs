using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiHeQuanTriDuLieu.Data   
{
    internal class TruyXuatCSDL
    {
        private static string duongDan = @"Data Source=.;Initial Catalog=quanLyNhanVien;Integrated Security=True;TrustServerCertificate=True;";
        
        private static SqlConnection TaoKetNoi()
        {
            return new SqlConnection (duongDan);
        }
        public static DataTable LayBang(string sql, SqlParameter[] parameters)
        {
            using(SqlConnection ketNoi =  TaoKetNoi())
            {
                ketNoi.Open();
                using (SqlCommand cmd = new SqlCommand (sql,ketNoi))
                {
                    if(parameters != null)
                    {
                        cmd.Parameters.AddRange (parameters);
                    }
                    using(SqlDataAdapter MayLayDl = new SqlDataAdapter(cmd)){
                        DataTable kq = new DataTable();
                        MayLayDl.Fill(kq);
                        return kq;
                    } 
                }  
            }   
        }

        public static void themSuaXoa(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection ketnoi = TaoKetNoi())
            {
                ketnoi.Open();
                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public object lay1DuLieu(string sql, SqlParameter[] parameters)
        {
            SqlConnection ketnoi = TaoKetNoi();
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand(sql, ketnoi);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            object kq = cmd.ExecuteScalar();
            cmd.Dispose();
            if (kq != null)
            {
                return kq.ToString();
            }
            else return "";
        }   

        public static ArrayList LayDanhSach(string sql, SqlParameter[] parameters)
        
            {
            DataTable b = LayBang(sql,parameters);
            ArrayList l = new ArrayList();
            l.Add("All");
            for (int i = 0; i < b.Rows.Count; i++)
            {
                l.Add(b.Rows[i][0].ToString());
            }
            return l;

        }

    }
}
