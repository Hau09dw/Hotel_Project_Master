﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class DangNhap_BLL
    {
        public static string LayTenDangNhap_MatKhau(string MaNV, string matkhau) => DangNhap_DAL.LayTenDangNhap_MatKhau(MaNV, matkhau);

        public static string DoiMatKhau(string maNV, string matkhau) => DangNhap_DAL.DoiMatKhau(maNV, matkhau);
        public static string LayMaQuyenHan(string maCanLay) => DangNhap_DAL.LayMaQuyenHan(maCanLay);

    }
}
