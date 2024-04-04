using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DAL
{
    public class DangNhap_DAL
    {
        public static string LayTenDangNhap_MatKhau(string MaNV,string matkhau)
        {
            string id = "";
            try
            {
                string strTruyVan = string.Format("SELECT * from DangNhap where MaNV = '" + MaNV + "' and MatKhau = '" + matkhau + "'");
                DataTable dt = new DataTable();
                dt = DataProvider.fillDataTable(strTruyVan);
                if(dt!=null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        id = dt.Rows[i]["MaNV"].ToString();
                    }
                }
               
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại :" + ex.Message);
            }
            
            return id;

        }

        public static string DoiMatKhau(string maNV, string matkhau)
        {
            string id = "";
            try
            {
                string strTruyVan = string.Format("update DangNhap set  MatKhau = '"+matkhau+"' where MaNV = '"+maNV+"'");
                DataTable dt = new DataTable();
                dt = DataProvider.fillDataTable(strTruyVan);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        id = dt.Rows[i]["MaNV"].ToString();
                        id = dt.Rows[i]["MatKhau"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại :" + ex.Message);
            }

            return id;

        }



        public static string LayMaQuyenHan(string maCanLay)
        {
            string id = "";
            try
            {
                string strTruyVan = string.Format("select * from NhanVien where MaNV = '"+maCanLay+"'");
                DataTable dt = new DataTable();
                dt = DataProvider.fillDataTable(strTruyVan);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                            id = dt.Rows[i]["MaQuyenHan"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại :" + ex.Message);
            }

            return id;
        }

       
  
    }
}
