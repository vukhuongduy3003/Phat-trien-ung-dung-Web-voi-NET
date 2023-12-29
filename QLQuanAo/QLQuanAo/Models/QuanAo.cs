using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLQuanAo.Models
{
    public class QuanAo
    {
        public QuanAo() { }
        public String MaQA { get; set; }
        public String TenQA { get; set; }
        public String ThuongHieu { get; set; }
        public String KichThuoc { get; set; }
        public float DonGia { get; set; }
        public String HinhAnh { get; set; }
        public String MoTa { get; set; }
        public QuanAo(string maQA, string tenQA, string thuonghieu, string kichthuoc, float dongia, string hinhanh, string mota)
        {
            this.MaQA = maQA;
            this.TenQA = tenQA;
            this.ThuongHieu = thuonghieu;
            this.KichThuoc = kichthuoc;
            this.DonGia = dongia;
            this.HinhAnh = hinhanh;
            this.MoTa = mota;
        }

    }
}