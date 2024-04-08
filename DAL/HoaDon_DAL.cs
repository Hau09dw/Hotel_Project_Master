using DTO;
using System;
using System.Data;
namespace DAL
{
    public class HoaDon_DAL
    {
        public static DataTable HienThiDanhSachMaSuDungDichVu(string maPhong)
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("select * from DanhSachSDDichVu as DS inner join Phong as PHG on DS.MaPhong = PHG.MaPhong where PHG.MaPhong = '" + maPhong + "' and TinhTrangPhong = 1");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public static DataTable LayMaChiTietHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("SELECT * FROM ChiTietHoaDon");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }


        public static DataTable HienThiMaPhong(string maPhong)
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("select * from Phong where TinhTrangPhong = 1 and MaPhong = '" + maPhong + "'");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        public static int LayTienLoaiPhong(string maPhong)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("SELECT distinct GiaLoaiPhong FROM Phong as PHG inner join LoaiPhong as LPG on PHG.MaLoaiPhong = LPG.MaLoaiPhong where PHG.MaPhong = '" + maPhong + "' and TinhTrangPhong = 1");
                string tam = DataProvider.ExecuteScalar(strTruyVan).ToString().Split('.')[0];
                count = int.Parse(tam);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }
        public static int LayTienDichVu(string maPhong)
        {
            int count = 0;
            try
            {

                string strTruyVan2 = string.Format("Select sum(ct.SoLuong * dv.GiaDichVu) as ChiPhiPhatSinh from LoaiPhong lp join Phong p on p.MaLoaiPhong = lp.MaLoaiPhong join ChiTietHoaDonDichVu ct on ct.MaPhong = p.MaPhong join DichVu dv on ct.MaDichVu = dv.MaDichVu where p.MaPhong = '"+maPhong+"' group by lp.MaLoaiPhong");
                string tmp = DataProvider.ExecuteScalar(strTruyVan2).ToString().Split('.')[0];
                count = int.Parse(tmp);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }
        public static int ThemChiTietHoaDon(HoaDon_DTO hdDTO)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("INSERT INTO ChiTietHoaDon(MaChiTietHoaDon,PhuThu,TienPhong,TienDichVu,ThanhTien,MaPhong) VALUES('{0}', {1}, {2}, {3}, {4},'{5}')", hdDTO.MaChiTietHoaDon, hdDTO.PhuThu, hdDTO.TienPhong, hdDTO.TienDichVu, hdDTO.ThanhTien, hdDTO.MaPhong);

                count = DataProvider.ExecuteNonQuery(strTruyVan);

                string strTruyVan4 = string.Format("UPDATE ChiTietHoaDon SET DaThanhToan = 0 WHERE MaChiTietHoaDon = '" + hdDTO.MaChiTietHoaDon + "'");

                count = DataProvider.ExecuteNonQuery(strTruyVan4);

                string strTruyVan2 = string.Format("UPDATE Phong SET TinhTrangPhong = 0 WHERE MaPhong = '" + hdDTO.MaPhong + "'");
                count = DataProvider.ExecuteNonQuery(strTruyVan2);

                //string strTruyVan3 = string.Format("UPDATE PhieuDangKy SET DaXoa = 1 WHERE MaPhieuDK = '" +  + "'");
                //count = DataProvider.ExecuteNonQuery(strTruyVan3);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }
        public static int XacNhanHoaDon(HoaDon_DTO hdDTO)
        {
            int count = 0;
            try
            {
                //Tự sửa lại mã nhân viên
                string strTruyVan = string.Format("INSERT INTO HoaDon(MaHoaDon,NgayBatDau,NgayKetThuc, ChiPhiPhatSinh, TienCoc,TongTienHoaDon,MaNV,MaPhieuDK) VALUES ('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}')", hdDTO.MaHoaDon, hdDTO.NgayBatDau, hdDTO.NgayKetThuc, hdDTO.ChiPhiPhatSinh, hdDTO.TienCoc, hdDTO.TongTienHoaDon, hdDTO.MaNV, hdDTO.MaPhieuDK);

                count = DataProvider.ExecuteNonQuery(strTruyVan);
                //Cập nhật mã hóa đơn vào các phiếu dịch vụ
                string strTruyVan2 = string.Format("UPDATE ChiTietHoaDonDichVu SET MaHoaDon = '"+hdDTO.MaHoaDon+ "' MaPhong = '" + hdDTO.MaPhong + "'");
                count = DataProvider.ExecuteNonQuery(strTruyVan2);

                string strTruyVan3 = string.Format("UPDATE Phong SET TinhTrangPhong = 0 WHERE MaPhong = '" + hdDTO.MaPhong + "'");
                count = DataProvider.ExecuteNonQuery(strTruyVan2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;

        }

        public static int LayTienDatCoc(string maPhong)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("select PDK.TienDatCoc,PDK.MaPhieuDK from PhieuDangKy as PDK inner join ChiTietLoaiPhong as CTLP on PDK.MaPhieuDK = CTLP.MaPhieuDK inner join ChiTietHoaDon as CTHD on CTHD.MaPhong = CTLP.MaPhong where CTLP.MaPhong = '" + maPhong + "'");
                string tmp = DataProvider.ExecuteScalar(strTruyVan).ToString().Split('.')[0];
                count = int.Parse(tmp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }

        public static DataTable HienThiDanhSachChiTietHoaDon(string MaPH)
        {
            DataTable dt = new DataTable();
            try
            {
                    string strTruyVan = string.Format("SELECT DV.TenDichVu , DV.GiaDichVu , CT.SoLuong , DV.GiaDichVu * CT.SoLuong as ThanhTien, P.TenPhong , KH.TenKH, CT.MaDichVu, CT.MaPhong " +
                        "FROM ChiTietHoaDonDichVu CT " +
                        "LEFT JOIN DichVu DV ON DV.MaDichVu = CT.MaDichVu " +
                        "LEFT JOIN Phong P ON P.MaPhong = CT.MaPhong " +
                        "LEFT JOIN HoaDon HD ON HD.MaHoaDon = CT.MaHoaDon " +
                        "LEFT JOIN PhieuDangKy DK ON HD.MaPhieuDK = DK.MaPhieuDK " +
                        "LEFT JOIN KhachHang KH ON DK.MaKH = KH.MaKH " +
                    "WHERE P.MaPhong = '" + MaPH + "'");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public static DataTable HienThiDanhSachHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("select MaHoaDon,NgayBatDau,NgayKetThuc, ChiPhiPhatSinh, TienCoc,TongTienHoaDon,MaNV,MaPhieuDK from HoaDon ");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        public static DataTable LayMaHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("SELECT MaHoaDon FROM HoaDon");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }


        public static DataTable TimMaHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();
            try
            {
                string strTruyVan = string.Format("SELECT * FROM HoaDon WHERE MaHoaDon = '" + maHoaDon + "'");
                dt = DataProvider.fillDataTable(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }



    }
}
