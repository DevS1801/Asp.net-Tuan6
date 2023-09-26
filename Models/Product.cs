using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Tuan6.Models
{
    public class Product
    {
        private int masp;
         private string tensp;
        private string duongdan;
        private float gia;
        private string mota;
        private int maloai;
        private string tenLoai;
        public int Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Duongdan { get => duongdan; set => duongdan = value; }
        public float Gia { get => gia; set => gia = value; }
        public string Mota { get => mota; set => mota = value; }
        public int Maloai { get => maloai; set => maloai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }

        public Product()
        {
            Masp = 0;
            Tensp = string.Empty;
            Duongdan = string.Empty;
            Gia = 0;
            Mota = string.Empty;
            maloai = 0;
            TenLoai = string.Empty;
        }


    }
}