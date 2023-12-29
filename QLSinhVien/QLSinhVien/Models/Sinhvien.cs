using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLSinhVien.Models
{
    public class Sinhvien
    {
        public String MaSV { get; set; }
        public String TenSV { get; set; }
        public String NgaySinh { get; set; }
        public String GioiTinh { get; set; }
        public String QueQuan { get; set; }
        public String HinhAnh { get; set; }
        public Sinhvien(string masv, string tensv, string ngaysinh, string gioitinh, string quequan, string hinhanh)
        {
            this.MaSV = masv;
            this.TenSV = tensv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.QueQuan = quequan;
            this.HinhAnh = hinhanh;
        }
    }
}