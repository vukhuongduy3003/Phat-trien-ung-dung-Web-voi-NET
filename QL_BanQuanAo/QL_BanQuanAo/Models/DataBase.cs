using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace QL_BanQuanAo.Models
{
    public class DataBase
    {
        public SqlConnection sqlcon;
        public void OpenData()
        {
            String sql = @"Data Source=DESKTOP-E5HV7G4\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True";
            sqlcon = new SqlConnection(sql);
            if(sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
        }
        public void CloseData()
        {
            sqlcon.Close();
        }
        public DataTable get_AllQA()
        {
            DataTable tb = new DataTable();
            OpenData();
            String sql = "select * from QuanAo";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            CloseData();
            return tb;
        }
        public bool checkMa(String ma)
        {
            bool check = false;
            DataTable tb = new DataTable();
            OpenData();
            String sql = "select * from QuanAo where MaQA = @MaQA";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaQA", ma);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            CloseData();
            if(tb.Rows.Count > 0)
            {
                return check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public void insert(QuanAo qa)
        {
            OpenData();
            String sql = "INSERT INTO QuanAo VALUES (@MaQA, @TenQA, @ThuongHieu, @KichThuoc, @DonGia, @HinhAnh, @MoTa)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaQA", qa.MaQA);
            sqlcom.Parameters.AddWithValue("TenQA", qa.TenQA);
            sqlcom.Parameters.AddWithValue("ThuongHieu", qa.ThuongHieu);
            sqlcom.Parameters.AddWithValue("KichThuoc", qa.KichThuoc);
            sqlcom.Parameters.AddWithValue("DonGia", qa.DonGia);
            sqlcom.Parameters.AddWithValue("HinhAnh", qa.HinhAnh);
            sqlcom.Parameters.AddWithValue("MoTa", qa.MoTa);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void update(QuanAo qa)
        {
            OpenData();
            String sql = "UPDATE QuanAo SET TenQA = @TenQA, ThuongHieu = @ThuongHieu, KichThuoc = @KichThuoc, DonGia = @DonGia, HinhAnh = @HinhAnh, MoTa = @MoTa WHERE MaQA = @MaQA";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaQA", qa.MaQA);
            sqlcom.Parameters.AddWithValue("TenQA", qa.TenQA);
            sqlcom.Parameters.AddWithValue("ThuongHieu", qa.ThuongHieu);
            sqlcom.Parameters.AddWithValue("KichThuoc", qa.KichThuoc);
            sqlcom.Parameters.AddWithValue("DonGia", qa.DonGia);
            sqlcom.Parameters.AddWithValue("HinhAnh", qa.HinhAnh);
            sqlcom.Parameters.AddWithValue("MoTa", qa.MoTa);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void delete(String ma)
        {
            OpenData();
            String sql = "DELETE FROM QuanAo WHERE MaQA = @MaQA";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaQA", ma);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
    }
}