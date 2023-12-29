using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai1.Models
{
    public class Books
    {
        public Books() { }
        public String Masach { get; set; }
        public String Tensach { get; set; }
        public String NhaXB { get; set; }
        public int NamXB { get; set; }
        public String Tacgia { get; set; }
        public decimal Dongia { get; set; }
        public String HinhAnh { get; set; }

        public Books(String masach, String tensach, String nhaXB, int namXB, String tacgia, decimal dongia, String hinhanh)
        {
            this.Masach = masach;
            this.Tensach = tensach;
            this.NhaXB= nhaXB;
            this.NamXB = namXB;
            this.Tacgia = tacgia;   
            this.Dongia= dongia;
            this.HinhAnh= hinhanh;
        }

    }
}