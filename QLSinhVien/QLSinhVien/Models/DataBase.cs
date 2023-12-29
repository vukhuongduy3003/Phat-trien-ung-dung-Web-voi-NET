using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace QLSinhVien.Models
{
    public class DataBase
    {
       public SqlConnection sqlcon;
        public void OpenData()
        {
            String sql = @"Data Source=DESKTOP-E5HV7G4\SQLEXPRESS;Initial Catalog=QL_SV;Integrated Security=True";
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
        public DataTable get_AllSinhVien()
        {
            OpenData();
            DataTable tb = new DataTable();
            String sql = "Select * from Sinhvien";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            CloseData();
            return tb;
        }
        public bool Check_Ma(String ma)
        {
            bool check = false;
            OpenData();
            DataTable tb = new DataTable();
            String sql = "Select * from Sinhvien Where MaSV = @MaSV";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaSV", ma);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            if(tb.Rows.Count > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            CloseData();
            return check;
        }
        public void insert(Sinhvien sv)
        {
            OpenData();
            String sql = "INSERT INTO Sinhvien VALUES (@MaSV, @TenSV, @NgaySinh, @GioiTinh, @QueQuan, @HinhAnh)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaSV", sv.MaSV);
            sqlcom.Parameters.AddWithValue("TenSV", sv.TenSV);
            sqlcom.Parameters.AddWithValue("NgaySinh", sv.NgaySinh);
            sqlcom.Parameters.AddWithValue("GioiTinh", sv.GioiTinh);
            sqlcom.Parameters.AddWithValue("QueQuan", sv.QueQuan);
            sqlcom.Parameters.AddWithValue("HinhAnh", sv.HinhAnh);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void update(Sinhvien sv)
        {
            OpenData();
            String sql = "UPDATE Sinhvien SET TenSV = @TenSV, NgaySinh= @NgaySinh, GioiTinh = @GioiTinh, QueQuan = @QueQuan, HinhAnh = @HinhAnh WHERE MaSV = @MaSV";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaSV", sv.MaSV);
            sqlcom.Parameters.AddWithValue("TenSV", sv.TenSV);
            sqlcom.Parameters.AddWithValue("NgaySinh", sv.NgaySinh);
            sqlcom.Parameters.AddWithValue("GioiTinh", sv.GioiTinh);
            sqlcom.Parameters.AddWithValue("QueQuan", sv.QueQuan);
            sqlcom.Parameters.AddWithValue("HinhAnh", sv.HinhAnh);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void delete(String ma)
        {
            OpenData();
            String sql = "DELETE FROM Sinhvien WHERE MaSV = @MaSV";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("MaSV", ma);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
    }
}