using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics.Contracts;

namespace Bai1.Models
{
    public class DataBase
    {
        public SqlConnection sqlcon;
        public void OpenData()
        {
            String sql = @"Data Source=DESKTOP-E5HV7G4\SQLEXPRESS;Initial Catalog=QL_Sach;Integrated Security=True";
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
        public DataTable Get_AllSach()
        {
            DataTable tb  = new DataTable();
            OpenData();
            String sql = "select * from Sach";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            CloseData();
            return tb;
        }
        public bool CheckMa(String ma)
        {
            bool check = false;
            OpenData();
            DataTable tb = new DataTable();
            String sql = "Select * from Sach where Masach = @masach";
            SqlCommand sqlcom = new SqlCommand(sql,sqlcon);
            sqlcom.Parameters.AddWithValue("masach", ma);
            SqlDataReader dr = sqlcom.ExecuteReader();
            tb.Load(dr);
            CloseData();
            if(tb.Rows.Count > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public void insert(Books b)
        {
            String sql = "INSERT INTO Sach VALUES(@Masach, @Tensach, @NhaXB, @NamXB, @Tacgia, @Dongia, @Hinhanh)";
            OpenData();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("Masach", b.Masach);
            sqlcom.Parameters.AddWithValue("Tensach", b.Tensach);
            sqlcom.Parameters.AddWithValue("NhaXB", b.NhaXB);
            sqlcom.Parameters.AddWithValue("NamXB", b.NamXB);
            sqlcom.Parameters.AddWithValue("Tacgia", b.Tacgia);
            sqlcom.Parameters.AddWithValue("Dongia", b.Dongia);
            sqlcom.Parameters.AddWithValue("Hinhanh",b.HinhAnh);
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void update(Books b)
        {
            OpenData();
            String sql = "UPDATE Sach SET Tensach = @Tensach, NhaXB = @NhaXB, NamXB = @NamXB, Tacgia = @Tacgia, Dongia = @Dongia, Hinhanh = @Hinhanh WHERE  Masach = @Masach";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("Masach", b.Masach);
            sqlcom.Parameters.AddWithValue("Tensach", b.Tensach);
            sqlcom.Parameters.AddWithValue("NhaXB", b.NhaXB);
            sqlcom.Parameters.AddWithValue("NamXB", b.NamXB);
            sqlcom.Parameters.AddWithValue("Tacgia", b.Tacgia);
            sqlcom.Parameters.AddWithValue("Dongia", b.Dongia);
            if (b.HinhAnh != null)
            {
                sqlcom.Parameters.AddWithValue("Hinhanh", b.HinhAnh);
            }else
            {
                sqlcom.Parameters.AddWithValue("Hinhanh", "");
            }
            sqlcom.ExecuteNonQuery();
            CloseData();
        }
        public void delete(String ma)
        {
            OpenData();
            String sql = "DELETE FROM Sach WHERE  Masach = @Masach";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("Masach", ma);
            sqlcom.ExecuteNonQuery();
            CloseData();

        }
    }
}