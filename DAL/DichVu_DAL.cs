using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using DevExpress.XtraEditors;

namespace DAL
{
    public class DichVu_DAL
    {
        public static List<DichVu_DTO> HienThiDanhSachCacDichVu(int index)
        {
            List<DichVu_DTO> lstDichVu = new List<DichVu_DTO>();
            try
            {
                /*string strTruyVan = string.Format("select PNG.MaPhong,DV.MaLoaiDichVu,DV.MaDichVu,PNG.TenPhong,LDV.TenLoaiDichVu,DV.TenDichVu from DichVu as DV,Phong as PNG, LoaiDichVu as LDV,HoaDon as HD where LGV.MaLoaiDichVu = DV.MaLoaiDichVu,PNG.MaPhong = HD.MaPhong, ");*///,DoVi.MaDonVi,DoVi.TenDonVi--, DonVi as DoVi where DV.MaDonVi = DoVI.MaDonVi
                string strTruyVan = string.Format("select DV.MaDichVu,DV.TenDichVu,DV.GiaDichVu,DV.MaLoaiDichVu,LGV.TenLoaiDichVU from DichVu as DV,LoaiDichVu as LDV where DV.MaLoaiDichVu = LGV.MaLoaiDichVu");
                DataTable _dt = new DataTable();
                _dt = DataProvider.fillDataTable(strTruyVan);
                if (_dt != null)
                {
                    for (index = 0; index < _dt.Rows.Count; index++)
                    {
                        DichVu_DTO dvDTO = new DichVu_DTO();
                        dvDTO.MaDichVu = _dt.Rows[index]["MaDichVu"].ToString();
                        dvDTO.TenDichVu = _dt.Rows[index]["TenDichVu"].ToString();
                        dvDTO.DonGia = Convert.ToInt32(_dt.Rows[index]["GiaDichVu"]);
                        dvDTO.MaLoaiDichVu = _dt.Rows[index]["MaLoaiDichVu"].ToString();
                        dvDTO.MaDonVi = _dt.Rows[index]["MaDonVi"].ToString();
                        dvDTO.TenDonVi = _dt.Rows[index]["TenDonVi"].ToString();

                        lstDichVu.Add(dvDTO);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }

            return lstDichVu;
            
        }


        public static List<DichVu_DTO> HienThiTenDichVuTheoMaDichVu(string maLoaiDichVu)
        {
            List<DichVu_DTO> lstDichVu = new List<DichVu_DTO>();
            try
            {
                string strTruyVan = string.Format("SELECT * FROM DichVu where MaLoaiDichVu = '"+ maLoaiDichVu + "'");
                DataTable _dt = new DataTable();
                _dt = DataProvider.fillDataTable(strTruyVan);
                if (_dt != null)
                {
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        DichVu_DTO dvDTO = new DichVu_DTO();
                        dvDTO.MaDichVu = _dt.Rows[i]["MaDichVu"].ToString();
                        dvDTO.TenDichVu = _dt.Rows[i]["TenDichVu"].ToString();

                        lstDichVu.Add(dvDTO);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }

            return lstDichVu;

        }

        public static DataTable HienThiThongTinPhongDaDangKyDichVu(Phong_DTO phgDTO)
        {
            DataTable _dt = new DataTable();
            try
            {
                string strTruyVan = string.Format(@"select distinct p.MaPhong, p.TenPhong, k.TenKH, ldv.MaLoaiDichVu, ldv.TenLoaiDichVu, dv.MaDichVu, TenDichVu, count(TenDichVu) as [SoLuong], sum(cthd.Gia) as [Tong Tien] from ChiTietHoaDonDichVu cthd join Phong p on p.MaPhong = cthd.MaPhong join LoaiPhong lp on lp.MaLoaiPhong = p.MaLoaiPhong join ChiTietLoaiPhong c on lp.MaLoaiPhong = c.MaLoaiPhong join PhieuDangKy ph on ph.MaPhieuDK = c.MaPhieuDK  join KhachHang k on k.MaKH = ph.MaKH join DichVu dv on dv.MaDichVu = cthd.MaDichVu join LoaiDichVu ldv on dv.MaLoaiDichVu = ldv.MaLoaiDichVu where p.MaPhong = '" + phgDTO.MaPhong+ "' group by TenDichVu, k.TenKH, p.TenPhong, p.MaPhong, dv.MaDichVu, ldv.MaLoaiDichVu, ldv.TenLoaiDichVu");//sua theo sql
                _dt = DataProvider.fillDataTable(strTruyVan);

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }

            return _dt;

        }




        //Lấy giá dịch vụ và hiển thị lên combobox
        public static List<DichVu_DTO>HienThiGiaDichVuLenComboBox(string maDichVu)
        {
            List<DichVu_DTO> lstGiaDichVu = new List<DichVu_DTO>();
            try
            {
                string strTruyVan = string.Format("select * from DichVu where MaDichVu = '"+maDichVu+"'");
                DataTable _dt = new DataTable();
                _dt = DataProvider.fillDataTable(strTruyVan);
                if (_dt != null)
                {
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        DichVu_DTO dvDTO = new DichVu_DTO();
                        dvDTO.MaDichVu = _dt.Rows[i]["MaDichVu"].ToString();
                        dvDTO.DonGia = Convert.ToInt32(_dt.Rows[i]["GiaDichVu"]);                
                        lstGiaDichVu.Add(dvDTO);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }

            return lstGiaDichVu;
        }

        public static List<DichVu_DTO>HienThiDonViTinh(string maDichVu)// đã xóa luôn trên form(hậu)
        {
            List<DichVu_DTO> lstDonViTinh = new List<DichVu_DTO>();
            try
            {
                string strTruyVan = string.Format("select DV.MaDichVu,DV.GiaDichVu,DV.DonViTinh from DichVu as DV where DV.MaDichVu = '"+maDichVu+"'");//DoVi.MaDonVi,DoVi.TenDonVi--, DonVi as DoVi -- DV.MaDonVi = DoVI.MaDonVi and 
                DataTable _dt = new DataTable();
                _dt = DataProvider.fillDataTable(strTruyVan);
                if (_dt != null)
                {
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        DichVu_DTO dvDTO = new DichVu_DTO();
                        dvDTO.MaDichVu = _dt.Rows[i]["MaDichVu"].ToString();
                        dvDTO.DonGia = Convert.ToInt32(_dt.Rows[i]["GiaDichVu"]);
                        dvDTO.MaDonVi = _dt.Rows[i]["DonViTinh"].ToString();//--> sua tu MaDonVi
                        //dvDTO.TenDonVi = _dt.Rows[i]["TenDonVi"].ToString();

                        lstDonViTinh.Add(dvDTO);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }

            return lstDonViTinh;
        }

            public static DataTable HienThiDanhSachCacDichVuCanCapNhat(string maDichVu, string maPhong)
            {
                DataTable dt = new DataTable();
                try { 
                
                    string strTruyVan = string.Format("select distinct dv.MaDichVu, p.MaPhong, p.TenPhong, k.TenKH,ldv.MaLoaiDichVu, ldv.TenLoaiDichVu, dv.TenDichVu, count(TenDichVu) as [SoLuong], sum(cthd.Gia) as [Tong Tien] from ChiTietHoaDonDichVu cthd join Phong p on p.MaPhong = cthd.MaPhong join LoaiPhong lp on lp.MaLoaiPhong = p.MaLoaiPhong join ChiTietLoaiPhong c on lp.MaLoaiPhong = c.MaLoaiPhong join PhieuDangKy ph on ph.MaPhieuDK = c.MaPhieuDK join KhachHang k on k.MaKH = ph.MaKH join DichVu dv on dv.MaDichVu = cthd.MaDichVu join LoaiDichVu ldv on dv.MaLoaiDichVu = ldv.MaLoaiDichVu where p.MaPhong = '" + maPhong + "' and cthd.MaDichVu = '"+ maDichVu + "' group by dv.TenDichVu, k.TenKH, p.TenPhong, p.MaPhong, dv.MaDichVu, ldv.MaLoaiDichVu, ldv.TenLoaiDichVu");//sua lai theo sql
                    dt = DataProvider.fillDataTable(strTruyVan);
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Error : " + ex.Message);
                }
                return dt;
           



        }

        public static int XacNhanDichVu(DichVu_DTO dvDTO,Phong_DTO phgDTO)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("INSERT INTO DanhSachSDDichVu(MaSuDungDichVu,MaDichVu,MaPhong,ThanhTien) VALUES('{0}','{1}','{2}',{3})",dvDTO.MaSuDungDichVu,dvDTO.MaDichVu,phgDTO.MaPhong,dvDTO.ThanhTien);

                count = DataProvider.ExecuteNonQuery(strTruyVan);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }

        public static int CapNhatDichVu(DichVu_DTO dvDTO)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("UPDATE DanhSachSDDichVu SET MaDichVu = '{0}',ThanhTien ={1} WHERE MaSuDungDichVu = '{2}'", dvDTO.MaDichVu,dvDTO.ThanhTien,dvDTO.MaSuDungDichVu);
                count = DataProvider.ExecuteNonQuery(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }

        public static int XoaDichVu(string maSuDungDichVu)
        {
            int count = 0;
            try
            {
                string strTruyVan = string.Format("DELETE FROM DanhSachSDDichVu where MaSuDungDichVu = '"+maSuDungDichVu+"'");
                count = DataProvider.ExecuteNonQuery(strTruyVan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return count;
        }

        public static string TongTien(string maPhong)
        {
            string count ="";
            try
            {

                string strTruyVan = string.Format("select sum(ThanhTien) from DanhSachSDDichVu where MaPhong = '"+ maPhong +"'");

                count = DataProvider.ExecuteScalar(strTruyVan);


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }
            return count;
        }



    }
}
